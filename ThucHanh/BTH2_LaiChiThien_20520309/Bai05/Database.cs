using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class Database
    {
        protected int _n;
        public int N
        {
            set { _n = value; }
            get { return _n; }
        }
        protected DiaOc[] DiaOcs;
        public Database(int n)
        {
            N = n;
            DiaOcs = new DiaOc[n];
        }
        public void buildListNhaDat()
        {
            for (int i = 0; i < DiaOcs.Length; i++)
            {
                Console.Write("Chon doi tuong muon them vao [1 / 2 / 3] [Khu dat / Nha pho / Chung cu]: ");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        DiaOcs[i] = new KhuDat();
                        DiaOcs[i].Nhap();
                        break;
                    case 2:
                        DiaOcs[i] = new NhaPho();
                        DiaOcs[i].Nhap();
                        break;
                    case 3:
                        DiaOcs[i] = new ChungCu();
                        DiaOcs[i].Nhap();
                        break;
                    default:
                        DiaOcs[i] = new ChungCu();
                        break;
                }
            }
        }
        public void Xuat()
        {
            Console.WriteLine("========================");
            for (int i = 0; i < DiaOcs.Length; i++)
            {

                Console.WriteLine("========================");
                Console.WriteLine("|\tDia oc thu {0}\t|", i+1);
                DiaOcs[i].Xuat();
                Console.WriteLine("========================");
            }
            Console.WriteLine("========================");
        }
        public int TongGiaBan()
        {
            int result = 0;
            for (int i = 0; i < DiaOcs.Length; i++)
            {
                result += DiaOcs[i].GiaBan;
            }
            return result;
        }
        public void CustomList()
        {
            Console.WriteLine("========================");
            for (int i = 0; i < DiaOcs.Length; i++)
            {

                
                
                if ((DiaOcs[i].Loai == 1 && DiaOcs[i].DienTich > 100) || (DiaOcs[i].Loai == 2 && DiaOcs[i].DienTich > 60 && DiaOcs[i].getNamXayDung() >= 2019))
                {
                    Console.WriteLine("========================");
                    Console.WriteLine("Dia oc thu {0}", i + 1);
                    DiaOcs[i].Xuat();
                    Console.WriteLine("========================");
                }
            }
            Console.WriteLine("========================");
        }
        public void Search(string diaDiem, int giaBan, int dienTich)
        {
            Console.WriteLine("========================");
            for (int i = 0; i < DiaOcs.Length; i++)
            {
                if (DiaOcs[i].DiaDiem.Trim().ToLower() == diaDiem.ToLower().Trim() && DiaOcs[i].GiaBan<=giaBan && DiaOcs[i].DienTich>=dienTich)
                {
                    Console.WriteLine("========================");
                    Console.WriteLine("Dia oc thu {0}", i + 1);
                    DiaOcs[i].Xuat();
                    Console.WriteLine("========================");
                }
            }
            Console.WriteLine("========================");
        }
    }
}
