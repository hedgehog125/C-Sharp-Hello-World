using System;
using System.Threading;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //while (true) { }


            // https://stackoverflow.com/questions/30947971/prevent-program-from-closing-when-console-window-closes
            Thread t = new Thread(new ThreadStart(doNothing));

            t.IsBackground = false;
            t.Priority = ThreadPriority.Normal;
            t.SetApartmentState(ApartmentState.STA);

            t.Start();
        }

        static void doNothing()
        {

        }
    }
}
