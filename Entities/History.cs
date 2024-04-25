using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using water_tracker.Interface;
using Windows.System;

namespace water_tracker.Entities
{
    internal class History
    {
        public History(DayTarget targ, UserAccaunt user) 
        {
            targ.NextDay += OnDrincFunc;
            string filePath = $"{user.Login}{user.Password}hist.json";
            if (File.Exists(filePath))
            {
                var loadData = SerializationLibrary.SerilestirJson.Deserialize<Dictionary<DateTime, int>>(filePath);
                this.drinkAmount = loadData;
            }
        }
        Dictionary<DateTime, int> drinkAmount = new Dictionary<DateTime, int>();

        public void OnDrincFunc(DayTarget targ, UserAccaunt user)
        {
            drinkAmount.Add(DateTime.Now, targ.Volume);
            string filePath = $"{user.Login}{user.Password}hist.json";
            SerializationLibrary.SerilestirJson.Serialize(drinkAmount, filePath);

            //Console.WriteLine(drinkAmount.Values.Count);
        }
        public void GetDayHistory()
        {//DayTarget
         //Время
         //Количество
            DateTime today = DateTime.Today;

            foreach (var amount in drinkAmount)
            {
                if(amount.Key.Day == today.Day && amount.Key.Month == today.Month && amount.Key.Year == today.Year && amount.Value != 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine($"Time: {amount.Key.Hour}:{amount.Key.Minute}  Water Amount: {amount.Value}");
                }
            }
            Console.ReadLine();

        }
        public void GetWeekHistory()
        {//День недели
         //Количество 
            DateTime today = DateTime.Today;

            foreach (var amount in drinkAmount)
            {
                if (amount.Key.Month == today.Month)
                {
                    Console.WriteLine($"Day of the Week: {amount.Key}  Water Amount: {amount.Value}");
                }
            }
        }
        public void GetMonthHistory()
        {// День 1 6 11 16 21 26 31(30)
         //Количество
            CultureInfo ci = new CultureInfo("en-US");
            DateTime day = DateTime.Today;
            DateTime lastDay = DateTime.Today;
            bool flag = true;
            int dayAmount = 0;
            Console.WriteLine("");
            Console.WriteLine(day.ToString("MMMM", ci));
            foreach (var amount in drinkAmount)
            {
                if(amount.Key.Year < day.Year)
                {
                    continue;
                }
                if (amount.Key.Month == day.Month)
                {

                    if(amount.Key.Day == lastDay.Day || flag == true)
                    {
                        dayAmount += amount.Value;
                        lastDay = amount.Key;
                        flag = false;
                        continue;
                    }
                    Console.WriteLine($"Day {lastDay.Day}: {dayAmount}");
                    Console.WriteLine("");
                    if (amount.Key.Day != lastDay.Day || flag == true)
                    {
                        dayAmount = 0;
                        dayAmount += amount.Value;
                        lastDay = amount.Key;
                        flag = false;
                        continue;
                    }


                }
 
            }
            Console.WriteLine($"Day {lastDay.Day}: {dayAmount}");
            Console.ReadLine();

        }

    }
}
