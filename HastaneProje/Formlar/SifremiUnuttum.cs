using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace hastaaa
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }
        public void TamamlanidMesaj(string mesaj)
        {
            MessageBox.Show(mesaj);
        }        
        public string SifreOlustur()
        {
            Random rndm = new Random();
            string yenis = "";
            for (int i = 0; i < 3; i++)
            {
                yenis += rndm.Next(1, 10);
                yenis += Convert.ToChar(rndm.Next(65, 91));
            }
            return yenis;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Hastalar h = new Hastalar();
            HastalarDb hdb = new HastalarDb();
            h.H_eposta = sifreunuttumBox.Text;
            hdb.EpostaKontrol(h);
         }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new GirisEkrani().Show();
            this.Hide();
        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        
        private void SifremiUnuttum_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void SifremiUnuttum_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void SifremiUnuttum_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
