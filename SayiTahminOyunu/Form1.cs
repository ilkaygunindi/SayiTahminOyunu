using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SayiTahminOyunu
{
    public partial class Form1 : Form
    {

        int tahminEdilecekSayi = (new Random()).Next(0, 100);

        int can = 5;

        public Form1()
        {
            InitializeComponent();
        }

        public String kalanCan(int canDegeri)
        {
            string canYazisi = "";

            if (canDegeri == 4)
            {
                canYazisi = "❤❤❤❤✘";
            }
            else if (canDegeri == 3)
            {
                canYazisi = "❤❤❤✘✘";
            }
            else if (canDegeri == 2)
            {
                canYazisi = "❤❤✘✘✘";
            }
            else if (canDegeri == 1)
            {
                canYazisi = "❤✘✘✘✘";
            }
            else if (canDegeri == 0)
            {
                canYazisi = "✘✘✘✘✘";
            }
            return canYazisi;
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnTahmin_Click(object sender, EventArgs e)
        {
            if (can == 0)
            {
                MessageBox.Show("Maalesef canınız kalmadı" + can, "Üzgünüz!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtTahmin.Text == null)
            {
                MessageBox.Show("Lütfen bir değer giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            int tahmin = Convert.ToInt32(txtTahmin.Text);

            can--;

            lblKalanCan.Text = kalanCan(can);

            if (tahmin == tahminEdilecekSayi)
            {
                if (MessageBox.Show("Tahmininiz Doğru! Yeni Oyuna Başlamak İster misiniz?", "!!Tebrikler!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    MessageBox.Show("Uygulama Kapatılıyor.", "Kapatılıyor.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else
            {
                if (can == 0)
                {
                    MessageBox.Show("Oyun Bitti! Bulmanız gereken sayı: " + tahminEdilecekSayi, "Üzgünüz.", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
                    if (MessageBox.Show("Yeni Oyuna Başlamak İster misiniz?", "Bİr El Daha :)", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        MessageBox.Show("Tekrar Görüşmek Üzere. Uygulama Kapatılıyor.", "Kapatılıyor.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                }
                if (tahminEdilecekSayi > tahmin)
                {
                    MessageBox.Show("Tahmininiz Yanlış. Tahmin Değerinizi Büyütün \n Kalan Canınız: " + can, "Üzgünüz!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Tahmininiz Yanlış! Tahmin Değerinizi Küçültün \n Kalan canınız: " + can, "Üzgünüz!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
