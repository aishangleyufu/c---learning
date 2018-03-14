using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 对话框
{
    public partial class Form1 : Form
    {
        List<string> list =new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;

            textBox1.WordWrap = false;
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void 隐藏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要打开的文本文件";
            ofd.InitialDirectory = @"C:\Users\c\Desktop";
            ofd.Multiselect = true;
            ofd.Filter = "文本文件|*.txt|所有文件|*.*";
            ofd.ShowDialog();

            string path = ofd.FileName;
            list.Add(path);
            string filename = Path.GetFileName(path);
            listBox1.Items.Add(filename);
            if (path=="")
            {
                return;
            }
            using (FileStream fsRead = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = fsRead.Read(buffer, 0, buffer.Length);
                textBox1.Text = Encoding.UTF8.GetString(buffer,0,r);
            }

        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = @"C:\Users\c\Desktop";
            sfd.Title = "请选择你要保存的路径";
            sfd.Filter = "文本文件|*.txt|所有文件|*.*";
            sfd.ShowDialog();

            string path = sfd.FileName;
            if (path == "")
            {
                return;
            }

            using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(textBox1.Text);
                fsWrite.Write(buffer, 0, buffer.Length);
            }
            MessageBox.Show("保存成功");

        }

        private void 自动换行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (自动换行ToolStripMenuItem.Text=="☆自动换行")
            {
                textBox1.WordWrap = true;
                自动换行ToolStripMenuItem.Text = "★取消自动换行";
            }
            else if (自动换行ToolStripMenuItem.Text == "★取消自动换行")
            {
                  textBox1.WordWrap = false;
                自动换行ToolStripMenuItem.Text = "☆自动换行";
            }
        }

        private void 字体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.ShowDialog();
            textBox1.Font = fd.Font;
        }

        private void 颜色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.ShowDialog();
            textBox1.ForeColor = cd.Color;
            
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            //双击打开

            string path_click = list[listBox1.SelectedIndex];
            using (FileStream fsRead = new FileStream(path_click, FileMode.OpenOrCreate, FileAccess.Read))
            {
                byte[] buffer = new byte[1024 * 1024 * 5];
                int r = fsRead.Read(buffer, 0, buffer.Length);
                textBox1.Text = Encoding.UTF8.GetString(buffer, 0, r);
            }
        }


    }
}
