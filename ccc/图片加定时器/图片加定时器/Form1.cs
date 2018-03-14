using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace 图片加定时器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SoundPlayer sp = new SoundPlayer();
            //sp.SoundLocation=(@"C:\Users\c\Desktop\yy所有\小渔夫 童话 .mp3");
            //sp.Play();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromFile(@"C:\Users\c\Desktop\1\QQ图片20161101123554.jpg");
            pictureBox2.Image = Image.FromFile(@"C:\Users\c\Desktop\1\xlarge_kuaa_3bc20000756f125d.jpg");
            pictureBox3.Image = Image.FromFile(@"C:\Users\c\Desktop\1\xlarge_ySvY_169800008a18118f.jpg");
            pictureBox4.Image = Image.FromFile(@"C:\Users\c\Desktop\1\YY图片20161110175925.png");
        }

        string[] path=System.IO.Directory.GetFiles(@"C:\Users\c\Desktop\1");
        int i1 = 0;
        int i2 = 1;
        int i3 = 2;
        int i4 = 3;
        private void timer1_Tick(object sender, EventArgs e)
        {
            i1++;
            if (i1 == path.Length)
            {
                i1 = 0;
            }
            i2++;
            if (i2 == path.Length)
            {
                i2 = 0;
            }
            i3++;
            if (i3 == path.Length)
            {
                i3 = 0;
            }
            i4++;
            if (i4 == path.Length)
            {
                i4 = 0;
            }
            pictureBox1.Image = Image.FromFile(path[i1]);
            pictureBox2.Image = Image.FromFile(path[i2]);
            pictureBox3.Image = Image.FromFile(path[i3]);
            pictureBox4.Image = Image.FromFile(path[i4]);
        }
    }
}
