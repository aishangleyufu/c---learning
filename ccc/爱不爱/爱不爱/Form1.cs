using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 爱不爱
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("我也爱你呦");
            this.Close();

        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            int x = this.ClientSize.Width-button2.Width;
            int y = this.ClientSize.Height-button2.Height;

            Random r = new Random();
            button2.Location = new Point(r.Next(0,x+1),r.Next(0,y+1));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("还是被你这个屌丝点到了");
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txtbox_TextChanged(object sender, EventArgs e)
        {
            labbox.Text = txtbox.Text;
        }
    }
}
