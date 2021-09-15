using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace hastaaa
{
    public partial class Hastakayit : Form
    {
        public Hastakayit()
        {
            InitializeComponent();
        }
       
        public void HataMesaj(string mesaj)
        {
            MessageBox.Show(mesaj, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void TamamlandiMesaj(string mesaj)
        {
            MessageBox.Show(mesaj, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void HastaResimEkle()
        {
            try
            {
                string dosyadi = adBox.Text + ".jpg";
                bool dosya = File.Exists(Application.StartupPath + "\\Hasta Resim\\" + adBox.Text + ".jpg");
                if (dosya)
                {
                    File.Delete(Application.StartupPath + "\\Hasta Resim\\" + adBox.Text + ".jpg");
                }

                File.Copy(openFileDialog_HastaResim.FileName, Application.StartupPath + "\\Hasta Resim\\" + adBox.Text + ".jpg");
            }
            catch (Exception)
            {
                
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GirisEkrani anaekran = new GirisEkrani();
            anaekran.Show();
            this.Hide();
        }
        private void label26_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void label13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public bool Hatalar()
        {
            TextBox[] t = { adBox, soyadBox, anneadBox, babaadBox, dyeriBox, epostaBox, sifreBox, adresBox };
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i].Text == "")
                {
                    HataMesaj("Lütfen Boş Bırakmayınız!");
                    return true;
                }
            }
            if (tcBox.MaskFull == false) { HataMesaj("TC Kimlik NUmaranızı Doğru Giriniz."); return true; }
            else if (sifreBox.Text.Length < 4 || sifreBox.Text.Length > 15) {HataMesaj("Şifre En Az 4, En Fazla 15 Karakterli Olmalı."); return true; }
            else if (sifreBox.Text != sifretkrrBox.Text) { HataMesaj("Lütfen Şifrenizi Doğru Giriniz."); return true; }
            else if (telnoBox.MaskFull == false) { HataMesaj("Size Ulaşabileceğimiz Bir Telefon Numarası Giriniz."); return true; }
            else if (epostaBox.Text == "") { HataMesaj("Lütfen E-Posta Adresinizi Giriniz."); return true; }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox_HastaResim.Image == null) { openFileDialog_HastaResim.FileName = ""; }
                Hastalar hasta = new Hastalar();
                hasta.H_ad = adBox.Text;
                hasta.H_soyad = soyadBox.Text;
                hasta.H_annead = anneadBox.Text;
                hasta.H_babad = babaadBox.Text;
                hasta.H_dyeri = dyeriBox.Text;
                hasta.H_eposta = epostaBox.Text;
                hasta.H_sifre = sifreBox.Text;
                hasta.H_tc = tcBox.Text;
                hasta.H_tel = telnoBox.Text;
                hasta.H_dtarih = dateTimePicker1.Value;
                hasta.H_adres = adresBox.Text;
                hasta.H_resim = adBox.Text + ".jpg";
                string cinsiyet = "";
                if (radioButton1.Checked)
                    cinsiyet = radioButton1.Text;
                else if (radioButton2.Checked)
                    cinsiyet = radioButton2.Text;
                else if (radioButton3.Checked)
                    cinsiyet = radioButton3.Text;
                hasta.H_cinsiyet = cinsiyet;

                HastalarDb hastadb = new HastalarDb();
                if (Hatalar() == true) { }
                else
                {
                    hastadb.Ekle(hasta);
                    HastaResimEkle();
                }                                          
        }
        private void sifretkrrBox_TextChanged(object sender, EventArgs e)
        {
            if (sifreBox.Text == sifretkrrBox.Text) { sifretkrrBox.ForeColor = Color.Green; }
            else { sifretkrrBox.ForeColor = Color.Red; }
        }

        private void Hastakayit_Load(object sender, EventArgs e)
        {

        }

        private void button_ResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog_HastaResim.ShowDialog();
            if (openFileDialog_HastaResim.FileName != "")
            {
                pictureBox_HastaResim.ImageLocation = openFileDialog_HastaResim.FileName;
                pictureBox_HastaResim.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button_ResimIptal_Click(object sender, EventArgs e)
        {
            pictureBox_HastaResim.Image = null;
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void Hastakayit_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void Hastakayit_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void Hastakayit_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
