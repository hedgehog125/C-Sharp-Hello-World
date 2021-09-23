using System;
using System.Threading;
using System.Collections.Generic;

namespace HelloWorld
{
    class Program
    {
        static int answerValue = 42;
        static string answerName = "the meaning of life";
        static string source = "The Hitchiker's Guide to the Galaxy";
        static float pi = 3.14f;
        static string word = "testing";
        static List<int> numbers = new List<int>();

        static bool waiting = false;
        static float dotSpeed = 0.02f;
        static void Main(string[] args)
        {
            Console.WriteLine("According to " + source + ", " + answerName + " is " + answerValue);
            Console.WriteLine("Pi is " + pi);
            Console.WriteLine("This is a word: " + word);

            System.Threading.Thread.Sleep(500);
            Console.WriteLine("\nEnter 5 numbers and press enter between each one...");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Enter a number... ");
                int input = 1;
                //int input = Int32.Parse(Console.ReadLine());
                numbers.Add(input);
            }

            Console.WriteLine("\nThese are your numbers:");

            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("\nAnyway, here's some spam.");
            System.Threading.Thread.Sleep(1000);

            //Console.WriteLine("Hello World!");

            asyncWait(0.25f);
            while (waiting)
            {
                Console.WriteLine("Hello World!");
                System.Threading.Thread.Sleep(15);
            }

            Console.WriteLine("\nAnd a cool animation.");
            System.Threading.Thread.Sleep(1000);

            float x = 0;
            int padding = 10;
            int width = 118 - (padding * 2);
            while (true)
            {
                int spaces = (int)(
                    Math.Round(
                        (Math.Sin(x) + 1) * (width / 2)
                    ) / 2);
                string output = "";
                for (int i = -padding; i < spaces; i++)
                {
                    output += " ";
                }
                output += ".";
                spaces = (width - spaces) - output.Length;
                for (int i = -padding; i < spaces; i++)
                {
                    output += " ";
                }
                output += ".";
                Console.WriteLine(output);

                x += dotSpeed;

                System.Threading.Thread.Sleep(15);
            }


            //while (true) { }


            // https://stackoverflow.com/questions/30947971/prevent-program-from-closing-when-console-window-closes
            /*
            Thread t = new Thread(new ThreadStart(doNothing));

            t.IsBackground = false;
            t.Priority = ThreadPriority.Normal;
            t.SetApartmentState(ApartmentState.STA);

            t.Start();
            */
        }

        static void syncWait()
        {
            System.Threading.Thread.Sleep(1000);
            waiting = false;
        }
        static void asyncWait(float duration)
        {
            Thread t = new Thread(new ThreadStart(syncWait));

            t.IsBackground = false;
            t.Priority = ThreadPriority.Normal;
            t.SetApartmentState(ApartmentState.STA);

            t.Start();
            waiting = true;
        }

        static void doNothing()
        {

        }
    }
}
