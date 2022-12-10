using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Form1 : Form
    {
        public string filePath = string.Empty;
        public Form1()
        {
            InitializeComponent();

            toolStripStatusLabel1.Text = "Hôm nay là ngày " + DateTime.Now.Date.ToString("dd/MM/yyyy") + " - Bây giờ là " + DateTime.Now.ToString("h:m:s tt");
            timer1.Start();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "AVI file (*.avi)|*.avi|MPEG file (*.mpeg)|*.mpeg|WAV file (*.wav)|*.wav|MIDI file (*.midi)|*.midi|MP4 file (*.mp4)|*.mp4|MP3 file (*.mp3)|*.mp3";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                axWindowsMediaPlayer1.URL = openFileDialog.FileName;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Hôm nay là ngày " + DateTime.Now.Date.ToString("dd/MM/yyyy") + " - Bây giờ là " + DateTime.Now.ToString("h:m:s tt");
        }
    }
}
