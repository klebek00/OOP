using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using water_tracker.Entities;
using Windows.UI.Xaml.Documents;

namespace water_tracker
{
    public class MainFunction
    {
        public static void Welcome(UserAccaunt user, DayTarget target)
        {
            string userName = user.Name;
            int goal = target.DrinkCount;
            if (target.DrinkCount < 0) goal = 0;
            if (userName == null)
            {
                Console.WriteLine("Welcome! Let's create a new accaunt");
                user.NewAccaunt();
                target.CalculateWaterGoal(user);
                return;
            }
            Console.WriteLine($"Welcome {user.Name}!!");
            Console.WriteLine($"Today goal {goal}");
            Utility.ProgressBar(target);
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {
            UserAccaunt user = new UserAccaunt();
            DayTarget target = new DayTarget(user);
            Welcome(user, target);
            TimeReminder time = new TimeReminder();
            time.Init();
            History history = new History(target);
            while(true)
            {
                Console.Clear();

                Welcome(user, target);

                Console.WriteLine("");
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. Drink");
                Console.WriteLine("2. History");
                Console.WriteLine("3. Chage Personal Data");
                Console.WriteLine("4. Notification settings");
                Console.WriteLine("5. Change Volume");
                Console.WriteLine("6. QUIT");
                Console.WriteLine("");
                Console.Write("Enter your selection: ");
                var input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();

                    target.DrinkFunc();
                }
                else if (input == "2")
                {
                    Console.Clear();

                    Console.WriteLine("");
                    Console.WriteLine("Please choose an option by entering a number.");
                    Console.WriteLine("1. Day History");
                    Console.WriteLine("2. Month History");
                    Console.WriteLine("");
                    Console.Write("Enter your selection: ");
                    var type = Console.ReadLine();
                    if (type == "1")
                    {
                        history.GetDayHistory();
                    }
                    else if (type == "2")
                    {
                        history.GetMonthHistory();
                    }


                }
                else if (input == "3")
                {
                    Console.Clear();

                    user.PersonalData();
                    target.CalculateWaterGoal(user);

                }
                else if (input == "4")
                {
                    Console.Clear();

                    string two;
                    if (time.notif == true) two = "Off";
                    else two = "On";
                    Console.WriteLine($"Want to Turn {two} notification? (Y/N)");
                    Console.Write("Enter your selection: ");
                    var type = Console.ReadLine();
                    if (type == "Y") 
                    {
                        if (two == "On") time.TurnOn();
                        if (two == "Off") time.TurnOff();
                        
                        Console.Write($"Nitification Turn {two}!");
                        Console.ReadLine();
                    }
                }
                else if (input == "5")
                {
                    Console.Clear();

                    target.SetVolumeType();
                }
                else if (input == "6")
                {
                    Console.Clear();

                    Environment.Exit(0);
                }
                else
                {

                }
            }

        }
    }
}
