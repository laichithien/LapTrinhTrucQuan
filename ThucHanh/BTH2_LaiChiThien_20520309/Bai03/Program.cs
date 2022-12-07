using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
{
    internal class MaTran
    {
        int[,] mt;
        public MaTran(int x, int y)
        {
            mt = new int[y, x];
            generateMT();
        }
        public void generateMT()
        {
            Console.Write("Random ? [y/n]: ");
            string ans = Console.ReadLine();
            if (ans == "y")
            {
                Random r = new Random();
                for (int i = 0; i < mt.GetLength(0); i++)
                {
                    
                    for (int j = 0; j < mt.GetLength(1); j++)
                    {
                        mt[i, j] = r.Next(0, 100);
                    }
                }
            }
            else if (ans == "n")
            {
                for (int i = 0; i < mt.GetLength(0); i++)
                {
                    for (int j = 0; j < mt.GetLength(1); j++)
                    {
                        Console.Write("Nhap vao tung phan tu [{0}, {1}]: ", i, j);
                        mt[i, j] = Convert.ToInt16(Console.ReadLine());
                    }
                }
            }

        }
        public void show()
        {
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    Console.Write("\t" + mt[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        public int[] search(int target)
        {
            int[] pos = new int[2];
            pos[0] = -1;
            pos[1] = -1;
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    if (mt[i, j] == target)
                    {
                        pos[0] = i;
                        pos[1] = j;
                    }
                }
            }
            return pos;
        }
        public bool isPrime(int target)
        {
            bool flag = true;
            if (target == 1)
            {
                return false;
            }
            if (target == 2)
            {
                return true;
            }
            for (int i = 2; i < Math.Sqrt(target); i++)
            {
                if (target % i == 0)
                {
                    flag = false;
                }
            }
            return flag;
        }
        public void showPrime()
        {
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    if (isPrime(mt[i, j]))
                    {
                        Console.Write(mt[i, j] + "\t");
                    }
                }
            }
            Console.WriteLine();
        }
        public int nhieuNguyenToNhat()
        {
            int line = -1;
            int nhieuNhat = -1;
            for (int i = 0; i < mt.GetLength(0); i++)
            {
                int count = 0;
                for (int j = 0; j < mt.GetLength(1); j++)
                {
                    if (isPrime(mt[i, j]))
                    {
                        count++;
                    }
                }
                if (count > nhieuNhat)
                {
                    nhieuNhat = count;
                    line = i;
                }
            }
            return line;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kich thuoc ma tran: ");
            Console.Write("X: ");
            int x = Convert.ToInt16(Console.ReadLine());
            Console.Write("Y: ");
            int y = Convert.ToInt16(Console.ReadLine());
            MaTran mt = new MaTran(x, y);
            mt.show();
            Console.Write("Nhap so can tim: ");
            int target = Convert.ToInt16(Console.ReadLine());
            int[] resultSearch = mt.search(target);
            if (resultSearch[0] == -1 || resultSearch[1] == -1)
            {
                Console.WriteLine("Khong co so ban can tim trong ma tran!!");
            }
            else
            {
                Console.WriteLine("Vi tri cua so can tim la [{0}, {1}]", resultSearch[0], resultSearch[1]);
            }
            Console.Write("Cac so nguyen to co trong ma tran la: ");
            mt.showPrime();
            Console.Write("Dong co so nhieu so nguyen to nhat la: ");
            Console.WriteLine(mt.nhieuNguyenToNhat());
            Console.ReadLine();

        }
    }
}
