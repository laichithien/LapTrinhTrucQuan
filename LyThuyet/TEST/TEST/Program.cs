using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TEST
{
    internal class Program
    {
        int goal = 1000000000;
        public static int counter = 0;
        public static object flag = 1;
        static void Main(string[] args)
        {
            Thread Thread1 = new Thread(() => Count());
            Thread Thread2 = new Thread(() => Count());
            //Thread Thread3 = new Thread(() => findPrime(500000001, 750000000));
            //Thread Thread4 = new Thread(() => findPrime(750000001, 1000000000));
            Thread1.Start();
            Thread2.Start();
            Thread1.Join();
            Thread2.Join();
            Console.WriteLine(counter);
            Console.ReadLine();
        }
        public static void Count()
        {
            for (int i = 1; i <= 300000; i++)
            {
                lock (flag)
                {
                    int temp = counter;
                    temp++;
                    counter = temp;
                }
            }
        }
        public static void findPrime(int begin, int end)
        {
            for (int i = begin; i <= end; i++)
            {
                if (isPrime(i))
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadLine();
        }
        public static bool isPrime(int a)
        {
            if (a < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static void Even()
        {
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(1);
                if (i % 2 == 0)
                {
                    Console.WriteLine("Chan" + i);
                }
            }
            Console.ReadLine();
        }
        public static void Odd()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (i == 500)
                {
                }
                if (i % 2 == 1)
                {
                    Console.WriteLine("Le" + i);
                }
            }
            Console.ReadLine();
        }
        public static void myFunction()
        {
            Console.WriteLine("Haha");
            Console.ReadLine();
        }
        public static void yourFunction()
        {
            Console.WriteLine("Hihi");
            Console.ReadLine();
        }
    }
}
