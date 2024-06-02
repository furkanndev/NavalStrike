
/*
FURKAN GÜLTEKİN B221200388 NDP PROJE
*/



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Savas.Desktop.AnaForm;

namespace Savas.Desktop
{
    public partial class Form1 : Form
    {
   
        public Form1()
        {
            InitializeComponent();
          
            
        }
        public static string SetValueForText1 = "";
        private void button1_Click(object sender, EventArgs e)
        {
            
            AnaForm form2 = new AnaForm();
            form2.Show();
            this.Hide();

            SetValueForText1 = oyuncu.Text;

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
