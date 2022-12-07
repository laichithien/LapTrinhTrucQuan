using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ChessGameNew
{
    class Board
    {
        public const int DEFAULT_SQUARE_WIDTH = 64; 
        public const int DEFAULT_SQUARE_HEIGHT = 64;

        protected Square[,] _squares;
        protected int _squareWidth;
        protected int _squareHeight;
        public Form ParentForm { get; set; }

        public Board(Form parent, int height=DEFAULT_SQUARE_HEIGHT, int width=DEFAULT_SQUARE_WIDTH)
        {
            _squares = new Square[8, 8];
            _squareWidth = width;
            _squareHeight = height;
            ParentForm = parent;
            _init();
        }
        protected void _init()
        {
            int left = 0;
            int top = 0;
            SquareColor c = SquareColor.White;
            for (int i = 0; i < 8; i++)
            {
                left = 0;
                for (int j = 0; j < 8; j++)
                {
                    Square sq = new Square(c, this);
                    sq.Size = new System.Drawing.Size(_squareWidth, _squareHeight);
                    sq.Left = left;
                    sq.Top = top;

                    left += _squareWidth;
                    if (c == SquareColor.White) c = SquareColor.Black;
                    else c = SquareColor.White;

                    _squares[i, j] = sq;
                    ParentForm.Controls.Add(sq);
                }
                top += _squareHeight;
                if (c == SquareColor.White) c = SquareColor.Black;
                else c = SquareColor.White;
            }
            this[0, 0] = new King(_squares[0, 0], PieceColor.Black);
        }
    }
}
