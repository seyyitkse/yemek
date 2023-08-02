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
        private object TBL_KATEGORI;

        private void FrmRestoranKayit_Load(object sender, EventArgs e)
        {
            List<string> dataList = restoranKayit.TBL_KATEGORI.Select(item => item.KategoriAD).ToList();

            foreach (string data in dataList)
            {
                checkedListBox1.Items.Add(data);
            }
        }

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            List<string> secilenDegerler = new List<string>();

            foreach (object item in checkedListBox1.CheckedItems)
            {
                secilenDegerler.Add(item.ToString());
            }

            var sorgu = from kategoriler in restoranKayit.TBL_KATEGORI
                        where secilenDegerler.Contains(kategoriler.KategoriAD)
                        select kategoriler.KategoriID;

            List<int> idListesi = sorgu.ToList();
            int kategoriIndex = 0;

            while (kategoriIndex < idListesi.Count)
            {
                TBL_RESTORAN yeniRestoran = new TBL_RESTORAN
                {
                     RestoranAD = TxtAd.Text,
                     RestoranKATEGORI= idListesi[kategoriIndex]
                };

                restoranKayit.TBL_RESTORAN.Add(yeniRestoran);

                kategoriIndex++;
            }

            restoranKayit.SaveChanges();
        }

        private void BtnAnaSayfa_Click(object sender, EventArgs e)
        {
            
            geriFrm.Show();
            this.Hide();
        }
    }
}
