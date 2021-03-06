using System;

namespace MiControl.Events
{
    public class DensityEventArgs : EventArgs
    {
        public DensityEventArgs(float t)
        {
            Density = t;
        }

        public float Density { get; }
    }
}