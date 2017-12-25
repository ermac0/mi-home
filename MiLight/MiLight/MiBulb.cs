using PlanckHome;

namespace MiLight
{
    public class MiBulb : IDimmableLightBulb
    {
        private readonly MiLightGateway mGateway;
        private readonly int mGroup;

        public MiBulb(MiLightGateway gateway, int group)
        {
            mGateway = gateway;
            mGroup = @group;
        }

        public bool IsOn { get; private set; }

        public void SwitchOn()
        {
            mGateway.RGBW.SwitchOn(mGroup);
        }
        public void SwitchOff()
        {
            mGateway.RGBW.SwitchOff(mGroup);
        }
        public void Toggle()
        {
            if (IsOn)
            {
                SwitchOff();
            }
            else
            {
                SwitchOn();
            }
            IsOn = !IsOn;
        }

        public void SetBrightness(int percentage)
        {
            mGateway.RGBW.SetBrightness(mGroup, percentage);
        }
    }
}