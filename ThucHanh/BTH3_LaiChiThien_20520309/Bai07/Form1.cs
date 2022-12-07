using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai07
{
    public partial class Form1 : Form
    {
        int[] state = new int[16];
        int type;
        int total = 0;
        public Form1()
        {
            InitializeComponent();
            reloadPrice();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 15; i++)
            {
                Button bt = new Button();
                bt.Size = new Size(64, 64);
                bt.Name = "seat"+ i.ToString();
                bt.Text = i.ToString();
                bt.Click += new EventHandler(seat_Click);
                flowLayoutPanel1.Controls.Add(bt);
            }
        }
        private void getMoney()
        {
            total = 0;
            for (int i = 1; i <= 15; i++)
            {
                if (state[i] == 1)
                {
                    if ((i - 1) / 5 == 0)
                        total += 5000;
                    else if ((i - 1) / 5 == 1) total += 6500;
                    else total += 8000;
                }
            }
        }
        private void reloadPrice()
        {
            getMoney();
            label3.Text = total.ToString();
        }
        private void setColor()
        {
            for (int i = 1; i <= 15; i++)
            {
                if (state[i] == 0)
                {
                    this.flowLayoutPanel1.Controls["seat"+ i.ToString()].BackColor = Color.White;
                }
                else if (state[i] == -1)
                {
                    this.flowLayoutPanel1.Controls["seat" + i.ToString()].BackColor = Color.Yellow;
                }
                else if (state[i] == 1)
                {
                    this.flowLayoutPanel1.Controls["seat" + i.ToString()].BackColor = Color.Blue;
                }
            }
        }
        private void seat_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            if (state[Convert.ToInt16(bt.Name.Substring(4))] == 0)
            {
                state[Convert.ToInt16(bt.Name.Substring(4))] = 1;
            }
            else if (state[Convert.ToInt16(bt.Name.Substring(4))] == 1)
            {
                state[Convert.ToInt16(bt.Name.Substring(4))] = 0;
            }
            else if (state[Convert.ToInt16(bt.Name.Substring(4))] == -1)
            {
                MessageBox.Show("Không được đâu sói à!!");
            }
            reloadPrice();
            setColor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 15; i++)
            {
                if (state[i] == 1)
                {
                    state[i] = -1;
                }
            }
            reloadPrice();
            setColor();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 15; i++)
            {
                if (state[i] == 1)
                {
                    state[i] = 0;
                }
            }
            reloadPrice();
            setColor();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
