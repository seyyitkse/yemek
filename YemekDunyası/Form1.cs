using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekDunyası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            DialogResult secim= MessageBox.Show("Gerçekten sipariş vermeden çıkmak mı istiyorsunuz ?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (secim==DialogResult.OK) 
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Gitmediğinize sevindik :)", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {

        }
    }
}
