using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("---------------------------------------------------------------------------");
            //KhuDat khuDat = new KhuDat();
            //khuDat.Nhap();
            //Console.WriteLine("---------------------------------------------------------------------------");
            //NhaPho nhaPho = new NhaPho();
            //nhaPho.Nhap();
            //Console.WriteLine("---------------------------------------------------------------------------");
            //ChungCu chungCu = new ChungCu();
            //chungCu.Nhap();
            //Console.WriteLine("---------------------------------------------------------------------------");
            //khuDat.Xuat();
            //Console.WriteLine("---------------------------------------------------------------------------");
            //nhaPho.Xuat();
            //Console.WriteLine("---------------------------------------------------------------------------");
            //chungCu.Xuat();
            //Console.WriteLine("---------------------------------------------------------------------------");
            //Console.ReadLine();
            Database list = new Database(3);
            list.buildListNhaDat();
            Console.WriteLine("Tong gia ban: {0}", list.TongGiaBan());
            list.Xuat();
            Console.WriteLine("Dia oc theo dieu kien: ");
            list.CustomList();

            Console.WriteLine("Nhap vao dia diem: ");
            string dd = Console.ReadLine();
            Console.WriteLine("Nhap vao gia ban: ");
            int gb = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Nhap vao dien tich: ");
            int dt = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Cac dia oc thoa man dieu kien tim kiem: ");
            list.Search(dd, gb, dt);    
            Console.ReadLine();
        }
    }
}
