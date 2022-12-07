using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai07
{
    public partial class Form1 : Form
    {
        public int[,] seatList;
        public int[,] isClicked;
        public Form1()
        {
            InitializeComponent();
            seatList = new int[3, 5];
            isClicked = new int[3, 5];
            getSeatClick();
        }
        public void setColor(int x, int y)
        {
            foreach (Button item in panel2.Controls)
            {
                if (seatList[(item.Name[item.Name.Length - 1] - 1)/ 5, (item.Name[item.Name.Length - 1] - 1)% 5] == 0)
                {
                    item.BackColor = Color.White;
                }
                else item.BackColor = Color.Yellow;
            }
        }
        public void getSeatClick()
        {
            foreach (Button item in panel2.Controls)
            {
                item.Click += new EventHandler(seatClicked);
            }
        }
        public void seatClicked(Object sender, EventArgs e)
        {
            Button b = sender as Button;
            int a = Convert.ToInt16(Convert.ToString((b.Name[b.Name.Length - 1] - 1)));
            label4.Text = Convert.ToString(a - 1);
            //isClicked[(b.Name[b.Name.Length - 1] -1) / 5, (b.Name[b.Name.Length - 1] - 1) / 5] = 1;
            label3.Text = Convert.ToString((b.Name[b.Name.Length - 1] - 1 - 48) / 5) + Convert.ToString((b.Name[b.Name.Length - 1] - 1 -48) / 5);
            //Label label_Thien = new Label();
            //label_Thien.Text = b.Name;
            //this.Controls.Add(label_Thien);
            b.BackColor = Color.AliceBlue;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (isClicked[i, j] != seatList[i, j])
                    {
                        seatList[i, j] =1;
                        setColor(i, j);
                    }
                }
            }
                
        }
    }
}
