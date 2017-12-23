using System;

namespace MiControl.Events
{
    public class HumidityEventArgs : EventArgs
    {
        public HumidityEventArgs(float t)
        {
            Humidity = t;
        }

        public float Humidity { get; }
    }
}