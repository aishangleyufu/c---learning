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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnMemmber_Click(object sender, EventArgs e)
        {
            FrmMemmber fm = new FrmMemmber();
            fm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmCategory fc = new FrmCategory();
            fc.ShowDialog();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            LoadRoomInfoByDelFlag(0);

            LoadDeskInfoByRoomIdAndTabIndex(tabControl1.TabPages[0]);

            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDeskInfoByRoomIdAndTabIndex(tabControl1.SelectedTab);
        }

        private void LoadDeskInfoByRoomIdAndTabIndex(TabPage tp)
        {
            if (tp != null)
            {


                RoomInfo r = tp.Tag as RoomInfo;
                ListView lv = tp.Controls[0] as ListView;
                lv.Clear();
                DeskInfoBll dbll = new DeskInfoBll();
                List<DeskInfo> listDesk = dbll.GetAllDeskInfoByRoomId(Convert.ToInt32(r.RoomId));
                for (int i = 0; i < listDesk.Count; i++)
                {
                    lv.Items.Add(listDesk[i].DeskName, Convert.ToInt32(listDesk[i].DeskState));
                    lv.Items[i].Tag = listDesk[i];
                }
            }
        }

        private void LoadRoomInfoByDelFlag(int p)
        {
            RoomInfoBll rbll = new RoomInfoBll();
            List<RoomInfo> listroom=rbll.GetAllRoomInfoByDelFlag(p);
            for (int i = listroom.Count-1; i >= 0; i--)
            {
                TabPage tp = new TabPage();
                tp.Text = listroom[i].RoomName;
                tp.Tag = listroom[i];
                ListView lv = new ListView();
                //设置内容较多
                lv.LargeImageList = imageList1;
                lv.View = View.LargeIcon;
                lv.Dock = DockStyle.Fill;
                lv.MultiSelect = false;
                lv.BackColor = Color.Pink;
                tp.Controls.Add(lv);

                tabControl1.TabPages.Add(tp);
            }
        }
        public event EventHandler evtFbm;
        public event EventHandler evtFam;

        private void button1_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl1.SelectedTab;
            ListView lv = tp.Controls[0] as ListView;
            if (lv.SelectedItems.Count<=0)
            {
                MessageBox.Show("请选中");
                return;
            }
            if ((lv.SelectedItems[0].Tag as DeskInfo).DeskState!=0)
            {
                MessageBox.Show("请选择未开单的餐桌");
                return;
            }
            MyEventArgs mea=new MyEventArgs();
            mea.Obj = lv.SelectedItems[0].Tag;
            FrmBilling fbm=new FrmBilling();
            
            mea.Name = (tp.Tag as RoomInfo).RoomName;
            mea.Money = Convert.ToDecimal((tp.Tag as RoomInfo).RoomMinimunConsume);
            this.evtFbm += new EventHandler(fbm.SetText);
            if (evtFbm!=null)
            {
                this.evtFbm(this,mea);
                fbm.FormClosed += new FormClosedEventHandler(fbm_Formclosed);
                fbm.ShowDialog();
            }
        }

        private void fbm_Formclosed(object sender, FormClosedEventArgs e)
        {
            LoadDeskInfoByRoomIdAndTabIndex(tabControl1.SelectedTab);
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {
            TabPage tp = tabControl1.SelectedTab;
            ListView lv = tp.Controls[0] as ListView;
            if (lv.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选中");
                return;
            }
            if ((lv.SelectedItems[0].Tag as DeskInfo).DeskState != 1)
            {
                MessageBox.Show("请选择开单的餐桌");
                return;
            }
            MyEventArgs mea_add = new MyEventArgs();
            FrmAddMoney fam = new FrmAddMoney();
            mea_add.Name = (lv.SelectedItems[0].Tag as DeskInfo).DeskName;
            OrderInfoBll obll = new OrderInfoBll();
            int orde = obll.GetOrderIdByDeskId((lv.SelectedItems[0].Tag as DeskInfo).DeskId);
            mea_add.Temp = orde;
            this.evtFam += new EventHandler(fam.SetText);
            if (this.evtFam!=null)
            {
                this.evtFam(this, mea_add);
                fam.FormClosed += new FormClosedEventHandler(fam_Formclose);
                fam.ShowDialog();
            }
        }

        private void fam_Formclose(object sender, FormClosedEventArgs e)
        {
            LoadDeskInfoByRoomIdAndTabIndex(tabControl1.SelectedTab);
        }
        public event EventHandler evtjz;
        private void btnJieZhang_click(object sender, EventArgs e)
        {
            TabPage tp = tabControl1.SelectedTab;
            ListView lv = tp.Controls[0] as ListView;
            if (lv.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选中");
                return;
            }
            if ((lv.SelectedItems[0].Tag as DeskInfo).DeskState != 1)
            {
                MessageBox.Show("请选择开单的餐桌");
                return;
            }
            MyEventArgs mea_jiezhang = new MyEventArgs();
            FrmBalance fb = new FrmBalance();
            this.evtjz += new EventHandler(fb.SetText);
            mea_jiezhang.Obj = lv.SelectedItems[0].Tag;
            if (this.evtjz!=null)
            {
                this.evtjz(this, mea_jiezhang);
                fb.FormClosed += new FormClosedEventHandler(fb_Formclosed);
                fb.ShowDialog();
            }

        }

        private void fb_Formclosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmRoom fr = FrmRoom.Instance;
            fr.FormClosed += new FormClosedEventHandler(fr_FormClosed);
            fr.Show();
        }

        private void fr_FormClosed(object sender, FormClosedEventArgs e)
        {
            tabControl1.TabPages.Clear();
            //加载房间
            LoadRoomInfoByDelFlag(0);
            //加载餐桌
            LoadDeskInfoByRoomIdAndTabIndex (tabControl1.TabPages[0]);
            //加载其他的餐桌注册一个事件
            tabControl1.SelectedIndexChanged += new EventHandler(tabControl1_SelectedIndexChanged);
        }
    }
}
