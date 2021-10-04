using System;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";
            MyServer.start(50, 26950);

            Console.ReadKey();
        }
    }
}
