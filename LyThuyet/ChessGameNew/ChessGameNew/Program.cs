using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGameNew
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Size = new Size(600, 600);
            Board board = new Board(form);
            Application.Run(board.ParentForm);
        }
    }
}
