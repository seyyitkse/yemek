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
    public partial class FrmSepet : Form
    {
        public FrmSepet()
        {
            InitializeComponent();
        }
        EntitiesUrun sepetIslem =new EntitiesUrun();
        FrmSiparis frmsiparis = new FrmSiparis();
        public int kullaniciID;
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

            var sepetSiparisler = from item in sepetIslem.TBL_SEPET
                                  where item.KullanıcıID == kullaniciID
                                  group item by item.SepetID into g
                                  select new
                                  {
                                      SiparisID = g.Key,
                                      Urunler = g.ToList()
                                  };

            int resimX = 37;
            int resimY = 25;
            int labelX = 201;
            int labelY = 90;
            int numericX = 313;
            int numericY = 118;
            int panelX = 13;
            int panelY = 25;
            foreach (var siparis in sepetSiparisler)
            {
                panel1.AutoScroll = true;

                foreach (var urunSiparisi in siparis.Urunler)
                {

                    var urun = sepetIslem.TBL_URUN.FirstOrDefault(p => p.UrunID == urunSiparisi.UrunID);

                    if (urun != null)
                    {
                        Label lblUrunAdi = new Label();
                        PictureBox resimUrun = new PictureBox();
                        NumericUpDown urunAdet = new NumericUpDown();

                        lblUrunAdi.Text = urun.UrunAD;
                        lblUrunAdi.Location = new Point(labelX, labelY);
                        lblUrunAdi.AutoSize = true;
                        resimUrun.Height = 150;
                        resimUrun.Width = 100;
                        resimUrun.Location = new Point(resimX, resimY);
                        resimUrun.ImageLocation = urun.UrunResim;
                        resimUrun.SizeMode = PictureBoxSizeMode.Zoom;

                        urunAdet.Width = 43;
                        urunAdet.Height = 26;
                        urunAdet.Location = new Point(numericX, numericY);

                        panel1.Controls.Add(lblUrunAdi);
                        panel1.Controls.Add(resimUrun);
                        panel1.Controls.Add(urunAdet);

                        labelY += 194;
                        resimY += 192;
                        numericY += 194;
                    }
                }

            }
        }
    }
}
