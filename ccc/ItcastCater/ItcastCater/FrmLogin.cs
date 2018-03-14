using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ItcastCater.Bll;
using ItcastCater.Model;

namespace ItcastCater
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckText())//判断账号密码不为空
            {
                string msg = "";
                UserInfoBll bll=new UserInfoBll();
                if (bll.IsLoginBtLoginName(txtName.Text,txtPwd.Text,out msg))
                {
                    msgDiv1.MsgDivShow(msg,1,Bind);
                }
                else
                {
                    msgDiv1.MsgDivShow(msg,1);
                }
               
            }
      
        }

        public void Bind()
        {
            //窗体值变为1
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
     
        private bool CheckText()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                msgDiv1.MsgDivShow("账号不能为空",1);
                return false;
            }
            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                msgDiv1.MsgDivShow("密码不能为空", 1);
                return false;
            }
            return true;
        }

        private void msgDiv1_Click(object sender, EventArgs e)
        {

        }
    }
}
