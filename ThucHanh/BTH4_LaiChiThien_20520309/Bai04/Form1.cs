using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai04
{
    public partial class Form1 : Form
    {
        public string fontName = "";
        public float fontSize = 8;
        public FontStyle fontStyleBold = FontStyle.Regular;
        public FontStyle fontStyleItalic = FontStyle.Regular;
        public FontStyle fontStyleUnderline = FontStyle.Regular;
        public FontStyle fontStyle = FontStyle.Regular;
        public bool isBold = false;
        public bool isItalic = false;
        public bool isUnderline = false;
        public string filePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
            load();
        }
        private void loadFont()
        {
            richTextBox1.SelectionFont = new Font(fontName, fontSize, fontStyleBold | fontStyleItalic | fontStyleUnderline);
        }
        private void loadFontandSize()
        {
            fontName = toolStripComboBox1.Text;
            bool tryparse = float.TryParse(toolStripComboBox2.Text, out fontSize);
        }
        private void load()
        {
            loadFontComboBox();
            loadSizeComboBox();
            loadFontandSize();
        }
        private void loadSizeComboBox()
        {
            int[] sizes = new int[] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
            {
                toolStripComboBox2.Items.Add(Convert.ToString(size));
            }
            toolStripComboBox2.SelectedIndex = 0;
        }
        private void loadFontComboBox()
        {
            int counter = 0;
            foreach (System.Drawing.FontFamily font in System.Drawing.FontFamily.Families)
            {
                toolStripComboBox1.Items.Add(font.Name);
                if (font.Name == "Tahoma")
                {
                    toolStripComboBox1.SelectedIndex = counter;
                }
                counter++;
            }
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                fontName = fontDialog.Font.Name;
                fontSize = fontDialog.Font.Size;
                fontStyle = fontDialog.Font.Style;
                richTextBox1.SelectionFont = new Font(fontName, fontSize, fontStyle);
            }
            load();
        }
        private void reloadBIU()
        {
            toolStripButton3.BackColor = isBold ? Color.SteelBlue : Color.White;
            toolStripButton4.BackColor = isItalic ? Color.SteelBlue : Color.White;
            toolStripButton5.BackColor = isUnderline ? Color.SteelBlue : Color.White;
        }

        private void tạoVănBảnMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            filePath = String.Empty;
            load();
        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            fontName = toolStripComboBox1.Text;
            loadFont();
        }

        private void toolStripComboBox2_TextChanged(object sender, EventArgs e)
        {
            bool tryparse = float.TryParse(toolStripComboBox2.Text, out fontSize);
            loadFont();
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fontName = toolStripComboBox1.Text;
            loadFont();
        }
        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool tryparse = float.TryParse(toolStripComboBox2.Text, out fontSize);
            loadFont();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            isBold = isBold ? false : true;
            fontStyleBold = isBold ? FontStyle.Bold : FontStyle.Regular;
            reloadBIU();
            loadFont();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            isItalic = isItalic ? false : true;
            fontStyleItalic = isItalic ? FontStyle.Italic : FontStyle.Regular;
            reloadBIU();
            loadFont();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            isUnderline = isUnderline ? false : true;
            fontStyleUnderline = isUnderline ? FontStyle.Underline : FontStyle.Regular;
            reloadBIU();
            loadFont();
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "RichTextFile (*rtf)|*.rtf|Text file (*.txt)|*.txt";
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                if (Path.GetExtension(openFileDialog.FileName) == ".txt")
                {
                    try
                    {
                        richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Error File Opening!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (Path.GetExtension(openFileDialog.FileName) == ".rtf")
                {
                    try
                    {
                        richTextBox1.LoadFile(openFileDialog.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Error File In Opening!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void lưuNộiDungVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter = "rtf Files (*.rtf*)|*.rtf*";

            if (File.Exists(saveFileDialog.FileName))
            {
                if (Path.GetExtension(saveFileDialog.FileName) == ".txt")
                {
                    try
                    {
                        File.WriteAllLines(saveFileDialog.FileName, richTextBox1.Lines);
                        MessageBox.Show("File save successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error File In Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (Path.GetExtension(saveFileDialog.FileName) == ".rtf")
                {
                    try
                    {
                        richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        MessageBox.Show("File saved successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error File in Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName + ".rtf", RichTextBoxStreamType.RichText);
                    MessageBox.Show("File saved successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error File Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            filePath = string.Empty;
            load();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.Filter = "RichTextFile (*.rtf*)|*.rtf*|Text file (*.txt*)|*.txt*";
            if (filePath != string.Empty)
            {
                if (Path.GetExtension(filePath) == ".txt")
                {
                    try
                    {
                        File.WriteAllLines(filePath, richTextBox1.Lines);
                        MessageBox.Show("Saved!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error File In Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (Path.GetExtension(filePath) == ".rtf")
                {
                    try
                    {
                        richTextBox1.SaveFile(filePath, RichTextBoxStreamType.RichText);
                        MessageBox.Show("File saved successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error File in Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (File.Exists(saveFileDialog.FileName))
            {
                filePath = saveFileDialog.FileName;
                if (Path.GetExtension(saveFileDialog.FileName) == ".txt")
                {
                    try
                    {
                        File.WriteAllLines(saveFileDialog.FileName, richTextBox1.Lines);
                        MessageBox.Show("File save successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error File In Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (Path.GetExtension(saveFileDialog.FileName) == ".rtf")
                {
                    try
                    {
                        richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        MessageBox.Show("File saved successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error File in Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                try
                {
                    richTextBox1.SaveFile(saveFileDialog.FileName + ".rtf", RichTextBoxStreamType.RichText);
                    MessageBox.Show("File saved successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error File Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
