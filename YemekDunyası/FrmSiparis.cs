using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YemekDunyası.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;

namespace YemekDunyası
{
    public partial class FrmSiparis : Form
    {
        public FrmSiparis()
        {
            InitializeComponent();
        }

        EntitiesUrun siparisIslem = new EntitiesUrun();



        //public void kategoriGetir()
        //{
        //    var kategoriGetir = (from kategori in siparisIslem.TBL_KATEGORI
        //                         select new
        //                         {
        //                             kategori.KategoriID,
        //                             kategori.KategoriAD,
        //                         }).ToList();

        //    CmbKategori.ValueMember = "KategoriID";
        //    CmbKategori.DisplayMember = "KategoriAD";
        //    CmbKategori.DataSource = kategoriGetir;
        //}

        FrmKullaniciGiris frmKullanici = new FrmKullaniciGiris();
        public string kullaniciNick;

     
        private void FrmSiparis_Load(object sender, EventArgs e)
        {
            var kullanici = (from item in siparisIslem.TBL_MUSTERI
                             where item.KullaniciNick == kullaniciNick
                             select item.KullaniciID).FirstOrDefault();

            if (kullanici != null)
            {
                if (int.TryParse(kullanici.ToString(), out int kullaniciID))
                {
                    LblKullaniciID.Text = kullaniciID.ToString();
                }
                else
                {
                    // KullaniciID çevrilemiyorsa buraya girebilirsiniz
                    // Hata yönetimi veya uygun bir mesaj gösterimi yapabilirsiniz
                }
            }
        
            try
            {
                var categories = siparisIslem.TBL_KATEGORI.ToList();

                TabControl tabControl = new TabControl();
                tabControl.Width = 1037;
                tabControl.Height = 712;
                tabControl.Location = new Point(0, 126);

                foreach (var category in categories)
                {

                    TabPage tabPage = new TabPage(category.KategoriAD);
                    tabPage.Name = $"tabPage_{category.KategoriID}";
                    tabPage.AutoScroll = true;
                    var products = siparisIslem.TBL_URUN.Where(p => p.UrunKategori == category.KategoriID).ToList();
                    var sorgu = siparisIslem.TBL_URUN.Select(p => p.UrunID).ToList();
                
                    int yKonum = 50;
                    int xKonum = 40;
                    int numericKonum = 30;
                    int butonX = 25;
                    foreach (var product in products)
                    {
                        string lblYazi = product.UrunAD;

                        PictureBox resimUrun = new PictureBox();
                        NumericUpDown yeniArtis = new NumericUpDown();
                        Button yeniButon = new Button();
                        System.Windows.Forms.Label lblDeneme = new System.Windows.Forms.Label();
                        tabPage.Name = product.UrunAD;

                        lblDeneme.Text = lblYazi;
                        lblDeneme.Location = new Point(butonX, 300);
                        //lblDeneme.AutoSize = true;

                        resimUrun.Height = 150;
                        resimUrun.Width = 100;
                        resimUrun.Location = new Point(numericKonum, 130);
                        resimUrun.ImageLocation = product.UrunResim;
                        resimUrun.SizeMode = PictureBoxSizeMode.Zoom;

                        yeniArtis.Location = new Point(20 + numericKonum, 340);
                        yeniArtis.Width = 40;
                        yeniArtis.Height = 40;
                        yeniArtis.Tag = product.UrunID;

                        yeniButon.Location = new Point(butonX, 380);
                        yeniButon.Text = "Sepete Ekle";
                        yeniButon.AutoSize = true;
                        yeniButon.BackColor = Color.White;
                        yeniButon.Name = (product.UrunID).ToString();
                        yeniButon.Tag = product.UrunID;

                        yeniButon.Click += new EventHandler(yeniButon_Click);


                        tabPage.Controls.Add(lblDeneme);
                        tabPage.Controls.Add(resimUrun);
                        tabPage.Controls.Add(yeniArtis);
                        tabPage.Controls.Add(yeniButon);
                        butonX += 200;
                        numericKonum += 200;

                        yKonum += 250;
                    }

                    tabControl.TabPages.Add(tabPage);
                }

                this.Controls.Add(tabControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }

        }
        decimal numericValue;

        public string tagDegeri;
        //private void yeniButon_Click(object sender, EventArgs e)
        //{

        //    Button tiklanmisButon = (Button)sender;
        //    string tag = tiklanmisButon.Tag.ToString();
        //    label2.Text = tag;
        //    tagDegeri = label2.Text;
        //    label5.Text = numericValue.ToString();

        //}

    
        private void yeniButon_Click(object sender, EventArgs e)
        {
            Button tiklanmisButon = (Button)sender;
            int urunId = (int)tiklanmisButon.Tag;

            // NumericUpDown kontrolünü bulun
            foreach (Control control in tiklanmisButon.Parent.Controls)
            {
                if (control is NumericUpDown numericUpDown && (int)numericUpDown.Tag == urunId)
                {
                 
                    if ( numericUpDown.Value !=0)
                    {
                        decimal urunAdet = numericUpDown.Value;
                        MessageBox.Show($"Ürün ID: {urunId}, NumericUpDown Değeri: {urunAdet}");
                        int urunSayi = Convert.ToInt32(urunAdet);
                        TBL_SEPET yeniSepet = new TBL_SEPET();
                        yeniSepet.UrunID = urunId;
                        yeniSepet.KullanıcıID = int.Parse(LblKullaniciID.Text);
                        yeniSepet.UrunEklenen =urunSayi;

                        siparisIslem.TBL_SEPET.Add(yeniSepet);
                        siparisIslem.SaveChanges();

                        MessageBox.Show("Siparişiniz başarıyla eklendi.");
                    }
                    else
                    {
                        MessageBox.Show("Lütfen adet seçiniz !", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabIcecek_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_VisibleChanged(object sender, EventArgs e)
        {

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

        private void BtnSepet_Click(object sender, EventArgs e)
        {
            FrmSepet sepetGetir= new FrmSepet();
            sepetGetir.kullaniciID =Convert.ToInt32(LblKullaniciID.Text);
            sepetGetir.Show();
            this.Hide();
        }
    }

    internal class DBUrunEntities
    {
    }
}
