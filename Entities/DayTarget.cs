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
        public int DayNorm { get; set; }
        public int Volume { get; set; }
        public int DayCounter { get; set; }
        public int DrinkCount { get; set; }

        public TimeCheck time;
        public DayTarget(UserAccaunt user)
        {
            DayNorm = 0;//constanta
            DayCounter = 0;//vipito
            DrinkCount = DayNorm;//ostalos' 
            Volume = 250;
            time = new TimeCheck();
            time.NewDay += OnNewDay;
            CalculateWaterGoal(user);
        }
        public delegate void NextDayHandler(DayTarget targ);
        public event NextDayHandler NextDay;
        public void SetVolumeType()
        {
            Console.WriteLine("Choose volume setting type");
            Console.WriteLine($"Your volume now: {Volume}");
            Console.WriteLine("");
            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. System volumes");
            Console.WriteLine("2. Your personal");

            Console.Write("Enter your selection: ");
            var num = Console.ReadLine();

            Console.Clear();

            if (num == "1")
            {
                Console.WriteLine("Choose volume type");
                Console.WriteLine("");
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. 100 ml");
                Console.WriteLine("2. 125 ml");
                Console.WriteLine("3. 150 ml");
                Console.WriteLine("4. 175 ml");
                Console.WriteLine("5. 300 ml");
                Console.WriteLine("6. 400 ml");

                var type = Convert.ToInt32(Console.ReadLine());

                switch (type)
                {
                    case 1:
                        Volume = 100;
                        break;
                    case 2:
                        Volume = 125;
                        break;
                    case 3:
                        Volume = 150;
                        break;
                    case 4:
                        Volume = 175;
                        break;
                    case 5:
                        Volume = 300;
                        break;
                    case 6:
                        Volume = 400;
                        break;
                }
            }

            if (num == "2")
            {
                Console.Write("Please, enter your personal volume: ");

                Volume = Convert.ToInt32(Console.ReadLine());
            }
        }

        public void DrinkFunc()
        {
            time.NewDayStart();
            DayCounter += Volume;
            DrinkCount -= Volume;
            NextDay?.Invoke(this);
        }

        public void OnNewDay()
        {
            DayCounter = 0;
            DrinkCount = DayNorm;
        }
        public void CalculateWaterGoal(UserAccaunt user)
        {
            if (user.Gender == false)
            {
                DayNorm = Convert.ToInt32(88.362 + 13.397 * user.Waight + 4.799 * user.Hight - 5.677 * user.Age);
            }

            if (user.Gender == true)
            {
                DayNorm = Convert.ToInt32(447.593 + 9.247 * user.Waight + 3.098 * user.Hight - 4.330 * user.Age);
            }
            DrinkCount = DayNorm;
            DrinkCount -= DayCounter;

        }
    }
}
