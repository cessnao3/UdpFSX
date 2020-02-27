using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdpFSX
{
    class NetworkParser
    {
        /// <summary>
        /// Provides a string that contains all the important flight state data
        /// </summary>
        /// <param name="data">The current aircraft flight state data</param>
        /// <returns>The string to send over UDP</returns>
        public static String UdpStringFromAC(FsDataObjects.AircraftDataStructure data)
        {
            double deg2rad = Math.PI / 180.0;

            string udpString = "";
            udpString += data.longitude + "," + data.latitude + "," + data.altitude + ",";
            udpString += data.u + "," + data.v + "," + (-data.w_neg) + ",";
            udpString += (-data.p_neg) + "," + (-data.q_neg) + "," + data.r + ",";
            udpString += data.yaw* deg2rad + "," + (-data.pitch_neg)* deg2rad + "," + (-data.roll_neg)* deg2rad + "," + data.mach + "," + data.beta + "\n";

            return udpString;
        }
    }
}
