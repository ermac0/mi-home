using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MiControl.Devices
{
    public class DoubleKeySwitch : MiHomeDevice
    {
        public event EventHandler<EventArgs> OnLeftKeyClicked;
        public event EventHandler<EventArgs> OnRightKeyClicked;

        public DoubleKeySwitch(string sid) : base(sid, "86sw2") { }


        public override void ParseData(JObject data)
        {
            if (data["channel_0"] != null)
            {
                var channel0 = data["channel_0"].ToString();

                if (channel0 == "click")
                {
                    OnLeftKeyClicked?.Invoke(this, EventArgs.Empty);
                }
            }
            if (data["channel_1"] != null)
            {
                var channel1 = data["channel_1"].ToString();

                if (channel1 == "click")
                {
                    OnRightKeyClicked?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public override string ToString()
        {
            return $"{(!string.IsNullOrEmpty(Name) ? "Name: " + Name + ", " : string.Empty)}, Voltage: {Voltage}V";
        }
    }
}