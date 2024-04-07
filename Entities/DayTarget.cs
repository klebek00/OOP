using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace water_tracker.Entities
{
    public class DayTarget
    {
        public double DayNorm { get; set; }
        public int Volume { get; set; }
        public int DayCounter { get; set; }
        public TimeCheck time;
        public DayTarget(UserAccaunt user)
        {
            DayCounter = 0;
            Volume = 250;
            time = new TimeCheck();
            time.NewDay += OnNewDay;
            CalculateWaterGoal(user);
        }
        public delegate void NextDayHandler(DayTarget targ);
        public event NextDayHandler NextDay;
        public void SetVolumeType(int num)
        {
            if (num == 1)
            {
                num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case 0:
                        Volume = 100;
                        break;
                    case 1:
                        Volume = 125;
                        break;
                    case 2:
                        Volume = 150;
                        break;
                    case 3:
                        Volume = 175;
                        break;
                    case 4:
                        Volume = 300;
                        break;
                    case 5:
                        Volume = 400;
                        break;
                }
            }

            if (num == 2)
            {
                Volume = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DrinkFunc()
        {
            time.NewDayStart();
            DayCounter += Volume;
            NextDay?.Invoke(this);
        }

        public void OnNewDay()
        {
            DayCounter = 0;
        }
        void CalculateWaterGoal(UserAccaunt user)
        {
            if (user.Gender == false)
            {
                DayNorm = 88.362 + 13.397 * user.Waight + 4.799 * user.Hight - 5.677 * user.Age;
            }

            if (user.Gender == true)
            {
                DayNorm = 447.593 + 9.247 * user.Waight + 3.098 * user.Hight - 4.330 * user.Age;
            }

        }
    }
}
