using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    public class PhanSo
    {
        private int tu;
        private int mau;
        public PhanSo(int ttu = 1, int mmau = 1)
        {
            tu = ttu;
            mau = mmau;
        }

        public void Xuat()
        {
            Console.Write(tu + "/" + mau + "  ");
        }
        public void Nhap()
        {
            Console.Write("Nhap tu: ");
            int ttu = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap mau: ");
            int mmau = Convert.ToInt32(Console.ReadLine());
            while (mmau == 0)
            {
                Console.Write("Mau khong duoc bang 0 !");
                Console.Write("Nhap mau: ");
                mmau = Convert.ToInt32(Console.ReadLine());
            }
            tu = ttu;
            mau = mmau;
        }
        public PhanSo RutGon()
        {
            int ucln = 1;
            for (int i = mau > tu ? tu : mau; i > 0; i--)
            {
                if (mau % i == 0 && tu % i == 0)
                {
                    ucln = i;
                    break;
                }
            }
            tu = tu / ucln;
            mau = mau / ucln;
            return this;
        }
        public static bool operator <(PhanSo a, PhanSo b)
        {
            return ((float)a.tu / (float)a.mau < (float)b.tu / (float)b.mau);
        }
        public static bool operator >(PhanSo a, PhanSo b)
        {
            return ((float)a.tu / (float)a.mau > (float)b.tu / (float)b.mau);
        }
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            PhanSo result = new PhanSo();
            result.mau = a.mau * b.mau;
            result.tu = a.tu * b.mau + a.mau * b.tu;
            result = result.RutGon();
            return result;
        }
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            PhanSo result = new PhanSo();
            result.mau = a.mau * b.mau;
            result.tu = a.tu * b.mau - a.mau * b.tu;
            result = result.RutGon();
            return result;
        }
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            PhanSo result = new PhanSo();
            result.mau = a.mau * b.tu;
            result.tu = a.tu * b.mau;
            result = result.RutGon();
            return result;
        }
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            PhanSo result = new PhanSo();
            result.mau = a.mau * b.mau;
            result.tu = a.tu * b.tu;
            result = result.RutGon();
            return result;
        }
    }
    internal class Program
    {
        static PhanSo LonNhat(PhanSo[] a)
        {
            PhanSo result = new PhanSo();
            result = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (result < a[i])
                {
                    result = a[i];
                }
            }
            return result;
        }
        static PhanSo[] SapXepTang(PhanSo[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] > a[j])
                    {
                        PhanSo temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
            return a;
        }
        static void XuatMang(PhanSo[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i].Xuat();
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Phan so dau tien: "); PhanSo a = new PhanSo(2, 3); a.Xuat(); Console.WriteLine();
            Console.Write("Phan so tiep theo: "); PhanSo b = new PhanSo(3, 4); b.Xuat(); Console.WriteLine();
            Console.Write("Tong cua hai phan so nay la: "); (a + b).Xuat(); Console.WriteLine();
            Console.Write("Hieu cua hai phan so nay la: "); (a - b).Xuat(); Console.WriteLine();
            Console.Write("Tich cua hai phan so nay la: "); (a * b).Xuat(); Console.WriteLine();
            Console.Write("Thuong cua hai phan so nay la: "); (a / b).Xuat(); Console.WriteLine();
            Console.Write("Nhap so luong phan so ban muon xet: "); Console.WriteLine();
            PhanSo[] phanSos = new PhanSo[Convert.ToInt32(Console.ReadLine())];
            for (int i = 0; i < phanSos.Length; i++)
            {
                phanSos[i] = new PhanSo();
                phanSos[i].Nhap();
            }
            Console.Write("Mang vua nhap la: "); XuatMang(phanSos); Console.WriteLine();
            Console.Write("Phan so lon nhat la: "); LonNhat(phanSos).Xuat(); Console.WriteLine();
            Console.Write("Mang sau khi sap xep: "); XuatMang(SapXepTang(phanSos)); Console.WriteLine();
            Console.ReadLine();
        }
    }
}
