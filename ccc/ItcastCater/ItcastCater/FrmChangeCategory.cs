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
    public partial class FrmChangeCategory : Form
    {
        public FrmChangeCategory()
        {
            InitializeComponent();
        }
        private int TP { get; set; }
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;
            if (this.TP==1)
            {
                
            }
            else if (this.TP==2)
            {
                CategoryInfo ct = mea.Obj as CategoryInfo;
                txtCName.Text = ct.Catname;
                txtCNum.Text = ct.Catnum;
                txtCRemark.Text = ct.Remark;
                labId.Text = ct.Catid.ToString();
            }
        }
        private void FrmChangeCategory_Load(object sender, EventArgs e)
        {
            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckBox2())
            {
                CategoryInfo cat = new CategoryInfo();
                cat.Catname = txtCName.Text;
                cat.Catnum = txtCNum.Text;
                cat.Remark = txtCRemark.Text;
                if (this.TP==1)
                {
                    cat.Delflag = 0;
                    cat.Subtime = System.DateTime.Now;
                    cat.Subby = 1;
                }
                else if (this.TP==2)
                {
                    cat.Catid = Convert.ToInt32(labId.Text);
                }
                CategoryInfoBll bll = new CategoryInfoBll();
                string msg2 = bll.SaveCategoryInfo(cat,this.TP)?"操作成功":"操作失败";
                MessageBox.Show(msg2);
                this.Close();
            }
        }
        /// <summary>
        /// 判断商品各个文本框不为空
        /// </summary>
        /// <returns></returns>
        private bool CheckBox2()
        {
            if (string.IsNullOrEmpty(txtCName.Text))
            {
                MessageBox.Show("名字不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtCRemark.Text))
            {
                MessageBox.Show("评价不能为空");
                return false;
            }
            return true;
        }
    }
}
