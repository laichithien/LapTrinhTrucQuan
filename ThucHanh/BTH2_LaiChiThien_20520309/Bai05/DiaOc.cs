using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    public class DiaOc
    {
        protected int _loai;
        public virtual int Loai
        {
            set { _loai = value; }
            get { return _loai; }
        }
        protected string _diadiem;
        public string DiaDiem
        {
            get { return _diadiem; }
            set { _diadiem = value; }
        }
        protected int _giaban;
        public int GiaBan
        {
            get { return _giaban; }
            set { _giaban = value; }
        }
        protected int _dientich;
        public int DienTich
        {
            get { return _dientich; }
            set { _dientich = value; }
        }
        public DiaOc(string diaDiem = "Unknow", int giaBan = 0, int dienTich = 0)
        {
            _diadiem = diaDiem;
            _giaban = giaBan;
            _dientich = dienTich;
            Loai = 0;
        }
        public virtual void Nhap()
        {
            Console.Write("Nhap vao dia diem: ");
            string dd = Console.ReadLine();
            Console.Write("Nhap vao gia ban: ");
            int gb = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap vao dien tich: ");
            int dt = Convert.ToInt32(Console.ReadLine());
            DiaDiem = dd;
            GiaBan = gb;
            DienTich = dt;
        }
        public virtual void Xuat()
        {
            Console.WriteLine("Dia diem: {0}", DiaDiem);
            Console.WriteLine("Gia ban: {0}", GiaBan);
            Console.WriteLine("Dien tich: {0}", DienTich);
        }
        public virtual int getNamXayDung()
        {
            return 1;
        }
    }
}
