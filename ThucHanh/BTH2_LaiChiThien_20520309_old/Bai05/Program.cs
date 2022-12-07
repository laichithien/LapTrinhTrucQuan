using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class Program
    {
        class ListNhaDat
        {
            protected int n;
            protected NhaDat[] nhaDats;
            public ListNhaDat(int n)
            {
                this.n = n;
                this.nhaDats = new NhaDat[n];
            }
            public void buildListNhaDat()
            {
                for (int i = 0; i < nhaDats.Length; i++)
                {
                    Console.Write("Chon doi tuong muon them vao (1. Khu dat     2. Nha pho     3. Chung cu): ");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            nhaDats[i] = new KhuDat();
                            nhaDats[i].Nhap();
                            break;
                        case 2:
                            nhaDats[i] = new NhaPho();
                            nhaDats[i].Nhap();
                            break;
                        case 3:
                            nhaDats[i] = new ChungCu();
                            nhaDats[i].Nhap();
                            break;
                        default:
                            nhaDats[i] = new ChungCu();
                            break;
                    }
                }
            }
            public void Xuat()
            {
                for (int i = 0; i < nhaDats.Length; i++)
                {
                    nhaDats[i].Xuat();
                    Console.WriteLine();
                }
            }
            public double TongGiaBan()
            {
                double result = 0;
                for (int i = 0; i < nhaDats.Length; i++)
                {
                    result += nhaDats[i].getGiaBan();
                }
                return result;
            }
        }

        abstract class NhaDat
        {
            protected string DiaDiem;
            protected double GiaBan;
            protected double DienTich;
            public NhaDat(string DiaDiem = "Unknown", double GiaBan = 0, double DienTich = 0)
            {
                this.DiaDiem = DiaDiem;
                this.GiaBan = GiaBan;
                this.DienTich = DienTich;
            }
            public abstract void Nhap();
            public abstract void Xuat();
            public abstract double getGiaBan();
        }
        class KhuDat : NhaDat
        {
            public KhuDat(string DiaDiem = "Unknown", double GiaBan = 0, double DienTich = 0) : base(DiaDiem, GiaBan, DienTich)
            {
            }
            public override void Nhap()
            {
                Console.Write("Nhap vao dia diem: "); DiaDiem = Console.ReadLine();
                Console.Write("Nhap vao gia ban: "); GiaBan = Convert.ToDouble(Console.ReadLine());
                Console.Write("Nhap vao dien tich: "); DienTich = Convert.ToDouble(Console.ReadLine());
            }
            public override void Xuat()
            {
                Console.WriteLine("Dia diem: " + DiaDiem);
                Console.WriteLine("Gia ban: " + Convert.ToString(GiaBan) + "VND");
                Console.WriteLine("Dien tich: " + DienTich + " m2");
            }
            public override double getGiaBan()
            {
                return this.GiaBan;
            }
        }
        class NhaPho : NhaDat
        {
            private int NamXay;
            private int SoTang;
            public NhaPho(string DiaDiem = "Unknown", double GiaBan = 0, double DienTich = 0, int NamXay = 0, int SoTang = 0) : base(DiaDiem, GiaBan, DienTich)
            {
                this.NamXay = NamXay;
                this.SoTang = SoTang;
            }
            public override void Nhap()
            {
                Console.Write("Nhap vao dia diem: "); DiaDiem = Console.ReadLine();
                Console.Write("Nhap vao gia ban: "); GiaBan = Convert.ToDouble(Console.ReadLine());
                Console.Write("Nhap vao dien tich: "); DienTich = Convert.ToDouble(Console.ReadLine());
                Console.Write("Nhap vao nam xay: "); this.NamXay = Convert.ToInt32(Console.ReadLine());
                Console.Write("Nhap vao so tang: "); this.SoTang = Convert.ToInt32(Console.ReadLine());
            }
            public override void Xuat()
            {
                Console.WriteLine("Dia diem: " + DiaDiem);
                Console.WriteLine("Gia ban: " + Convert.ToString(GiaBan) + "VND");
                Console.WriteLine("Dien tich: " + DienTich + " m2");
                Console.WriteLine("Nam xay dung: " + Convert.ToString(NamXay));
                Console.WriteLine("So tang nha pho: " + Convert.ToString(SoTang));
            }
            public override double getGiaBan()
            {
                return this.GiaBan;
            }
        }
        class ChungCu : NhaDat
        {
            private int Tang;
            public ChungCu(string DiaDiem = "Unknown", double GiaBan = 0, double DienTich = 0, int Tang = 0) : base(DiaDiem, GiaBan, DienTich)
            {
                this.Tang = Tang;
            }
            public override void Nhap()
            {
                Console.Write("Nhap vao dia diem: "); DiaDiem = Console.ReadLine();
                Console.Write("Nhap vao gia ban: "); GiaBan = Convert.ToDouble(Console.ReadLine());
                Console.Write("Nhap vao dien tich: "); DienTich = Convert.ToDouble(Console.ReadLine());
                Console.Write("Nhap vao tang: "); this.Tang = Convert.ToInt32(Console.ReadLine());
            }
            public override void Xuat()
            {
                Console.WriteLine("Dia diem: " + DiaDiem);
                Console.WriteLine("Gia ban: " + Convert.ToString(GiaBan) + "VND");
                Console.WriteLine("Dien tich: " + DienTich + " m2");
                Console.WriteLine("Tang: " + Convert.ToString(Tang));
            }
            public override double getGiaBan()
            {
                return this.GiaBan;
            }
        } 
        static void Main(string[] args)
        {
            //KhuDat khuDat = new KhuDat();
            //khuDat.Nhap();
            //NhaPho nhaPho = new NhaPho();
            //nhaPho.Nhap();
            //ChungCu chungCu = new ChungCu();
            //chungCu.Nhap();
            //khuDat.Xuat();
            //nhaPho.Xuat();
            //chungCu.Xuat();

            //Console.Write("Nhap so luong chung cu can quan ly: ");
            //KhuDat[] khuDatLlist = new KhuDat[Convert.ToInt32(Console.ReadLine())];
            //NhaPho[] nhaPhoLlist = new NhaPho[Convert.ToInt32(Console.ReadLine())];
            //ChungCu[] chungCuLlist = new ChungCu[Convert.ToInt32(Console.ReadLine())];

            ListNhaDat list = new ListNhaDat(3);
            list.buildListNhaDat();
            list.TongGiaBan();
            list.Xuat();

            //NhapDanhSachKD(khuDatLlist);
            //NhapDanhSachNP(nhaPhoLlist);
            //NhapDanhSachCC(chungCuLlist);

            //XuatDanhSachKD(khuDatLlist);
            //XuatDanhSachNP(nhaPhoLlist);
            //XuatDanhSachCC(chungCuLlist);

            Console.ReadLine();
        }
    }
}
