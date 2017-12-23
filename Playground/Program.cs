using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MiControl;
using MiLight;
using YeeLight;

namespace Playground
{
    class Program
    {
        private static MiHome _miHome;
        private static MiLightGateway _miLightGateway;
        private static bool _toggle;
        private static List<YeelightDevice> _yeelightDevices;
        private static DeviceIO _deviceIo;

        public static void Main(string[] args)
        {

            _InitializeYeelight();
            //Console.ReadLine();

            _InitializeMiLight();
            Devices.Initialize(_miLightGateway);

            _miHome = new MiHome(
                gatewayPassword: "w4oq0yay03lawvj2", 
                gatewaySid: "34ce00fa5c3c", 
                wellKwownDevices: Devices.MiHomeDevices);


            var lightA = new YeelightDevice("192.168.10.77", "0x000000000361df8b", false, 0, "mono");
            _deviceIo.Connect(lightA);
            _deviceIo.SwitchOff();

            //miHome.GetGateway().StartPlayMusic(3);
            //Task.Delay(2000).Wait();
            //miHome.GetGateway().StartPlayMusic(2);
            //Task.Delay(2000).Wait();
            //miHome.GetGateway().StartPlayMusic(5);
            //miHome.GetGateway().EnableLight(255, 0, 255, 1000);

            Devices.MotionHall.OnMotion += (sender, eventArgs) =>
            {
                Console.WriteLine("Motion Hall");
                _deviceIo.SwitchOn();
            };

            Devices.MotionLivingRoom.OnMotion += (sender, eventArgs) =>
            {
                Console.WriteLine("Motion Living Room");

                //_deviceIo.SwitchOn();
            };
            Devices.MotionBathroom.OnMotion += (sender, eventArgs) =>
            {
                Console.WriteLine("Motion Bathroom");
            };

            Devices.SwitchC.OnClicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Switch C clicked");
                Devices.BulbA.Toggle();
                _deviceIo.SwitchOff();
            };

            Devices.SwitchD.OnClicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Switch D clicked");
                Devices.BulbC.Toggle();
                _deviceIo.SwitchOn();

            };
            Devices.SwitchE.OnLeftKeyClicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Left Key Clicked");
                Devices.BulbA.Toggle();
            };
            Devices.SwitchE.OnRightKeyClicked += (sender, eventArgs) =>
            {
                Console.WriteLine($"Right Key Clicked");
                Devices.BulbB.Toggle();
            };

            Console.ReadLine();
            _miHome.Dispose();

        }

        private static void _InitializeMiLight()
        {
            _miLightGateway = new MiLightGateway("192.168.10.36");
        }

        private static void _InitializeYeelight()
        {
            _deviceIo = new DeviceIO();
            //var devicesDiscovery = new DevicesDiscovery();
            //devicesDiscovery.StartListening();
            //devicesDiscovery.SendDiscoveryMessage();
            //Thread.Sleep(5000);
            //_yeelightDevices = devicesDiscovery.GetDiscoveredDevices();
            //Console.WriteLine("********************  Discovered Devices  **************************");

            //foreach (var device in _yeelightDevices)
            //{
            //    Console.WriteLine($"        - {device.Ip}, {device.Id}, {device.Model}");
            //}
        }

        private static void MotionSensorCOnOnMotion(object sender, EventArgs eventArgs)
        {
            foreach (var yeelightDevice in _yeelightDevices)
            {
                _deviceIo.Connect(yeelightDevice);
                _deviceIo.Toggle();
            }
        }

        private static void MotionSensorBOnOnMotion(object sender, EventArgs eventArgs)
        {
            foreach (var yeelightDevice in _yeelightDevices)
            {
                _deviceIo.Connect(yeelightDevice);
                _deviceIo.Toggle();
            }
        }

        private static void MotionSensorAOnOnMotion(object sender, EventArgs eventArgs)
        {
            foreach (var yeelightDevice in _yeelightDevices)
            {
                _deviceIo.Connect(yeelightDevice);
                _deviceIo.Toggle();
            }
        }

        private static void SwitchAOnOnClicked(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Clicked");
            foreach (var yeelightDevice in _yeelightDevices)
            {
                _deviceIo.Connect(yeelightDevice);
                _deviceIo.Toggle();
            }

            //_toggleLight();
        }
    }
}
