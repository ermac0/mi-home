using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanckHome
{
    public class Class1
    {
    }
    public interface ILightBulb
    {
        bool IsOn { get; }
        void SwitchOn();
        void SwitchOff();
        void Toggle();
    }

    public interface ISwitch
    {

    }
}
