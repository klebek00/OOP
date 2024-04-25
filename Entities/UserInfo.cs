using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;
using Newtonsoft.Json;

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
            Console.WriteLine("Create a Login");
            string nLog = Console.ReadLine();
            Login = nLog;
            Console.WriteLine("Create a Password");
            string nPass = Console.ReadLine();
            Password = nPass;
            PersonalData();
            string filePath = $"{this.Login}{this.Password}.json";
            SerializationLibrary.SerilestirJson.Serialize(this, filePath);
        }
        public void LogIn()///
        {
            Console.WriteLine("Enter Login");
            string nLog = Console.ReadLine();
            //Login = nLog;
            Console.WriteLine("Enter Password");
            string nPass = Console.ReadLine();
            //Password = nPass;

            string filePath = $"{nLog}{nPass}.json";

            var loadData = SerializationLibrary.SerilestirJson.Deserialize<UserAccaunt>(filePath);

            this.Id = loadData.Id;
            this.Login = loadData.Login;
            this.Password = loadData.Password;
            this.Name = loadData.Name;
            this.Age = loadData.Age;
            this.Gender = loadData.Gender;
            this.Hight = loadData.Hight;
            this.Waight = loadData.Waight;
            this.MorningTime = loadData.MorningTime;
            this.SleepTime = loadData.SleepTime;
        }
        public void PersonalData()
        {
            if(Name == null)
            {
                Console.Clear();

                Console.WriteLine("Enter your Name");
                string nName = Console.ReadLine();
                Name = nName;

                Console.Clear();

                Console.WriteLine("Enter your Hight");
                int nHight = Convert.ToInt32(Console.ReadLine());
                Hight = nHight;

                Console.Clear();

                Console.WriteLine("Enter your Waight");
                int nWaight = Convert.ToInt32(Console.ReadLine());
                Waight = nWaight;

                Console.Clear();

                Console.WriteLine("Enter your Age");
                int nAge = Convert.ToInt32(Console.ReadLine());
                Age = nAge;

                Console.Clear();

                Console.WriteLine("Enter your Gander (F/M)");
                string nGender = Console.ReadLine();
                if(nGender == "F")
                {
                    Gender = true;
                }
                else
                {
                    Gender= false;
                }

                Console.Clear();

                Console.WriteLine("What time do you start your day??");
                DateTime nMorning = Convert.ToDateTime(Console.ReadLine());
                MorningTime = nMorning;

                Console.Clear();

                Console.WriteLine("What time do you go to sleep??");
                DateTime nSleep = Convert.ToDateTime(Console.ReadLine());   
                SleepTime = nSleep;

                Console.Clear();

                Console.WriteLine("Thanks You!! Calculate your Day Target");
                Utility.PrintDotAnimation();

            }
            else
            {
                Console.WriteLine("What kind if data you want to change??");
                Console.WriteLine("");
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. Name");
                Console.WriteLine("2. Haight");
                Console.WriteLine("3. Waight");
                Console.WriteLine("4. Age");
                Console.WriteLine("5. Gander");
                Console.WriteLine("6. Day Start");
                Console.WriteLine("7. Day End");

                Console.Write("Enter your selection: ");
                var input = Console.ReadLine();

                Console.Clear();

                if (input == "1")
                {
                    Console.WriteLine("Enter your new Name");
                    string nName = Console.ReadLine();
                    Name = nName;

                    string filePath = $"{this.Login}{this.Password}.json";
                    SerializationLibrary.SerilestirJson.Serialize(this, filePath);

                }
                else if (input == "2")
                {
                    Console.WriteLine("Enter your new Hight");
                    int nHight = Convert.ToInt32(Console.ReadLine());
                    Hight = nHight;

                    Console.WriteLine("Ok!! Calculate your New Day Target");
                    Utility.PrintDotAnimation();

                    string filePath = $"{this.Login}{this.Password}.json";
                    SerializationLibrary.SerilestirJson.Serialize(this, filePath);


                }
                else if (input == "3")
                {
                    Console.WriteLine("Enter your new Waight");
                    int nWaight = Convert.ToInt32(Console.ReadLine());
                    Waight = nWaight;

                    string filePath = $"{this.Login}{this.Password}.json";
                    SerializationLibrary.SerilestirJson.Serialize(this, filePath);


                }
                else if (input == "4")
                {
                    Console.WriteLine("Enter your new Age");
                    int nAge = Convert.ToInt32(Console.ReadLine());
                    Age = nAge;

                    string filePath = $"{this.Login}{this.Password}.json";
                    SerializationLibrary.SerilestirJson.Serialize(this, filePath);

                }
                else if (input == "5")
                {
                    Console.WriteLine("Enter your Gander (F/M)");
                    string nGender = Console.ReadLine();
                    if (nGender == "F")
                    {
                        Gender = true;
                    }
                    else
                    {
                        Gender = false;
                    }

                    string filePath = $"{this.Login}{this.Password}.json";
                    SerializationLibrary.SerilestirJson.Serialize(this, filePath);

                }
                else if (input == "6")
                {
                    Console.WriteLine("What time do you start your day now??");
                    DateTime nMorning = Convert.ToDateTime(Console.ReadLine());
                    MorningTime = nMorning;

                    string filePath = $"{this.Login}{this.Password}.json";
                    SerializationLibrary.SerilestirJson.Serialize(this, filePath);

                }
                else if (input == "7")
                {
                    Console.WriteLine("What time do you go to sleep now??");
                    DateTime nSleep = Convert.ToDateTime(Console.ReadLine());
                    SleepTime = nSleep;

                    string filePath = $"{this.Login}{this.Password}.json";
                    SerializationLibrary.SerilestirJson.Serialize(this, filePath);

                }
                else
                {

                }


            }
        }



    }
}
