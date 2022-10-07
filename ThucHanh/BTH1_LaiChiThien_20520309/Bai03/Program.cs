using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai03
{
    internal class Program
    {
        private static void checkValidTime(int dd, int MM, int yyyy)
        {
            string timeStr;
            try
            {
                DateTime time = new DateTime(yyyy, MM, dd);
                timeStr = string.Format("{0:dd/MM/yyyy}", time);
            }
            catch
            {
                Console.WriteLine("Ngay khong hop le!!");
                Console.ReadLine();
                return;
            }
            Console.WriteLine("Ngay hop le!!");
            Console.ReadLine();
            return ;
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap vao ngay ");
            int dd = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao thang ");
            int MM = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao thang ");
            int yyyy = int.Parse(Console.ReadLine());
            checkValidTime(dd, MM, yyyy);
        }
    }
}
