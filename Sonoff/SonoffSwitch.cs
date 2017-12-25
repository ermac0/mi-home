using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PlanckHome;

namespace Sonoff
{
    public class SonoffSwitch : ILightBulb
    {
        private readonly string mIpAddress;

        public SonoffSwitch(string ipAddress)
        {
            this.mIpAddress = ipAddress;
        }

        public bool IsOn { get; private set; }

        public void SwitchOn()
        {
            _SendCommand("Power%20On");
            IsOn = true;
        }

        public void SwitchOff()
        {
            _SendCommand("Power%20Off");
            IsOn = false;
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
        }

        private void _SendCommand(string cmd)
        {
            var foo = new WebClient();
            foo.DownloadString($"http://{mIpAddress}/cm?cmnd={cmd}");
        }
    }
}
