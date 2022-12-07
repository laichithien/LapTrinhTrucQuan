using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class NhaPho : DiaOc
    {
        protected int _loai;
        public override int Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }
        protected int _namxaydung;
        public int NamXayDung
        {
            set { _namxaydung = value; }
            get { return _namxaydung; }
        }
        protected int _sotang;
        public int SoTang
        {
            get { return _sotang; }
            set { _sotang = value; }
        }
        public NhaPho(string diaDiem = "Unknown", int giaBan = 0, int dienTich = 0, int namXayDung = 1, int soTang = 1) : base(diaDiem, giaBan, dienTich)
        {
            NamXayDung = namXayDung;
            SoTang = soTang;
            Loai = 2;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap vao nam xay dung: ");
            int nxd = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhap vao so tang: ");
            int st = Convert.ToInt32(Console.ReadLine());
            NamXayDung = nxd;
            SoTang = st;
        }
        public override void Xuat()
        {
            Console.WriteLine("Loai dia oc: Nha pho");
            base.Xuat();
            Console.WriteLine("Nam xay dung: {0}",  NamXayDung);
            Console.WriteLine("So tang: {0}", SoTang);
        }
        public override int getNamXayDung()
        {
            return NamXayDung;
        }
    }
}
