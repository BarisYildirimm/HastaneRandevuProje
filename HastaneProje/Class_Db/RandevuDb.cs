using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace hastaaa
{
    public class RandevuDb : Temel
    {
        public override void Ekle(Interface1 varlik)
        {
            Baglan();
            Randevu gelen = (Randevu)varlik;
            komut = new System.Data.SqlClient.SqlCommand("insert into Randevu(D_ad,H_tc,Tarih,Poliklinik,Saat) values (@p1,@p2,@p3,@p4,@p5)", baglanti);
            komut.Parameters.AddWithValue("p1", gelen.D_ad);
            komut.Parameters.AddWithValue("p2", gelen.H_tc);
            komut.Parameters.AddWithValue("p3", gelen.Tarih);
            komut.Parameters.AddWithValue("p4", gelen.Poliklinik);
            komut.Parameters.AddWithValue("p5", gelen.Saat);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        internal object Randevular()
        {
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("Select * from Randevu",baglanti);
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        public override void Sil(Interface1 varlik)
        {
            Baglan();
            Randevu gelen = (Randevu)varlik;
            komut = new System.Data.SqlClient.SqlCommand("Delete From Randevu where Islem_no=@no", baglanti);
            komut.Parameters.AddWithValue("no", gelen.Islem_no);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        public override void Guncelle(Interface1 varlik)
        {
            throw new System.NotImplementedException();
        }

        public override void Arama(Interface1 varlik)
        {          
        }

        public override void Giris(Interface1 varlik)
        {
            throw new NotImplementedException();
        }
        internal List<string> ListeDoldur(string b)
        {
            List<string> dizi = new List<string>();
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("select D_ad from Doktorlar where  D_bolumid = (select bolum_id from Bolumler where bolum_ad='"+b+"')", baglanti);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                dizi.Add(okuyucu["D_ad"].ToString());
            }
            baglanti.Close();
            baglanti.Dispose();
            return dizi;
        }

        internal void getir(Chart chart1)
        {
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("select year(getdate())-year(H_dtarih),COUNT(*) from HastaKayit group by H_dtarih",baglanti);
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                chart1.Series["Yaş"].Points.AddXY(okuyucu[0].ToString(), okuyucu[1].ToString());
            }
            baglanti.Close();
        }

        internal object RandevuListele()
        {
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("Select * From Randevu where H_tc = @tc", baglanti);
            komut.Parameters.AddWithValue("tc", HastalarDb.tc.ToString());
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }
        internal object RandevuAra(Randevu r,string a)
        {
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("Select * from Randevu where Poliklinik  like'%" + r.Poliklinik + "%' and H_Tcno ='" + a + "' ", baglanti);
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }
        internal List<string> SaatKontrol(string text)
        {
            List<string> dizi = new List<string>();
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("select * from Randevu where D_ad =@ad", baglanti);
            komut.Parameters.AddWithValue("ad", text);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                dizi.Add(okuyucu["Saat"].ToString());
            }
            baglanti.Close();
            baglanti.Dispose();
            return dizi;
        }

        internal void HastaneHakkinda()
        {
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("select COUNT(bolum_id) as 'p1' from Bolumler", baglanti);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                Randevuislemleri.text1 = okuyucu["p1"].ToString();
            }
            okuyucu.Close();
            komut = new System.Data.SqlClient.SqlCommand("select COUNT(D_id) as 'p2' from Doktorlar", baglanti);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                Randevuislemleri.text2 = okuyucu["p2"].ToString();
            }
            okuyucu.Close();
            komut = new System.Data.SqlClient.SqlCommand("select COUNT(H_tc) as 'p3' from HastaKayit", baglanti);
            komut.ExecuteNonQuery();
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                Randevuislemleri.text3 = okuyucu["p3"].ToString();
            }
            baglanti.Close();
            baglanti.Dispose();         
        }

       

        internal object TarihArasıArama(DateTime value1, DateTime value2)
        {
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("SELECT * FROM Randevu Where Tarih BETWEEN '"+ value1.ToString("yyyy-MM-dd") + "' and '"+ value2.ToString("yyyy-MM-dd") + "'", baglanti);
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal object BugunRandevu()
        {
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("SELECT  *FROM Randevu WHERE DAY(Tarih)=DAY(GETDATE()) AND MONTH(Tarih)=MONTH(GETDATE())", baglanti);
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new System.Data.SqlClient.SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal void RandevuSil(int Islem_No)
        {
            Baglan();
            komut = new System.Data.SqlClient.SqlCommand("Delete From Randevu where Islem_no = @p1", baglanti);
            komut.Parameters.AddWithValue("p1", Islem_No);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }
    }
}