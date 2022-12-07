using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai07
{
    internal class Management
    {
        protected int _x;
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        int _y;
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int[,] SeatList;
        public Management(int x, int y)
        {
            _x = x;
            _y = y;
            SeatList = new int[_x, _y];
        }
    }
}
