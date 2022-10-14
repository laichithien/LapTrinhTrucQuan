using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Keyboard_Mouse_Timer
{
    class MyForm : Form
    {
        Label label = new Label();
        public MyForm()
        {
            this.Size = new Size(1920, 1080);
            this.Text = "Test keyboard";
            this.KeyDown += new KeyEventHandler(MyForm_KeyDown);
            this.KeyUp += new KeyEventHandler(MyForm_KeyUp);
            this.KeyPress += new KeyPressEventHandler(MyForm_KeyPress);
            this.MouseUp += new MouseEventHandler(MyForm_MouseUp);
            this.MouseMove += new MouseEventHandler(MyForm_MouseMove);
            this.MouseClick += new MouseEventHandler(MyForm_MouseClick);
            this.MouseDown += new MouseEventHandler(MyForm_MouseDown);
            Timer timer = new Timer();
            timer.Interval = 10;
            timer.Tick += new EventHandler(TimerOnTick);
            timer.Enabled = true;
            label.Text = ">>>>>>>";
            this.Controls.Add(label);
        }
        void TimerOnTick(Object sender, EventArgs t)
        {
            Console.WriteLine(">>>>>>>");
            Random random = new Random();
            label.Top = random.Next(0, 1080);
            label.Left = random.Next(0, 1920);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        void MyForm_MouseDown(Object sender, MouseEventArgs m)
        {
            
        }
        void MyForm_MouseClick(Object sender, MouseEventArgs m)
        {
            
            
        }
        void MyForm_MouseMove(Object sender, MouseEventArgs m)
        {
            Graphics g = CreateGraphics();
            Pen pen = new Pen(Color.Black);
            int size = 20;
            Rectangle rect = new Rectangle(m.X - size/2, m.Y - size/2, size, size);
            if (m.Button == MouseButtons.Left)
            {
                g.DrawRectangle(pen, rect);
            }
            else if (m.Button == MouseButtons.Right)
            {
                g.DrawEllipse(pen, rect);
            }
        }
        void MyForm_MouseUp(Object sender, MouseEventArgs m)
        {
            Console.WriteLine(m.Button);
        }

        void MyForm_KeyPress(Object sender, KeyPressEventArgs kea)
        {
            {
                Console.WriteLine("Pressed " + kea.KeyChar);
            }
            Console.WriteLine("Key pressed!");
        }
        void MyForm_KeyDown(Object sender, KeyEventArgs kea)
        {
            if (kea.KeyCode == Keys.Up)
            {
                label.Top--;
            }
            else if (kea.KeyCode == Keys.Down)
            {
                label.Top++;
            }
            else if (kea.KeyCode == Keys.Left)
            {
                label.Left--;
            }
            else if (kea.KeyCode == Keys.Right)
            {
                label.Left++;
            }
        }
        void MyForm_KeyUp(Object sender, KeyEventArgs kea)
        {
            Console.WriteLine("Key Up");
        }
}

    internal class Program
    {
        static void Main(string[] args)
        {
            MyForm form = new MyForm();
            Label label = new Label();
            Application.Run(form);
        }
    }
}
