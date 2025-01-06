using Google_Map_API;
using Google_Map_API.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gmap
{
    public static class FormExtention
    {           
        private static System.Threading.Timer Timer = null;

        public static void Timerextention(this Form form, Action callback)
        {
            form.Tag = callback;
            if (Timer == null)
            {
                Timer = new System.Threading.Timer(TimerCallback, form, 1000, Timeout.Infinite);
            }
            else
            {
                Timer.Change(1000, Timeout.Infinite);
            }     

        }
                       
        private static void TimerCallback(object data)
        {
            Form form = (Form)data;
            Action callback = (Action)form.Tag;
            form.Invoke(new Action(() => callback.Invoke()));
          
        }

    }
    
}
