using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai06
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

        public static int[,] generate2dArray(int hang, int cot)
        {
            Random random = new Random();
            int[,] values = new int[hang, cot];
            for (int i = 0; i < hang; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    values[i, j] = random.Next(0, 100);
                }
            }
            return values;
        }
        public static int[,] deleteRows(int[,] matrix, int rowDelete)
        {
            int[,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i < rowDelete)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        newMatrix[i, j] = matrix[i, j];
                        //Console.WriteLine(i + "-> " + i);
                    }
                }
                else if (i > rowDelete)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        newMatrix[i - 1, j] = matrix[i, j];
                        //Console.WriteLine(i + "-> " + (i-1));
                    }
                }
            }
            return newMatrix;
        }
        public static int[,] deleteColumns(int[,] matrix, int colDelete)
        {
            int[,] newMatrix = new int[matrix.GetLength(0), matrix.GetLength(1) -1];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j < colDelete)
                    {
                        newMatrix[i, j] = matrix[i, j];
                    }
                    //Console.WriteLine(i + "-> " + i);
                }
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j > colDelete)
                    {

                        newMatrix[i, j-1] = matrix[i, j];
                    }
                    //Console.WriteLine(i + "-> " + (i-1));
                }
            }
            return newMatrix;
        }
        public static void printMatrix(int[,] tdarrray)
        {
            for (int i = 0; i < tdarrray.GetLength(0); i++)
            {
                for (int j = 0; j < tdarrray.GetLength(1); j++)
                {
                    if (i == tdarrray.GetLength(0) - 1 && j == tdarrray.GetLength(1) - 1)
                    {
                        Console.Write(tdarrray[i, j]);
                    }
                    else
                        Console.Write(tdarrray[i, j] + ",\t");
                }
                if (i < tdarrray.GetLength(0) - 1)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("]");
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap vao so hang: ");
            int hang = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao so cot: ");
            int cot = int.Parse(Console.ReadLine());
            int[,] array = generate2dArray(hang, cot);

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Ma tran vua tao la: ");
            Console.Write("[");
            int max, min;
            max = array[0, 0];
            min = array[0, 0];
            int maxsum = 0;
            int maxsumidx = 0;
            int sumNotPrime = 0;
            int maxElementCol = 0;
            for (int i = 0; i < hang; i++)
            {
                int sum = 0;
                for (int j = 0; j < cot; j++)
                {
                    if (!isPrime(array[i, j]))
                    {
                        sumNotPrime += array[i, j];
                    }
                    sum += array[i, j];
                    if (max < array[i, j])
                    {
                        max = array[i, j];
                        maxElementCol = j;
                    }
                    if (min > array[i, j])
                    {
                        min = array[i, j];
                    }
                    if (i == hang - 1 && j == cot - 1)
                    {
                        Console.Write(array[i, j]);
                    }
                    else
                        Console.Write(array[i, j] + ",\t");
                }
                if (sum > maxsum)
                {
                    maxsum = sum;
                    maxsumidx = i;
                }
                if (i < hang - 1)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("]");

            Console.WriteLine("---------------------------------------------------------");

            Console.WriteLine("So lon nhat la: " + max);
            Console.WriteLine("So be nhat la: " + min);

            Console.WriteLine("Hang co tong lon nhat la: " + maxsumidx);

            Console.WriteLine("Tong cac so khong phai la so nguyen to: " + sumNotPrime);

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Nhap vao dong can xoa: ");

            int dongXoa = int.Parse(Console.ReadLine());

            int[,] newMatrix = deleteRows(array, dongXoa);

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Ma tran sau khi xoa: ");
            Console.Write("[");
            printMatrix(newMatrix);

            int[,] newMatrixDelMaxCol = deleteColumns(array, maxElementCol);

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Ma tran sau khi xoa cot chua gia tri lon nhat: ");
            printMatrix(newMatrixDelMaxCol);

            Console.ReadLine();
        }
    }
}
