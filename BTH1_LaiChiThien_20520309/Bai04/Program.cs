using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.Write("Nhap vao thang ");
            int MM = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao thang ");
            int yyyy = int.Parse(Console.ReadLine());
            int days = DateTime.DaysInMonth(yyyy, MM);
            Console.WriteLine("So ngay trong thang vua nhap: "+ days);
            Console.ReadLine();
        }
    }
}
