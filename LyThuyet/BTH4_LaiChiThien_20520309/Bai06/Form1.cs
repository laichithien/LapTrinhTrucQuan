using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Bai06
{
    public partial class Form1 : Form
    {
        string source = "";
        string target = "";
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }
        private void copyFolder(string source, string target)
        {
            if (source != "" && target != "")
            {
                string fileName = "";
                if (System.IO.Directory.Exists(source))
                {
                    //backgroundWorker1.ReportProgress(1);
                    string[] files = System.IO.Directory.GetFiles(source);
                    int count = 0;
                    foreach (string file in files)
                    {
                        fileName = System.IO.Path.GetFileName(file);
                        string desFile = System.IO.Path.Combine(target ,fileName);
                        System.IO.File.Copy(file, desFile, true);
                        count++;
                        backgroundWorker1.ReportProgress(count);
                        Thread.Sleep(35);
                    }
                }
            }
            else
            {
                MessageBox.Show("404");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Custom Description";
            string path = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }
            textBox1.Text = path;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Custom Description";
            string path = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                path = dialog.SelectedPath;
            }
            textBox2.Text = path;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            source = textBox1.Text;
            target = textBox2.Text;
            
            progressBar1.Minimum = 0;
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(source);
            int count = dir.GetFiles().Length;
            progressBar1.Maximum = count;
            if (backgroundWorker1.IsBusy != true)
            {
                // Start the asynchronous operation.
                backgroundWorker1.RunWorkerAsync();
            }
            //MessageBox.Show("Copy done!");
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            copyFolder(source, target);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label3.Text = e.ProgressPercentage.ToString();
        }
    }
}
