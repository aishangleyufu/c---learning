using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 石头剪刀布
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStone_Click(object sender, EventArgs e)
        {
            string str = "石头";
            PlayGame(str);
        }

        private void PlayGame(string str)
        {
            lblPlayer.Text = str;

            Player player = new Player();
            int playernumber = player.SHowFist(str);

            Computer compueter = new Computer();
            int cpunumber = compueter.ShowFist();
            lblComputer.Text = compueter.Fist;

            Result res = Caipan.Judge(playernumber, cpunumber);

            lblResult.Text = res.ToString();
        }

        private void lblPlayer_Click(object sender, EventArgs e)
        {

        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            string str = "剪刀";
            PlayGame(str);
            
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            string str = "布";
            PlayGame(str);
            
        }
    }
}
