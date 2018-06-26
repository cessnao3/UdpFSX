using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.FlightSimulator.SimConnect;

namespace UdpFSX
{
    class FsDataObjects
    {
        /* Sending data to FSX
        FsDataObjects.ControlDataStructure dataStruct = new FsDataObjects.ControlDataStructure();
        dataStruct.elevator = -elevator_pos / 90.0;
        dataStruct.aileron = -aileron_pos / 90.0;
        simconnect.SetDataOnSimObject(FsDataObjects.DEFINITIONS.ArduinoDataStructure, SimConnect.SIMCONNECT_OBJECT_ID_USER, 0, dataStruct); 
        */

        public enum EVENTS
        {
            FLAPS0,
            FLAPS1,
            FLAPS2,
            GEAR_DOWN,
            GEAR_UP
        };

        public enum NOTIFICATION_GROUPS
        {
            GROUP0
        };

        public enum DEFINITIONS
        {
            AircraftDataStruct,
            ControlDataStruct,
        };

        public enum DATA_REQUESTS
        {
            REQUEST_1,
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct AircraftDataStructure
        {
            // Declare as a fixed-size string
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public String title;

            // General aircraft position information
            public double latitude;
            public double longitude;
            public double altitude;

            // Body-fixed angles
            public double pitch_neg;
            public double yaw;
            public double roll_neg;

            // Body-fixed velocities
            public double u;
            public double v;
            public double w_neg;

            // Body-fixed rotational velocities
            public double p_neg;
            public double q_neg;
            public double r;

            // Other
            public double mach;
            public double beta; // Sideslip, rad
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        public struct ControlDataStructure
        {
            public double aileron;
            public double elevator;
            public double rudder;
            public double throttle1;
            public double throttle2;
            public double throttle3;
            public double throttle4;
        };

        public static void RegisterDataObjects(SimConnect sim)
        {
            // Define the data structure from FSX
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Title", null, SIMCONNECT_DATATYPE.STRING256, 0.0f, SimConnect.SIMCONNECT_UNUSED);

            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "PLANE LATITUDE", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "PLANE LONGITUDE", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "INDICATED ALTITUDE", "feet", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Plane Pitch Degrees", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Plane Heading Degrees True", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Plane Bank Degrees", "degrees", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Velocity Body Z", "feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Velocity Body X", "feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Velocity Body Y", "feet per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Rotation Velocity Body Z", "radians per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Rotation Velocity Body X", "radians per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Rotation Velocity Body Y", "radians per second", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "Airspeed Mach", "Mach", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.AircraftDataStruct, "INCIDENCE BETA", "Radians", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

            // Define the data structure to FSX
            sim.AddToDataDefinition(DEFINITIONS.ControlDataStruct, "AILERON POSITION", "Position", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.ControlDataStruct, "ELEVATOR POSITION", "Position", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.ControlDataStruct, "RUDDER POSITION", "Position", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.ControlDataStruct, "GENERAL ENG THROTTLE LEVER POSITION:1", "Percent", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.ControlDataStruct, "GENERAL ENG THROTTLE LEVER POSITION:2", "Percent", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.ControlDataStruct, "GENERAL ENG THROTTLE LEVER POSITION:3", "Percent", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            sim.AddToDataDefinition(DEFINITIONS.ControlDataStruct, "GENERAL ENG THROTTLE LEVER POSITION:4", "Percent", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);
            //sim.AddToDataDefinition(DEFINITIONS.ControlDataStruct, "SPOILERS HANDLE POSITION", "Percent", SIMCONNECT_DATATYPE.FLOAT64, 0.0f, SimConnect.SIMCONNECT_UNUSED);

            // Register data objects with the simconnect managed wrapper marshaller 
            sim.RegisterDataDefineStruct<AircraftDataStructure>(DEFINITIONS.AircraftDataStruct);
            sim.RegisterDataDefineStruct<ControlDataStructure>(DEFINITIONS.ControlDataStruct);

            // Map Events
            sim.MapClientEventToSimEvent(EVENTS.FLAPS0, "FLAPS_UP");
            sim.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.FLAPS0, false);

            sim.MapClientEventToSimEvent(EVENTS.FLAPS1, "FLAPS_1");
            sim.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.FLAPS1, false);

            sim.MapClientEventToSimEvent(EVENTS.FLAPS2, "FLAPS_2");
            sim.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.FLAPS2, false);

            sim.MapClientEventToSimEvent(EVENTS.GEAR_DOWN, "GEAR_DOWN");
            sim.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.GEAR_DOWN, false);

            sim.MapClientEventToSimEvent(EVENTS.GEAR_UP, "GEAR_UP");
            sim.AddClientEventToNotificationGroup(NOTIFICATION_GROUPS.GROUP0, EVENTS.GEAR_UP, false);

            sim.SetNotificationGroupPriority(NOTIFICATION_GROUPS.GROUP0, SimConnect.SIMCONNECT_GROUP_PRIORITY_HIGHEST);
        }
    }
}

