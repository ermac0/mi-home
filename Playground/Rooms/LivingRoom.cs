using MiControl.Devices;
using MiLight;
using PlanckHome;

namespace Playground.Rooms
{
    public static class LivingRoom
    {
        public static IMotionSensor MotionSensor => Devices.MotionLivingRoom;
        public static IDimmableLightBulb MainLight => Devices.BulbA;
        public static IDimmableLightBulb LampLight => Devices.BulbB;
        public static DoubleKeySwitch LightSwitch => Devices.SwitchE;
    }
}