using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class ChungCu : DiaOc
    {
        protected int _loai;
        public override int Loai
        {
            get { return _loai; }
            set { _loai = value; }
        }
        protected int _tang;
        public int Tang { get { return _tang; } set { _tang = value; } }
        public ChungCu(string diaDiem = "Unknown", int giaBan = 0, int dienTich = 0, int tang = 1) : base(diaDiem, giaBan, dienTich)
        {
            Tang = tang;
            Loai = 3;
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap vao tang: ");
            int t = Convert.ToInt32(Console.ReadLine());
            Tang = t;
        }
        public override void Xuat()
        {
            Console.WriteLine("Loai dia oc: Chung cu");
            base.Xuat();
            Console.WriteLine("Tang: {0}", Tang);
        }
    }
}
