using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.FlightSimulator.SimConnect;
using System.Net;

namespace UdpFSX
{
    public partial class MainForm : Form
    {
        private SimConnect simconnect = null;
        private const int WM_USER_SIMCONNECT = 0x0402;

        UdpClient udpListenerSocket;
        UdpClient udpSendingSocket;

        private const int SENDING_PORT = 7070;
        private const int LISTEN_PORT = 7071;

        IPEndPoint endpointListen;
        IPEndPoint endpointSending;

        private static bool UdpMessageReceived = true;

        public class UdpState
        {
            public IPEndPoint e;
            public UdpClient u;
        }

        DateTime LastSendTime;

        FsDataObjects.ControlDataStructure ControlsLatest;

        int flight_mode = 0;
        int flight_mode_last = 0;

        bool play_flap = false;

        public MainForm()
        {
            InitializeComponent();

            endpointListen = new IPEndPoint(IPAddress.Any, LISTEN_PORT);
            //endpointSending = new IPEndPoint(IPAddress.Loopback, SENDING_PORT);
            endpointSending = new IPEndPoint(IPAddress.Parse("10.0.0.66"), SENDING_PORT);

            udpListenerSocket = new UdpClient(endpointListen);
            udpSendingSocket = new UdpClient(SENDING_PORT);

            //udpListenerSocket.EnableBroadcast = true;
            udpSendingSocket.EnableBroadcast = true;
        }

