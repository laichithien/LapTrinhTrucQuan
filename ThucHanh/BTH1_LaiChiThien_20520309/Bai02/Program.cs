using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai02
{
    internal class Program
    {
        public static bool isPrime(int number)
        {
            bool flag = true;
            if (number == 1)
            {
                return false;
            }
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    flag = false;
                }
            }
            return flag;
        }

        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen duong n: ");
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                if (isPrime(i))
                {
                    sum += i;
                }
            }
            Console.WriteLine("Tong so nguyen to be hon n: "+sum);
            Console.ReadLine();
        }
    }
}
