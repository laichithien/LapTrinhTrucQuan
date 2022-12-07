using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    internal class MyCalendar
    {
        int[,] calendar = new int[6,7];
        int[] days;
        DateTime dt;
        public MyCalendar(int month, int year)
        {
            days = new int[7*7];
            dt = new DateTime(year, month, 01);
            int startPos = 0;
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    startPos = 0;
                    break;
                case DayOfWeek.Monday:
                    startPos = 1;
                    break;
                case DayOfWeek.Tuesday:
                    startPos = 2;
                    break;
                case DayOfWeek.Wednesday:
                    startPos = 3;
                    break;
                case DayOfWeek.Thursday:
                    startPos = 4;
                    break;
                case DayOfWeek.Friday:
                    startPos = 5;
                    break;
                case DayOfWeek.Saturday:
                    startPos=6;
                    break;
                default:
                    break;
            }
            int day = 1;
            for (int i = startPos; i < DateTime.DaysInMonth(dt.Year, dt.Month) + startPos; i++)
            {
                days[i] = day;
                //Console.Write(day);
                day++;
            }
            int match = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    calendar[i, j] = days[match];
                    //Console.Write(days[match]);
                    match++;
                }
            }

        }
        public void Draw()
        {
            Console.WriteLine("==================================================================================================================");
            string[] dayList = new string[7] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            Console.Write("|");
            for (int i = 0; i < 7; i++) Console.Write("|\t" + dayList[i] + "\t|");
            Console.Write("|");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < 6; i++)
            {
                Console.Write("|");
                for (int j = 0; j < 7; j++)
                {
                    if (calendar[i, j] == 0)
                    {
                        Console.Write("|\t" + "" + "\t|");
                    }
                    else
                    {
                        Console.Write("|\t" + calendar[i, j] + "\t|");
                    }
                        
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("==================================================================================================================");
            Console.ReadLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bai 01: ");
            Console.Write("Nhap vao thang: ");
            int month = Convert.ToInt16(Console.ReadLine());
            Console.Write("Nhap vao nam: ");
            int year = Convert.ToInt16(Console.ReadLine());
            MyCalendar cl = new MyCalendar(month, year);
            cl.Draw();
        }
    }
}