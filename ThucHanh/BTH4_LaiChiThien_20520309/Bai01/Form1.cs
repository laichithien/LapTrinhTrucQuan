﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                label1.Text = "Left mouse clicked! \n" + (Cursor.Position.ToString());
            }
            else if (e.Button == MouseButtons.Right)
            {
                label1.Text = "Right mouse clicked! \n" + (Cursor.Position.ToString());
            }
        }
    }
}
