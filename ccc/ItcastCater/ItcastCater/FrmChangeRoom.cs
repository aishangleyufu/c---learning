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
    public partial class FrmChangeRoom : Form
    {
        public FrmChangeRoom()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            RoomInfo r = new RoomInfo();
            r.DelFlag = 0;
            r.IsDefault = Convert.ToInt32(txtIsDeflaut.Text);
            r.RoomId = Convert.ToInt32(labId.Text);
            r.RoomMaxConsumer = Convert.ToDecimal(txtRPerNum.Text);
            r.RoomMinimunConsume = Convert.ToDecimal(txtRMinMoney.Text);
            r.RoomName = txtRName.ToString();
            r.RoomType = Convert.ToInt32(txtRType.Text);
            r.SubBy = 1;
            r.SubTime = System.DateTime.Now;
            RoomInfoBll rbll = new RoomInfoBll();
            string msg = rbll.AddRoom(r) ? "添加房间成功" : "添加房间失败";
            MessageBox.Show(msg);
            this.Close();
        }
    }
}
