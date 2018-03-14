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
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }

        private void FrmBilling_Load(object sender, EventArgs e)
        {

        }
        int ID { get; set; }
        MyEventArgs mea_money=new MyEventArgs();
        public event EventHandler evtFrmmoney;
        public void SetText(object sender, EventArgs e)
        {
            MyEventArgs mea = e as MyEventArgs;
            DeskInfo desk = mea.Obj as DeskInfo;
            labDeskName.Text = desk.DeskName;
            labLittleMoney.Text = mea.Money.ToString();
            labRoomType.Text = mea.Name;
            this.ID = desk.DeskId;
        }
        /// <summary>
        /// 确定开单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            //做三件事情
            //1更改餐桌状态
            DeskInfoBll dkbll = new DeskInfoBll();
            bool dkFlag=dkbll.UpdateDeskStateByDeskId(this.ID, 1);

            //2添加一个订单
            OrderInfoBll orbll = new OrderInfoBll();
            OrderInfo o = new OrderInfo();
            o.SubTime = System.DateTime.Now;
            o.DelFlag = 0;
            o.OrderMoney = 0;
            o.OrderState = 1;
            o.Remark = txtPersonCount.Text + txtDescription.Text;
            o.SubBy = 1;
            int orderId=orbll.AddOrderInfo(o);

            //3添加一个中间表
            R_Order_DeskBll rodbll = new R_Order_DeskBll();
            R_Order_Desk rod=new R_Order_Desk();
            rod.DeskId = this.ID;
            rod.OrderId = orderId;
            bool rodFlag=rodbll.AddOrderDesk(rod);

            if (dkFlag&&rodFlag)
            {
                MessageBox.Show("开单成功");
            }
            else
            {
                MessageBox.Show("开单失败");
            }

            if (ckbMeal.Checked)
            {
                FrmAddMoney frm_money = new FrmAddMoney();
                mea_money.Name = labDeskName.Text;//餐桌的编号
                mea_money.Temp = orderId;//订单id
                this.evtFrmmoney += new EventHandler(frm_money.SetText);
                if (this.evtFrmmoney!=null)
                {
                    this.evtFrmmoney(this, mea_money);
                    frm_money.FormClosed += new FormClosedEventHandler(frm_money_formclosed);
                    frm_money.ShowDialog();
                }
            }
            else
            {

            }

        }

        private void frm_money_formclosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
