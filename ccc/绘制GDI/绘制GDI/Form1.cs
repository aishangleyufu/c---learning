using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 绘制GDI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //笔 纸 颜色 窗体
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Brushes.Red);
            Point p1 = new Point(30, 50);
            Point p2 = new Point(250, 250);
            g.DrawLine(pen, p1, p2);
        }
        int i = 0;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //笔 纸 颜色 窗体
            i++;
            label1.Text = i.ToString();
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Brushes.Red);
            Point p1 = new Point(30, 50);
            Point p2 = new Point(250, 250);
            g.DrawLine(pen, p1, p2);
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(Brushes.Blue);
            Size size=new System.Drawing.Size(80,80);
            Rectangle rec = new Rectangle(new Point(50, 50),size );
            g.DrawRectangle(p, rec);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Brushes.DarkCyan);
            Size size = new System.Drawing.Size(180,90);
            Rectangle rec = new Rectangle(new Point(150, 150), size);
            g.DrawPie(pen, rec, 180, 20);
        }
    }
}
