using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ChessGameNew
{
    public enum SquareColor { White, Black };
    class Square : PictureBox
    {
        protected Piece _piece;
        protected Board _board;
        //protected Piece _piece;
        //public Piece Piece
        //{
        //    get { return _piece; }
        //    set { _piece = value; }
        //}
        protected SquareColor _color;
        public Piece Piece
        {
            get { return _piece; }
            set
            {
                _piece = value;
                if (_piece != null) Image = _piece.Image;
                else Image = null;
            }
        }
        public SquareColor Color
        {
            get { return _color; }
            set
            {
                _color = value;
                if (_color == SquareColor.White)
                {
                    this.BackColor = System.Drawing.Color.White;
                }
                else
                    this.BackColor = System.Drawing.Color.Gray;
            }
        }
        public Square(SquareColor c, Board b, Piece p = null)
        {
            _piece = p;
            _board = b;
            Color = c;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }

}
