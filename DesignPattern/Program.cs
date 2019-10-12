using System;
using DesignPattern.creational.singleton;
namespace DesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            LazySingleton a1 = LazySingleton.GetInstance;
            LazySingleton a2 = LazySingleton.GetInstance;
            if (a1.Equals(a2))
            {
                Console.WriteLine("a1, a2 are the same object");
            }

            Console.WriteLine("Hello World!");
        }
    }
}
