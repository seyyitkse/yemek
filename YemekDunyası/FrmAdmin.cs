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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void BtnGiris_Click(object sender, EventArgs e)
        {
            if (TxtSifre.Text == "" && TxtKullaniciAd.Text == "")
            {
                MessageBox.Show("Şifre ya da kullanıcı adı boş geçilemez. Lütfen tekrar deneyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                DbUrunEntity kullanici = new DbUrunEntity();

                var girisYap = from bilgi in kullanici.TBL_ADMİN where bilgi.AdminAD == TxtKullaniciAd.Text && bilgi.AdminSifre == TxtSifre.Text select bilgi;
                if (girisYap.Any())
                {
                    FrmRestoranIslem frmRestoran= new FrmRestoranIslem();
                    frmRestoran.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Hatalı şifre ya da ID girdiniz. Lütfen tekrar deneyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
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

        private void BtnAnaSayfa_Click(object sender, EventArgs e)
        {
            FrmAnaGiris frmGeri=new FrmAnaGiris();
            frmGeri.Show();
            this.Hide();
        }
    }
}
