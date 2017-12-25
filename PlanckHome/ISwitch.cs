using System;

namespace PlanckHome
{
    public interface ISwitch
    {
        event EventHandler<EventArgs> Clicked;
    }
}