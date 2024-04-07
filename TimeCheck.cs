using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace water_tracker
{
    public class TimeCheck
    {
        public DateTime _yesturday;
        public TimeCheck() 
        {
            _yesturday = DateTime.Today;
        }

        public delegate void DayHandler();
        public event DayHandler NewDay;

        public void NewDayStart()
        {
            if (_yesturday != DateTime.Today)
            {
                NewDay?.Invoke();
                _yesturday = DateTime.Today;
            }
        }


    }
}
