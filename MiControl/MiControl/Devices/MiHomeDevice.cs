using Newtonsoft.Json.Linq;

namespace MiControl.Devices
{
    public abstract class MiHomeDevice
    {
        public string Sid { get; }
        public string Name { get; set; }
        public string CustomName { get; set; }
        public string Type { get; }
        public float? Voltage { get; private set; }


        protected MiHomeDevice(string sid, string type)
        {
            Sid = sid;
            Type = type;
        }

        public virtual void ParseData(string command)
        {
            var jObject = JObject.Parse(command);

            if (jObject["voltage"] != null && float.TryParse(jObject["voltage"].ToString(), out float v))
            {
                Voltage = v / 1000;
            }

            ParseData(jObject);
        }

        public abstract void ParseData(JObject data);
    }
}