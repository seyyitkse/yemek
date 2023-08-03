using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekDunyası
{
    public partial class FrmRestoranIslem : Form
    {
        public FrmRestoranIslem()
        {
            InitializeComponent();
        }
        DbUrunEntity restoranIslem=new DbUrunEntity ();

        FrmAnaGiris geriFrm = new FrmAnaGiris();

        public void restoranListele()
        {
            dataGridView1.DataSource = restoranIslem.restoranBilgi().ToList();   
        }

        private void FrmRestoranKayit_Load(object sender, EventArgs e)
        {
           

            dataGridView1.DataSource = restoranIslem.restoranBilgi().ToList();
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            if (TxtAd.Text=="" || checkedListBox1.CheckedItems.Count==0)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                List<string> secilenDegerler = new List<string>();

                foreach (object item in checkedListBox1.CheckedItems)
                {
                    secilenDegerler.Add(item.ToString());
                }

                var sorgu = from kategoriler in restoranIslem.TBL_KATEGORI
                            where secilenDegerler.Contains(kategoriler.KategoriAD)
                            select kategoriler.KategoriID;

                List<int> idListesi = sorgu.ToList();
                int kategoriIndex = 0;

                while (kategoriIndex < idListesi.Count)
                {
                    TBL_RESTORAN yeniRestoran = new TBL_RESTORAN
                    {
                        RestoranAD = TxtAd.Text,
                        //RestoranKATEGORI = idListesi[kategoriIndex]
                    };

                    restoranIslem.TBL_RESTORAN.Add(yeniRestoran);

                    kategoriIndex++;
                }

                restoranIslem.SaveChanges();
                MessageBox.Show("Restoran eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

        }

        private void BtnAnaSayfa_Click(object sender, EventArgs e)
        {
            geriFrm.Show();
            this.Hide();
        }
        private void BtnKategori_Click(object sender, EventArgs e)
        {
            FrmKategoriIslem kategoriIslem = new FrmKategoriIslem();
            kategoriIslem.Show();
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

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            FrmAdmin geriAdmin = new FrmAdmin();
            geriAdmin.Show();
            this.Hide();    
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            restoranListele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //kategori ad ve checklistteki ad aynı mı onu kodlayacaksın

            int secim = dataGridView1.SelectedCells[0].RowIndex;
            TxtID.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            //lblPuan.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
                var restoranSil = restoranIslem.TBL_RESTORAN.Find(id);
                restoranIslem.TBL_RESTORAN.Remove(restoranSil);
                restoranIslem.SaveChanges();
                MessageBox.Show("Restoran silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (TxtID.Text == "")
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kategoriyi seçiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int restoranID = Convert.ToInt32(TxtID.Text);
                var ID = restoranIslem.TBL_RESTORAN.Find(restoranID);
                ID.RestoranAD = TxtAd.Text;
                restoranIslem.SaveChanges();
                restoranListele();
                MessageBox.Show("Restoran kategori güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUrunIslem_Click(object sender, EventArgs e)
        {
            FrmUrunKayit frmUrunIslem=new FrmUrunKayit();
            frmUrunIslem.Show();
            this.Hide();
        }
    }
    
}
