using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    internal class Program
    {
        public static int[] generateArray(int count)
        {
            Random random = new Random();
            int[] values = new int[count];
            for (int i = 0; i < count; i++)
            {
                values[i] = random.Next(0, 100);
            }
            return values;
        }

        private static bool isOdd(int number)
        {
            return number % 2 != 0;
        }
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
        public static bool isSquare(int number)
        {
            if (number < 1)
                return false;
            int i = 1;
            while (i * i <= number)
            {
                if (i * i == number)
                {
                    return true;
                }
                i++;
            }
            return false;
        }
        private static int sumOdd(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (isOdd(array[i]))
                {
                    sum += array[i];
                }
            }
            return sum;
        }
        private static int countPrime(int[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (isPrime(array[i]))
                    count++;
            }
            return count;
        }
        private static int smallestSquare(int[] array)
        {
            int smallest = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (smallest != -1)
                {
                    if (isSquare(array[i]) && smallest >= array[i])
                        smallest = array[i];
                }
                else if (isSquare(array[i]))
                    smallest = array[i];
            }
            return smallest;
        }
        private static void Bai01()
        {
            int[] array = generateArray(100);
            Console.WriteLine("Mang vua tao:");
            Console.Write("[");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.Write(array[i]);
                }
                else
                    Console.Write(array[i] + ", ");
            }
            Console.WriteLine("]");

            int answer;
            answer = sumOdd(array);
            Console.WriteLine("Tong cac so le trong mang la: " + answer);

            answer = countPrime(array);
            Console.WriteLine("So cac so nguyen to trong mang la: " + answer);

            answer = smallestSquare(array);
            if (answer == -1)
            {
                Console.WriteLine("Hong co so chinh phuong");
            }
            else Console.WriteLine("So chinh phuong nho nhat la: " + answer);

        }
        static void Main(string[] args)
        {
            Bai01();
            Console.ReadLine();
        }
    }
}
