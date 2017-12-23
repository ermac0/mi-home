using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;

namespace YeeLight
{
    public class YeelightDevice
    {
        //Default port
        private static int port = 55443;

        public YeelightDevice(string ip, string id, bool state, int bright, string model)
        {
            Id = id;
            Ip = ip;
            State = state;
            Brightness = bright;
            Model = model;
        }


        public string Model { get; }
        public string Ip { get; set; }
        public string Id { get; set; }
        public int Brightness { get; set; }
        public bool State { get; set; }

        public IPEndPoint getEndPoint()
        {
            return new IPEndPoint(IPAddress.Parse(Ip), port);
        }


    }
}
