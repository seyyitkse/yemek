using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YemekDunyası
{
    public partial class FrmRestoranKayit : Form
    {
        public FrmRestoranKayit()
        {
            InitializeComponent();
        }
        DbUrunEntity restoranKayit=new DbUrunEntity ();

        FrmAnaGiris geriFrm = new FrmAnaGiris();

        private void FrmRestoranKayit_Load(object sender, EventArgs e)
        {
            List<string> dataList = restoranKayit.TBL_KATEGORI.Select(item => item.KategoriAD).ToList();

            // Verileri ListBox'a aktar
            foreach (string data in dataList)
            {
                checkedListBox1.Items.Add(data);
            }
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            if ( TxtAd.Text == "" || checkedListBox1.CheckedItems.Count==0 )
            {
                MessageBox.Show("Tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                TBL_RESTORAN yeniRestoran = new TBL_RESTORAN();
                yeniRestoran.RestoranAD = TxtAd.Text;

                List<int> secilenKategoriList = new List<int>();
                foreach (object item in checkedListBox1.CheckedItems)
                {
                    int kategoriId;
                    if (int.TryParse(item.ToString(), out kategoriId))
                    {
                        secilenKategoriList.Add(kategoriId);
                    }
                }

               

                restoranKayit.TBL_RESTORAN.Add(yeniRestoran);
                restoranKayit.SaveChanges();

                DialogResult secim = MessageBox.Show("Kullanıcı kaydedildi. Ana menüye dönmek ister misiniz =", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (secim == DialogResult.Cancel)
                {
                    Application.Exit();
                }
                else
                {
                    geriFrm.Show();
                    this.Hide();
                }
            }
        }

        private void BtnAnaSayfa_Click(object sender, EventArgs e)
        {
            
            geriFrm.Show();
            this.Hide();
        }
    }
}
