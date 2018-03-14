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
    public partial class FrmBalance : Form
    {
        public FrmBalance()
        {
            InitializeComponent();
        }
        private int dkId { get; set; }
        private void FrmBalance_Load(object sender, EventArgs e)
        {
            LoadMemmberInfoByDelFlag(0);

            LoadProductInfo(Convert.ToInt32(labOrderId.Text));
        }

        private void LoadProductInfo(int p)
        {
            R_OrderInfo_ProductBll rbll = new R_OrderInfo_ProductBll();
            dgvAllPro.DataSource = rbll.GetROrderInfoProduct(p);
            dgvAllPro.AutoGenerateColumns = false;
            dgvAllPro.SelectedRows[0].Selected = false;
        }

        private void LoadMemmberInfoByDelFlag(int p)
        {
            MemmberInfoBll mbll = new MemmberInfoBll();
            List<MemmberInfo> list = mbll.GetAllMemmberInfoByDelflag(p);
            list.Insert(0, new MemmberInfo() { MemmberId = -1, MemName = "请选择" });
            cmbMemmber.DataSource = list;
            cmbMemmber.DisplayMember = "MemName";
            cmbMemmber.ValueMember = "MemmberId";
        }

        private void cmbMemmber_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMemmber.SelectedIndex != 0)
            {
                MemmberInfoBll bll = new MemmberInfoBll();
                MemmberInfo mem = cmbMemmber.SelectedItem as MemmberInfo;
                labTp.Text = bll.GetMemmberTpNameByMemmberId(mem.MemmberId);//会员的级别
                labyeMoney.Text = mem.MemMoney.ToString();//余额
                lblDis.Text = mem.MemDiscount.ToString();//折扣
                lblMoney.Text = (Convert.ToDecimal(labMoney.Text) * mem.MemDiscount / 10).ToString();
            }
            else
            {
                labTp.Text = "";
                labyeMoney.Text = "";
                lblDis.Text = "";
                lblMoney.Text = labMoney.Text;
            }
        }
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea_jiezhang = e as MyEventArgs;
            DeskInfo dk = mea_jiezhang.Obj as DeskInfo;
            this.dkId = dk.DeskId;
            labDeskName.Text = dk.DeskName;
            OrderInfoBll obll = new OrderInfoBll();
            int orderId=obll.GetOrderIdByDeskId(this.dkId);
            labOrderId.Text = orderId.ToString();
            decimal money = obll.GetMoney(orderId);
            labMoney.Text = money.ToString();
            lblMoney.Text = money.ToString();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMoney.Text))
            {
                MessageBox.Show("想吃霸王餐做你的美梦去吧");
                return;
            }
            if (Convert.ToDecimal(txtMoney.Text)<Convert.ToDecimal(lblMoney.Text))
            {
                MessageBox.Show("这点钱只能买个茶叶蛋");
                return;
            }
            //餐桌状态改变
            DeskInfoBll dbll = new DeskInfoBll();
            bool dkFlag=dbll.UpdateDeskStateByDeskId(this.dkId,0);
            OrderInfo order = new OrderInfo();
            if (cmbMemmber.SelectedIndex != 0)
            {
                MemmberInfo mem = cmbMemmber.SelectedItem as MemmberInfo;
                order.OrderMemId = mem.MemmberId;//会员的id
                order.DisCount = mem.MemDiscount;//折扣
                //会员的余额.
                decimal money = Convert.ToDecimal(mem.MemMoney) - Convert.ToDecimal(lblMoney.Text);
                //判断给你们了

                //更新会员卡内的钱
                MemmberInfoBll memBll = new MemmberInfoBll();
                bool memFlag = memBll.UpdateMoneyByMemId(mem.MemmberId, money);
            }
            //订单的状态改变,钱,会员的id，折扣
            order.EndTime = System.DateTime.Now;//结束时间
            order.OrderId = Convert.ToInt32(labOrderId.Text);
            order.OrderMoney = Convert.ToDecimal(lblMoney.Text);

            OrderInfoBll obll = new OrderInfoBll();
            bool oFlag = obll.UpdateOrderInfoMoney(order);
            if (dkFlag && oFlag)
            {
                MessageBox.Show("结账成功");
            }
            else
            {
                MessageBox.Show("失败");
            }

        }


    }
}
