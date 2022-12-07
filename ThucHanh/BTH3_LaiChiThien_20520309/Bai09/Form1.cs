using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Bai09
{
    public partial class Form1 : Form
    {
        static DataTable dt;
        static string path = "data.csv";
        public Form1()
        {
            InitializeComponent();
            loadDataToForm();
            checkBox1.Checked = true;
        }
        private void loadDataToForm()
        {
            dt = new DataTable();
            using (StreamReader sr = new StreamReader(path))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                dt.Columns[1].DataType = typeof(string);
                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            dataGridView1.DataSource = dt;
        }
        private void saveDataToCSV()
        {
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }
            System.IO.File.WriteAllText(path, sb.ToString(), System.Text.Encoding.UTF8);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = richTextBox1.Text;
            richTextBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox2.Text;
            richTextBox2.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string MSSV = textBox1.Text == "" ? "Empty" : textBox1.Text;
            string HoTen = textBox2.Text == "" ? "Empty" : textBox2.Text;
            string ChuyenNganh = textBox3.Text == "" ? "Empty" : textBox3.Text;
            string GioiTinh = checkBox1.Checked == true ? "Nam" : "Nữ";
            string SoMon = richTextBox2.Lines.Count().ToString();
            dt.Rows.Add(MSSV,HoTen,ChuyenNganh, GioiTinh, SoMon);
            saveDataToCSV();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox2.Checked = false;
            }
            else checkBox1.Checked = true;
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = false;
            }
            else checkBox2.Checked = true;
        }
    }
}
