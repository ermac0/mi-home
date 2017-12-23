using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using PlanckHome;

namespace YeeLight
{
    public class YeelightDevice : ILightBulb
    {

        private readonly TcpClient mTcpClient;
        //Default port
        private static int port = 55443;

        public YeelightDevice(string ip, string id, bool state, int bright, string model)
        {
            Id = id;
            Ip = ip;
            State = state;
            Brightness = bright;
            Model = model;

            mTcpClient = new TcpClient();
            mTcpClient.Connect(new IPEndPoint(IPAddress.Parse(Ip), port));
        }


        public string Model { get; }
        public string Ip { get; set; }
        public string Id { get; set; }
        public int Brightness { get; set; }
        public bool State { get; set; }






        public void Toggle()
        {
            StringBuilder cmd_str = new StringBuilder();
            cmd_str.Append("{\"id\":");
            cmd_str.Append(Id);
            cmd_str.Append(",\"method\":\"toggle\",\"params\":[]}\r\n");

            byte[] data = Encoding.ASCII.GetBytes(cmd_str.ToString());
            mTcpClient.Client.Send(data);

            //Toggle
            State = !State;

            /* Receive Bulb Reponse
            byte[] buffer = new Byte[256];
            m_TcpClient.Client.Receive(buffer);
            Console.WriteLine(Encoding.ASCII.GetString(buffer));
            */
        }

        public bool IsOn => State;

        public void SwitchOn()
        {
            ExecCommand("set_power", "\"on\"", 500);
            State = true;
        }
        public void SwitchOff()
        {
            ExecCommand("set_power", "\"off\"", 500);
            State = false;

        }

        public void SetBrightness(int value, int smooth)
        {
            StringBuilder cmd_str = new StringBuilder();
            cmd_str.Append("{\"id\":");
            cmd_str.Append(Id);
            cmd_str.Append(",\"method\":\"set_bright\",\"params\":[");
            cmd_str.Append(value);
            cmd_str.Append(", \"smooth\", " + smooth + "]}\r\n");

            byte[] data = Encoding.ASCII.GetBytes(cmd_str.ToString());
            mTcpClient.Client.Send(data);

            //Apply Value
            Brightness = value;
        }


        public void SetColor(int r, int g, int b, int smooth)
        {
            //Convert r,g,b into integer 0x00RRGGBB no alpha 
            int value = ((r) << 16) | ((g) << 8) | (b);

            StringBuilder cmd_str = new StringBuilder();
            cmd_str.Append("{\"id\":");
            cmd_str.Append(Id);
            cmd_str.Append(",\"method\":\"set_rgb\",\"params\":[");
            cmd_str.Append(value);
            cmd_str.Append(", \"smooth\", " + smooth + "]}\r\n");

            byte[] data = Encoding.ASCII.GetBytes(cmd_str.ToString());
            mTcpClient.Client.Send(data);
        }

        public void ExecCommand(string method, string param, int smooth)
        {
            StringBuilder cmd_str = new StringBuilder();
            cmd_str.Append("{\"id\":");
            cmd_str.Append(Id);
            cmd_str.Append(",\"method\":\"" + method + "\",\"params\":[");
            cmd_str.Append(param);
            cmd_str.Append(", \"smooth\", " + smooth + "]}\r\n");

            //Console.WriteLine(cmd_str);
            byte[] data = Encoding.ASCII.GetBytes(cmd_str.ToString());
            mTcpClient.Client.Send(data);
        }
    }
}
