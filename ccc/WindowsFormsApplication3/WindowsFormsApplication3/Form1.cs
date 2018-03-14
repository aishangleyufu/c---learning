using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Boolean blnClear = false;
        string strOper = "+";
        double sum = 0;

        public void append_num(int i)
        {
            if (blnClear)//如果准备输入下一个加数，应先清除textBox1显示内容
            {
                textBox1.Text = "0";//阴影部分为新增语句
                blnClear = false;
            }
            if (textBox1.Text != "0")
                textBox1.Text += Convert.ToString(i);
            else
                textBox1.Text = Convert.ToString(i);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (sender == button0) append_num(0);
            if (sender == button1) append_num(1);
            if (sender == button2) append_num(2);
            if (sender == button3) append_num(3);
            if (sender == button4) append_num(4);
            if (sender == button5) append_num(5);
            if (sender == button6) append_num(6);
            if (sender == button7) append_num(7);
            if (sender == button8) append_num(8);
            if (sender == button9) append_num(9);
        }

        private void btn_dot_Click(object sender, EventArgs e)
       {
           if (blnClear) //如果准备输入下一个数，应先清除textBox1显示内容
           {
               textBox1.Text = "0";//阴影部分为新增语句
               blnClear = false;
           }
           int n = textBox1.Text.IndexOf(".");
            if(n==-1)
                textBox1.Text=textBox1.Text+".";
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            double dbsecond = Convert.ToDouble(textBox1.Text);
            if (!blnClear)
            {
                switch (strOper)
                {
                    case "+":
                        sum += dbsecond;
                        break;
                    case "-":
                        sum -= dbsecond;
                        break;
                    case "*":
                        sum *= dbsecond;
                        break;
                    case "/":
                        sum /= dbsecond;
                        break;

                }




            }
        }
         
    }
}
