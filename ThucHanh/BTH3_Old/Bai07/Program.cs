using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Bai07
{
    internal class UI : Form
    {
        protected Management data;
        protected Panel Screen;
        public UI(Management data)
        {
            data = data;
            this.Size = new Size(400,400);
            this.StartPosition = FormStartPosition.CenterScreen;
            buildUI();
        }
        public void buildUI()
        {
            Panel Screen = new Panel();
            Label labelScreen = new Label();
            labelScreen.Text = "Màn hình";
            Screen.Controls.Add(labelScreen);
            Screen.BackColor = Color.Gray;
            Screen.Width = 400;
            Screen.Height = 75;
            this.Controls.Add(Screen);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Management mn = new Management(5,6);
            UI ui = new UI(mn);
            Application.Run(ui);

        }
    }
}
