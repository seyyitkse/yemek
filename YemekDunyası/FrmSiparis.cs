using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace YemekDunyası
{
    public partial class FrmSiparis : Form
    {
        public FrmSiparis()
        {
            InitializeComponent();
        }

        DbUrunEntity siparisIslem = new DbUrunEntity();
       

        public void aracOlustur()
        {
            for (int i = 1; i < 6; i++)
            {
                ListBox resim= new ListBox();
                Label lbl = new Label();

                Point konum = new Point(i * 105, 100);
                Point konumlbl = new Point(i * 110, 250);

                lbl.Location = konumlbl;
                resim.Location = konum;
                
                resim.Height = 82;
                resim.Width = 82;
                this.Controls.Add(resim);
            }
 
            
        }

        private void FrmSiparis_Load(object sender, EventArgs e)
        {
            aracOlustur();
            List<TBL_URUN> urunler = siparisIslem.TBL_URUN.ToList();

            

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
