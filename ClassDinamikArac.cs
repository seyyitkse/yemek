using System;


public class Class1
{
	public static pictureBoxOlustur()
	{
        System.Windows.Forms.Label lbl = new System.Windows.Forms.Label();
        //1. sıra için döngüm
        for (int i = 1; i < 30; i++)
        {
            //Buton sınıfımdan nesne türettim. 
            System.Windows.Forms.Label resim = new System.Windows.Forms.Label();

            //Point sınıfından nesne türetip, X ve Y koordinatlarının değerlerini verdim.
            Point konum = new Point(i * 100, 200);

            //X ve Y koordinatlarını butona aktardım.
            resim.Location = konum;

            //Butona ilişkin diğer özelliklerimi atadım.
            resim.Text = i.ToString() + "A";
            resim.Height = 100;
            resim.Width = 50;
            resim.Font = new Font(btn.Font.FontFamily, 6);

            //Butonu forma ekledim.
            this.Controls.Add(resim);

        }
        public static class butonOlustur()
        {
        System.Windows.Forms.Button btn = new System.Windows.Forms.Button();
            //1. sıra için döngüm
            for (int i = 1; i< 30; i++)
            {
                //Buton sınıfımdan nesne türettim. 
               System.Windows.Forms.ListBox resim = new System.Windows.Forms.ListBox();

                //Point sınıfından nesne türetip, X ve Y koordinatlarının değerlerini verdim.
                Point konum = new Point(i * 100, 100);

                //X ve Y koordinatlarını butona aktardım.
                 resim.Location = konum;

                //Butona ilişkin diğer özelliklerimi atadım.
                resim.Text = i.ToString() + "A";
                resim.Height = 100;
                resim.Width = 50;
                resim.Font = new Font(btn.Font.FontFamily, 6);

                //Butonu forma ekledim.
                this.Controls.Add(resim);

            }
}

}
}
