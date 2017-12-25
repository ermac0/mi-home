using System;
using Newtonsoft.Json.Linq;
using PlanckHome;

namespace MiControl.Devices
{
    public class SimpleSwitch :
        MiHomeDevice,
        ISwitch
    {
        public event EventHandler<EventArgs> Clicked;

        public SimpleSwitch(string sid) : base(sid, (string) "switch") { }


        public override void ParseData(JObject data)
        {
            if (data["status"] != null && data["status"].ToString() == "click")
            {
                Clicked?.Invoke(this, EventArgs.Empty);
            }
        }

        public override string ToString()
        {
            return $"{(!string.IsNullOrEmpty(Name) ? "Name: " + Name + ", " : string.Empty)}, Voltage: {Voltage}V";
        }
    }
}