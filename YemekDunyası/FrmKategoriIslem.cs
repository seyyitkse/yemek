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
    public partial class FrmKategoriIslem : Form
    {
        public FrmKategoriIslem()
        {
            InitializeComponent();
        }
        DbUrunEntity kategoriIslem=new DbUrunEntity();
        
        public void listele()
        {
            var listele = (from bilgi in kategoriIslem.TBL_KATEGORI
                           select new
                           {
                               bilgi.KategoriID,
                               bilgi.KategoriAD,
                           }).ToList();
            dataGridView1.DataSource = listele;
        }

        private void FrmKategoriIslem_Load(object sender, EventArgs e)
        {
            listele();
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }
  

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            if (TxtKategoriAd.Text == "" || TxtID.Text == "")
            {
                MessageBox.Show("Tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bool kullaniciAdiVarMi = kategoriIslem.TBL_KATEGORI.Any(k => k.KategoriAD == TxtKategoriAd.Text);

                if (kullaniciAdiVarMi)
                {
                    MessageBox.Show("Bu kategori zaten mevcut.Yeni bir kategori eklemeyi deneyin.", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
                else
                {
                    TBL_KATEGORI yeniKategori = new TBL_KATEGORI();
                    yeniKategori.KategoriAD = TxtKategoriAd.Text;
                    kategoriIslem.TBL_KATEGORI.Add(yeniKategori);
                    kategoriIslem.SaveChanges();
                    MessageBox.Show("Kategori kaydedildi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listele();
                }
            }
        }


        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtID.Text=="")
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kategoriyi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int kategoriID = Convert.ToInt32(TxtID.Text);
                var ID = kategoriIslem.TBL_KATEGORI.Find(kategoriID);
                ID.KategoriAD = TxtKategoriAd.Text;
                kategoriIslem.SaveChanges();
                listele();
                MessageBox.Show("Kategori güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kategoriyi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id = int.Parse(TxtID.Text);
                var kategoriSil = kategoriIslem.TBL_KATEGORI.Find(id);
                kategoriIslem.TBL_KATEGORI.Remove(kategoriSil);
                kategoriIslem.SaveChanges();
                MessageBox.Show("Kategori silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtKategoriAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void BtnAnaSayfa_Click(object sender, EventArgs e)
        {
            FrmAnaGiris geriFrm= new FrmAnaGiris();
            geriFrm.Show();
            this.Hide();
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
    }
}
