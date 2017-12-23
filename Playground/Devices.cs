using System.Collections.Generic;
using MiControl.Devices;
using MiLight;

namespace Playground
{
    public static class LivingRoom
    {
        public static MotionSensor MotionSensor => Devices.MotionLivingRoom;
        public static MiBulb MainLight => Devices.BulbA;
        public static MiBulb LampLight => Devices.BulbB;
        public static DoubleKeySwitch LightSwitch => Devices.SwitchE;
    }

    public static class Office
    {
        
    }

    public static class Bathroom
    {
        
    }
    public static class Hallway
    {
        
    }
    public static class Kitchen
    {
        
    }

    public static class Devices
    {
        public static void Initialize(MiLightGateway miLightGateway)
        {
            //Mi Light Devices
            BulbA = new MiBulb(miLightGateway, 1, "BulbA");
            BulbB = new MiBulb(miLightGateway, 2, "BulbB");
            BulbC = new MiBulb(miLightGateway, 3, "BulbC");
            
            //Mi Home Devices
            DoorBathroom = new DoorWindowSensor("158d0001e037e5") {CustomName = "Badezimmertür"};
            ApartmentDoor = new DoorWindowSensor("158d0001a5db48") { CustomName = "Wohnungstür" };
            SwitchA = new SimpleSwitch("158d00019dbac7") { CustomName = "Switch A" };
            SwitchB = new SimpleSwitch("158d00016da2ed") { CustomName = "Switch B" };
            MotionBathroom = new MotionSensor("158d0001d87940") { CustomName = "Motion Bathroom" };
            MotionHall = new MotionSensor("158d0001d47c2f") { CustomName = "Motion Hall" };
            MotionLivingRoom = new MotionSensor("158d00014dc328") { CustomName = "Motion Living Room" };
            SwitchC = new SensorSwitch("158d0001b86fed") { CustomName = "Switch C" };
            SwitchD = new SensorSwitch("158d0001b86f59") { CustomName = "SwitchD" };
            WaterLeakBathroom = new WaterLeakSensor("158d0001bb89e9") { CustomName = "Water Leak" };
            TempSensorLivingRoom = new TempSensor("158d0001b7edbb") { CustomName = "Temperatur Wohnzimmer" };
            SwitchE = new DoubleKeySwitch("158d0001718576") {CustomName = "Switch Wandregal"};
        }

        //Mi Light Devices
        public static MiBulb BulbA { get; private set; }

        public static MiBulb BulbB {get; private set; }
        public static MiBulb BulbC {get; private set; }

        //Mi Home Devices
        public static DoubleKeySwitch SwitchE { get; private set; }
        public static TempSensor TempSensorLivingRoom { get; private set; }
        public static WaterLeakSensor WaterLeakBathroom { get; private set; }
        public static SensorSwitch SwitchD { get; private set; }
        public static SensorSwitch SwitchC { get; private set; }
        public static MotionSensor MotionHall { get; private set; }
        public static MotionSensor MotionLivingRoom { get; private set; }
        public static MotionSensor MotionBathroom { get; private set; }
        public static SimpleSwitch SwitchB { get; private set; }
        public static SimpleSwitch SwitchA { get; private set; }
        public static DoorWindowSensor ApartmentDoor { get; private set; }
        public static DoorWindowSensor DoorBathroom { get; private set; }

        public static IReadOnlyList<MiHomeDevice> MiHomeDevices => new MiHomeDevice[]
        {
            SwitchE,
            TempSensorLivingRoom,
            WaterLeakBathroom,
            SwitchD,
            SwitchC,
            MotionHall,
            MotionLivingRoom,
            MotionBathroom,
            SwitchB,
            SwitchA,
            ApartmentDoor,
            DoorBathroom
        };
    }
}