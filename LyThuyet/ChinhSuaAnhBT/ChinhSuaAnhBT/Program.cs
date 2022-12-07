using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace ChinhSuaAnhBT
{
    internal class Program
    {
        static PictureBox before;
        static PictureBox after;
        static Bitmap beforeImage;
        static Bitmap afterImage;
        static Button loadButton;
        static Button saveButton;
        static Button resetButton;
        const float rwgt = 0.3086f;
        const float gwgt = 0.6094f;
        const float bwgt = 0.0820f;
        [STAThread]
        static void Main(string[] args)
        {
            Form f1 = new Form();
            f1.Size = new Size(1090, 800);
            f1.StartPosition = FormStartPosition.CenterScreen;

            before = new PictureBox();
            after = new PictureBox();

            before.SizeMode = PictureBoxSizeMode.StretchImage;
            after.SizeMode = PictureBoxSizeMode.StretchImage;

            before.Size = new Size(512, 512);
            after.Size = new Size(512, 512);

            after.Location = new Point(0,0);
            before.Location = new Point(520, 0);

            before.BackColor = Color.Red;
            after.BackColor = Color.Blue;

            loadButton = new Button();
            loadButton.Text = "Load";
            loadButton.AutoSize = true;
            loadButton.Location = new Point(800, 600);
            loadButton.Click += new EventHandler(loadButton_Click);

            saveButton = new Button();
            saveButton.Text = "Save";
            saveButton.AutoSize = true;
            saveButton.Location = new Point(800, 650);

            resetButton = new Button();
            resetButton.Text = "Reset";
            resetButton.AutoSize = true;
            resetButton.Location = new Point(900, 600);

            TrackBar brightness = new TrackBar();
            TrackBar saturation = new TrackBar();

            brightness.Location = new Point(0,600);
            brightness.SetRange(-100, 100);
            brightness.Width = 700;
            brightness.Scroll += new EventHandler(brightness_Scroll);

            saturation.Location = new Point(0,650);
            saturation.SetRange(-100, 100);
            saturation.Width = 700;
            saturation.Scroll += new EventHandler(saturation_Scroll);

            f1.Controls.Add(before);
            f1.Controls.Add(after);
            f1.Controls.Add(loadButton);
            f1.Controls.Add(saveButton);
            f1.Controls.Add(resetButton);
            f1.Controls.Add(brightness);
            f1.Controls.Add(saturation);

            Application.Run(f1);
        }
        private static void brightness_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            int brightness = Convert.ToInt16(tb.Value);
            after.Image = brightnessAdjust(before.Image, brightness);
        }
        private static void loadButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open image";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    beforeImage = new Bitmap(dlg.FileName);
                }
            }
            before.Image = beforeImage;
        }
        public static Bitmap brightnessAdjust(Image img, int br)
        {
            Bitmap currBitmap = new Bitmap(img);
            for (int i = 0; i < currBitmap.Width; i++)
            {
                for (int j = 0; j < currBitmap.Height; j++)
                {
                    Color curColor = currBitmap.GetPixel(i, j);
                    int r = curColor.R + Convert.ToInt16(curColor.R * (br / (float)100));
                    r = (r > 255) ? 255 : ((r < 0) ? 0 : r);
                    int g = curColor.G + Convert.ToInt16(curColor.G * (br / (float)100));
                    g = (g > 255) ? 255 : ((g < 0) ? 0 : g);
                    int b = curColor.B + Convert.ToInt16(curColor.B * (br / (float)100));
                    b = (b > 255) ? 255 : ((b < 0) ? 0 : b);
                    currBitmap.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return currBitmap;
        }
        private static void saturation_Scroll(object sender, EventArgs e)
        {
            TrackBar tb = (TrackBar)sender;
            int saturation = Convert.ToInt16(tb.Value);
            after.Image = saturationAdjust(before.Image, saturation);
        }
        public static Bitmap saturationAdjust(Image img, int sa)
        {
            ColorMatrix colorMatrix = new ColorMatrix();
            float s = 1f + (float)sa/200;
            float baseSat = 1.0f - sa;

            colorMatrix[0, 0] = baseSat * rwgt + sa;
            colorMatrix[0, 1] = baseSat * rwgt;
            colorMatrix[0, 2] = baseSat * rwgt;
            colorMatrix[1, 0] = baseSat * gwgt;
            colorMatrix[1, 1] = baseSat * gwgt + sa;
            colorMatrix[1, 2] = baseSat * gwgt;
            colorMatrix[2, 0] = baseSat * bwgt;
            colorMatrix[2, 1] = baseSat * bwgt;
            colorMatrix[2, 2] = baseSat * bwgt + sa;


            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            Point[] points =
            {
                new Point(0, 0),
                new Point(img.Width, 0),
                new Point(0, img.Height),
            };
            Rectangle rect = new Rectangle(0, 0, img.Width, img.Height);

            Bitmap bm = new Bitmap(img.Width, img.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(img, points, rect, GraphicsUnit.Pixel, attributes);
            }

            return bm;
        }

    }
}
