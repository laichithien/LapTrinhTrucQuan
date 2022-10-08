using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;

namespace CongNhanMaTranVuong
{
    internal class Program
    {
        static Form form;
        static int[] startingPoint = { 40, 40 };
        static ComboBox comboBox;
        static Button equalButton;
        public static decimal size = 0;
        static TextBox[,] matrixTextBox1;
        static TextBox[,] matrixTextBox2;
        static TextBox[,] matrixTextBox3;
        static int[,] plusMatrix(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrixresult = new int[matrix1.GetLength(0),matrix1.GetLength(0)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(0); j++)
                {
                    matrixresult[i,j] = matrix1[i,j] + matrix2[i, j];
                }
            }
            return matrixresult;
        }
        static int[,] minusMatrix(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrixresult = new int[matrix1.GetLength(0), matrix1.GetLength(0)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(0); j++)
                {
                    matrixresult[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return matrixresult;
        }
        static int[,] multiplyMatrix(int[,] matrix1, int[,] matrix2)
        {
            int[,] matrixresult = new int[matrix1.GetLength(0), matrix1.GetLength(0)];
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(0); j++)
                {
                    int sum = 0;
                    for (int k = 0; k < matrix1.GetLength(0); k++)
                    {
                        Console.WriteLine(matrix1[k, i] + "*" + matrix2[j, k]);
                        sum+=matrix1[k, i] * matrix2[j, k];
                    }
                    matrixresult[j, i] = sum;
                }
            }
            return matrixresult;
        }
        static int[,] getMatrix(TextBox[,] TextBoxMatrix)
        {
            int[,] matrix = new int[TextBoxMatrix.GetLength(0),TextBoxMatrix.GetLength(0)];
            for (int i = 0; i < TextBoxMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < TextBoxMatrix.GetLength(0); j++)
                {
                        matrix[i, j] = Convert.ToInt16((TextBoxMatrix[i, j].Text));
                }
            }
            return matrix;
        }
        static void showMatrixTextBox(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrixTextBox3[i, j].Text = Convert.ToString(matrix[i, j]);
                }
            }
        }
        static TextBox[,] generateMatrixText(int startx, int starty, int size)
        {
            TextBox[,] textBoxMatrix = new TextBox[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    textBoxMatrix[i, j] = new TextBox();
                    textBoxMatrix[i, j].Location = new Point(startx + 40*i, starty + 40*j);
                    textBoxMatrix[i, j].Size = new Size(40, 40);
                }
            }
            return textBoxMatrix;
        }
        static void setSize(decimal newsize)
        {
            //--------------------TextBoxMatrix---------------------------//
            for (int i = 0; i < matrixTextBox1.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTextBox1.GetLength(0); j++)
                {
                    form.Controls.Remove(matrixTextBox1[i, j]);
                }
            }
            for (int i = 0; i < matrixTextBox2.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTextBox2.GetLength(0); j++)
                {
                    form.Controls.Remove(matrixTextBox2[i, j]);
                }
            }
            for (int i = 0; i < matrixTextBox3.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTextBox3.GetLength(0); j++)
                {
                    form.Controls.Remove(matrixTextBox3[i, j]);
                }
            }
            //--------------------ComboBox---------------------------//
            form.Controls.Remove(comboBox);

            
            //--------------------EqualButton---------------------------//
            form.Controls.Remove(equalButton);

            size = newsize;

            comboBox = new ComboBox();
            comboBox.Location = new Point(startingPoint[0] + Convert.ToInt16(size) * 40 + 30, startingPoint[1] + 40 * (Convert.ToInt16(size) / 2));
            comboBox.Width = 50;
            comboBox.Items.Add(" + ");
            comboBox.Items.Add(" X ");
            comboBox.Items.Add(" - ");
            comboBox.SelectedIndex = 0;
            comboBox.Font = new Font("Time New Romans", 14);
            form.Controls.Add(comboBox);

            equalButton = new Button();
            equalButton.Text = "=";
            equalButton.Click += new EventHandler(equalButton_Click);
            equalButton.Width = 50;
            equalButton.Location = new Point(startingPoint[0] + Convert.ToInt16(size) * 40 + 100 + Convert.ToInt16(size) * 40 + 30, startingPoint[1] + 40 * (Convert.ToInt16(size) / 2));
            form.Controls.Add(equalButton);

            matrixTextBox1 = generateMatrixText(startingPoint[0], startingPoint[1], Convert.ToInt16(size));
            for (int i = 0; i < matrixTextBox1.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTextBox1.GetLength(0); j++)
                {
                    form.Controls.Add(matrixTextBox1[i, j]);
                }
            }
            matrixTextBox2 = generateMatrixText(startingPoint[0] + Convert.ToInt16(size) * 40 + 100, startingPoint[1], Convert.ToInt16(size));
            for (int i = 0; i < matrixTextBox2.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTextBox2.GetLength(0); j++)
                {
                    form.Controls.Add(matrixTextBox2[i, j]);
                }
            }
            matrixTextBox3 = generateMatrixText(startingPoint[0] + Convert.ToInt16(size) * 40 + 200 + Convert.ToInt16(size) * 40, startingPoint[1], Convert.ToInt16(size));
            for (int i = 0; i < matrixTextBox3.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTextBox3.GetLength(0); j++)
                {
                    form.Controls.Add(matrixTextBox3[i, j]);
                }
            }

        }
        static void checkSize()
        {
            MessageBox.Show(Convert.ToString(size));
        }
        static void Main(string[] args)
        {
            form = new Form();
            
            form.Size = new Size(1910, 1070);

            NumericUpDown numericUpDown = new NumericUpDown();
            numericUpDown.Location = new Point(10, 10);
            numericUpDown.ValueChanged += new EventHandler(numericUpDown_ValueChanged);
            form.Controls.Add(numericUpDown);

            matrixTextBox1 = generateMatrixText(startingPoint[0], startingPoint[1], Convert.ToInt16(size));
            for (int i = 0; i < matrixTextBox1.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTextBox1.GetLength(0); j++)
                {
                    form.Controls.Add(matrixTextBox1[i, j]);
                }
            }

            comboBox = new ComboBox();
            comboBox.Location = new Point(startingPoint[0] + Convert.ToInt16(size) * 40 + 30, startingPoint[1] + 40 * (Convert.ToInt16(size)/2));
            comboBox.Width = 50;
            comboBox.Items.Add(" + ");
            comboBox.Items.Add(" X ");
            comboBox.Items.Add(" - ");
            comboBox.SelectedIndex = 0;
            comboBox.Font = new Font("Time New Romans",14);
            comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
            form.Controls.Add(comboBox);

            matrixTextBox2 = generateMatrixText(startingPoint[0] + Convert.ToInt16(size) * 40 + 100, startingPoint[1], Convert.ToInt16(size));
            for (int i = 0; i < matrixTextBox2.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTextBox2.GetLength(0); j++)
                {
                    form.Controls.Add(matrixTextBox2[i, j]);
                }
            }

            equalButton = new Button();
            equalButton.Text = "=";
            equalButton.Click += new EventHandler(equalButton_Click);
            equalButton.Width = 50;
            equalButton.Location = new Point(startingPoint[0] + Convert.ToInt16(size) * 40 + 100 + Convert.ToInt16(size) * 40 + 30, startingPoint[1] + 40 * (Convert.ToInt16(size) / 2));
            form.Controls.Add(equalButton);

            matrixTextBox3 = generateMatrixText(startingPoint[0] + Convert.ToInt16(size) * 40 + 200 + Convert.ToInt16(size) * 40, startingPoint[1], Convert.ToInt16(size));
            for (int i = 0; i < matrixTextBox3.GetLength(0); i++)
            {
                for (int j = 0; j < matrixTextBox3.GetLength(0); j++)
                {
                    form.Controls.Add(matrixTextBox3[i, j]);
                }
            }

            Application.Run(form);
        }
        static void equalButton_Click(Object sender, EventArgs e)
        {
            int[,] matrix1;
            int[,] matrix2;
            try
            {
                matrix1 = getMatrix(matrixTextBox1);
                matrix2 = getMatrix(matrixTextBox2);
                int[,] matrixanswer = matrix1;
                switch (comboBox.SelectedIndex)
                {
                    case 0:
                        matrixanswer = plusMatrix(matrix1, matrix2);
                        break;
                    case 1:
                        matrixanswer = multiplyMatrix(matrix1, matrix2);
                        break;
                    case 2:
                        matrixanswer = minusMatrix(matrix1, matrix2);
                        break;
                    default:
                        break;
                }
                showMatrixTextBox(matrixanswer);
            }
            catch
            {
                MessageBox.Show("Bạn chưa nhập đủ dữ liệu cần thiết !!!!");
            }
        }
        static void numericUpDown_ValueChanged(Object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            decimal value = numericUpDown.Value;
            setSize(value);
        }
        static void comboBox_SelectedIndexChanged(Object sender, EventArgs e)
        {

        }
    }
}
