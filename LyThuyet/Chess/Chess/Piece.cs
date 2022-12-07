using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Resources
    {
        public static Image IMAGE_PAWN_BLACK = Image.FromFile("images\\pawn_black.png");
        public static Image IMAGE_ROOK_BLACK = Image.FromFile("images\\rook_black.png");
        public static Image IMAGE_KNIGHT_BLACK = Image.FromFile("images\\knight_black.png");
        public static Image IMAGE_BISHOP_BLACK = Image.FromFile("images\\bishop_black.png");
        public static Image IMAGE_QUEEN_BLACK = Image.FromFile("images\\queen_black.png");
        public static Image IMAGE_KING_BLACK = Image.FromFile("images\\king_black.png");

        public static Image IMAGE_PAWN_WHITE = Image.FromFile("images\\pawn_white.png");
        public static Image IMAGE_ROOK_WHITE = Image.FromFile("images\\rook_white.png");
        public static Image IMAGE_KNIGHT_WHITE = Image.FromFile("images\\knight_white.png");
        public static Image IMAGE_BISHOP_WHITE = Image.FromFile("images\\bishop_white.png");
        public static Image IMAGE_QUEEN_WHITE = Image.FromFile("images\\queen_white.png");
        public static Image IMAGE_KING_WHITE = Image.FromFile("images\\king_white.png");
    }
    public enum PieceColor { White, Black }
    public class Piece
    {
        protected Image _image;
        protected Square _square;
        public Square Square { get { return _square; } }
        public Image Image { get { return _image; } }
        protected PieceColor _color;
        protected PieceColor Color
        {
            get { return _color; }
        }
        public Piece(Square sq, PieceColor color)
        {
            _square = sq;
            _color = color;
        }
    }
    public class King : Piece
    {
        public King(Square sq, PieceColor color) : base(sq, color)
        {
            if (color == PieceColor.White)
                _image = Resources.IMAGE_KING_WHITE;
            else
                _image = Resources.IMAGE_KING_BLACK;
        }
    }
    public class Pawn : Piece
    {
        public Pawn(Square sq, PieceColor color) : base(sq, color)
        {
            if (color == PieceColor.White)
                _image = Resources.IMAGE_PAWN_WHITE;
            else
                _image = Resources.IMAGE_PAWN_BLACK;

        }
    }

    public class Queen : Piece
    {
        public Queen(Square sq, PieceColor color) : base(sq, color)
        {
            if (color == PieceColor.White)
                _image = Resources.IMAGE_QUEEN_WHITE;
            else
                _image = Resources.IMAGE_QUEEN_BLACK;

        }
    }

    public class Rook : Piece
    {
        public Rook(Square sq, PieceColor color) : base(sq, color)
        {
            if (color == PieceColor.White)
                _image = Resources.IMAGE_ROOK_WHITE;
            else
                _image = Resources.IMAGE_ROOK_BLACK;

        }
    }

    public class Knight : Piece
    {
        public Knight(Square sq, PieceColor color) : base(sq, color)
        {
            if (color == PieceColor.White)
                _image = Resources.IMAGE_KNIGHT_WHITE;
            else
                _image = Resources.IMAGE_KNIGHT_BLACK;

        }
    }

    public class Bishop : Piece
    {
        public Bishop(Square sq, PieceColor color) : base(sq, color)
        {
            if (color == PieceColor.White)
                _image = Resources.IMAGE_BISHOP_WHITE;
            else
                _image = Resources.IMAGE_BISHOP_BLACK;

        }
    }
}
