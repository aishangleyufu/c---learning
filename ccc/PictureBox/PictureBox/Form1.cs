using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PictureBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\c\Desktop\1\QQ图片20161101123554.jpg");
            


               
        }
        string[] path = Directory.GetFiles(@"C:\Users\c\Desktop\1");

        int i = 0;

        private void button2_Click(object sender, EventArgs e)
        {

                i++;
                if (i == path.Length)
                {
                    i = 0;

                }
            pictureBox1.Image = Image.FromFile(path[i]);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

                i--;
                if (i < 0)
                {
                    i = path.Length - 1;
                }
            pictureBox1.Image = Image.FromFile(path[i]);
        }
    }
}
