using System;

namespace PlanckHome
{
    public interface IDoorSensor
    {
        event EventHandler Opened;
        event EventHandler Closed;
    }
}