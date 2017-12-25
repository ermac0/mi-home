using System.Threading;
using System.Threading.Tasks;

namespace PlanckHome
{
    public class LightDimmer
    {
        private readonly IDimmableLightBulb mDimmableLight;
        private CancellationTokenSource mCancellation = new CancellationTokenSource();
        private int mBrightness = 0;

        public LightDimmer(IDimmableLightBulb dimmableLight)
        {
            mDimmableLight = dimmableLight;
        }
        public void TransitionTo(int brightness)
        {

        }

        public async Task Ramp()
        {
            while (!mCancellation.IsCancellationRequested)
            {
                mBrightness++;
                mDimmableLight.SetBrightness(mBrightness);
                await Task.Delay(100, mCancellation.Token);
            }
        }
        public void RampUp()
        {
            mCancellation = new CancellationTokenSource();
            Task.Factory.StartNew(Ramp, mCancellation.Token);
        }
        public void RampDown()
        {
            mCancellation = new CancellationTokenSource();
            Task.Factory.StartNew(Ramp, mCancellation.Token);
        }
        public void Hold()
        {
            mCancellation.Cancel();
        }
    }
}