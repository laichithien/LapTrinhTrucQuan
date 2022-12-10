using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace BaiThiKiNangLan2
{
    internal class MyData
    {
        public string Key { get; set; }
        public string Parent { get; set; }
        public string Text { get; set; }
        public string Price { get; set; }

    }

    internal class Program
    {
        static Form mainForm = new Form();
        static TreeView treeView = new TreeView();
        static Button loadButton = new Button();
        static TextBox txtKey;
        static TextBox txtName;
        static TextBox txtPrice;
        [STAThread]
        static void Main(string[] args)
        {

            mainForm.Size = new Size(600, 600);

            treeView.Size = new Size(500, 400);
            treeView.AfterSelect += new TreeViewEventHandler(TreeViewClicked);

            loadButton.Location = new Point(10, 410);
            loadButton.Text = "Load";
            loadButton.Click += new EventHandler(LoadButtonClicked);

            txtKey = new TextBox();
            txtKey.Location = new Point(510, 10);
            txtName = new TextBox();
            txtName.Location = new Point(510, 30);
            txtPrice = new TextBox();
            txtPrice.Location = new Point(510, 50);

            mainForm.Controls.Add(treeView);
            mainForm.Controls.Add(loadButton);
            mainForm.Controls.Add(txtKey);
            mainForm.Controls.Add(txtPrice);
            mainForm.Controls.Add(txtName);

            Application.Run(mainForm);
        }
        static void TreeViewClicked(object sender, TreeViewEventArgs e)
        {
            MyData d = (MyData)e.Node.Tag;
            txtKey.Text = d.Key;
            txtName.Text = d.Text;
            txtPrice.Text = d.Price;
        }
        static private void LoadButtonClicked(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadDBToTreeView(openFileDialog.FileName, treeView);
            }
        }
        static private void LoadDBToTreeView(string fileName, TreeView tv)
        {
            foreach (string line in File.ReadLines(fileName))
            {
                //Console.WriteLine(">>" + line);
                string[] parts = line.Split('|');
                MyData d = new MyData();
                d.Key = parts[0];
                d.Parent = parts[1];
                d.Text = parts[2];
                if (parts.Length > 3)
                {
                    d.Price = parts[3];
                }
                //Console.WriteLine(d.Key + "|" + d.Parent + "|" + d.Text + "|" + d.Price + "\n");
                if (d.Parent == "0")
                {
                    TreeNode treeNode = tv.Nodes.Add(d.Key, d.Text);
                    treeNode.Tag = d;
                }
                else
                {
                    TreeNode[] parent = tv.Nodes.Find(d.Parent, true);
                    foreach (TreeNode node in parent)
                    {
                        TreeNode n = node.Nodes.Add(d.Key, d.Text);
                        n.Tag = d;
                    }
                }
            }
        }
    }
}
