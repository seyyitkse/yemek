using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekDunyası.Properties;

namespace YemekDunyası
{
    public partial class FrmSepet : Form
    {
        public FrmSepet()
        {
            InitializeComponent();
        }
        EntitiesUrun sepetIslem =new EntitiesUrun();
        FrmSiparis frmsiparis = new FrmSiparis();

        public int kullaniciiD;
        public string kullanicinick;
        private void urunAdet_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown urunAdet = (NumericUpDown)sender;
            int sepetID = Convert.ToInt32(urunAdet.Tag);

            var sepetUrun = sepetIslem.TBL_SEPET.FirstOrDefault(item => item.SepetID == sepetID);
            var urun = sepetIslem.TBL_URUN.FirstOrDefault(p => p.UrunID == sepetUrun.UrunID);
            int urunStok = urun?.UrunStok ?? 0;

            if (urunAdet.Value > urunStok)
            {
                MessageBox.Show("Stok yetersiz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                urunAdet.Value = urunStok;
                return;
            }

            sepetUrun.UrunEklenen = Convert.ToInt32(urunAdet.Value);
            sepetIslem.SaveChanges();
            MessageBox.Show("Sayı güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void sepetUrunGetir()
        {

            var sepetSiparisler = from item in sepetIslem.TBL_SEPET
                                  where item.KullanıcıID == kullaniciiD
                                  group item by item.SepetID into g
                                  select new
                                  {
                                      SiparisID = g.Key,
                                      Urunler = g.ToList()
                                  };
            int resimX = 50;
            int resimY = 50;
            int labelX = 214;
            int labelY = 115;
            int numericX = 326;
            int numericY = 113;
            int butonX = 415;
            int butonY = 113;

            foreach (var siparis in sepetSiparisler)
            {
                panel1.AutoScroll = true;

                foreach (var urunSiparisi in siparis.Urunler)
                {
                    var urun = sepetIslem.TBL_URUN.FirstOrDefault(p => p.UrunID == urunSiparisi.UrunID);
                    int urunID = urun.UrunID;
                    var sepetID = (from item in sepetIslem.TBL_SEPET
                                   where item.UrunID == urunID && item.KullanıcıID == kullaniciiD
                                   select item.SepetID).FirstOrDefault();
                    var urunSayi = sepetIslem.TBL_SEPET
                           .FirstOrDefault(a => a.UrunID == urunSiparisi.UrunID && a.SepetID == siparis.SiparisID);
                    var urunStok = sepetIslem.TBL_URUN.FirstOrDefault(p => p.UrunID == urunSiparisi.UrunID)?.UrunStok ?? 0;


                    if (urun != null && urunSayi != null)
                    {
                        Label lblUrunAdi = new Label();
                        PictureBox resimUrun = new PictureBox();
                        NumericUpDown urunAdet = new NumericUpDown();
                        Button yeniButon = new Button();

                        lblUrunAdi.Text = urun.UrunAD;
                        lblUrunAdi.Location = new Point(labelX, labelY);
                        lblUrunAdi.AutoSize = true;
                        lblUrunAdi.Tag = urun.UrunID;


                        resimUrun.Height = 100;
                        resimUrun.Width = 100;
                        resimUrun.Location = new Point(resimX, resimY);
                        resimUrun.ImageLocation = urun.UrunResim;
                        resimUrun.SizeMode = PictureBoxSizeMode.Zoom;

                        urunAdet.Tag = urunSayi.SepetID;
                        urunAdet.Value = Convert.ToInt32(urunSayi.UrunEklenen);
                        urunAdet.Width = 43;
                        urunAdet.Height = 26;
                        urunAdet.Location = new Point(numericX, numericY);
                        urunAdet.ValueChanged += urunAdet_ValueChanged;

                        yeniButon.Location = new Point(butonX, butonY);
                        yeniButon.Text = "Ürünü Sil";
                        yeniButon.AutoSize = true;
                        yeniButon.BackColor = Color.White;
                        yeniButon.Tag = sepetID;
                        yeniButon.Click += new EventHandler(yeniButon_Click);

                        //
                        //urunAdet.Value > urunStok && urunAdet.ValueChanged == true && urunAdet.Tag == urun.UrunID


                        panel1.Controls.Add(lblUrunAdi);
                        panel1.Controls.Add(resimUrun);
                        panel1.Controls.Add(urunAdet);
                        panel1.Controls.Add(yeniButon);
                        labelY += 194;
                        resimY += 192;
                        numericY += 194;
                        butonY += 194;
                    }
                }

            }
        }


        private void yeniButon_Click(object sender, EventArgs e)
        {
            Button tiklanmisButon = (Button)sender;
            int sepetId = (int)tiklanmisButon.Tag;

            using (var context = new EntitiesUrun()) // SepetIslem nesnesinin yerine gerçek bağlantı nesnesi kullanılmalı
            {
                var sepetOgesi = context.TBL_SEPET.FirstOrDefault(item => item.SepetID == sepetId);

                if (sepetOgesi != null)
                {
                    DialogResult secim = MessageBox.Show("Ürünü kaldırmak istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    if (secim == DialogResult.OK)
                    {
                        context.TBL_SEPET.Remove(sepetOgesi);
                        context.SaveChanges();

                        panel1.Controls.Clear();
                        sepetUrunGetir();
                        MessageBox.Show("Ürün kaldırıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ürün kaldırılmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void FrmSepet_Load(object sender, EventArgs e)
        {

            //int resimX = 50;
            //int resimY = 50;
            //int labelX = 214;
            //int labelY = 115;
            //int numericX = 326;
            //int numericY = 113;
            //int panelX = 13;
            //int panelY = 25;
            lblnick.Text = kullanicinick;
            
            sepetUrunGetir();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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

        private void BtnSepetTemizle_Click(object sender, EventArgs e)
        {
            DialogResult secim = MessageBox.Show("Sepeti temizlemek istediğinize emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (secim == DialogResult.OK) 
            {
                var sepetUrunler = from item in sepetIslem.TBL_SEPET
                                   where item.KullanıcıID == kullaniciiD
                                   select item;

                foreach (var urun in sepetUrunler)
                {
                    sepetIslem.TBL_SEPET.Remove(urun);
                }

                sepetIslem.SaveChanges();

                // Arayüzdeki dinamik kontrol öğelerini temizleyin
                panel1.Controls.Clear();

                // Kullanıcının sepetini temizledikten sonra gerekirse bir mesaj gösterin
                MessageBox.Show("Sepetiniz başarıyla temizlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Sepet temizlenmedi !!!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void BtnSiparisEkran_Click(object sender, EventArgs e)
        {
            frmsiparis.kullaniciid = kullaniciiD;
            frmsiparis.kullaniciNick = lblnick.Text;
            frmsiparis.Show();
            
        }
    }
}
