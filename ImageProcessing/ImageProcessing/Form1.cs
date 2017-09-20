using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = Application.StartupPath+"\\img\\";
            if (open.ShowDialog() == DialogResult.OK)
                pictureBox1.ImageLocation = open.FileName;
        }

        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter= "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif|Png Image|*.png";
            save.Title = "Save Image";
            if(save.ShowDialog()==System.Windows.Forms.DialogResult.OK && save.FileName!= "")
                switch(save.FilterIndex)
                {
                    case 1:
                        pictureBox2.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        pictureBox2.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        pictureBox2.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case 4:
                        pictureBox2.Image.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;

                }
        }

        private void copyImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;

        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(pictureBox1.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)     
                {
                    int R = image1.GetPixel(i, j).R;
                    int G = image1.GetPixel(i, j).G;
                    int B = image1.GetPixel(i, j).B;
                    double Gray = 0;
                    if (R == G && G == B)
                        Gray = R;
                    else
                        Gray = R * 0.299 + G * 0.587 + B * 0.114;
                    /*灰階化公式為
                     * double Gray = R * 0.299 + G * 0.587 + B * 0.114;
                     * 也可以簡化為
                     * double Gray = R * 0.3 + G * 0.59 + B * 0.11;*/
                    image2.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray)); 
                }
            pictureBox2.Image = image2;
        }

        private void filterGreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(pictureBox1.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = image1.GetPixel(i, j).R;
                    int B = image1.GetPixel(i, j).B;

                    image2.SetPixel(i, j, Color.FromArgb(R, 0, B));

                    //綠色濾鏡為將綠色元素歸0
                }
            pictureBox2.Image = image2;
        }

        private void filterRedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(pictureBox1.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {

                    int G = image1.GetPixel(i, j).G;
                    int B = image1.GetPixel(i, j).B;

                    image2.SetPixel(i, j, Color.FromArgb(0, G, B));

                    //紅色濾鏡為將紅色元素歸0
                }
            pictureBox2.Image = image2;
        }


        private void filterBlueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(pictureBox1.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = image1.GetPixel(i, j).R;
                    int G = image1.GetPixel(i, j).G;

                    image2.SetPixel(i, j, Color.FromArgb(R, G, 0));

                    //藍色濾鏡為將藍色元素歸0
                }
            pictureBox2.Image = image2;
        }

        private void negativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(pictureBox1.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = image1.GetPixel(i, j).R;
                    int G = image1.GetPixel(i, j).G;
                    int B = image1.GetPixel(i, j).B;
                    R = 255 - R;
                    G = 255 - G;
                    B = 255 - B;

                    image2.SetPixel(i, j, Color.FromArgb(R, G, B));

                    //藍色濾鏡為將藍色元素歸0
                }
            pictureBox2.Image = image2;
        }

        private void binarizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(pictureBox1.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = image1.GetPixel(i, j).R;
                    int G = image1.GetPixel(i, j).G;
                    int B = image1.GetPixel(i, j).B;
                    double Gray = 0;
                    if (R == G && G == B)
                        Gray = R;
                    else
                        Gray = R * 0.299 + G * 0.587 + B * 0.114;
                    if (Gray > 127)
                        Gray = 255;
                    else
                        Gray = 0;

                    image2.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                }
            pictureBox2.Image = image2;
        }

        private void averageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayToolStripMenuItem.PerformClick();
            Bitmap image1 = new Bitmap(pictureBox2.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            int[,] newImage = new int[w, h];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)     
                {
                    int R = image1.GetPixel(i, j).R;
                    newImage[i, j] = (int)R;
                }
            for (int k = 1; k < w - 1; k++)
                for (int p = 1; p < h - 1; p++)
                {
                    int avg = newImage[k - 1, p - 1] + newImage[k - 1, p] + newImage[k - 1, p + 1] + newImage[k, p - 1] + newImage[k, p] + newImage[k, p + 1] + newImage[k + 1, p - 1] + newImage[k + 1, p] + newImage[k + 1, p + 1];       //9*9
                    avg = avg / 9;    
                    image2.SetPixel(k, p, Color.FromArgb(avg, avg, avg));  
                }
            pictureBox3.Image = image2;
        }

        private void laplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayToolStripMenuItem.PerformClick();
            Bitmap image1 = new Bitmap(pictureBox2.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            int[,] newImage = new int[w, h];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = image1.GetPixel(i, j).R;
                    newImage[i, j] = (int)R;
                }
            for (int k = 1; k < w - 1; k++)
                for (int p = 1; p < h - 1; p++)
                {
                    int avg = 9*newImage[k, p]-(newImage[k - 1, p - 1] + newImage[k - 1, p] + newImage[k - 1, p + 1] + newImage[k, p - 1] + newImage[k, p + 1] + newImage[k + 1, p - 1] + newImage[k + 1, p] + newImage[k + 1, p + 1]);
                    if (avg > 255)      //避免值大於255或小於0
                        avg = 255;
                    if (avg < 0)
                        avg = 0;
                    image2.SetPixel(k, p, Color.FromArgb(avg, avg, avg)); 
                }
            pictureBox3.Image = image2;
        }

        private void medianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayToolStripMenuItem.PerformClick();
            Bitmap image1 = new Bitmap(pictureBox2.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            int[,] newImage = new int[w, h];
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = image1.GetPixel(i, j).R;
                    newImage[i, j] = (int)R;
                }
            for (int k = 1; k < w - 1; k++)
                for (int p = 1; p < h - 1; p++)
                {
                    int[] list = new int[9] { newImage[k - 1, p - 1], newImage[k - 1, p], newImage[k - 1, p + 1], newImage[k, p - 1], newImage[k, p], newImage[k, p + 1], newImage[k + 1, p - 1], newImage[k + 1, p], newImage[k + 1, p + 1] };
                    for(int i = 0;i < 9;i++ )
                        for(int j = 0; j < 8; j++)
                            if(list[j]>list[j+1])
                            {
                                int tmp = list[j];
                                list[j] = list[j + 1];
                                list[j + 1] = tmp;
                            }
                    image2.SetPixel(k, p, Color.FromArgb(list[5], list[5], list[5]));
                }
            pictureBox3.Image = image2;
        }

        private void gaussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayToolStripMenuItem.PerformClick();
            Bitmap image1 = new Bitmap(pictureBox2.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            int[,] newImage = new int[w, h];
            int cen = Convert.ToInt16(textBox1.Text);

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int R = image1.GetPixel(i, j).R;
                    newImage[i, j] = (int)R;
                }
            for (int k = 1; k < w - 1; k++)
                for (int p = 1; p < h - 1; p++)
                {
                    int avg = (cen+8) * newImage[k, p] - (newImage[k - 1, p - 1] + newImage[k - 1, p] + newImage[k - 1, p + 1] + newImage[k, p - 1] + newImage[k, p + 1] + newImage[k + 1, p - 1] + newImage[k + 1, p] + newImage[k + 1, p + 1]);
                    if (avg > 255)      //避免值大於255或小於0
                        avg = 255;
                    if (avg < 0)
                        avg = 0;
                    image2.SetPixel(k, p, Color.FromArgb(avg, avg, avg));
                }
            pictureBox3.Image = image2;
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double cen = Convert.ToDouble(textBox2.Text);
            double bas = Convert.ToDouble(textBox3.Text);

            grayToolStripMenuItem.PerformClick();
            Bitmap image1 = new Bitmap(pictureBox2.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    double Gray = image1.GetPixel(i, j).R;
                    Gray = cen * (int)Math.Log(1 + Gray, bas);
                    if (Gray > 255)      //避免值大於255或小於0
                        Gray = 255;
                    if (Gray < 0)
                        Gray = 0;
                    image2.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                }
            pictureBox3.Image = image2;
        }

        private void powerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double cen = Convert.ToDouble(textBox4.Text);
            double gama = Convert.ToDouble(textBox3.Text);

            grayToolStripMenuItem.PerformClick();
            Bitmap image1 = new Bitmap(pictureBox2.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    double Gray = image1.GetPixel(i, j).R;
                    Gray = cen * (int)Math.Pow(Gray, gama);
                    if (Gray > 255)      //避免值大於255或小於0
                        Gray = 255;
                    if (Gray < 0)
                        Gray = 0;
                    image2.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                }
            pictureBox3.Image = image2;
        }

        private void equlizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grayToolStripMenuItem.PerformClick();
            Bitmap image1 = new Bitmap(pictureBox2.Image);
            int w = image1.Width;
            int h = image1.Height;
            Bitmap image2 = new Bitmap(w, h);
            int[,] newImage = new int[w, h];
            int[] histogram = new int[256];
            int sum = 0;
            int[] sum_hist = new int[256];
            int area = w * h;
            double constant = (double)255 / (double)area;

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    int Gray = image1.GetPixel(i, j).R;
                    histogram[Gray]++;
                }

            for(int i = 0; i <256; i++)
            {
                sum = sum + histogram[i];
                sum_hist[i] = sum;
            }

            for (int i = 0; i < w; i++)
                for (int j = 0; j < h; j++)
                {
                    double Gray = image1.GetPixel(i, j).R;
                    Gray = constant * sum_hist[(int)Gray];
                    image2.SetPixel(i, j, Color.FromArgb((int)Gray, (int)Gray, (int)Gray));
                }


            pictureBox3.Image = image2;
        }
    }
}
