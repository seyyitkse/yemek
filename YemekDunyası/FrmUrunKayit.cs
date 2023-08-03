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
    public partial class FrmUrunKayit : Form
    {
        public FrmUrunKayit()
        {
            InitializeComponent();
        }
        DbUrunEntity urunIslem = new DbUrunEntity();


        public void urunListele()
        {
            dataGridView1.DataSource = (from bilgi in urunIslem.TBL_URUN
                                        select new
                                        {
                                            bilgi.UrunID,
                                            bilgi.UrunAD,
                                            bilgi.UrunFiyat,
                                            bilgi.UrunStok,
                                            bilgi.UrunResim,
                                            bilgi.UrunKategori,
                                        }).ToList();

        }
        public void kategoriGetir()
        {
            var kategoriGetir = (from kategori in urunIslem.TBL_KATEGORI
                                 select new
                                 {
                                     kategori.KategoriID,
                                     kategori.KategoriAD,
                                 }).ToList();

            CmbKategori.ValueMember = "KategoriID";
            CmbKategori.DisplayMember = "KategoriAD";
            CmbKategori.DataSource = kategoriGetir;
        }

        private void FrmUrunKayit_Load(object sender, EventArgs e)
        {
            kategoriGetir();
            CmbKategori.Text = "";
            urunListele();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
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



        private void BtnKayit_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text == "" || CmbKategori.SelectedIndex == -1 || TxtFiyat.Text=="" || TxtStok.Text=="" || TxtResim.Text=="")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else if (CmbKategori.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen  kategori seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                TBL_URUN urun = new TBL_URUN();
                urun.UrunAD=TxtAd.Text;
                urun.UrunStok=int.Parse(TxtStok.Text);
                urun.UrunFiyat = int.Parse(TxtFiyat.Text);
                urun.UrunKategori=int.Parse(CmbKategori.SelectedValue.ToString());
                urun.UrunResim=TxtResim.Text;

                urunIslem.SaveChanges();
                MessageBox.Show("Ürün eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                urunListele();
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            urunListele();
        }

        private void BtnResim_Click(object sender, EventArgs e)
        {
            resimSecDialog.ShowDialog();
            urunResimBox.ImageLocation = resimSecDialog.FileName;
            TxtResim.Text = resimSecDialog.FileName;        
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                MessageBox.Show("Lütfen silmek istediğiniz restoran kategorisini seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id = int.Parse(TxtID.Text);
                var urunSil = urunIslem.TBL_URUN.Find(id);
                urunIslem.TBL_URUN.Remove(urunSil);
                urunIslem.SaveChanges();
                MessageBox.Show("Ürün silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtFiyat.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtStok.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtResim.Text=dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            urunResimBox.ImageLocation = TxtResim.Text;
            string kategoriID= dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            var sorgu = urunIslem.TBL_KATEGORI.Where(x => x.KategoriID == secilen).Select(x => x.KategoriAD).FirstOrDefault();
            CmbKategori.Text =sorgu;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text == "" || CmbKategori.SelectedIndex == -1 || TxtFiyat.Text == "" || TxtStok.Text == "" || TxtResim.Text == "")
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kategoriyi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int urunID = Convert.ToInt32(TxtID.Text);
                var ID = urunIslem.TBL_URUN.Find(urunID);
                ID.UrunAD = TxtAd.Text;
                ID.UrunFiyat = int.Parse(TxtFiyat.Text);
                ID.UrunResim= TxtResim.Text;
                ID.UrunStok = int.Parse(TxtStok.Text);
                ID.UrunResim=TxtResim.Text;
                ID.UrunKategori= int.Parse(CmbKategori.SelectedValue.ToString());

                urunIslem.SaveChanges();
                urunListele();
                MessageBox.Show("Ürün güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
