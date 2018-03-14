using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Button)sender).Text="Clicked!";
        Label newbutton = new  Label();
          
         newbutton.Text = "New Button ";
   ;
            newbutton.Click += new EventHandler(newbutton_Click);
       
            Controls.Add(newbutton);
        
        }

        private void newbutton_Click(object sender, EventArgs e)
        {

            ((Label)sender).Text = "Clicked!!";
        }

    
    }
}
