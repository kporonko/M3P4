using System;

namespace Logger_module
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Starter starter = new Starter();
            Starter.Start();
            Console.ReadKey();
        }
    }
}
