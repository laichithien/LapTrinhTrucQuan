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
    public partial class Form2 : Form
    {
        public string MSSV;
        public string HoTen;
        public string Khoa;
        public double DiemTB;
        private int stt;
        public Form2(int stt)
        {
            InitializeComponent();
            this.stt = stt;
            comboBox1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            MSSV = textBox1.Text.Trim();
            HoTen = textBox2.Text.Trim();
            Khoa = comboBox1.Text.Trim();
            if (MSSV == "" || HoTen == "" || Khoa == "")
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin nha!!");
            }
            bool checkDiem = Double.TryParse(textBox3.Text, out DiemTB);
            if (!checkDiem)
            {
                MessageBox.Show("Điểm thì bạn phải nhập số chứ :((");
            }
            else if (DiemTB > 10 || DiemTB < 0)
            {
                MessageBox.Show("Điểm hơi ảo nha ba :)))");
            }
            else {
                string query = "insert into QLSV(STT, MSSV, TENSV, KHOA, DIEMTB) VALUES ";
                query += "('" + stt + "', '" + MSSV + "', N'" + HoTen + "', N'" + Khoa + "', " + DiemTB + ")";
                Data_Provider dp = new Data_Provider();
                dp.ExecuteNonQuery(query);
                this.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
