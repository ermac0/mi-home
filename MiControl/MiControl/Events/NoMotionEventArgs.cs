using System;

namespace MiControl.Events
{
    public class NoMotionEventArgs: EventArgs
    {
        public NoMotionEventArgs(int seconds)
        {
            Seconds = seconds;
        }

        public int Seconds { get; }
    }
}
