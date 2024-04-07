using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace water_tracker.Entities
{
    public class UserAccaunt
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int Hight { get; set; }
        public int Waight { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public DateTime MorningTime { get; set; }
        public DateTime SleepTime { get; set; }
        public void NewAccaunt()
        {
            string nLog = Console.ReadLine();
            string nPass = Console.ReadLine();
            Login = nLog;
            Password = nPass;
            PersonalData();

        }
        internal void LogIn()///
        {

        }
        public void PersonalData()
        {
            if(Name == null)
            {
                string nName = Console.ReadLine();
                Name = nName;

                int nHight = Convert.ToInt32(Console.ReadLine());
                Hight = nHight;

                int nWaight = Convert.ToInt32(Console.ReadLine());
                Waight = nWaight;

                int nAge = Convert.ToInt32(Console.ReadLine());
                Age = nAge;

                string nGender = Console.ReadLine();
                if(nGender == "F")
                {
                    Gender = true;
                }
                else
                {
                    Gender= false;
                }

                DateTime nMorning = Convert.ToDateTime(Console.ReadLine());
                MorningTime = nMorning;

                DateTime nSleep = Convert.ToDateTime(Console.ReadLine());   
                SleepTime = nSleep;

            }
            else///
            {

            }
        }



    }
}
