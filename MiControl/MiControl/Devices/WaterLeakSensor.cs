using System;
using Newtonsoft.Json.Linq;

namespace MiControl.Devices
{
    public class WaterLeakSensor : MiHomeDevice
    {
        public event EventHandler OnLeak;
        public event EventHandler OnNoLeak;
        
        public WaterLeakSensor(string sid) : base(sid, "sensor_wleak.aq1") { }

        public string Status { get; private set; }

        public override void ParseData(JObject data)
        {
            if (data["status"] != null)
            {
                Status = data["status"].ToString();

                if (Status == "leak")
                {
                    OnLeak?.Invoke(this, EventArgs.Empty);
                }
                else if (Status == "no_leak")
                {
                    OnNoLeak?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public override string ToString()
        {
            return $"Status: {Status}";
        }
    }
}