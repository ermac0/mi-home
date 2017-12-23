using System;
using MiControl.Events;
using Newtonsoft.Json.Linq;

namespace MiControl.Devices
{
    public class MotionSensor : MiHomeDevice
    {
        public event EventHandler OnMotion;
        public event EventHandler<NoMotionEventArgs> OnNoMotion;

        public MotionSensor(string sid) : base(sid, "motion") {}

        public string Status { get; private set; }

        public int NoMotion { get; set; }


        public DateTime? LastMotionTimestamp { get; private set; }

        public override string ToString()
        {
            return $"Status: {Status}, Voltage: {Voltage}V, NoMotion: {NoMotion}s";
        }


        public override void ParseData(JObject data)
        {
            if (data["status"] != null)
            {
                Status = data["status"].ToString();

                if (Status == "motion")
                {
                    LastMotionTimestamp = DateTime.Now;
                    OnMotion?.Invoke(this, EventArgs.Empty);
                }
            }

            if (data["no_motion"] != null)
            {
                NoMotion = int.Parse(data["no_motion"].ToString());

                OnNoMotion?.Invoke(this, new NoMotionEventArgs(NoMotion));
            }
        }
    }
}