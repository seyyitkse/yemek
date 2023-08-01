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
    public partial class FrmKayit : Form
    {
        public FrmKayit()
        {
            InitializeComponent();
        }


        FrmKullaniciGiris kullaniciGeriFrm = new FrmKullaniciGiris();

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Gerçekten çıkmak mı istiyorsunuz ?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (secim == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                kullaniciGeriFrm.Show();
                this.Hide();
            }
        }


        DbUrunEntity kullaniciKayit= new DbUrunEntity();


        private void BtnKayit_Click(object sender, EventArgs e)
        {
            if(TxtAd.Text=="" || TxtSoyad.Text=="" || TxtSifre.Text=="" || TxtNick.Text=="")
            {
                MessageBox.Show("Tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TBL_MUSTERI yeniMusteri = new TBL_MUSTERI();
                yeniMusteri.KullaniciAD = TxtAd.Text;
                yeniMusteri.KullaniciSOYAD = TxtSoyad.Text;
                yeniMusteri.KullaniciNick = TxtNick.Text;
                yeniMusteri.KullaniciSifre = TxtSifre.Text;
                kullaniciKayit.TBL_MUSTERI.Add(yeniMusteri);
                kullaniciKayit.SaveChanges();
           
                DialogResult secim = MessageBox.Show("Kullanıcı kaydedildi. Ana menüye dönmek ister misiniz =", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (secim == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else
                {
                    kullaniciGeriFrm.Show();
                    this.Hide();
                }
            }
        }
    }
}
