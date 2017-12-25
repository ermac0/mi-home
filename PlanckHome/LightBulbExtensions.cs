using System;

namespace PlanckHome
{
    public static class LightBulbExtensions
    {
        public static void SwitchOn(this ILightBulb lightBulb, TimeSpan offAfter)
        {
            var timer = new AutomaticOffTimer(lightBulb);
            timer.Run(offAfter);
        }
    }
}