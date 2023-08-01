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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        

=======
>>>>>>> e436e9c042b6e37e29abcf227c870e998f3dfc4e
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            DialogResult secim= MessageBox.Show("Gerçekten sipariş vermeden çıkmak mı istiyorsunuz ?", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (secim==DialogResult.OK) 
            {
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Gitmediğinize sevindik :)", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
<<<<<<< HEAD

        private void BtnGiris_Click(object sender, EventArgs e)
        {

        }
=======
>>>>>>> e436e9c042b6e37e29abcf227c870e998f3dfc4e
    }
}
