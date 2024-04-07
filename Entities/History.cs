using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using water_tracker.Interface;

namespace water_tracker.Entities
{
    internal class History
    {
        public History(DayTarget targ) 
        {
            targ.NextDay += OnDrincFunc;
        }
        Dictionary<DateTime, int> drinkAmount = new Dictionary<DateTime, int>();

        public void OnDrincFunc(DayTarget targ)
        {
            drinkAmount.Add(DateTime.Now, targ.Volume);
            //Console.WriteLine(drinkAmount.Values.Count);
        }
        public void GetDayHistory()
        {//DayTarget
         //Время
         //Количество
            DateTime today = DateTime.Today;
            foreach (var amount in drinkAmount)
            {
                if(amount.Key.Day == today.Day && amount.Key.Month == today.Month && amount.Key.Year == today.Year)
                {
                    Console.WriteLine($"key: {amount.Key}  value: {amount.Value}");
                }
            }

        }
        public void GetWeekHistory()
        {//День недели
         //Количество 
            DateTime today = DateTime.Today;

            foreach (var amount in drinkAmount)
            {
                if (amount.Key.Month == today.Month)
                {
                    Console.WriteLine($"key: {amount.Key}  value: {amount.Value}");
                }
            }
        }
        public void GetMonthHistory()
        {// День 1 6 11 16 21 26 31(30)
         //Количество
            DateTime today = DateTime.Today;

            foreach (var amount in drinkAmount)
            {
                if (amount.Key.Month == today.Month)
                {
                    Console.WriteLine($"key: {amount.Key}  value: {amount.Value}");
                }
            }
        }

    }
}
