using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string text1 = "你的爱好是:";
            if (checkBox1.Checked)
          
                text1 = text1 + checkBox1.Text;
          
            if (checkBox2.Checked)
           
                text1 += checkBox2.Text;
          

            label1.Text = text1;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            string text1 = "你的爱好是:";
            if (checkBox1.Checked)

                text1 = text1 + checkBox1.Text;

            if (checkBox2.Checked)

                text1 += checkBox2.Text;


            label1.Text = text1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer1.Interval = 10000;
            this.timer1.Enabled = true;
            label1.Text = DateTime.Now.ToString();


        }
    }
}
