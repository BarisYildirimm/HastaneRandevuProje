using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace hastaaa
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox_sifre.PasswordChar = '\0'; }
            else textBox_sifre.PasswordChar = '*';
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Hastakayit hastakyt = new Hastakayit();
            hastakyt.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Hastalar h = new Hastalar();
            h.H_tc = textBox_tc.Text;
            h.H_sifre = textBox_sifre.Text;
            HastalarDb hdb = new HastalarDb();
            hdb.Arama(h);
        }
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SifremiUnuttum sifreekrani = new SifremiUnuttum();
            sifreekrani.Show();
            this.Hide();
        }

        private void GirisEkrani_Load(object sender, EventArgs e)
        {

        }
        int Move;
        int Mouse_X;
        int Mouse_Y;
        private void GirisEkrani_MouseUp(object sender, MouseEventArgs e)
        {
            Move = 0;
        }

        private void GirisEkrani_MouseDown(object sender, MouseEventArgs e)
        {
            Move = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void GirisEkrani_MouseMove(object sender, MouseEventArgs e)
        {
            if (Move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
    }
}
