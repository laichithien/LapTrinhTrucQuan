using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class KhuDat : DiaOc
    {
        protected int _loai;
        public override int Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }
        public KhuDat(string diaDiem = "Unknown", int giaBan = 0, int dienTich = 0) : base(diaDiem, giaBan, dienTich)
        {
            Loai = 1;
        }
        public override void Nhap()
        {
            base.Nhap();
        }
        public override void Xuat()
        {
            Console.WriteLine("Loai dia oc: Khu dat");
            base.Xuat();
        }
    }
}
