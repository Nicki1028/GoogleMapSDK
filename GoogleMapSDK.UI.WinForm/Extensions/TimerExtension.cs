using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.UI.WinForm.Extensions
{
    public static class TimerExtension
    {
        private static System.Threading.Timer Timer = null;
        private static Control control = null;
        public static void Timerextention(this Control control, Action callback)
        {
            TimerExtension.control = control;
            TimerExtension.control.Tag = callback;
            if (Timer == null)
            {
                Timer = new System.Threading.Timer(TimerCallback, null, 1000, Timeout.Infinite);
            }
            else
            {
                Timer.Change(1000, Timeout.Infinite);
            }

        }

        private static void TimerCallback(object data)
        {
            Action callback = (Action)control.Tag;
            control.Invoke(new Action(() => callback.Invoke()));

        }

    }
}
