using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Form1 : Form
    {
        int op_code;
        public Form1()
        {
            InitializeComponent();
        }
        private void ShowResult()
        {
            double result = 0;
            switch (op_code)
            {
                case 0:
                    result = Convert.ToDouble("0" + textBox1.Text) + Convert.ToDouble("0" + textBox2.Text);
                    break; 
                case 1:
                    result = Convert.ToDouble("0" + textBox1.Text) - Convert.ToDouble("0" + textBox2.Text);
                    break;
                case 2:
                    result = Convert.ToDouble("0" + textBox1.Text) * Convert.ToDouble("0" + textBox2.Text);
                    break;
                case 3:
                    if (Convert.ToDouble("0" + textBox2.Text) == 0)
                    {
                        MessageBox.Show("Bạn không thể chia cho 0");
                    }
                    else result = Convert.ToDouble("0" + textBox1.Text) / Convert.ToDouble("0" + textBox2.Text);
                    break;
                default:
                    break;
            }
            textBox3.Text = Convert.ToString(result);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            op_code = 0;
            ShowResult();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            op_code = 1;
            ShowResult();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            op_code = 2;
            ShowResult();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            op_code = 3;
            ShowResult();
        }
    }
}
