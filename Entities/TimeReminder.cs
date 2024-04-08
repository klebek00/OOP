using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
namespace water_tracker.Entities
{
    public class TimeReminder
    {
        static Timer timer;
        long interval = 60000;
        static object synclock = new object();
        public bool notif {  get; set; }
        public TimeReminder() 
        {
            notif = true;

        }
        public void Init()
        {
            timer = new Timer(new TimerCallback(ToastNotificationSend), null, 0, interval);
        }
        public void TurnOn()
        {
            timer.Change(0,interval);
            notif = true;
        }
        public void TurnOff()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            notif = false;
        }

        private void ToastNotificationSend(object obj)
        {
            DateTime dd = DateTime.Now;
            if (dd.Hour == 8 && dd.Minute == 30)
            {
                Console.WriteLine("Good Morning! It's time to make your first sip!!" );
                notif = true;
            }
            else if (dd.Hour == 10 && dd.Minute == 00)
            {
                Console.WriteLine("It's time to drink woter!");
                notif = true;
            }
            else if (dd.Hour == 14 && dd.Minute == 00)
            {
                Console.WriteLine("It's time to drink woter!");
                notif = true;
            }
            else if (dd.Hour == 16 && dd.Minute == 00)
            {
                Console.WriteLine("It's time to drink woter!");
                notif = true;
            }
            else if (dd.Hour == 20 && dd.Minute == 00)
            {
                Console.WriteLine("It's time to drink woter!");
                notif = true;
            }
            else if (dd.Hour == 22 && dd.Minute == 00)
            {
                Console.WriteLine("It's time to drink woter!");
                notif = true;
            }
            else if (dd.Hour == 23 && dd.Minute == 40)
            {
                Console.WriteLine("Sweet dreams! Don't forget to drink water.");
                notif = true;
            }
            
        }

    }
}
