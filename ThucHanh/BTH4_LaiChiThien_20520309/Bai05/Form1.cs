using AppBanHang.DAO;
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
        public int stt;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            loadDataGridView();
        }
        private void loadDataGridView()
        {
            Data_Provider dp = new Data_Provider();
            string searchString = toolStripTextBox1.Text;
            
            string query = "select * from QLSV where TENSV like N'%"+searchString+"%'";
            
            DataTable dataTable = dp.ExecuteQuery(query);
            dataGridView1.DataSource = dataTable;
            stt = dataTable.Rows.Count;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            stt++;
            Form2 themThongTin = new Form2(stt);
            themThongTin.Show();
            loadDataGridView();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            loadDataGridView();
        }

        private void thêmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stt++;
            Form2 themThongTin = new Form2(stt);
            themThongTin.Show();
            loadDataGridView();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
