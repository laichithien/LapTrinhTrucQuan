using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Chess
{
    public enum SquareColor { White, Black };
    public class Square : PictureBox
    {
        protected Piece _piece;
        public Piece Piece
        {
            get { return _piece; }
            set
            {
                _piece = value;
                if (_piece != null)
                    Image = _piece.Image;
                else 
                    Image = null;
            }
        }
        protected Board _board;
        protected Boolean _selected;
        public Boolean Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                if (value == true)
                {
                    _board.SelectedSquare = this;
                    BackColor = System.Drawing.Color.Yellow;
                }
                else
                    Color = Color;
            }
        }
        public SquareColor _color;
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
        public Square(SquareColor c, Board b, Piece p=null)
        {
            _piece = p;
            _board = b;
            Color = c;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
