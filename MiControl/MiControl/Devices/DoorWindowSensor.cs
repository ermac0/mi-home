using System;
using Newtonsoft.Json.Linq;

namespace MiControl.Devices
{
    public class DoorWindowSensor : MiHomeDevice
    {
        public event EventHandler OnOpen;
        public event EventHandler OnClose;

        public DoorWindowSensor(string sid) : base(sid, "magnet") { }

        public string Status { get; private set; }

        public override void ParseData(JObject data)
        {
            if (data["status"] == null) return;
            Status = data["status"].ToString();

            switch (Status)
            {
                case "open":
                    OnOpen?.Invoke(this, EventArgs.Empty);
                    break;
                case "close":
                    OnClose?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }

        public override string ToString()
        {
            return $"Status: {Status}, Voltage: {Voltage}V";
        }
    }
}