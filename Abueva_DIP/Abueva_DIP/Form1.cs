using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abueva_DIP
{
    public partial class Form1 : Form
    {
        Bitmap loaded, processed;
        Color c;


        public Form1()
        {
            InitializeComponent();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            processed = new Bitmap(loaded);
            pictureBox2.Image = processed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
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

            pictureBox2.Image = processed;
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

            pictureBox2.Image = processed;
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

            pictureBox2.Image = processed;
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

            pictureBox2.Image = processed;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
    }
}
