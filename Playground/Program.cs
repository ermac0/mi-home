using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MiControl;
using MiLight;
using PlanckHome;
using Playground.Rooms;
using YeeLight;

namespace Playground
{
    class Program
    {
        private static MiHome _miHome;
        private static MiLightGateway _miLightGateway;

        public static void Main(string[] args)
        {

            //Console.ReadLine();

            _InitializeMiLight();
            Devices.Initialize(_miLightGateway);

            _miHome = new MiHome(
                gatewayPassword: "w4oq0yay03lawvj2", 
                gatewaySid: "34ce00fa5c3c", 
                wellKwownDevices: Devices.MiHomeDevices);



            Devices.LightHallway.SwitchOff();

            //miHome.GetGateway().StartPlayMusic(3);
            //Task.Delay(2000).Wait();
            //miHome.GetGateway().StartPlayMusic(2);
            //Task.Delay(2000).Wait();
            //miHome.GetGateway().StartPlayMusic(5);
            //miHome.GetGateway().EnableLight(255, 0, 255, 1000);





            Devices.TempSensorLivingRoom.OnTemperatureChange += (sender, eventArgs) =>
            {
                Console.WriteLine($"Temperature: {eventArgs.Temperature} °C");
            };

            Devices.MotionHall.MotionDetected += (sender, eventArgs) =>
            {
                Console.WriteLine("Motion Hall");
                Devices.LightHallway.SwitchOn(TimeSpan.FromSeconds(90));
            };

            Devices.MotionLivingRoom.MotionDetected += (sender, eventArgs) =>
            {
                Console.WriteLine("Motion Living Room");
            };
            Devices.MotionBathroom.MotionDetected += (sender, eventArgs) =>
            {
                Console.WriteLine("Motion Bathroom");
            };

            var foo = new LightSceneSwitcher(new []
            {
                new LightScene(new []
                {
                    new LightSetting(LivingRoom.MainLight, 0), 
                    new LightSetting(LivingRoom.LampLight, 0), 
                }),
                new LightScene(new []
                {
                    new LightSetting(LivingRoom.MainLight, 50), 
                    new LightSetting(LivingRoom.LampLight, 50), 
                }), 
                new LightScene(new []
                {
                    new LightSetting(LivingRoom.MainLight, 100), 
                    new LightSetting(LivingRoom.LampLight, 50), 
                }), 
                new LightScene(new []
                {
                    new LightSetting(LivingRoom.MainLight, 50), 
                    new LightSetting(LivingRoom.LampLight, 100), 
                }), 
                new LightScene(new []
                {
                    new LightSetting(LivingRoom.MainLight, 100), 
                    new LightSetting(LivingRoom.LampLight, 100), 
                }), 
            }, Devices.SwitchA);


            Devices.SwitchA.Clicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Switch A clicked");

            };
            Devices.SwitchB.Clicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Switch B clicked");

            };
            Devices.SwitchC.Clicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Switch C clicked");
                Devices.BulbA.Toggle();
                Devices.LightHallway.SwitchOff();
                Devices.ChristmasLights.Toggle();
            };

            Devices.SwitchD.Clicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Switch D clicked");
                Devices.BulbC.Toggle();
                Devices.LightHallway.SwitchOn();
                Devices.KitchenLights.Toggle();
            };
            LivingRoom.LightSwitch.OnLeftKeyClicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Left Key Clicked");
                LivingRoom.MainLight.Toggle();
            };
            LivingRoom.LightSwitch.OnRightKeyClicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Right Key Clicked");
                LivingRoom.LampLight.Toggle();
            };

            Console.ReadLine();
            _miHome.Dispose();

        }

        private static void _InitializeMiLight()
        {
            _miLightGateway = new MiLightGateway("192.168.10.36");
        }


        private static void _DiscoverYeelightDevices()
        {
            var devicesDiscovery = new DevicesDiscovery();
            devicesDiscovery.StartListening();
            devicesDiscovery.SendDiscoveryMessage();
            Thread.Sleep(5000);
            var yeelightDevices = devicesDiscovery.GetDiscoveredDevices();
            Console.WriteLine("********************  Discovered Devices  **************************");

            foreach (var device in yeelightDevices)
            {
                Console.WriteLine($"        - {device.Ip}, {device.Id}, {device.Model}");
            }
        }
    }
}
