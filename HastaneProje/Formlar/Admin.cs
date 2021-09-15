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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        int Doktor;
        string hasta;
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void Admin_Load(object sender, EventArgs e)
        {
            BolumListele();
            DoktorListele();
            HastaListele();
            timer_Tarih.Start();
            RandevuDb ydb = new RandevuDb();
            ydb.getir(chart1);
           
        }
        #region Tarih islemleri
        private void label26_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void timer_Tarih_Tick(object sender, EventArgs e)
        {
            label_Tarih.Text  = DateTime.Now.ToLongDateString();
            label_Saat.Text = DateTime.Now.ToLongTimeString();
        }
        #endregion
        #region Sayfalar
        private void button_Doktorlar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_Doktorlar;
        }

        private void button_Bolumler_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_Bölümler;
        }

        private void button_Hastalar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_Hastalar;
        }

        private void button_Randevular_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_Randevular;
        }
        private void button_Cik_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button_istatistikler_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_istatistik;
        }
        #endregion
        #region BölümKısmı

        public void BolumListele()
        {
            BolumlerDb bolumler = new BolumlerDb();
            dataGridView1.DataSource = bolumler.Listele();
            comboBox_DoktorBolum.DataSource = bolumler.Listele();
            comboBox_DoktorBolum.DisplayMember = "Bolum_ad";
            comboBox_DoktorBolum.ValueMember = "bolum_id";

            comboBox_Aramayapmakicindoktorlar.DataSource = bolumler.Listele();
            comboBox_Aramayapmakicindoktorlar.DisplayMember = "Bolum_ad";
            comboBox_Aramayapmakicindoktorlar.ValueMember = "bolum_id";           
        }
        
        private void button_BolumEkle_Click(object sender, EventArgs e)
        {
            BolumlerDb blmdb = new BolumlerDb();
            Bolumler bolum = new Bolumler();
            bolum.Bolum_ad = textBox_Bolumad.Text;
            blmdb.Ekle(bolum);
            BolumListele();
            textBox_Bolumad.Clear();
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            BolumListele();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kaydı Silme istiyor musunuz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Bolumler b = new Bolumler();
            BolumlerDb db = new BolumlerDb();
            b.Bolum_ad =textBox_BolumSil.Text;
            if (secenek == DialogResult.Yes)
            {
                db.Sil(b);
                textBox_BolumSil.Clear();
                label_Degistirilecek_Id.Text = "";
                textBox_Degistirad.Clear();
            }
            else if (secenek == DialogResult.No) { MessageBox.Show("Silme İşlemi İptal Edildi!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information); }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Bolumler b = new Bolumler();
            BolumlerDb db = new BolumlerDb();
            b.Bolum_ad = textBox_Degistirad.Text;          
            b.Bolum_id = Convert.ToInt32(label_Degistirilecek_Id.Text);
            try
            {
                db.Guncelle(b);
                if (b.Bolum_id !=0)
                {
                    MessageBox.Show("Güncelleme Başarılı");
                }
                else
                {
                    MessageBox.Show("Lütfen Tekrar Deneyiniz");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Bir Hata Oluştu Tekrar Deneyiniz");
            }        
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            BolumListele();
            textBox_Bolumad.Text = "";
            textBox_Degistirad.Text = "";
            textBox_BolumSil.Text = "";
            label_Degistirilecek_Id.Text = "";
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView1.SelectedCells[0].RowIndex;
            textBox_BolumSil.Text = dataGridView1.Rows[a].Cells[1].Value.ToString();
            label_Degistirilecek_Id.Text = dataGridView1.Rows[a].Cells[0].Value.ToString();
            textBox_Degistirad.Text = dataGridView1.Rows[a].Cells[1].Value.ToString();
        }
        private void textBox_Bolumarama_TextChanged_1(object sender, EventArgs e)
        {
            BolumlerDb bolumlerdb = new BolumlerDb();
            Bolumler bolum = new Bolumler();
            bolum.Bolum_ad = textBox_Bolumarama.Text;
            dataGridView1.DataSource = bolumlerdb.Listele(bolum);
        }
        #endregion
        #region DoktorKısmı
        public void DoktorListele()
        {
            DoktorlarDb d = new DoktorlarDb();
            dataGridView_Doktorlar.DataSource = d.DoktorListele();
        }
        private void button_DoktorEkle_Click_1(object sender, EventArgs e)
        {
            Doktorlar doktor = new Doktorlar();
            doktor.Bolum_No.Bolum_id = Convert.ToInt32(comboBox_DoktorBolum.SelectedValue);
            doktor.D_tc = textBox_Doktortc.Text;
            doktor.D_ad = textBox_Doktorad.Text;
            doktor.D_soyad = textBox_DoktorSoyad.Text;
            doktor.D_dtarih1 = dateTimePicker1.Value;
            doktor.D_dyeri = textBox_DYeri.Text;
            doktor.D_cinsiyet = comboBox_Cinsiyet.Text;
            doktor.D_adres = textBox_DoktorAdres.Text;
            doktor.D_tel = textBox_DoktorTelefon.Text;
            DoktorlarDb ddb = new DoktorlarDb();
            ddb.Ekle(doktor);
        }

        private void button_DoktorYenile_Click(object sender, EventArgs e)
        {
            comboBox_Aramayapmakicindoktorlar.Text = "Seçiniz...";
            DoktorListele();
        }
        private void button_DoktorGuncelle_Click(object sender, EventArgs e)
        {
            Doktorlar doktor = new Doktorlar();
            DoktorlarDb doktordb = new DoktorlarDb();
            doktor.Bolum_No.Bolum_id = Convert.ToInt32(comboBox_DoktorBolum.SelectedValue);
            doktor.D_tc = textBox_Doktortc.Text;
            doktor.D_ad = textBox_Doktorad.Text;
            doktor.D_soyad = textBox_DoktorSoyad.Text;
            doktor.D_dtarih1 = dateTimePicker1.Value;
            doktor.D_dyeri = textBox_DYeri.Text;
            doktor.D_cinsiyet = comboBox_Cinsiyet.Text;
            doktor.D_adres = textBox_DoktorAdres.Text;
            doktor.D_tel = textBox_DoktorTelefon.Text;
            try
            {
                doktordb.Guncelle(doktor);
                MessageBox.Show("Güncelleme Başarılı");
            }
            catch (Exception)
            {

                MessageBox.Show("Güncelleme Başarısız!");
            }
        }
        void Doktor_Temizle()
        {
            TextBox[] Temizle = { textBox_Doktorad, textBox_DoktorSoyad, textBox_DYeri, textBox_DoktorAdres, textBox_DoktorTelefon };
            for (int i = 0; i < Temizle.Length; i++)
            {
                Temizle[i].Text = "";
            }
            textBox_Doktortc.Text = "";
            comboBox_Cinsiyet.Text = "Seçin...";
            comboBox_DoktorBolum.Text = "Seçin...";
        }
        private void button_DoktorTemizle_Click(object sender, EventArgs e)
        {
            Doktor_Temizle();
        }
        private void dataGridView_Doktorlar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                int satir = dataGridView_Doktorlar.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1)
                {
                    dataGridView_Doktorlar.Rows[satir].Selected = true;
                    Doktor = Convert.ToInt32(dataGridView_Doktorlar.Rows[satir].Cells[0].Value);
                }
            }
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kaydı Silme istiyor musunuz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secenek == DialogResult.Yes)
            {
                Doktorlar d = new Doktorlar();
                DoktorlarDb ddb = new DoktorlarDb();
                d.D_id = Doktor;
                ddb.Sil(d);
                DoktorListele();
                Doktor_Temizle();
            }
            else if (secenek == DialogResult.No) { MessageBox.Show("Silme İşlemi İptal Edildi!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
        private void textBox_DoktorAra_TextChanged(object sender, EventArgs e)
        {
            DoktorlarDb ddb = new DoktorlarDb();
            Doktorlar doktor = new Doktorlar();
            doktor.D_tc = textBox_DoktorAra.Text;
            if (comboBox_Aramayapmakicindoktorlar.Text == "Seçiniz...")
            {
                dataGridView_Doktorlar.DataSource = ddb.A(doktor);
            }
            else
            {
                string a = comboBox_Aramayapmakicindoktorlar.SelectedValue.ToString();
                dataGridView_Doktorlar.DataSource = ddb.Listele(doktor, a);
            }          
        }
        #endregion
        #region Hareketlerndirme
       
        #endregion      
        public void HastaListele()
        {
            HastalarDb h = new HastalarDb();
            dataGridView_Hastalar.DataSource = h.HastaListele();
        }
        private void silToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Kaydı Silme istiyor musunuz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secenek == DialogResult.Yes)
            {
                Hastalar h = new Hastalar();
                HastalarDb hdb = new HastalarDb();
                h.H_tc = hasta;
                hdb.Sil(h);
                HastaListele();
            }
            else if (secenek == DialogResult.No) { MessageBox.Show("Silme İşlemi İptal Edildi!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void dataGridView_Hastalar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {

                int satir = dataGridView_Hastalar.HitTest(e.X, e.Y).RowIndex;
                if (satir > -1) 
                {
                    dataGridView_Hastalar.Rows[satir].Selected = true;
                    hasta = dataGridView_Hastalar.Rows[satir].Cells[0].Value.ToString();
                }
            }
        }

        private void comboBox_Aramayapmakicindoktorlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox_Aramayapmakicindoktorlar.Text = "Seçiniz...";
            string a = comboBox_Aramayapmakicindoktorlar.SelectedValue.ToString();
            DoktorlarDb rdb = new DoktorlarDb();
            dataGridView_Doktorlar.DataSource = rdb.Getir(a);
            
        }
        void RandevuListele()
        {
            RandevuDb ydb = new RandevuDb();
            dataGridView_Randevular.DataSource= ydb.Randevular();
        }
        private void button_RandevuArama_Click(object sender, EventArgs e)
        {
            RandevuDb rdb = new RandevuDb();
            dataGridView_Randevular.DataSource = rdb.TarihArasıArama(dateTimePicker_RandevuAra1.Value, dateTimePicker_RandevuAra2.Value);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                RandevuDb rdb = new RandevuDb();
                dataGridView_Randevular.DataSource = rdb.BugunRandevu();
            }
            else { RandevuListele(); }
           
        }

        private void textBox_HastaAra_TextChanged(object sender, EventArgs e)
        {            
           string a = textBox_HastaAra.Text;
           HastalarDb hdb = new HastalarDb();
           dataGridView_Hastalar.DataSource = hdb.Getir(a);
        }

        private void button_RandevuYenile_Click(object sender, EventArgs e)
        {
            RandevuListele();
        }

        private void button_RandevuSilme_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show(" Seçili Kayıtları Silmek istiyor musunuz?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secenek == DialogResult.Yes)
            {
                RandevuDb rdb = new RandevuDb();
                foreach (DataGridViewRow drow in dataGridView_Randevular.SelectedRows)
                {
                    int Islem_No = Convert.ToInt32(drow.Cells[0].Value);
                    rdb.RandevuSil(Islem_No);
                }
                RandevuListele();
            }
            else if (secenek == DialogResult.No) { MessageBox.Show("Silme İşlemi İptal Edildi!", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information); }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }       
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
        private void dataGridView_Doktorlar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = dataGridView_Doktorlar.SelectedCells[0].RowIndex;
            textBox_Doktortc.Text = dataGridView_Doktorlar.Rows[a].Cells[1].Value.ToString();
            textBox_Doktorad.Text = dataGridView_Doktorlar.Rows[a].Cells[2].Value.ToString();
            textBox_DoktorSoyad.Text = dataGridView_Doktorlar.Rows[a].Cells[3].Value.ToString();
            comboBox_Cinsiyet.Text = dataGridView_Doktorlar.Rows[a].Cells[4].Value.ToString();
            textBox_DYeri.Text = dataGridView_Doktorlar.Rows[a].Cells[5].Value.ToString();
            dateTimePicker1.Text = dataGridView_Doktorlar.Rows[a].Cells[6].Value.ToString();
            textBox_DoktorAdres.Text = dataGridView_Doktorlar.Rows[a].Cells[7].Value.ToString();
            textBox_DoktorTelefon.Text = dataGridView_Doktorlar.Rows[a].Cells[8].Value.ToString();
            comboBox_DoktorBolum.SelectedValue = Convert.ToInt16(dataGridView_Doktorlar.Rows[a].Cells[9].Value);
        }
    }
}
