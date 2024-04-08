using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using water_tracker.Entities;

namespace water_tracker
{
    public static class Utility
    {
        public static void PrintDotAnimation(int timer = 10)
        {
            for (int i = 0; i < timer; i++)
            {
                Console.Write(".");
                Thread.Sleep(200);
            }
            Console.Clear();
        }

        public static void ProgressBar(DayTarget targ)
        {
            double a = targ.DayNorm;
            double b = Convert.ToDouble(targ.DayCounter);
            int f = Convert.ToInt32(100 * b / a);
            if (f > 100) f = 100;
            int w = f / 2;

            for (int i = 0; i <= w; i++)
            {
                Console.Write("~");
                Thread.Sleep(20);
            }
            Console.Write($"{f}%");
            if(f == 100) 
            {
                Console.WriteLine("\nCongratulations! You have completed your daily goal!");
            }
            //Console.WriteLine("Done.");
        }
    }
}
