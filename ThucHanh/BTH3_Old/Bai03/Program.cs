using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Bai03
{
    internal class Program
    {
        protected void button_Clicked(object sender, EventArgs a)
        {
            Form f = (Form)sender;
            f.BackColor = Color.Black;
        }
        static void Main(string[] args)
        {
            Form f1 = new Form();
            f1.Size = new Size(600, 600);
            Button b = new Button();
            b.Text = "Change color";
            b.Location = new Point(275, 275);
            b.Size = new Size(50,50);
            b.Click += new EventHandler(button_Clicked);
            f1.Controls.Add(b);
            Application.Run(f1);
        }
        
    }
}
