using PlanckHome;

namespace Playground.Rooms
{
    public static class Hallway
    {
        public static ILightBulb Light => Devices.LightHallway;
        public static IMotionSensor MotionSensor => Devices.MotionHall;
        public static IDoorSensor ApartmentDoor => Devices.ApartmentDoor;
    }
}