using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        public bool waiting = false;
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            ///*
            asyncWait(1.0f);
            while (waiting)
            {
                Console.WriteLine("Hello World!");
            }
            Console.WriteLine("A");
            int x = 0;
            while (true)
            {
                string output = "";
                for (int i = 0; i < x; i++)
                {
                    output += " ";
                }
                output += ".";
                x++;
                System.Threading.Thread.Sleep(100);
            }
            //*/


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

        void syncWait()
        {
            System.Threading.Thread.Sleep(1000);
            waiting = false;
        }
        void asyncWait(float duration)
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
