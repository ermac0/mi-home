using System;

namespace PlanckHome
{
    public interface IMotionSensor
    {
        event EventHandler MotionDetected;
    }
}