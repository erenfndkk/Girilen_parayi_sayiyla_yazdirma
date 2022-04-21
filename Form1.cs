


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nesneye_Dayalı_Programlama_Ödev_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void yaziylaYazdirma(object sender, EventArgs e)
        {
            // yanlış karakter girildi mi diye kontrol etmek için

            foreach (var item in txtSayi.Text)
            {
                if ((Convert.ToInt32(item) < 48 || Convert.ToInt32(item) > 57))
                {
                    if (item != '.')
                    {
                        MessageBox.Show("Lütfen Doğru değerler giriniz...");
                    }

                }
            }

            // tam ve kuruş kısmı ayırmak için
            string[] numbers = txtSayi.Text.Split('.');
            long tamkisim = Convert.ToInt64(numbers[0]);
            long kısımkurus = 0;
            if (numbers.Length == 2)
            {
                kısımkurus = Convert.ToInt32(numbers[1]);
            }

            string[] BirlerB = new string[] { "", "BİR ", "İKİ ", "ÜÇ ", "DÖRT ", "BEŞ ", "ALTI ", "YEDİ ", "SEKİZ ", "DOKUZ " };
            string[] OnlarB = new string[] { "", "ON ", "YİRMİ ", "OTUZ ", "KIRK ", "ELLİ ", "ALTMIŞ ", "YETMİŞ ", "SEKSEN ", "DOKSAN " };
            string[] YuzlerB = new string[] { "", "YÜZ ", "İKİ YÜZ ", "ÜÇ YÜZ ", "DÖRT YÜZ ", "BEŞ YÜZ ", "ALTI YÜZ ", "YEDİ YÜZ ", "SEKİZ YÜZ ", "DOKUZ YÜZ " };
            string[] BinlerB = new string[] { "", "BİN ", " İKİ BİN ", "ÜÇ BİN ", "DÖRT BİN ", "BEŞ BİN ", "ALTI BİN ", "YEDİ BİN ", "SEKİZ BİN ", "DOKUZ BİN " };
            string[] OnbinlerB = new string[] { "", "ON ", "YİRMİ ", "OTUZ ", "KIRK ", "ELLİ ", "ALTMIŞ ", "YETMİŞ ", "SEKSEN ", "DOKSAN " };

            // girilen sayının 5 basamaktan fazla olup olmadığını kontrol etmek için
            if (tamkisim < 0 || tamkisim >= 100000)
            {
                MessageBox.Show("Lütfen geçerli bir değer aralığı giriniz...(1-99999)");
            }
            //sayının tam kısmını yazdırmak için
            else
            {
                long onbinler = tamkisim / 10000;
                tamkisim -= onbinler * 10000;
                long binler = tamkisim / 1000;
                tamkisim -= binler * 1000;
                long yuzler = tamkisim / 100;
                tamkisim -= yuzler * 100;
                long onlar = tamkisim / 10;
                tamkisim -= onlar * 10;
                long birler = tamkisim;

                
                if (binler == 0 && (onbinler <= 9 && onbinler >= 1))
                {
                    lblYazi.Text = (OnbinlerB[onbinler] + "BİN " + YuzlerB[yuzler] + OnlarB[onlar] + BirlerB[birler] + "TL ");
                }
                else
                {
                    lblYazi.Text = (OnbinlerB[onbinler] + BinlerB[binler] + YuzlerB[yuzler] + OnlarB[onlar] + BirlerB[birler] + "TL ");
                }


                // varsa eğer kuruş kısmı yazdırmak için
                if (kısımkurus != 0)
                {
                    long KurusOnlar = kısımkurus / 10;
                    kısımkurus -= KurusOnlar * 10;
                    long Kurusbirler = kısımkurus;
                    lblYazi.Text += (OnlarB[KurusOnlar] + BirlerB[Kurusbirler] + "KURUŞ");
                }
                if (kısımkurus >= 3)
                {
                    MessageBox.Show("Lütfem kuruş kısmını doğru giriniz.");
                }

            }
        }

        TextBox txtSayi = new TextBox();
        Label lblYazi = new Label();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;

            // button eklemek için
            Button btnHesapla = new Button();
            btnHesapla.Width = 150;
            btnHesapla.Height = 50;
            this.Controls.Add(btnHesapla);
            btnHesapla.Text = "Hesapla";
            btnHesapla.BackColor = Color.Red;
            btnHesapla.Location = new Point(250, 200);

            //TextBox eklemek için
            txtSayi.Width = 210;
            txtSayi.Height = 70;
            this.Controls.Add(txtSayi);
            txtSayi.Location = new Point(360, 70);
            txtSayi.Text = "";
            txtSayi.BackColor = Color.White;

            //labelleri eklemek için
            Label label1 = new Label();
            label1.Width = 130;
            label1.Height = 30;
            label1.Text = "girilen sayı";
            this.Controls.Add(label1);
            label1.BackColor = Color.White;
            label1.Location = new Point(130, 70);

            Label label2 = new Label();
            label2.Width = 130;
            label2.Height = 30;
            label2.Text = "girilen sayının yazıyla yazılmış hali";
            this.Controls.Add(label2);
            label2.BackColor = Color.White;
            label2.Location = new Point(130, 120);

            // Yazıyla yazılacak labelin özellikleri
            lblYazi.Width = 210;
            lblYazi.Height = 30;
            lblYazi.Text = "";
            this.Controls.Add(lblYazi);
            lblYazi.BackColor = Color.White;
            lblYazi.Location = new Point(360, 120);

            btnHesapla.Click += new EventHandler(yaziylaYazdirma);
        }
    }
}
