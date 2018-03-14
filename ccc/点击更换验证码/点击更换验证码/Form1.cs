using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 点击更换验证码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            string str = null;
            for (int i = 0; i < 5; i++)
            {
                int rNumber = r.Next(0,10);
                str += rNumber;
            }
            Bitmap bmp = new Bitmap(200, 40);
            Graphics g = Graphics.FromImage(bmp);
            for (int i = 0; i < 5; i++)
            {
                string[] fonts={"微软雅黑","宋体","黑体","隶书"};
                Color[] color={Color.Yellow,Color.Red,Color.Blue,Color.Green};
                Point po=new Point(i*30,0);
                g.DrawString(str[i].ToString(),new Font(fonts[r.Next(0,4)],25,FontStyle.Bold),new SolidBrush(color[r.Next(0,4)]),po);
            }

            for (int i = 0; i < 30; i++)
            {
                Point p1 = new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                Point p2 = new Point(r.Next(0, bmp.Height), r.Next(0, bmp.Height));
                Pen pen1= new Pen(Brushes.Violet);
                g.DrawLine(pen1, p1, p2);
            }

            for (int i = 0; i < 500; i++)
            {
                Point p=new Point(r.Next(0, bmp.Width), r.Next(0, bmp.Height));
                bmp.SetPixel(p.X, p.Y, Color.Black);
            }

            pictureBox1.Image = bmp;
        }
    }
}
