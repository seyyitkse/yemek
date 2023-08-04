using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        DbUrunEntity siparisIslem = new DbUrunEntity();
       

        
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
        private void FrmSiparis_Load(object sender, EventArgs e)
        {
            //var sorgu = siparisIslem.TBL_URUN.ToList();

            //var girisYap = from bilgi in siparisIslem.TBL_URUN
            //               where bilgi.UrunKategori == 4
            //               select new
            //               {
            //                   bilgi.UrunResim,
            //                   bilgi.UrunAD,
            //                   bilgi.UrunKategori,
            //               };

            ////int yKonum = 50;
            //int xKonum = 40;
            //int butonX = 35;
            //int resimY = 35;
            //foreach (var bilgi in girisYap)
            //{

            //    string lblYazi = bilgi.UrunAD;
            //    Label lblDeneme = new Label();
            //    PictureBox resimUrun = new PictureBox();
            //    NumericUpDown yeniArtis = new NumericUpDown();
            //    Button yeniButon = new Button();
            //    tabPage1.Name = bilgi.UrunAD;

            //    lblDeneme.Text = lblYazi;
            //    lblDeneme.Location = new Point(xKonum, 280);
            //    lblDeneme.AutoSize = true;

            //    resimUrun.Height = 150;
            //    resimUrun.Width = 100;
            //    resimUrun.Location = new Point(resimY, 130);
            //    resimUrun.ImageLocation = bilgi.UrunResim;
            //    resimUrun.SizeMode = PictureBoxSizeMode.Zoom;

            //    yeniArtis.Location = new Point(20 + xKonum, 300);
            //    yeniArtis.Width = 40;
            //    yeniArtis.Height = 40;

            //    yeniButon.Location = new Point(butonX, 340);
            //    yeniButon.Text = "Sepete Ekle";
            //    yeniButon.AutoSize = true;
            //    yeniButon.BackColor = Color.White;

            //    panel1.AutoScroll = true;

            //    panel1.Controls.Add(lblDeneme);
            //    panel1.Controls.Add(resimUrun);
            //    panel1.Controls.Add(yeniArtis);
            //    panel1.Controls.Add(yeniButon);

            //    butonX += 200;
            //    xKonum += 200;
            //    resimY += 200;
            //}

            //try
            //{
            //    var categories = siparisIslem.TBL_URUN.ToList();

            //    TabControl tabControl = new TabControl();
            //    tabControl.Width = 1005;
            //    tabControl.Height = 570;
            //    tabControl.Location=new Point(200, 150);
            //    foreach (var category in categories)
            //    {
            //        TabPage tabPage = new TabPage(category.UrunRestoran.ToString());
            //        tabPage.Name = $"tabPage_{category.UrunKategori}";

            //        var products = siparisIslem.TBL_RESTORAN.Where(p => p.RestoranID == category.UrunRestoran).ToList();

            //        foreach (var product in products)
            //        {
            //            Label label = new Label();
            //            label.Text = product.RestoranAD;
            //            label.AutoSize = true;
            //            tabPage.Controls.Add(label);
            //        }

            //        tabControl.TabPages.Add(tabPage);
            //    }

            //    this.Controls.Add(tabControl);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            //}

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
                    var products = siparisIslem.TBL_URUN.Where(p => p.UrunKategori == category.KategoriID ).ToList();
                    //                var products = siparisIslem.TBL_URUN
                    //.Where(p => p.UrunKategori == category.KategoriID)
                    //.OrderBy(p => p.UrunFiyat) // Fiyata göre küçükten büyüğe sırala
                    //.FirstOrDefault(); 
                    int yKonum = 50;
                    int xKonum = 40;
                    int numericKonum = 30;
                    int butonX = 25;
                    foreach (var product in products)
                    {
                        string lblYazi = product.UrunAD;
                        Label lblDeneme = new Label();
                        PictureBox resimUrun = new PictureBox();
                        NumericUpDown yeniArtis = new NumericUpDown();
                        Button yeniButon = new Button();
                        tabPage.Name = product.UrunAD;
                        yeniButon.Click +=(sender)
                            {

                        }
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

                        yeniButon.Location = new Point(butonX, 380);
                        yeniButon.Text = "Sepete Ekle";
                        yeniButon.AutoSize = true;
                        yeniButon.BackColor = Color.White;

                        yeniButon.Click += (sender, e) =>
                        {
                            // Butona tıklandığında çalışacak kodlar burada olacak
                            // Ürünü sepete eklemek için gerekli işlemleri yapabilirsiniz
                            sepet.Add(product); // Örnek olarak ürünü sepet listesine ekleyelim

                            // veya sepete eklenen ürünün adını kullanıcıya bildirelim
                            MessageBox.Show($"{product.UrunAD} sepete eklendi.");

                            // Daha sonra isterseniz sepete eklenen ürünleri başka bir formda veya başka bir yerde göstermek için bu sepet listesini kullanabilirsiniz.
                        };
                        // Ürünü satan restoranları dinamik olarak getirme ve Checkbox'lara liste oluşturma
                        var restorans = siparisIslem.TBL_RESTORAN.Where(r => r.RestoranID == product.UrunRestoran).ToList();
                        int restoranYKonum = yKonum + 250;

                        //foreach (var restoran in restorans)
                        //{
                        //    CheckBox checkBoxRestoran = new CheckBox();
                        //    checkBoxRestoran.Text = restoran.RestoranAD;
                        //    checkBoxRestoran.Location = new Point(numericKonum, 320);
                        //    checkBoxRestoran.AutoSize = true;

                        //    tabPage.Controls.Add(checkBoxRestoran);

                        //    restoranYKonum += 20; // Yeni restoran bilgilerini alt alta listelemek için
                        //}

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


            //try
            //{
            //    var categories = siparisIslem.TBL_KATEGORI.ToList();

            //    TabControl tabControl = new TabControl();
            //    tabControl.Width = 1037;
            //    tabControl.Height = 712;
            //    tabControl.Location = new Point(0, 126);
            //    foreach (var category in categories)
            //    {
            //        TabPage tabPage = new TabPage(category.KategoriAD);
            //        tabPage.Name = $"tabPage_{category.KategoriID}";
            //        tabPage.AutoScroll = true;
            //        var products = siparisIslem.TBL_URUN.Where(p => p.UrunKategori == category.KategoriID).ToList();

            //        int yKonum = 50;
            //        int xKonum = 40;
            //        int butonX = 35;
            //        int resimY = 35;

            //        int numericKonum = 30;

            //        foreach (var product in products)
            //        {
            //            string lblYazi = product.UrunAD;
            //            Label lblDeneme = new Label();
            //            PictureBox resimUrun = new PictureBox();
            //            NumericUpDown yeniArtis = new NumericUpDown();
            //            Button yeniButon = new Button();
            //            tabPage1.Name = product.UrunAD;

            //            lblDeneme.Text = lblYazi;
            //            lblDeneme.Location = new Point(butonX, 280);
            //            lblDeneme.AutoSize = true;

            //            resimUrun.Height = 150;
            //            resimUrun.Width = 100;
            //            resimUrun.Location = new Point(numericKonum, 130);
            //            resimUrun.ImageLocation = product.UrunResim;
            //            resimUrun.SizeMode = PictureBoxSizeMode.Zoom;

            //            yeniArtis.Location = new Point(20 + numericKonum, 300);
            //            yeniArtis.Width = 40;
            //            yeniArtis.Height = 40;

            //            yeniButon.Location = new Point(butonX, 360);
            //            yeniButon.Text = "Sepete Ekle";
            //            yeniButon.AutoSize = true;
            //            yeniButon.BackColor = Color.White;
            //            butonX += 200;
            //            numericKonum += 200;

            //            tabPage.Controls.Add(lblDeneme);
            //            tabPage.Controls.Add(resimUrun);
            //            tabPage.Controls.Add(yeniArtis);
            //            tabPage.Controls.Add(yeniButon);

            //            yKonum += 250;

            //            // Ürünü satan restoranları dinamik olarak getirme ve Checkbox'lara liste oluşturma
            //            var restorans = siparisIslem.TBL_RESTORAN.Where(r => r.RestoranID == product.UrunRestoran).ToList();
            //            int restoranYKonum = yKonum;

            //            foreach (var restoran in restorans)
            //            {
            //                CheckBox checkBoxRestoran = new CheckBox();
            //                checkBoxRestoran.Text = restoran.RestoranAD;
            //                checkBoxRestoran.Location = new Point(xKonum, restoranYKonum);
            //                checkBoxRestoran.AutoSize = true;

            //                tabPage.Controls.Add(checkBoxRestoran);

            //                restoranYKonum += 20; // Yeni restoran bilgilerini alt alta listelemek için
            //            }
            //        }

            //        tabControl.TabPages.Add(tabPage);
            //    }

            //    this.Controls.Add(tabControl);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            //}
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

       
    }
}