        private void tmrConnected_Tick(object sender, EventArgs e)
        {
            SubmitDataRequest();

            try
            {
                if (udpListenerSocket != null && UdpMessageReceived)
                {
                    UdpState s = new UdpState();
                    s.e = endpointListen;
                    s.u = udpListenerSocket;

                    udpListenerSocket.BeginReceive(new AsyncCallback(UdpReceiveCallback), s);

                    UdpMessageReceived = false;
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SubmitDataRequest()
        {
            if (simconnect != null)
            {
                try
                {
                    simconnect.RequestDataOnSimObjectType(FsDataObjects.DATA_REQUESTS.REQUEST_1, FsDataObjects.DEFINITIONS.AircraftDataStruct, 0, SIMCONNECT_SIMOBJECT_TYPE.USER);
                }
                catch (COMException e)
                {
                    WriteToLog(e.Message);
                    btnDisconnect_Click(null, null);
                    btnConnect_Click(null, null);
                }
            }
            else
            {
                setConnectDisconnectState();
            }
        }


        #region SimConnect Items

        protected override void DefWndProc(ref Message m)
        {
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                if (simconnect != null)
                {
                    try
                    {
                        simconnect.ReceiveMessage();
                    }
                    catch (Exception e)
                    {
                        WriteToLog(e.Message);
                    }
                }
            }
            else
            {
                base.DefWndProc(ref m);
            }
        }

        void simconnect_OnRecvSimobjectDataBytype(SimConnect sender, SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            switch ((FsDataObjects.DATA_REQUESTS)data.dwRequestID)
            {
                case FsDataObjects.DATA_REQUESTS.REQUEST_1:
                    FsDataObjects.AircraftDataStructure acData = (FsDataObjects.AircraftDataStructure)data.dwData[0];

                    lblX.Text = String.Format("{0,0:N5} deg", acData.longitude);
                    lblY.Text = String.Format("{0,0:N5} deg", acData.latitude);
                    lblAlt.Text = String.Format("{0,0:N2} ft", acData.altitude);
                    lblU.Text = String.Format("{0,0:N3} ft/s", acData.u);
                    lblV.Text = String.Format("{0,0:N3} ft/s", acData.v);
                    lblW.Text = String.Format("{0,0:N3} ft/s", -acData.w_neg);

                    lblYaw.Text = String.Format("{0,0:N3} deg", acData.yaw);
                    lblPitch.Text = String.Format("{0,0:N3} deg", -acData.pitch_neg);
                    lblRoll.Text = String.Format("{0,0:N3} deg", -acData.roll_neg);
                    lblP.Text = String.Format("{0,0:N3} rad/s", -acData.p_neg);
                    lblQ.Text = String.Format("{0,0:N3} rad/s", -acData.q_neg);
                    lblR.Text = String.Format("{0,0:N3} rad/s", acData.r);

                    lblMach.Text = String.Format("{0,0:N5}", acData.mach);

                    lblElevator.Text = String.Format("{0,0:N3}%", ControlsLatest.elevator*100);
                    lblThrottle.Text = String.Format("{0,0:N3}%", ControlsLatest.throttle1);
                    lblAileron.Text = String.Format("{0,0:N3}%", ControlsLatest.aileron*100);
                    lblRudder.Text = String.Format("{0,0:N3}%", ControlsLatest.rudder*100);
                    lblGear.Text = (gear_last == 0) ? "Down" : "Up";
                    lblFlaps.Text = String.Format("{0,0:N0}% Down", (flaps_last / 2.0) * 100.0);
                    lblBeta.Text = String.Format("{0,0:N3} deg", acData.beta * 180.0 / Math.PI);

                    String udpSend = NetworkParser.UdpStringFromAC(acData);
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(udpSend);

                    DateTime CurrentTime = DateTime.Now;

                    if ((CurrentTime - LastSendTime).Milliseconds > 250)
                    {
                        udpSendingSocket.BeginSend(sendBytes, sendBytes.Length, endpointSending, null, udpSendingSocket);
                        LastSendTime = DateTime.Now;
                    }

                    break;

                default:
                    WriteToLog("Unknown request ID: " + data.dwRequestID);
                    break;
            }
        }

        int gear_last = 0;
        int flaps_last = 0;

        private void SendToFSX(double aileron, double rudder, double elevator, double throttle, int gear, int flaps)
        {
            FsDataObjects.ControlDataStructure controls;
            controls.elevator = elevator;
            controls.aileron = aileron;
            controls.rudder = rudder;
            controls.throttle1 = throttle * 100;
            controls.throttle2 = throttle * 100;
            controls.throttle3 = throttle * 100;
            controls.throttle4 = throttle * 100;

            simconnect.SetDataOnSimObject(FsDataObjects.DEFINITIONS.ControlDataStruct, SimConnect.SIMCONNECT_OBJECT_ID_USER, 0, controls);

            ControlsLatest = controls;

            if (gear != gear_last)
            {
                gear_last = gear;

                FsDataObjects.EVENTS g_state = (gear == 1) ? FsDataObjects.EVENTS.GEAR_UP : FsDataObjects.EVENTS.GEAR_DOWN;

                simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER, g_state, 0, FsDataObjects.NOTIFICATION_GROUPS.GROUP0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            }

            if (flaps != flaps_last)
            {
                flaps_last = flaps;

                FsDataObjects.EVENTS f_state = FsDataObjects.EVENTS.FLAPS0;

                if (flaps == 0) f_state = FsDataObjects.EVENTS.FLAPS0;
                else if (flaps == 1) f_state = FsDataObjects.EVENTS.FLAPS1;
                else if (flaps == 2) f_state = FsDataObjects.EVENTS.FLAPS2;

                play_flap = true;

                simconnect.TransmitClientEvent(SimConnect.SIMCONNECT_OBJECT_ID_USER, f_state, 0, FsDataObjects.NOTIFICATION_GROUPS.GROUP0, SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            }
        }

        private void initConnection()
        {
            try
            {
                simconnect = new SimConnect("Managed Data Object Request", this.Handle, WM_USER_SIMCONNECT, null, 0);
            }
            catch (COMException e)
            {
                MessageBox.Show("Unable to Connect: " + e.ToString(), "Unable to Connect");
                WriteToLog("Unable to Connect");
                simconnect = null;
            }

            if (simconnect == null)
            {
                WriteToLog("Unable to Start Connection");
            }
            else
            {
                WriteToLog("Started Connection");
                initDataRequest();
                tmrConnected.Enabled = true;
            }

            setConnectDisconnectState();
        }

        private void initDataRequest()
        {
            try
            {
                simconnect.OnRecvOpen += new SimConnect.RecvOpenEventHandler(simconnect_OnRecvOpen);
                simconnect.OnRecvQuit += new SimConnect.RecvQuitEventHandler(simconnect_OnRecvQuit);

                // Register exception handler
                simconnect.OnRecvException += new SimConnect.RecvExceptionEventHandler(simconnect_OnRecvException);

                // Register data objects
                FsDataObjects.RegisterDataObjects(simconnect);

                // Register received data object
                simconnect.OnRecvSimobjectDataBytype += new SimConnect.RecvSimobjectDataBytypeEventHandler(simconnect_OnRecvSimobjectDataBytype);

                // Set starting time
                LastSendTime = DateTime.Now;
            }
            catch (COMException ex)
            {
                WriteToLog(ex.Message);
                UdpMessageReceived = true;
            }
        }

        void simconnect_OnRecvOpen(SimConnect sender, SIMCONNECT_RECV_OPEN data)
        {
            WriteToLog("Connection Successful");
            WriteToLog();
        }

        // The case where the user closes FSX 
        void simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            WriteToLog("FSX has exited");
            closeConnection();
        }

        private void closeConnection()
        {
            if (simconnect != null)
            {
                // Dispose serves the same purpose as SimConnect_Close() 
                simconnect.Dispose();
                simconnect = null;
                WriteToLog("Successfully Disconnected");
            }

            setConnectDisconnectState();
        }

        void simconnect_OnRecvException(SimConnect sender, SIMCONNECT_RECV_EXCEPTION data)
        {
            WriteToLog("Exception received: " + data.dwException);
        }

        #endregion

        #region Udp

        public void UdpReceiveCallback(IAsyncResult ar)
        {
            UdpMessageReceived = true;

            UdpClient u = (UdpClient)((UdpState)ar.AsyncState).u;
            IPEndPoint e = (IPEndPoint)((UdpState)ar.AsyncState).e;

            Byte[] receivedBytes = u.EndReceive(ar, ref e);
            String receivedString = Encoding.ASCII.GetString(receivedBytes);

            Console.WriteLine("Received: {0}", receivedString);

            String[] s = receivedString.Split(',');

            if (s.Length != 7)
            {
                return;
            }

            double delta_e, delta_t, delta_a, delta_r;
            int gear, flaps;

            if (!double.TryParse(s[0], out delta_e)) delta_e = 0.0;
            if (!double.TryParse(s[1], out delta_t)) delta_t = 0.0;
            if (!double.TryParse(s[2], out delta_a)) delta_a = 0.0;
            if (!double.TryParse(s[3], out delta_r)) delta_r = 0.0;
            if (!int.TryParse(s[4], out flaps)) flaps = 0;
            if (!int.TryParse(s[5], out gear)) gear = 0;

            SendToFSX(delta_a, delta_r, delta_e, delta_t, gear, flaps);
        }

        #endregion

        private void setConnectDisconnectState()
        {
            bool conn = simconnect != null;
            btnConnect.Enabled = !conn;
            btnDisconnect.Enabled = conn;
            tmrConnected.Enabled = conn;

            UdpMessageReceived = true;
        }

        private void WriteToLog()
        {
            txtHistory.AppendText("\n");
        }

        private void WriteToLog(String l)
        {
            txtHistory.AppendText(l + "\n");
        }

        #region Buttons

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (simconnect == null) initConnection();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            closeConnection();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            setConnectDisconnectState();
        }

        #endregion
    }
}
