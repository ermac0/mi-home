using System;
using Newtonsoft.Json.Linq;

namespace MiControl.Devices
{
    public class SensorSwitch : MiHomeDevice
    {
        public event EventHandler<EventArgs> OnClicked;

        public SensorSwitch(string sid) : base(sid, (string)"sensor_switch.aq2") { }

        public override void ParseData(JObject data)
        {
            if (data["status"] != null && data["status"].ToString() == "click")
            {
                OnClicked?.Invoke(this, EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            return $"{(!string.IsNullOrEmpty(Name) ? "Name: " + Name + ", " : string.Empty)}, Voltage: {Voltage}V";
        }
    }
}