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
        /// <summary>
        /// Defines the SimConnect connection object
        /// </summary>
        private SimConnect simconnect = null;

        /// <summary>
        /// The user connection to SimConnect constant
        /// </summary>
        private const int WM_USER_SIMCONNECT = 0x0402;

        /// <summary>
        /// Defines the actual UDP socket
        /// </summary>
        UdpClient udpSocket;

        /// <summary>
        /// Defines the point to send UDP data over
        /// </summary>
        private const int SENDING_PORT = 7070;

        /// <summary>
        /// Defines the port to receive UDP data over
        /// </summary>
        private const int LISTEN_PORT = 7071;

        /// <summary>
        /// Defines the endpoint storage location to receive from
        /// </summary>
        IPEndPoint endpointListen;

        /// <summary>
        /// Defines the endpoint to send UDP data to
        /// </summary>
        IPEndPoint endpointSending;

        /// <summary>
        /// Defines the last time FSX data has been sent via UDP
        /// </summary>
        DateTime LastSendTime;

        /// <summary>
        /// Contains the latest information received from FSX
        /// </summary>
        FsDataObjects.ControlDataStructure ControlsLatest;

        /// <summary>
        /// Defines the current flight mode received over UDP
        /// </summary>
        int flight_mode = 0;

        /// <summary>
        /// Defines the last flight mode to determine whether to play a sound
        /// </summary>
        int flight_mode_last = 0;

        /// <summary>
        /// Defines the last state of the landing gear for display
        /// </summary>
        int gear_last = 0;

        /// <summary>
        /// Defines the last state of the flaps for display
        /// </summary>
        int flaps_last = 0;

        /// <summary>
        /// Initializes the main form class
        /// </summary>
        public MainForm()
        {
            // Setup form components
            InitializeComponent();

            // Define the enpoint parameters
            endpointListen = new IPEndPoint(
                IPAddress.Any,
                LISTEN_PORT);
            endpointSending = new IPEndPoint(
                IPAddress.Loopback,
                SENDING_PORT);

            // Define the socket parameters
            udpSocket = new UdpClient(endpointListen);
            udpSocket.Client.ReceiveTimeout = 1;
            udpSocket.EnableBroadcast = true;
        }

        /// <summary>
        /// Triggers a read of all UDP packets available and sends the latest information to FSX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrConnected_Tick(object sender, EventArgs e)
        {
            // Request data from the flight simulator
            SubmitDataRequest();

            // Attempt to receive UDP data if available
            if (udpSocket != null)
            {
                // Read as many packets as are in the buffer
                while (true)
                {
                    // Use a try loop - with throw a SocketException when there is no
                    // more data to read
                    try
                    {
                        // Receive any available bytes
                        byte[] receivedBytes = udpSocket.Receive(ref endpointListen);

                        // Convert the bytes to a string
                        String receivedString = Encoding.ASCII.GetString(receivedBytes);

                        // Print the received string
                        Console.WriteLine("Received: {0}", receivedString);

                        // Split the string by commas
                        String[] s = receivedString.Split(',');

                        // Ensure that there is the proper number of values
                        if (s.Length != 7)
                        {
                            return;
                        }

                        // Create the storage locations for the values and parse from the string
                        double delta_e;
                        double delta_t;
                        double delta_a;
                        double delta_r;
                        int gear;
                        int flaps;
                        int mode;

                        if (!double.TryParse(s[0], out delta_e)) delta_e = 0.0;
                        if (!double.TryParse(s[1], out delta_t)) delta_t = 0.0;
                        if (!double.TryParse(s[2], out delta_a)) delta_a = 0.0;
                        if (!double.TryParse(s[3], out delta_r)) delta_r = 0.0;
                        if (!int.TryParse(s[4], out flaps)) flaps = 0;
                        if (!int.TryParse(s[5], out gear)) gear = 0;
                        if (!int.TryParse(s[6], out mode)) mode = 0;

                        // Update the current flight mode
                        flight_mode = mode;

                        // Send values to FSX for control inputs
                        SendToFSX(
                            delta_a,
                            delta_r,
                            delta_e,
                            delta_t,
                            gear,
                            flaps);
                    }
                    catch (SocketException)
                    {
                        // Stop the loop when no more packets available
                        break;
                    }
                }
            }
        }

        #region SimConnect Items

        /// <summary>
        /// Submits a request for data to SimConnect
        /// </summary>
        private void SubmitDataRequest()
        {
            // Ensure that we are connected
            if (simconnect != null)
            {
                // Try to request the updated data from SimConnect as a user
                // On failure, disconnect from the SimConnect object
                try
                {
                    simconnect.RequestDataOnSimObjectType(
                        FsDataObjects.DATA_REQUESTS.REQUEST_1,
                        FsDataObjects.DEFINITIONS.AircraftDataStruct,
                        0,
                        SIMCONNECT_SIMOBJECT_TYPE.USER);
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
                // Update the connection state displayed if invalid
                // to update the buttons and the timer
                setConnectDisconnectState();
            }
        }

        /// <summary>
        /// Defines the receive message from SimConnect
        /// </summary>
        /// <param name="m">The message received</param>
        protected override void DefWndProc(ref Message m)
        {
            // If the message is equal to the user simconnect message, intercept
            // Otherwise, call the base class value
            if (m.Msg == WM_USER_SIMCONNECT)
            {
                // Fully receive the message if simconnect is properly connected
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

        /// <summary>
        /// Fully receive the simconnect data object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        void simconnect_OnRecvSimobjectDataBytype(
            SimConnect sender,
            SIMCONNECT_RECV_SIMOBJECT_DATA_BYTYPE data)
        {
            // Switch by message data types
            switch ((FsDataObjects.DATA_REQUESTS)data.dwRequestID)
            {
                case FsDataObjects.DATA_REQUESTS.REQUEST_1:
                    // Receive the aircraft data
                    FsDataObjects.AircraftDataStructure acData = (FsDataObjects.AircraftDataStructure)data.dwData[0];

                    // Set display parameters
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

                    // Get the current time
                    DateTime CurrentTime = DateTime.Now;

                    // Only send if the time interval since the last send has been great enough
                    if ((CurrentTime - LastSendTime).Milliseconds > 100)
                    {
                        // Create the UDP sending string packet
                        String udpSend = NetworkParser.UdpStringFromAC(acData);
                        Byte[] sendBytes = Encoding.ASCII.GetBytes(udpSend);

                        // Send the packets and update the last send time
                        udpSocket.BeginSend(
                            sendBytes,
                            sendBytes.Length,
                            endpointSending,
                            null,
                            null);
                        LastSendTime = CurrentTime;
                    }

                    break;

                default:
                    WriteToLog("Unknown request ID: " + data.dwRequestID);
                    break;
            }
        }

        /// <summary>
        /// Sends the input parameters to FSX
        /// </summary>
        /// <param name="aileron">An aileron input in percent, between -1 and 1</param>
        /// <param name="rudder">An rudder input in percent, between -1 and 1</param>
        /// <param name="elevator">An elevator input in percent, between -1 and 1</param>
        /// <param name="throttle">An throttle input in percent, between 0 and 1</param>
        /// <param name="gear">The landing gear status, 0 being down and 1 being up</param>
        /// <param name="flaps">The flap status, with 0 being up, 1 being halfway, and 2 being down</param>
        private void SendToFSX(
            double aileron,
            double rudder,
            double elevator,
            double throttle,
            int gear,
            int flaps)
        {
            // Skip if not connected
            if (simconnect == null) return;

            // Set the data in the control data structure
            FsDataObjects.ControlDataStructure controls;
            controls.elevator = elevator;
            controls.aileron = aileron;
            controls.rudder = rudder;
            controls.throttle1 = throttle * 100;
            controls.throttle2 = throttle * 100;
            controls.throttle3 = throttle * 100;
            controls.throttle4 = throttle * 100;

            // Set the data in the simconnect object
            simconnect.SetDataOnSimObject(
                FsDataObjects.DEFINITIONS.ControlDataStruct,
                SimConnect.SIMCONNECT_OBJECT_ID_USER,
                0,
                controls);

            // Save the latest controls parameters
            ControlsLatest = controls;

            // Transmit the gear state if it is different from the last gear state
            if (gear != gear_last)
            {
                gear_last = gear;

                FsDataObjects.EVENTS g_state = (gear == 1) ? FsDataObjects.EVENTS.GEAR_UP : FsDataObjects.EVENTS.GEAR_DOWN;

                simconnect.TransmitClientEvent(
                    SimConnect.SIMCONNECT_OBJECT_ID_USER,
                    g_state,
                    0,
                    FsDataObjects.NOTIFICATION_GROUPS.GROUP0,
                    SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            }

            // Transmit the flaps state if it is different from the last flaps state
            if (flaps != flaps_last)
            {
                flaps_last = flaps;

                FsDataObjects.EVENTS f_state = FsDataObjects.EVENTS.FLAPS0;

                if (flaps == 0) f_state = FsDataObjects.EVENTS.FLAPS0;
                else if (flaps == 1) f_state = FsDataObjects.EVENTS.FLAPS1;
                else if (flaps == 2) f_state = FsDataObjects.EVENTS.FLAPS2;

                simconnect.TransmitClientEvent(
                    SimConnect.SIMCONNECT_OBJECT_ID_USER,
                    f_state,
                    0,
                    FsDataObjects.NOTIFICATION_GROUPS.GROUP0,
                    SIMCONNECT_EVENT_FLAG.GROUPID_IS_PRIORITY);
            }
        }

        /// <summary>
        /// Initialize the SimConnect object
        /// </summary>
        private void initConnection()
        {
            try
            {
                simconnect = new SimConnect(
                    "Managed Data Object Request",
                    this.Handle,
                    WM_USER_SIMCONNECT,
                    null,
                    0);
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

        /// <summary>
        /// Initialize the simconnect data request parameter
        /// </summary>
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
            }
        }

        /// <summary>
        /// Provide a success message if the simconnect socket opens successfully
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        void simconnect_OnRecvOpen(
            SimConnect sender,
            SIMCONNECT_RECV_OPEN data)
        {
            WriteToLog("Connection Successful");
            WriteToLog();
        }

        /// <summary>
        /// Message when the user closes FSX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        void simconnect_OnRecvQuit(SimConnect sender, SIMCONNECT_RECV data)
        {
            WriteToLog("FSX has exited");
            closeConnection();
        }

        /// <summary>
        /// Fully close the connection as much as possible
        /// </summary>
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

        /// <summary>
        /// Print an exception if received
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="data"></param>
        void simconnect_OnRecvException(
            SimConnect sender,
            SIMCONNECT_RECV_EXCEPTION data)
        {
            WriteToLog("Exception received: " + data.dwException);
        }

        #endregion

        /// <summary>
        /// Sets the button states and timer state for whether
        /// the simconnect object is connected or not
        /// </summary>
        private void setConnectDisconnectState()
        {
            bool conn = simconnect != null;
            btnConnect.Enabled = !conn;
            btnDisconnect.Enabled = conn;
            tmrConnected.Enabled = conn;
        }

        /// <summary>
        /// Writes the provided string to the text history log
        /// </summary>
        /// <param name="l">The line to append to the log</param>
        private void WriteToLog(string l="")
        {
            txtHistory.AppendText(l + Environment.NewLine);
        }

        #region Buttons

        /// <summary>
        /// Creates the simconnect connection if not already connected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (simconnect == null) initConnection();
        }

        /// <summary>
        /// Disconnects the simconnect connection if connected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            closeConnection();
        }

        /// <summary>
        /// Setup the enable states for the connect/disconnect buttons on load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            setConnectDisconnectState();
        }

        #endregion
    }
}
