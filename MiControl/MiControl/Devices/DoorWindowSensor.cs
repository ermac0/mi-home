using System;
using Newtonsoft.Json.Linq;
using PlanckHome;

namespace MiControl.Devices
{
    public class DoorWindowSensor :
        MiHomeDevice,
        IDoorSensor
    {
        public event EventHandler Opened;
        public event EventHandler Closed;

        public DoorWindowSensor(string sid) : base(sid, "magnet") { }

        public string Status { get; private set; }

        public override void ParseData(JObject data)
        {
            if (data["status"] == null) return;
            Status = data["status"].ToString();

            switch (Status)
            {
                case "open":
                    Opened?.Invoke(this, EventArgs.Empty);
                    break;
                case "close":
                    Closed?.Invoke(this, EventArgs.Empty);
                    break;
            }
        }

        public override string ToString()
        {
            return $"Status: {Status}, Voltage: {Voltage}V";
        }
    }
}