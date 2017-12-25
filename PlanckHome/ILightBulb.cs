using System;
using System.Collections.Generic;
using System.Linq;
using Timer = System.Timers.Timer;

namespace PlanckHome
{
    public class LightSetting
    {
        public LightSetting(IDimmableLightBulb lightBulb, int brightness)
        {
            LightBulb = lightBulb;
            Brightness = brightness;
        }

        public IDimmableLightBulb LightBulb { get; }
        public int Brightness { get; }

        public void Apply()
        {
            LightBulb.SetBrightness(Brightness);
            if(Brightness == 0) LightBulb.SwitchOff();
        }
    }

    public class LightScene
    {
        private readonly IEnumerable<LightSetting> mLightSettings;

        public LightScene(IEnumerable<LightSetting> lightSettings)
        {
            mLightSettings = lightSettings;
        }

        public void Apply()
        {
            foreach (var setting in mLightSettings)
            {
                setting.Apply();
            }
        }
    }

    public class LightSceneSwitcher
    {
        private readonly List<LightScene> mScenes;
        private LightScene mActiveScene;

        public LightSceneSwitcher(IReadOnlyList<LightScene> scenes, ISwitch @switch)
        {
            mScenes = scenes.ToList();
            mActiveScene = mScenes[0];
            @switch.Clicked += OnClicked;
        }

        private void OnClicked(object o, EventArgs eventArgs)
        {
            var currentIndex = mScenes.IndexOf(mActiveScene);
            var index = currentIndex + 1;
            if (index > mScenes.Count - 1) index = 0;
            mActiveScene = mScenes[index];
            mActiveScene.Apply();
        }
    }

    public class AutomaticOffTimer
    {
        private readonly ILightBulb mBulb;

        public AutomaticOffTimer(ILightBulb bulb)
        {
            mBulb = bulb;
        }

        public void Run(TimeSpan offAfter)
        {
            mBulb.SwitchOn();
            var timer = new Timer(offAfter.TotalMilliseconds);
            timer.Elapsed += (sender, args) =>
            {
                timer.Stop();
                mBulb.SwitchOff();
            };
            timer.Start();
        }
    }

    public interface IDimmableLightBulb : ILightBulb
    {
        void SetBrightness(int percentage);
    }

    public interface ILightBulb
    {
        bool IsOn { get; }
        void SwitchOn();
        void SwitchOff();
        void Toggle();
    }
}