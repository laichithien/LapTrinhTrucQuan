using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thi
{
    
    internal class Program
    {
        static PictureBox pb1;
        static PictureBox pb2;
        static int brightness = 0;
        static string satur = "0";
        static Bitmap sourceImage;
        public static void trackBarBr_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            brightness = Convert.ToInt16(tb.Value);
            pb2.Image = brightnessAdjust(pb1.Image, brightness);
        }
        public static void trackBarSa_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            satur = tb.Value.ToString();
        }
        public static Bitmap brightnessAdjust(Image img, int br)
        {
            br = 100 - br;
            Bitmap currBitmap = new Bitmap(img);          
            for (int i = 0; i < currBitmap.Width; i++)
            {
                for (int j = 0; j < currBitmap.Height; j++)
                {
                    Color curColor = currBitmap.GetPixel(i, j);
                    int r = curColor.R - Convert.ToInt16(curColor.R * (br / (float)100));
                    int g = curColor.G - Convert.ToInt16(curColor.G * (br / (float)100));
                    int b = curColor.B - Convert.ToInt16(curColor.B * (br / (float)100));
                    currBitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                    //currBitmap.SetPixel(i, j, Color.FromArgb(0,0,0));
                }
            }
            return currBitmap;
        }
        static void loadButton_Clicked(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    sourceImage = new Bitmap(dlg.FileName);
                }
            }
            pb1.Image = sourceImage;
        }
        static void resetButton_Clicked(object sender, EventArgs e)
        {
            pb2.Image = pb1.Image;
        }
        static void saveButton_Clicked(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                Bitmap myBitmap = new Bitmap(pb2.Image);
                dlg.FileName = "output.jpg";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    myBitmap.Save(dlg.FileName);
                }
            }
            
        }
        [STAThread]
        static void Main(string[] args)
        {
            Form f1 = new Form();

            pb1 = new PictureBox();
            pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb1.Size = new Size(512, 512);

            pb2 = new PictureBox();
            pb2.SizeMode = PictureBoxSizeMode.StretchImage;
            pb2.Size = new Size(512, 512);
            pb2.Location = new Point(600, 0);


            //Image img = Image.FromFile(sourceImage);
            //Bitmap bmp = new Bitmap(sourceImage);
            pb1.Image = sourceImage;
            //pb1.Image = img;

            //pb2.Image = brightnessAdjust(img, brightness);
            f1.Controls.Add(pb1);
            f1.Controls.Add(pb2);

            TrackBar trackBarBr = new TrackBar();
            trackBarBr.SetRange(0, 100);
            trackBarBr.TickFrequency = 10;
            trackBarBr.Scroll += new EventHandler(trackBarBr_Scroll);
            trackBarBr.Width = 512;
            trackBarBr.Location = new Point(300, 600);

            Label lbBr = new Label();
            lbBr.Text = "Brightness";
            lbBr.Location = new Point(230, 600);

            Label lbSa = new Label();
            lbSa.Text = "Saturation";
            lbSa.Location = new Point(230, 550);

            TrackBar trackBarSa = new TrackBar();
            trackBarSa.SetRange(0, 100);
            trackBarSa.TickFrequency = 10;
            trackBarSa.Scroll += new EventHandler(trackBarSa_Scroll);
            trackBarSa.Width = 512;
            trackBarSa.Location = new Point(300, 550);

            Label lb1 = new Label();
            Label lb2 = new Label();
            
            lb2.Location = new Point(100,100);

            Button loadButton = new Button();
            loadButton.Location = new Point(600, 700);
            loadButton.Text = "Load";
            loadButton.Click += new EventHandler(loadButton_Clicked);

            Button resetButton = new Button();
            resetButton.Location = new Point(400, 700);
            resetButton.Text = "Reset";
            resetButton.Click += new EventHandler(resetButton_Clicked);

            Button saveButton = new Button();
            saveButton.Location = new Point(800, 700);
            saveButton.Text = "Save";
            saveButton.Click += new EventHandler(saveButton_Clicked);

            f1.Controls.Add(lb1);
            f1.Controls.Add(lb2);

            f1.Size = new Size(1200, 800);
            f1.StartPosition = FormStartPosition.CenterScreen;

            f1.Controls.Add(trackBarBr);
            f1.Controls.Add(trackBarSa);
            f1.Controls.Add(loadButton);
            f1.Controls.Add(resetButton);
            f1.Controls.Add(saveButton);
            f1.Controls.Add(lbBr);
            f1.Controls.Add(lbSa);
            Application.Run(f1);
        }
    }
}
