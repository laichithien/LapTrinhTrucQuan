using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace OnThi
{
    internal class Program
    {
        static Form f1 = new Form();
        static TextBox tb = new TextBox();

        static TreeView tv = new TreeView();
        static void Main(string[] args)
        {
            f1.Size = new Size(1024, 512);
            f1.BackColor = Color.Coral;

            tv.Size = new Size(500, 400);
            tv.Location = new Point(32, 16);

            tb.Text = "";
            tb.Location = new Point(560, 16);

            Button btnThemNodeGoc = new Button();
            btnThemNodeGoc.Text = "Thêm node gốc";
            btnThemNodeGoc.Location = new Point(560, 48);
            btnThemNodeGoc.BackColor = Color.White;
            btnThemNodeGoc.Click += new EventHandler(btnThemNodeGoc_Click);

            Button btnThemNodeCon = new Button();
            btnThemNodeCon.Text = "Thêm node con";
            btnThemNodeCon.Location = new Point(560, 80);
            btnThemNodeCon.BackColor = Color.White;
            btnThemNodeCon.Click += new EventHandler(btnThemNodeCon_Click);


            f1.Controls.Add(tv);
            f1.Controls.Add(tb);
            f1.Controls.Add(btnThemNodeGoc);
            f1.Controls.Add(btnThemNodeCon);
            Application.Run(f1);
        }
        static void btnThemNodeCon_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb.Text))
            {
                if (tv.SelectedNode != null)
                {
                    TreeNode subnode = new TreeNode();
                    subnode.Text = tb.Text;
                    tv.SelectedNode.Nodes.Add(subnode);
                    tb.Clear();
                    tb.Focus();
                }
                else MessageBox.Show("Chọn vị trí tạo node con");
            }
            else MessageBox.Show("Node không được để trống");
        }
        static void btnThemNodeGoc_Click(object sender, EventArgs e)
        {
            bool t = false;
            if (!string.IsNullOrEmpty(tb.Text))
            {
                TreeNode Node = new TreeNode();
                Node.Text = tb.Text;
                foreach (TreeNode nodex in tv.Nodes)
                {
                    if (string.Equals(Node.Text, nodex.Text))
                    {
                        MessageBox.Show("Node đã tồn tại!");
                        t = true;
                    }
                }
                if (t == false) tv.Nodes.Add(Node);
                tb.Clear();
                tb.Focus();
            }
            else MessageBox.Show("Node không được để trống");
        }
    }
}
