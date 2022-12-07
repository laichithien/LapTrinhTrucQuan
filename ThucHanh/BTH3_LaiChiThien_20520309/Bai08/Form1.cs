using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai08
{
    public partial class Form1 : Form
    {
        static DataTable dt;
        static string path = "data.csv";
        public Form1()
        {
            InitializeComponent();
            loadDataToForm();
            textBox5.Text = dt.Compute("Sum(Tiền)", string.Empty).ToString();
            saveDataToCSV();
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
                dt.Columns[4].DataType = typeof(int);
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
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeColumns = false;
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
            string SoTaiKhoan = textBox1.Text == "" ? "Unknown": textBox1.Text;
            string TenKhachHang = textBox2.Text == "" ? "Unknown":textBox2.Text;
            string DiaChiKhachHang = textBox3.Text == "" ? "Unknown" : textBox3.Text;
            int SoTien = textBox4.Text == "" ? 0 :Convert.ToInt32(textBox4.Text);
            string STT = (dt.Rows.Count+1).ToString("D3");
            dt.Rows.Add(STT,SoTaiKhoan, TenKhachHang, DiaChiKhachHang, SoTien);
            textBox5.Text = dt.Compute("Sum(Tiền)", string.Empty).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int STT = dataGridView1.CurrentCell.RowIndex;
            dt.Rows.RemoveAt(STT);
        }
    }
}
