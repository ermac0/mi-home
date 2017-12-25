using PlanckHome;

namespace Playground.Rooms
{
    public static class Bathroom
    {
        public static ILightBulb Light => Devices.LightHallway;
        //public static ISwitch LightSwitch { get; }
        public static IMotionSensor MotionSensor => Devices.MotionBathroom;
        public static IDoorSensor Door => Devices.DoorBathroom;
    }
}