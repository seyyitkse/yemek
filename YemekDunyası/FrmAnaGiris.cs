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
    public partial class FrmAnaGiris : Form
    {
        public FrmAnaGiris()
        {
            InitializeComponent();
        }

        private void BtnSiparis_Click(object sender, EventArgs e)
        {
            FrmKullaniciGiris frmKullanici=new FrmKullaniciGiris();
            frmKullanici.Show();
            this.Hide();
        }

        private void BtnRestoran_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin=new FrmAdmin();
            frmAdmin.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Gerçekten çıkmak mı istiyorsunuz ?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (secim == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Gitmediğinize sevindik :)", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

      
    }
}
