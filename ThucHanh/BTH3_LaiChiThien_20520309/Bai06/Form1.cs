using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Form1 : Form
    {
        static double curr_re = 0;
        static double curr_input_d;
        static int curr_op = 0;
        static bool point = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void calculate()
        {
            point = false;
            switch (curr_op)
            {
                case 0:
                    curr_re = curr_re + curr_input_d;
                    break;
                case 1:
                    curr_re = curr_re - curr_input_d;
                    break;
                case 2:
                    curr_re = curr_re * curr_input_d;
                    break;
                case 3:
                    curr_re = curr_re / curr_input_d;
                    break;
                case 4:
                    curr_re = curr_re;
                    break;
                default:
                    break;
            }
        }
        private void button16_Click(object sender, EventArgs e)
        {
            label1.Text += "1";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            label1.Text += "2";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            label1.Text += "3";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            label1.Text += "4";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label1.Text += "5";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            label1.Text += "6";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text += "7";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text += "8";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            label1.Text += "9";
        }

        private void button26_Click(object sender, EventArgs e)
        {
            double.TryParse(label1.Text, out curr_input_d);
            calculate();
            label2.Text = Convert.ToString(curr_re)+ "+";
            curr_op = 0;
            label1.Text = "";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            double.TryParse(label1.Text, out curr_input_d);
            calculate();
            label2.Text = Convert.ToString(curr_re) + "-";
            curr_op = 1;
            label1.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            double.TryParse(label1.Text, out curr_input_d);
            calculate();
            label2.Text = Convert.ToString(curr_re) + "*";
            curr_op = 2;
            label1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double.TryParse(label1.Text, out curr_input_d);
            calculate();
            label2.Text = Convert.ToString(curr_re) + "/";
            curr_op = 3;
            label1.Text = "";
        }

        private void button27_Click(object sender, EventArgs e)
        {
            double.TryParse(label1.Text, out curr_input_d);
            calculate();
            label2.Text = Convert.ToString(curr_re) + "";
            curr_op = 4;
            label1.Text = "";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (!point)
                label1.Text += ".";
            point = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = label1.Text.Substring(0, label1.Text.Length - 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            curr_input_d = 0;
            curr_re = 0;
            curr_op = 0;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            label1.Text += "0";
        }
    }
}
