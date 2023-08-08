using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekDunyası.Properties;

namespace YemekDunyası
{
    public partial class FrmUrunKayit : Form
    {
        public FrmUrunKayit()
        {
            InitializeComponent();
        }
        EntitiesUrun urunIslem = new EntitiesUrun();


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
                                            bilgi.UrunRestoran,
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

        public void restoranGetir()
        {
            var restoranGetir=(from restoran in urunIslem.TBL_RESTORAN
                               select new
                               { restoran.RestoranID,
                               restoran.RestoranAD,
                               }).ToList ();
            CmbRestoran.ValueMember = "RestoranID";
            CmbRestoran.DisplayMember = "RestoranAD";
            CmbRestoran.DataSource = restoranGetir;
        }

        private void FrmUrunKayit_Load(object sender, EventArgs e)
        {
            kategoriGetir();
            urunListele();
            restoranGetir();
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
                urun.UrunRestoran = int.Parse(CmbRestoran.SelectedValue.ToString());
                urunIslem.TBL_URUN.Add(urun);
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
            TxtResim.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            urunResimBox.ImageLocation = TxtResim.Text;

            string kategoriID = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            string restoranID = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            int kategori = int.Parse(kategoriID);
            int restoran = int.Parse(restoranID);

            // Kategori adını alma
            var kategoriSorgu = urunIslem.TBL_KATEGORI.Where(x => x.KategoriID == kategori).Select(x => x.KategoriAD).FirstOrDefault();
            CmbKategori.Text = kategoriSorgu;

            // Restoran adını alma
            var restoranSorgu = urunIslem.TBL_RESTORAN.Where(x => x.RestoranID == restoran).Select(x => x.RestoranAD).FirstOrDefault();
            CmbRestoran.Text = restoranSorgu;

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
                ID.UrunRestoran=int.Parse(CmbRestoran.SelectedValue.ToString());
                urunIslem.SaveChanges();
                urunListele();
                MessageBox.Show("Ürün güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnKategori_Click(object sender, EventArgs e)
        {
            FrmKategoriIslem frmKategori = new FrmKategoriIslem();
            frmKategori.Show();
            this.Hide();
        }
        private void BtnAnaSayfa_Click(object sender, EventArgs e)
        {
            FrmAnaGiris frmGiris=new FrmAnaGiris();
            frmGiris.Show();
            this.Hide();
        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            FrmAdmin frmAdmin = new FrmAdmin();
            frmAdmin.Show();
            this.Hide();
        }

        private void BtnRestoranIslem_Click(object sender, EventArgs e)
        {
            FrmRestoranIslem frmRestoran=new FrmRestoranIslem();
            frmRestoran.Show();
            this.Hide();
        }

    
    }
}
