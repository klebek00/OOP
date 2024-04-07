using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using water_tracker.Entities;

namespace water_tracker
{
    public class MainFunction
    {
        static void Main(string[] args)
        {
            UserAccaunt user = new UserAccaunt();
            DayTarget dayTarget = new DayTarget(user);
            TimeReminder time = new TimeReminder();
            History h = new History(dayTarget);
            time.Init();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();
            dayTarget.DrinkFunc();

            h.GetDayHistory();  
            //DateTime nMorning = Convert.ToDateTime(Console.ReadLine());
            //Console.WriteLine(nMorning.ToString()); 
            //Console.WriteLine(nMorning.Minute.ToString());
            //Console.WriteLine(nMorning.Hour.ToString());    
            string i = Console.ReadLine();
            if(i == "q")
            {
                time.TurnOff();
            }
            string u = Console.ReadLine();
            if (u == "u")
            {
                time.TurnOn();
            }
            string t = Console.ReadLine();


        }
    }
}
