using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GoogleMapSDK.UI.WPF.Extensions
{
    public static class TimerExtension
    {
        private static System.Threading.Timer Timer = null;
        private static FrameworkElement control = null;
        public static void Timerextention(this FrameworkElement control, Action callback)
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
         
            control.Dispatcher.Invoke(() => {
                Action callback = (Action)control.Tag;
                callback?.Invoke();
            });

        }

    }
}
