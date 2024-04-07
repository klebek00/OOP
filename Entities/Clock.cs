using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;

namespace water_tracker.Entities
{
    public class Clock
    {
        private readonly Timer _timer = new Timer(1000);
        private DateTime _yesturday = DateTime.Today;

        public event EventHandler NewDay;

        public Clock()
        {
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (_yesturday != DateTime.Today)
            {
                NewDay?.Invoke(this, EventArgs.Empty);
                _yesturday = DateTime.Today;
            }
        }
    }
}
