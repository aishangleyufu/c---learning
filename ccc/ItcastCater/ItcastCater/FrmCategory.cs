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
    public partial class FrmCategory : Form
    {
        public FrmCategory()
        {
            InitializeComponent();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            //加载所有商品
            LoadCategoryInfoByDelFlag(0);
            //加载所有产品
            LoadProductInfoByDelFlag(0);

            LoadCategoryInfoByDelFlag_cmb(0);
        }

        private void LoadCategoryInfoByDelFlag_cmb(int p)
        {
            CategoryInfoBll bll = new CategoryInfoBll();
            
            List<CategoryInfo> list = new List<CategoryInfo>();
            list = bll.GetAllCategoryInfoByDelFlag(p);
            list.Insert(0,new CategoryInfo(){Catid=-1,Catname="请选择"});
            cmbCategory.DataSource=list;
            cmbCategory.DisplayMember="Catname";
            cmbCategory.ValueMember="Catid";
            //dgvCategoryInfo.SelectedRows[0].Selected = false;

        }

        public void LoadProductInfoByDelFlag(int p)
        {
            ProductInfoBll bll = new ProductInfoBll();
            dgvProductInfo.AutoGenerateColumns = false;
            dgvProductInfo.DataSource = bll.GetAllProductInfoByDelFlag(p);
            dgvProductInfo.SelectedRows[0].Selected = false;
        }

        public void LoadCategoryInfoByDelFlag(int p)
        {
            CategoryInfoBll bll = new CategoryInfoBll();
            dgvCategoryInfo.AutoGenerateColumns = false;
            dgvCategoryInfo.DataSource=bll.GetAllCategoryInfoByDelFlag(p);
            dgvCategoryInfo.SelectedRows[0].Selected = false;
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            LoadChangeCategoryInfo(1);
        }

        private void btnUpdateCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategoryInfo.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value.ToString());
                CategoryInfoBll bll = new CategoryInfoBll();
                CategoryInfo ct = bll.GetCategoryInfoById(id);
                if (ct!=null)
                {
                    mea.Obj = ct;
                    LoadChangeCategoryInfo(2);
                }
                
            }
            else
            {
                MessageBox.Show("请重新选中");
            }
        }

        MyEventArgs mea = new MyEventArgs();
        public event EventHandler evtFcc;
        /// <summary>
        /// 新增修改商品
        /// </summary>
        /// <param name="p"></param>
        private void LoadChangeCategoryInfo(int p)//1-新增 2--修改
        {
            FrmChangeCategory fcc = new FrmChangeCategory();
            this.evtFcc += new EventHandler(fcc.SetText);
            mea.Temp = p;
            if (this.evtFcc!=null)
            {
                this.evtFcc(this, mea);
                fcc.FormClosed += new FormClosedEventHandler(fcc_FormClosed);
                fcc.ShowDialog();
            }
        }

        private void fcc_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadCategoryInfoByDelFlag(0);
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count>0)
            {
                if (DialogResult.OK==MessageBox.Show("真的要删除么","删除",MessageBoxButtons.OKCancel,MessageBoxIcon.Question))
                {
                    string msg3 = "";
                    for (int i = 0; i < dgvProductInfo.SelectedRows.Count; i++)
                    {
                        int id = Convert.ToInt32(dgvProductInfo.SelectedRows[i].Cells[0].Value.ToString());
                        ProductInfoBll bll = new ProductInfoBll();
                        msg3=bll.SoftDeleteProductInfoByProId(id)?"删除成功":"删除失败";
                       
                    }
                    MessageBox.Show(msg3);
                    LoadProductInfoByDelFlag(0);
                    
                }
            }
            else
            {
                MessageBox.Show("请选中要删除的行");
            }
        }

        private void btnAddPro_Click(object sender, EventArgs e)
        {
            LoadChangeProductInfo(3);
        }

        private void btnUpdatePro_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString());
                ProductInfoBll bll = new ProductInfoBll();
                ProductInfo pro = new ProductInfo();
                pro=bll.GetProductInfoById(id);
                if (pro!=null)
                {
                    mep.Obj = pro;
                    LoadChangeProductInfo(4);
                }
            }
            else
            {
                MessageBox.Show("请选中要修改的行，谢谢哦");
            }
        }
        MyEventArgs mep = new MyEventArgs();
        public event EventHandler evtFcp;
        private void LoadChangeProductInfo(int p)
        {
            FrmChangeProduct fcp = new FrmChangeProduct();
            this.evtFcp += new EventHandler(fcp.SetText);
            mep.Temp = p;
            if (this.evtFcp!=null)
            {
                this.evtFcp(this, mep);
                fcp.FormClosed += new FormClosedEventHandler(fcp_FormClosed);
                fcp.ShowDialog();
            }
        }

        private void fcp_FormClosed(object sender,FormClosedEventArgs e)
        {
            LoadProductInfoByDelFlag(0);
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCategory.SelectedIndex != 0)
            {
                int id = Convert.ToInt32(cmbCategory.SelectedValue);
                ProductInfoBll bll = new ProductInfoBll();
                dgvProductInfo.DataSource=bll.GetProductInfoByCatid(id);
                dgvProductInfo.AutoGenerateColumns = false;
                if (dgvProductInfo.SelectedRows.Count>0)
	            {
                    dgvProductInfo.SelectedRows[0].Selected = false;
	            }
                
            }
            else
            {
                LoadProductInfoByDelFlag(0);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string txt = txtSearch.Text;
            ProductInfoBll bll = new ProductInfoBll();
            dgvProductInfo.DataSource = bll.GetProductInfoByProNum(txt);
            dgvProductInfo.AutoGenerateColumns = false;
            if (dgvProductInfo.SelectedRows.Count>0)
            {
                dgvProductInfo.SelectedRows[0].Selected = false;

            }
            
        }

        private void benDeleteCategory_Click(object sender, EventArgs e)
        {
            if (dgvCategoryInfo.SelectedRows.Count<=0)
            {
                MessageBox.Show("请选定后再删除");
                return;
            }
            if (DialogResult.OK==MessageBox.Show("你舍得删除么","删除类别",MessageBoxButtons.OKCancel,MessageBoxIcon.Question))
            {
                int r = -1;
                int id = Convert.ToInt32(dgvCategoryInfo.SelectedRows[0].Cells[0].Value.ToString());
                ProductInfoBll bll = new ProductInfoBll();
                List<ProductInfo> list=bll.GetProductInfoByCatid(id);
                r = list.Count;
                if (r>0)
                {
                    MessageBox.Show("该类别下有产品，不能删除，如想强制删除，请联系售后");
                }
                else
                {
                    CategoryInfoBll bll_c = new CategoryInfoBll();
                    string msg4 = bll_c.SoftDeleteCategoryInfoByCatId(id) ? "删除好了" : "删除出错了";
                    MessageBox.Show(msg4);
                    LoadCategoryInfoByDelFlag(0);
                }
            }
        }
    }
}
