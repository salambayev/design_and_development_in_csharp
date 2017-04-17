using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace SynchronizationDemo
{
    class Program
    {
        static Semaphore s = new Semaphore(2, 2);

        static void Eat(object id)
        {
            while (true)
            {
                Console.WriteLine(id + " wants to eat!");
                s.WaitOne();

                Console.WriteLine(id + " is eating spaghetti :)");
                Thread.Sleep(3000 * (int)id);
                Console.WriteLine(id + " giving a fork back...");
                s.Release();
                Console.WriteLine("FOR " + id + " thinking time !!!");
                Thread.Sleep(4000);
            }
        }

        static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++) new Thread(Eat).Start(i);
            Console.ReadKey();
        }
    }
}
