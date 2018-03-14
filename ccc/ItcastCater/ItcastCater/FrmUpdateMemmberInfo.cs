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
    public partial class FrmUpdateMemmberInfo : Form
    {
        public FrmUpdateMemmberInfo()
        {
            InitializeComponent();
        }
        private int TP { get; set; }

        private void LoadMemmberTypeByDelFlag(int p)
        {
            MemmberTypeBll blltype = new MemmberTypeBll();
            List<MemmberType> list=blltype.GetAllMemmberTypeByDelflag(p);
            list.Insert(0, new MemmberType() { MemType = -1, MemTpName = "请选择" });
            cmbMemType.DataSource = list;
            cmbMemType.DisplayMember = "MemTpName";
            cmbMemType.ValueMember = "MemType";
        }
        private void FrmUpdateMemmberInfo_Load(object sender, EventArgs e)
        {

        }

        public void SetText(object sender, EventArgs e)
        {
            LoadMemmberTypeByDelFlag(0);
            MyEventArgs mea = e as MyEventArgs;
            this.TP = mea.Temp;
            if (this.TP==1)
            {
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        TextBox tb = item as TextBox;
                        tb.Text = "";
                    }
                }
                txtMemIntegral.Text = "0";
                rdoMan.Checked = true;
            }
            else if (this.TP==2)
            {
                MemmberInfo mem = mea.Obj as MemmberInfo;
                txtBirs.Text = mem.MemBirthdaty.ToString();
                txtMemDiscount.Text = mem.MemDiscount.ToString();
                txtMemIntegral.Text = mem.MemIntegral.ToString();
                txtmemMoney.Text = mem.MemMoney.ToString();
                txtMemName.Text = mem.MemName;
                txtMemNum.Text = mem.MemNum;
                txtMemPhone.Text = mem.MemMobilePhone;
                rdoMan.Checked = mem.MemGender == "男" ? true : false;
                rdoWomen.Checked = mem.MemGender == "女" ? true : false;
                dtEndServerTime.Value = Convert.ToDateTime(mem.MemEndServerTime);
                labId.Text = mem.MemmberId.ToString();
                cmbMemType.SelectedValue = mem.MemType;
            }
        }

        private void txtMemIntegral_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckEmpty())
            {
                MemmberInfo mem = new MemmberInfo();
                mem.MemBirthdaty = Convert.ToDateTime(txtBirs.Text);
                mem.MemDiscount = Convert.ToDecimal(txtMemDiscount.Text);
                mem.MemEndServerTime = Convert.ToDateTime(dtEndServerTime.Value);
                mem.MemGender = CheckGender();
                mem.MemIntegral = Convert.ToInt32(txtMemIntegral.Text);
                mem.MemMobilePhone = txtMemPhone.Text;
                mem.MemMoney = Convert.ToDecimal(txtmemMoney.Text);
                mem.MemName = txtMemName.Text;
                mem.MemNum = txtMemNum.Text;
                mem.MemType = Convert.ToInt32(cmbMemType.SelectedValue);

                if (this.TP == 1)
                {
                    mem.SubTime = System.DateTime.Now;
                    mem.DelFlag = 0;
                }
                else if (this.TP == 2)
                {
                    mem.MemmberId = Convert.ToInt32(labId.Text);
                }
                MemmberInfoBll bll = new MemmberInfoBll();
                string msg = bll.SaveMemmberInfo(mem, this.TP) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                this.Close();
            }
        }
        /// <summary>
        /// 判断性别
        /// </summary>
        /// <returns></returns>
        private string CheckGender()
        {
            string str = "";
            if (rdoMan.Checked)
            {
                str="男";
            }
            else if (rdoWomen.Checked)
            {
                str="女";
            }
            return str;
        }
        /// <summary>
        /// 判断会员信息录入是否为空
        /// </summary>
        /// <returns></returns>
        private bool CheckEmpty()
        {
            if (string.IsNullOrEmpty(txtBirs.Text))
            {
                MessageBox.Show("生日不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(txtMemDiscount.Text))
            {
                MessageBox.Show("折扣不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(txtMemIntegral.Text))
            {
                MessageBox.Show("积分不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(txtmemMoney.Text))
            {
                MessageBox.Show("剩余金额不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(txtMemName.Text))
            {
                MessageBox.Show("名字不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(txtMemNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(txtMemPhone.Text))
            {
                MessageBox.Show("电话不能为空");
                return false;
            }

            if (cmbMemType.SelectedIndex==0)
            {
                MessageBox.Show("请选择会员级别");
                return false;
            }

            if (string.IsNullOrEmpty(txtBirs.Text))
            {
                MessageBox.Show("生日不能为空");
                return false;
            }

            if (string.IsNullOrEmpty(txtBirs.Text))
            {
                MessageBox.Show("生日不能为空");
                return false;
            }
            return true;
        }
    }
}
