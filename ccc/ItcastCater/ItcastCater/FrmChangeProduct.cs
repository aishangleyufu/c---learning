using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ItcastCater.Model;
using ItcastCater.Bll;

namespace ItcastCater
{
    public partial class FrmChangeProduct : Form
    {
        public FrmChangeProduct()
        {
            InitializeComponent();
        }
        private int TP { get; set; }
        private void LoadCategoryInfoByDelFlag_2(int p)
        {
            CategoryInfoBll bll = new CategoryInfoBll();
            List<CategoryInfo> list=new List<CategoryInfo>();
            list = bll.GetAllCategoryInfoByDelFlag(p);
            list.Insert(0,new CategoryInfo(){Catname="请选择",Catid=-1});
            cmbCategory.DataSource = list;
            cmbCategory.DisplayMember = "Catname";
            cmbCategory.ValueMember = "Catid";
        }
        public void SetText(object sender, EventArgs e)
        {
            LoadCategoryInfoByDelFlag_2(0);
            MyEventArgs mep = e as MyEventArgs;
            this.TP = mep.Temp;
            
            if (this.TP==3)
            {
                
            }
            else if (this.TP==4)
            {
                ProductInfo pro =  mep.Obj as ProductInfo;
                txtCost.Text = pro.ProCost.ToString();
                txtName.Text = pro.ProName;
                txtNum.Text = pro.ProNum;
                txtPrice.Text = pro.ProPrice.ToString();
                txtRemark.Text = pro.Remark;
                txtSpell.Text = pro.ProSpell;
                txtStock.Text = pro.ProStock.ToString();
                txtUnit.Text = pro.ProUnit;
                labId.Text = pro.ProId.ToString();
                cmbCategory.SelectedValue = pro.CatId;
            }
        }
        private void FrmChangeProduct_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckBox3())
            {
                ProductInfo pro = new ProductInfo();
                pro.CatId = Convert.ToInt32(cmbCategory.SelectedValue);
                pro.ProCost = Convert.ToDecimal(txtCost.Text);
                pro.ProName = txtName.Text;
                pro.ProNum = txtNum.Text;
                pro.ProPrice = Convert.ToDecimal(txtPrice.Text);
                pro.ProSpell = txtSpell.Text;
                pro.ProStock = Convert.ToDecimal(txtStock.Text);
                pro.ProUnit = txtUnit.Text;
                pro.Remark = txtRemark.Text;
           
                if (this.TP == 3)
                {
                    pro.DelFlag = 0;
                    pro.SubBy = 1;
                    pro.SubTime = System.DateTime.Now;
                }
                else if (this.TP == 4)
                {
                    pro.ProId = Convert.ToInt32(labId.Text);
                }
                ProductInfoBll bll = new ProductInfoBll();
                string msg3 = bll.SaveProductInfo(pro, this.TP) ? "操作成功" : "操作失败";
                MessageBox.Show(msg3);
                this.Close();
            }
        }

        private bool CheckBox3()
        {
            if(string.IsNullOrEmpty(txtCost.Text))
            {
                MessageBox.Show("花费不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtNum.Text))
            {
                MessageBox.Show("编号不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("价格不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtRemark.Text))
            {
                MessageBox.Show("评价不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtSpell.Text))
            {
                MessageBox.Show("拼写不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("货物数量不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("单位不能为空");
                return false;
            }
            if (cmbCategory.SelectedIndex==0)
            {
                MessageBox.Show("请选择货物分类");
                return false;
            }

            return true;
        }
    }
}
