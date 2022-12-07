using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Label label = new Label();
            label.Text = "Paint Event";
            Random rd = new Random();
            int x = rd.Next();
            int y = rd.Next();
            label.Location = new Point(x%300, y%300);
            this.Controls.Add(label);
        }
    }
}
