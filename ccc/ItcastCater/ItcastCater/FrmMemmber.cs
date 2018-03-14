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
    public partial class FrmMemmber : Form
    {
        public FrmMemmber()
        {
            InitializeComponent();
        }

        private void dgvMemmber_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmMemmber_Load(object sender, EventArgs e)
        {
            LoadMemmberInfoByDelflag(0);
        }
        
        public void LoadMemmberInfoByDelflag(int p)
        {
            MemmberInfoBll bll = new MemmberInfoBll();
            dgvMemmber.AutoGenerateColumns = false;
            dgvMemmber.DataSource = bll.GetAllMemmberInfoByDelflag(p);
            dgvMemmber.SelectedRows[0].Selected = false;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        MemmberInfoBll bll = new MemmberInfoBll();
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMemmber.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value.ToString());
               
                string msg = bll.DeleteMemmberInfoByMemmberId(id) ? "操作成功" : "操作失败";
                MessageBox.Show(msg);
                LoadMemmberInfoByDelflag(0);//刷新
            }
        }

        public event EventHandler evtMemmber;
        //增加会员
        private void btnAddMemMber_Click(object sender, EventArgs e)
        {
            ShowFrmUpdateMemmberInfo(1);
        }

        //修改会员
        private void btnUpdateMember_Click(object sender, EventArgs e)
        {
            if (dgvMemmber.SelectedRows.Count>0)
            {
                int id = Convert.ToInt32(dgvMemmber.SelectedRows[0].Cells[0].Value.ToString());
                mea.Obj=bll.GetMemmberInfoByMemmberId(id);
                ShowFrmUpdateMemmberInfo(2);
            }
            else
            {
                MessageBox.Show("请看准目标");
            }
           
        }
        MyEventArgs mea = new MyEventArgs();
        public void ShowFrmUpdateMemmberInfo(int p)
        {
            FrmUpdateMemmberInfo fum = new FrmUpdateMemmberInfo();
            this.evtMemmber+=new EventHandler(fum.SetText);
            mea.Temp = p;
            if (this.evtMemmber!=null)
            {
                this.evtMemmber(this, mea);
                fum.FormClosed += new FormClosedEventHandler(fum_FormClosed);
                fum.ShowDialog();
            }
            
        }

       void fum_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadMemmberInfoByDelflag(0);
        }

       private void button5_Click(object sender, EventArgs e)
       {
           string str = textBox1.Text;
           int searchId=0;
           try
           {
               searchId = Convert.ToInt32(str);
           }
           catch
           {
               searchId = -1;
           }
           if (searchId>0&&searchId<=1000)
           {
               mea.Obj = bll.GetMemmberInfoByMemmberId(searchId);
           }
           else 
           {
               mea.Obj = bll.GetMemmberInfoByMemmberName(str); 
           }

           if (mea.Obj != null)
           {
               ShowFrmUpdateMemmberInfo(2);
           }
           else
           {
               MessageBox.Show("查无此信息");
           }
       }



    }
}
