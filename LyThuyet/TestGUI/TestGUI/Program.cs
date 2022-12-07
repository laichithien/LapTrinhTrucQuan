using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace TestGUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form form1 = new Form();
            form1.Size = new Size(500, 500);
            form1.Paint += new PaintEventHandler(DrawArc_Paint);
            Application.Run(form1);
        }
        static public void DrawArc_Paint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; 
            Rectangle rect = new Rectangle(200, 20, 200, 200); 
            g.DrawArc(Pens.Red, rect, 45.0f, 90.0f);
        }
    }
}
