# UdpFSX

Connector to extract body-fixed flight parameters from the current aircraft in Microsoft's Flight Simulator X (FSX) through Simconnect

These properties include:
* Latitude
* Longitude
* Altitude
* Body-Fixed Velocity (u, v, w)
* Body-Fixed Angular Velocity (p, q, r)
* Body-Fixed Euler Angles (Pitch, Roll, Yaw)

The format is as follows, in comma-separated format:

- <double longitude (deg)>
- <double latitude (deg)>
- <double altitude (feet)>
- <double u (ft/s)>
- <double v (ft/s)>
- <double w (ft/s)>
- <double p (rad/s)>
- <double q (rad/s)>
- <double r (rad/s)>
- <double yaw (rad)>
- <double pitch (rad)>
- <double roll (rad)>
- <double mach ()>
- <double beta (rad)>


## Control Parameters

Variables allowed in the use of control to FSX include:

* Throttle Position
* Elevator Position
* Aileron Position
* Rudder Position
* Flap Position
* Landing Gear Position

The format is as follows, in comma-separated format:

- <double [-1.0, 1.0] elevator>
- <double [-1.0, 1.0] throttle>
- <double [-1.0, 1.0] aileron>
- <double [-1.0, 1.0] rudder>
- <int [0 = clean, N = dirty] flap_setting>  _Maximum flap setting dependent on aircraft_
- <int [1 = up, 2 = down] landing gear>
