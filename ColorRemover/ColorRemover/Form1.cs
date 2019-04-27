using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorRemover
{
    public partial class Form1 : Form
    {
        string path = @"C:\Users\OZ\source\repos\ColorRemover\ColorRemover\images\a.jpg";
        public Form1()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            timer1.Start();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(path);
            ColorDialog cd = new ColorDialog();
            cd.AllowFullOpen = true;
            Bitmap bmp = new Bitmap(path);
           
            Color a;
            if(cd.ShowDialog() == DialogResult.OK)
            {
                Color b = cd.Color;
                
                for (int i = 0; i < bmp.Width; i++) 
                {
                    for(int j = 0; j < bmp.Height; j++)
                    {
                        a = bmp.GetPixel(i, j);
                        if (isLike(a,b))
                        {
                            bmp.SetPixel(i, j, Color.Empty);
                        }
                    }
                }
                pictureBox2.Image = bmp;
            }
        }
        int colorCoEfficient;

        public bool isLike(Color one, Color two)
        {
            int counter = 0;
            if(Math.Abs(one.A - two.A) <= colorCoEfficient)
            {
                counter++;
            }
            if (Math.Abs(one.R - two.R) <= colorCoEfficient)
            {
                counter++;
            }
            if (Math.Abs(one.G - two.G) <= colorCoEfficient)
            {
                counter++;
            }
            if (Math.Abs(one.B - two.B) <= colorCoEfficient)
            {
                counter++;
            }
            if (counter != 4)
            {
              
                return false;
            }
            else
            {
               
                return true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            colorCoEfficient = trackBar1.Value;
            label1.Text = trackBar1.Value.ToString();
        }
    }
}
