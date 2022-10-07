using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap vao ngay ");
            int dd = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao thang ");
            int MM = int.Parse(Console.ReadLine());
            Console.Write("Nhap vao thang ");
            int yyyy = int.Parse(Console.ReadLine());
            DateTime days = new DateTime(yyyy, MM, dd);
            string dayofweek = Convert.ToString(days.DayOfWeek);
            Console.WriteLine("Ngay vua nhap la thu: "+ dayofweek);
            Console.ReadLine();
        }
    }
}
