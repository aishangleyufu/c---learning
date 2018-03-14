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
    public partial class FrmRoom : Form
    {
        private FrmRoom()
        {
            InitializeComponent();
        }

        private static FrmRoom _instance;

        public static FrmRoom Instance
        {
            get {
                if (_instance==null||_instance.IsDisposed)
                {
                    _instance = new FrmRoom();
                }
                return _instance; }
       
        }


        private void FrmRoom_Load(object sender, EventArgs e)
        {
            LoadRoomByDelFlag(0);
        }

        private void LoadRoomByDelFlag(int p)
        {
            RoomInfoBll bll = new RoomInfoBll();
            dgvRoomInfo.AutoGenerateColumns = false;
            dgvRoomInfo.DataSource = bll.GetAllRoomInfoByDelFlag(p);
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            FrmChangeRoom fcr = new FrmChangeRoom();
            fcr.FormClosed += new FormClosedEventHandler(fcr_FormClosed);
            fcr.Show();
        }

        private void fcr_FormClosed(object sender, FormClosedEventArgs e)
        {
            LoadRoomByDelFlag(0);
        }
    }
}
