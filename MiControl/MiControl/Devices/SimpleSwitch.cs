using System;
using Newtonsoft.Json.Linq;

namespace MiControl.Devices
{
    public class SimpleSwitch : MiHomeDevice
    {
        public event EventHandler<EventArgs> OnClicked;

        public SimpleSwitch(string sid) : base(sid, (string) "switch") { }


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