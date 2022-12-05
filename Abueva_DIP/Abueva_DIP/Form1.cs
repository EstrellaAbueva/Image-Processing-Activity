using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Abueva_DIP
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        Bitmap imageA, imageB, colorgreen;
        Color c;


        public Form1()
        {
            InitializeComponent();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded);
            pictureBox3.Image = processed;

            label1.Text = "Basic Copy";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNG Image|*.png";
            
            saveFileDialog1.ShowDialog();
            label1.Text = "Image Saved Successfully!";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
        }

        private void greyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    c = loaded.GetPixel(i, j);
                    int avg = (c.R + c.G + c.B) / 3;
                    processed.SetPixel(i, j, Color.FromArgb(avg, avg, avg));
                }
            }

            pictureBox3.Image = processed;
            label1.Text = "Grey Scale";
        }

        private void colorInversionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    c = loaded.GetPixel(i, j);
                    int r = 255 - c.R;
                    int g = 255 - c.G;
                    int b = 255 - c.B;
                    processed.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBox3.Image = processed;
            label1.Text = "Color Inversion";
        }

        private void mirrorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    c = loaded.GetPixel(i, j);
                    processed.SetPixel((loaded.Width - 1) - i, j, c);
                }
            }

            pictureBox3.Image = processed;
            label1.Text = "Horizontal Mirror";
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    c = loaded.GetPixel(i, j);
                    processed.SetPixel(i, (loaded.Height - 1) - j, c);
                }
            }

            pictureBox3.Image = processed;
            label1.Text = "Vertical Mirror";
        }

        private void histrogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);
            //process image to histogram
            int[] hist = new int[256];
            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    c = loaded.GetPixel(i, j);
                    int avg = (c.R + c.G + c.B) / 3;
                    hist[avg]++;
                }
            }

            //draw histogram
            int max = hist.Max();
            int scale = 100;
            int width = 256;
            int height = 100;
            Bitmap histImage = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (j < (hist[i] * scale / max))
                    {
                        histImage.SetPixel(i, j, Color.Black);
                    }
                    else
                    {
                        histImage.SetPixel(i, j, Color.White);
                    }
                }
            }
            
            Image img = histImage;
            img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            pictureBox3.Image = histImage;
            label1.Text = "Histogram";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded.Width, loaded.Height);

            for (int i = 0; i < loaded.Width; i++)
            {
                for (int j = 0; j < loaded.Height; j++)
                {
                    c = loaded.GetPixel(i, j);
                    int r = (int)(c.R * .393 + c.G * .769 + c.B * .189);
                    int g = (int)(c.R * .349 + c.G * .686 + c.B * .168);
                    int b = (int)(c.R * .272 + c.G * .534 + c.B * .131);
                    if (r > 255) r = 255;
                    if (g > 255) g = 255;
                    if (b > 255) b = 255;
                    processed.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            pictureBox3.Image = processed;
            label1.Text = "Sepia";
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (saveFileDialog1.FileName != "")
            {
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox3.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox3.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox3.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 4:
                        this.pictureBox3.Image.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                }
            }
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            imageB = new Bitmap(openFileDialog2.FileName);
            pictureBox1.Image = imageB;
        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {
            imageA = new Bitmap(openFileDialog3.FileName);
            pictureBox2.Image = imageA;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            label1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap resultImage = new Bitmap(imageA.Width, imageA.Height);

            Color mygreen = Color.FromArgb(59, 218, 67);
            int greygreen = (mygreen.R + mygreen.G + mygreen.B) / 3;
            int threshold = 5;

            for (int x = 0; x < imageB.Width; x++)
            {
                for (int y = 0; y < imageB.Height; y++)
                {
                    Color pixel = imageB.GetPixel(x, y);
                    Color backpixel = imageA.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractValue = Math.Abs(grey - greygreen);
                    if (subtractValue < threshold)
                    {
                        resultImage.SetPixel(x, y, backpixel);
                    }
                    else
                    {
                        resultImage.SetPixel(x, y, pixel);
                    }
                }
            }

            pictureBox3.Image = resultImage;
            label1.Text = "Subtract";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
