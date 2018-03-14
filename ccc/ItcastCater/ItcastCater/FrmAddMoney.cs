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
    public partial class FrmAddMoney : Form
    {
        public FrmAddMoney()
        {
            InitializeComponent();
        }
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea_add = e as MyEventArgs;
            labDeskName.Text = mea_add.Name;
            labDeskId.Text= mea_add.Temp.ToString();
        }

        private void FrmAddMoney_Load(object sender, EventArgs e)
        {

            //加载所有的产品
            LoadProductInfoByDelFlag(0);
            //加载节点树的产品
            LoadCategoryInfoByDelFlag(0);

            //显示所有的点菜
          LoadROrderInfoProductByOrderId(Convert.ToInt32(labDeskId.Text));
        }
        //显示点的什么菜
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">订单的id</param>
        private void LoadROrderInfoProductByOrderId(int p)
        {

            R_OrderInfo_ProductBll bll = new R_OrderInfo_ProductBll();
            dgvROrderProduct.AutoGenerateColumns = false;
            dgvROrderProduct.DataSource = bll.GetROrderInfoProduct(p);
            if (dgvROrderProduct.SelectedRows.Count > 0)
            {
                dgvROrderProduct.SelectedRows[0].Selected = false;
            }
            //没判断
            R_OrderInfo_Product rop = bll.GetMoneyAndCount(p);
            labSumMoney.Text = rop.MONEY.ToString();
            labCount.Text = rop.CT.ToString();
        }

        //加载节点树
        private void LoadCategoryInfoByDelFlag(int p)
        {
            //先加载商品类别
            CategoryInfoBll bll = new CategoryInfoBll();
            List<CategoryInfo> list = bll.GetAllCategoryInfoByDelFlag(p);
            for (int i = 0; i < list.Count; i++)
            {
                TreeNode tn = tvCategory.Nodes.Add(list[i].Catname);
                // tn.Tag = list[i].CatId;//存类别id
                LoadProductInfoByCatId(list[i].Catid, tn.Nodes);
            }
        }

        private void LoadProductInfoByCatId(int p, TreeNodeCollection tnc)
        {
            ProductInfoBll bll = new ProductInfoBll();
            List<ProductInfo> list = bll.GetProductInfoByCatid(p);
            for (int i = 0; i < list.Count; i++)
            {
                tnc.Add(list[i].ProName + "====" + list[i].ProPrice + "元");
            }
        }
        //加载主菜单
        private void LoadProductInfoByDelFlag(int p)
        {
            ProductInfoBll bll = new ProductInfoBll();
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = bll.GetAllProductInfoByDelFlag(p);
            dgvProduct.SelectedRows[0].Selected = false;
        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int proId = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells[0].Value.ToString());
            R_OrderInfo_Product rop = new R_OrderInfo_Product();
            rop.OrderId = Convert.ToInt32(labDeskId.Text);//订单的id
            
            rop.ProId = proId;//产品的id
            //,,DelFlag,SubTime,State,UnitCount

            rop.DelFlag = 0;
            rop.SubTime = System.DateTime.Now;
            rop.State = 0;
            if (string.IsNullOrEmpty(txtCount.Text) || txtCount.Text == "0" || txtCount.Text == "1")
            {
                rop.UnitCount = 1;
            }
            else
            {
                rop.UnitCount = Convert.ToInt32(txtCount.Text);//有异常--坑,
            }
            R_OrderInfo_ProductBll bll = new R_OrderInfo_ProductBll();
            bll.AddROrderInfoProduct(rop);
            LoadROrderInfoProductByOrderId(Convert.ToInt32(rop.OrderId));//查询点的什么产品
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            int n = 0;
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadProductInfoByDelFlag(0);
                return;
            }
            if (char.IsLetter(txtSearch.Text[0]))
            {
                n = 1;
            }
            else
            {
                n = 2;
            }
            ProductInfoBll pbll = new ProductInfoBll();
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.DataSource = pbll.GetProductInfoBySpellOrNum(txtSearch.Text, n);
            if (dgvProduct.SelectedRows.Count>0)
            {
                dgvProduct.SelectedRows[0].Selected = false;
            }
        }

        private void btnDeleteRorderPro_Click(object sender, EventArgs e)
        {
            if (dgvROrderProduct.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvROrderProduct.SelectedRows[0].Cells[0].Value);
                R_OrderInfo_ProductBll rbll = new R_OrderInfo_ProductBll();
                string msg=rbll.SoftDeleteROrderProName(id)?"退菜成功":"退菜失败";
                MessageBox.Show(msg);
                LoadROrderInfoProductByOrderId(Convert.ToInt32(labDeskId.Text));

            }
            else
            {
                MessageBox.Show("请选中要退的菜品");
            }
        }

        private void FrmAddMoney_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(labSumMoney.Text)&&labSumMoney.Text!="0")
            {
                OrderInfoBll obll=new OrderInfoBll();
                obll.UpdateMoney(Convert.ToInt32(labDeskId.Text), Convert.ToDecimal(labSumMoney.Text));

            }
        }
    }
}
