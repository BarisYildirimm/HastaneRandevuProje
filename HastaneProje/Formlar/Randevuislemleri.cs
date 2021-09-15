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
    public partial class Randevuislemleri : Form
    {

        public Randevuislemleri()
        {
            InitializeComponent();
        }

        #region TabDegistirme
        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_RandevuAl;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_RandevuGecmisi;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_HesapBilgileri;
        }

        private void button_Yardım_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_Yardım;
        }
        private void button_HastaneHakkinda_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_HastaneHakkında;
        }
        #endregion
        private void button_Cikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void HastaResimEklee()
        {
            try
            {
                string dosyadi = adBox.Text + ".jpg";
                bool dosya = File.Exists(Application.StartupPath + "\\Hasta Resim\\" + adBox.Text + ".jpg");
                if (dosya)
                {
                    File.Delete(Application.StartupPath + "\\Hasta Resim\\" + adBox.Text + ".jpg");
                }
              File.Delete(Application.StartupPath + "\\Hasta Resim\\" + label_Ad.Text + ".jpg");
                File.Copy(openFileDialog_HastaFotoGüncel.FileName, Application.StartupPath + "\\Hasta Resim\\" + adBox.Text + ".jpg");
            }
            catch (Exception)
            {
                
            }
        }
        public void Getir()
        {
            pictureBox_HastaFoto.ImageLocation = pictureBox_HastaFotoGüncelle.ImageLocation = Application.StartupPath + "//Hasta Resim//" + HastalarDb.resim.ToString();
        }
        string eskiisim = "";
        public void Bilgiler()
        {
            eskiisim = HastalarDb.resim;
            label_Tc.Text = HastalarDb.tc.ToString();
            label_Ad.Text = adBox.Text = HastalarDb.ad.ToString();
            label_Soyad.Text = soyadBox.Text = HastalarDb.soyad.ToString();
            label_Cinsiyet.Text = HastalarDb.cinsiyet.ToString();
            if (HastalarDb.cinsiyet.ToString() == "Erkek") { radioButton1.Checked = true; }
            else if (HastalarDb.cinsiyet.ToString() == "Kız") { radioButton2.Checked = true; }
            else { radioButton3.Checked = true; }
            dyeriBox.Text = HastalarDb.dyeri.ToString();
            //dateTimePicker_GuncelleHasta.Value.ToString() = HastalarDb.dtarih.ToString();
            label_AnneAd.Text = anneadBox.Text = HastalarDb.annead.ToString();
            label_BabaAd.Text = babaadBox.Text = HastalarDb.babaad.ToString();
            textBox_TelNoGunclle.Text = HastalarDb.tel.ToString();
            textBox_SifreGuncel.Text = HastalarDb.sifre.ToString();
            textBox_YeniEpostaGunclle.Text = HastalarDb.eposta.ToString();
            adresBox.Text = HastalarDb.adres.ToString();
        }
        void RandevuListele()
        {
            RandevuDb rdb = new RandevuDb();
            dataGridView_Randevu.DataSource = rdb.RandevuListele();
        }
        void PoliklinikListele()
        {
            BolumlerDb bdb = new BolumlerDb();
            comboBox_Poliklinik.DataSource = bdb.Listele();
            comboBox_Poliklinik.DisplayMember = "Bolum_ad";
            comboBox_Poliklinik.ValueMember = "bolum_id";
            comboBox_Poliklinik.Text = null;
            comboBox_Poliklinik.Text = "Seçiniz...";
        }
        private void button_ResimEkle_Click_1(object sender, EventArgs e)
        {
            string veri = pictureBox_HastaFotoGüncelle.ImageLocation;
            try
            {
                openFileDialog_HastaFotoGüncel.ShowDialog();
                if (openFileDialog_HastaFotoGüncel.FileName == "") { pictureBox_HastaFotoGüncelle.ImageLocation = veri; }
                else { pictureBox_HastaFotoGüncelle.ImageLocation = openFileDialog_HastaFotoGüncel.FileName; }
                
            }
            catch (Exception)
            {
                
            }
               
        }

        public static string text1, text2, text3;
        private void Randevuislemleri_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'hastaKayitDataSet3.Randevu' table. You can move, or remove it, as needed.

            PoliklinikListele();
            Getir();
            Bilgiler();
            RandevuListele();
            label_OgununTarihi.Text = new Admin().label_Tarih.Text.ToString();
            Rectangle rect = new Rectangle(tabPage_KulBilgiler.Left, tabPage_KulBilgiler.Top, tabPage_KulBilgiler.Width, tabPage_KulBilgiler.Height);
            tabControl1.Region = new Region(rect);
            timer1.Start();
            RandevuDb rdb = new RandevuDb();
            rdb.HastaneHakkinda();
            label_BolumSayisi.Text = text1;
            label_Doktor_Sayisi.Text = text2;
            label_HastaSayisi.Text = text3;
        }
        void sifirlasaat()
        {
            Button[] c = { bEx1, bEx2, bEx3, bEx4, bEx5, bEx6, bEx7, bEx8, bEx9, bEx10, bEx11, bEx12, bEx13, bEx14, bEx15, bEx16, bEx17, bEx18, bEx19, bEx20, bEx21, bEx22, bEx23, bEx24, bEx25 };
            for (int i = 0; i < c.Length; i++)
            {
                c[i].Enabled = true;
                c[i].BackColor = pictureBox3.BackColor;
            }
        }
        void ButonSifirlama()
        {
            Button[] c = { bEx1, bEx2, bEx3, bEx4, bEx5, bEx6, bEx7, bEx8, bEx9, bEx10, bEx11, bEx12, bEx13, bEx14, bEx15, bEx16, bEx17, bEx18, bEx19, bEx20, bEx21, bEx22, bEx23, bEx24, bEx25 };
            for (int i = 0; i < c.Length; i++)
            {
                c[i].Enabled = true;
                c[i].BackColor = pictureBox3.BackColor;
            }
            comboBox_DoktorAdlari.Items.Clear();
            comboBox_DoktorAdlari.Text = "";
        }

        private void comboBox_Poliklinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButonSifirlama();
            string b = comboBox_Poliklinik.Text;
            List<string> liste = new List<string>();
            RandevuDb rdb = new RandevuDb();
            liste = rdb.ListeDoldur(b);
            foreach (var item in liste)
            {
                comboBox_DoktorAdlari.Items.Add(item);
            }
        }
        public bool Hatalar()
        {
            TextBox[] t = { adBox, soyadBox, anneadBox, babaadBox, dyeriBox, textBox_YeniEpostaGunclle, textBox_SifreGuncel, adresBox };
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i].Text == "")
                {
                    MessageBox.Show("Lütfen Boş Bırakmayınız!");
                    return true;
                }
            }           
            if (textBox_SifreGuncel.Text.Length < 4 || textBox_SifreGuncel.Text.Length > 15) { MessageBox.Show("Şifre En Az 4, En Fazla 15 Karakterli Olmalı."); return true; }
            else if (textBox_TelNoGunclle.MaskFull == false) { MessageBox.Show("Size Ulaşabileceğimiz Bir Telefon Numarası Giriniz."); return true; }
            else if (textBox_YeniEpostaGunclle.Text == "") { MessageBox.Show("Lütfen E-Posta Adresinizi Giriniz."); return true; }
            return false;
        }
        private void button_GuncelleKimlikBilgileri_Click_1(object sender, EventArgs e)
        {           
                
                HastalarDb hdb = new HastalarDb();
                Hastalar hasta = new Hastalar();
                hasta.H_ad = adBox.Text;
                hasta.H_soyad = soyadBox.Text;
                hasta.H_annead = anneadBox.Text;
                hasta.H_babad = babaadBox.Text;
                hasta.H_dyeri = dyeriBox.Text;
                hasta.H_dtarih = dateTimePicker1.Value;
                hasta.H_adres = adresBox.Text;
                hasta.H_resim = adBox.Text + ".jpg";
                hasta.H_eposta = textBox_YeniEpostaGunclle.Text;
                hasta.H_tel = textBox_TelNoGunclle.Text;
                hasta.H_sifre = textBox_SifreGuncel.Text;

                string cinsiyet = "";
                if (radioButton1.Checked)
                    cinsiyet = radioButton1.Text;
                else if (radioButton2.Checked)
                    cinsiyet = radioButton2.Text;
                else if (radioButton3.Checked)
                    cinsiyet = radioButton3.Text;
                hasta.H_cinsiyet = cinsiyet;

            if (Hatalar() == true) { }
            else {
                if (eskiisim != hasta.H_resim) { File.Move(Application.StartupPath + "\\Hasta Resim\\" + eskiisim, Application.StartupPath + "\\Hasta Resim\\" +hasta.H_resim); }//amk deniz zaten var deniz girme bi deneme yapıyoz tm A:SD
                if (openFileDialog_HastaFotoGüncel.FileName != "")
                {
                    HastaResimEklee();
                }
                hdb.Guncelle(hasta);
                pictureBox_HastaFotoGüncelle.ImageLocation = Application.StartupPath + "\\Hasta Resim\\" + hasta.H_resim;
                eskiisim = hasta.H_resim;
                pictureBox_HastaFoto.ImageLocation = Application.StartupPath + "\\Hasta Resim\\" + hasta.H_resim;
            }
        }
        public bool HataKontrol()
        {
             if (comboBox_DoktorAdlari.Text=="" || comboBox_Poliklinik.Text == "")
            {
                MessageBox.Show("Lütfen Poliklinik Seçinip \n Doktor Adını Giriniz!!");
                return true;
            }
            return false;
        }

        public static string butontxt = "";
        private void button_RandevuEkle_Click(object sender, EventArgs e)
        {
            Randevu r = new Randevu();
            RandevuDb rdb = new RandevuDb();
            if (butontxt != "")
            {
                r.Saat = butontxt;
                r.Poliklinik = comboBox_Poliklinik.Text;
                r.D_ad = comboBox_DoktorAdlari.Text;
                r.Tarih = dateTimePicker1.Value;
                r.H_tc = HastalarDb.tc;
                if (HataKontrol() == true) { }
                else
                {
                    rdb.Ekle(r);
                    MessageBox.Show("Randevu Alınmıştır!!");
                }
                ButonSifirlama();
                comboBox_Poliklinik.Text = "Seçiniz...";
            }
            else { MessageBox.Show("Saat Seçiniz..."); }
            
        }

        private void comboBox_DoktorAdlari_SelectedIndexChanged(object sender, EventArgs e)
        {
            sifirlasaat();
            List<string> liste = new List<string>();
            RandevuDb rdb = new RandevuDb();
            liste = rdb.SaatKontrol(comboBox_DoktorAdlari.Text);

            Button[] c = { bEx1, bEx2, bEx3, bEx4, bEx5, bEx6, bEx7, bEx8, bEx9, bEx10, bEx11, bEx12, bEx13, bEx14, bEx15, bEx16, bEx17, bEx18, bEx19, bEx20, bEx21, bEx22, bEx23, bEx24, bEx25 };
            for (int i = 0; i < c.Length; i++)
            {
                for (int j = 0; j < liste.Count; j++)
                {
                    if (liste[j] == c[i].Text)                    
                    {
                        c[i].Enabled = false;
                        c[i].BackColor = Color.DarkGray;
                    }
                }
            }            
        }
        private void textBox_RandevuAra_TextChanged(object sender, EventArgs e)
        {
            Randevu r = new Randevu();
            r.Poliklinik = textBox_RandevuAra.Text;
            RandevuDb rdb = new RandevuDb();
            string a = HastalarDb.tc.ToString();
            dataGridView_Randevu.DataSource = rdb.RandevuAra(r,a);
        }

        private void button_RandevuSil_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kaydı Silme istiyor musunuz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Randevu r = new Randevu();
            RandevuDb rdb = new RandevuDb();
            r.Islem_no = Convert.ToInt16(dataGridView_Randevu.CurrentRow.Cells[0].Value.ToString());
            if (secenek == DialogResult.Yes)
            {
                rdb.Sil(r);
                RandevuListele();
            }
            else { }
        }

        private void button_RandevuYenile_Click(object sender, EventArgs e)
        {
            RandevuListele();
        }
        Font Baslik1 = new Font("Red", 16, FontStyle.Bold);
        Font Baslik = new Font("Red", 12, FontStyle.Bold);
        Font Metin = new Font("Blue", 10, FontStyle.Bold);
        SolidBrush sb = new SolidBrush(Color.Black);
        SolidBrush baslik_renk = new SolidBrush(Color.Red); 
        private void printDocument_Yazıcı_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Yıldırım Hastanesi",Baslik1,baslik_renk,197,50);
            e.Graphics.DrawString("Tc Kimlik Numaranız:" + HastalarDb.tc.ToString(), Baslik, sb, 80, 131);
            e.Graphics.DrawString("Adınız:" + HastalarDb.ad.ToString(), Baslik, sb, 80, 160);
            e.Graphics.DrawString("Soyadınız:" + HastalarDb.soyad.ToString(), Baslik, sb, 80, 190);
            e.Graphics.DrawString("Doğum Tarihiniz:" + Convert.ToDateTime( HastalarDb.dtarih).ToString("dd-MM-yyyy"), Baslik, sb, 80, 220);
            e.Graphics.DrawString("Doğum Yeriniz:" + HastalarDb.dyeri.ToString(), Baslik, sb, 80, 250);
            e.Graphics.DrawString("Telefon Numaranız:" + HastalarDb.tel.ToString(), Baslik,sb, 80, 280);
            e.Graphics.DrawString("E Posta Adresiniz:" + HastalarDb.eposta.ToString(), Baslik, sb, 80, 310);
            e.Graphics.DrawString("Adresiniz:" + HastalarDb.adres.ToString(), Baslik, sb, 80, 340);
            e.Graphics.DrawString("Anne Adı:" + HastalarDb.annead.ToString(), Baslik, sb, 80, 370);
            e.Graphics.DrawString("Baba Adı:" + HastalarDb.babaad.ToString(), Baslik, sb, 80, 400);
            e.Graphics.DrawString(DateTime.Now.ToLongDateString(), Baslik, sb, 550, 275);
            e.Graphics.DrawString("Lütfen Hastanemize Zamanında Geliniz Aksi Takdirde\n Başvurduğunuz Randevu Zamanı İptal Edilecektir!!!", Baslik, baslik_renk, 40, 1000);
            e.Graphics.DrawString("No       Doktor Ad       TC kimlik numarası              Tarih                      Poliklinik              Saat",Baslik,sb,48,500);
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------", Baslik, sb, 40, 520);
            for (int i = 0; i < dataGridView_Randevu.RowCount; i++)
            {       
                e.Graphics.DrawString(dataGridView_Randevu.Rows[i].Cells[0].Value.ToString(), Metin, sb, 40, 540 + (i * 30));
                e.Graphics.DrawString(dataGridView_Randevu.Rows[i].Cells[1].Value.ToString(), Metin, sb, 125, 540 + (i * 30));
                e.Graphics.DrawString(dataGridView_Randevu.Rows[i].Cells[2].Value.ToString(), Metin, sb, 255, 540 + (i * 30));
                e.Graphics.DrawString(Convert.ToDateTime(dataGridView_Randevu.Rows[i].Cells[3].Value).ToString("dd-MM-yyyy"), Metin, sb, 425, 540 + (i * 30));
                e.Graphics.DrawString(dataGridView_Randevu.Rows[i].Cells[4].Value.ToString(), Metin, sb, 570, 540 + (i * 30));
                e.Graphics.DrawString(dataGridView_Randevu.Rows[i].Cells[5].Value.ToString(), Metin, sb, 730, 540 + (i * 30));
            }
            Bitmap bmpKucuk = new Bitmap(pictureBox_HastaFoto.Image, 215, 160);
            e.Graphics.DrawImage(bmpKucuk,565,47);
        }

        private void button_Yazdır_Click(object sender, EventArgs e)
        {
           printPreviewDialog_Yazıcı.ShowDialog();        
        }

        private void button_AnaSayfaDon_Click(object sender, EventArgs e)
        {
            new GirisEkrani().Show();
            this.Hide();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label_OgununTarihi.Text = DateTime.Now.ToString();
        }

        private void button_RandevuAlTemizle_Click(object sender, EventArgs e)
        {
            sifirlasaat();
            TextBox[] Temizle = {};
            for (int i = 0; i < Temizle.Length; i++)
            {
                Temizle[i].Text = "";
            }
            comboBox_Poliklinik.Text = "Seçin...";
            comboBox_DoktorAdlari .Text = "Seçin...";           
        }
    }
    public class BEx : Button
    {
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Randevuislemleri.butontxt = base.Text;
        }
    }

}
