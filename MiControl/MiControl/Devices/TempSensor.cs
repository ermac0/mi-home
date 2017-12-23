using System;
using MiControl.Events;
using Newtonsoft.Json.Linq;

namespace MiControl.Devices
{
    public class TempSensor : MiHomeDevice
    {

        public TempSensor(string sid) : base(sid, "weather.v1") {}
        public event EventHandler<TemperatureEventArgs> OnTemperatureChange;
        public event EventHandler<HumidityEventArgs> OnHumidityChange;


        public override void ParseData(JObject data)
        {
            if (data["temperature"] != null && float.TryParse(data["temperature"].ToString(), out float t))
            {
                var newTemperature = t / 100;

                if (Temperature != null && Math.Abs(newTemperature - Temperature.Value) > 0.01)
                {
                    OnTemperatureChange?.Invoke(this, new TemperatureEventArgs(newTemperature));
                }

                Temperature = newTemperature;
            }

            if (data["humidity"] != null && float.TryParse(data["humidity"].ToString(), out float h))
            {
                var newHumidity = h / 100;

                if (Humidity != null && Math.Abs(newHumidity - Humidity.Value) > 0.01)
                {
                    OnHumidityChange?.Invoke(this, new HumidityEventArgs(newHumidity));
                }

                Humidity = newHumidity;
            }
        }

        public float? Humidity { get; set; }

        public float? Temperature { get; set; }

        public DateTime? MotionDate { get; private set; }

        public override string ToString()
        {
            return $"Voltage: {Voltage}V";
        }

        
    }

}