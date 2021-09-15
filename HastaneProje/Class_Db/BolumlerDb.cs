using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace hastaaa
{
    public class BolumlerDb : Temel
    {
        public override void Ekle(Interface1 varlik)
        {
            Hastakayit a = new Hastakayit();
            Admin admin = new Admin();
            Bolumler blm = (Bolumler)varlik;
            Baglan();
            komut = new SqlCommand("select * from Bolumler where bolum_ad = @bolumad", baglanti);
            komut.Parameters.AddWithValue("bolumad", blm.Bolum_ad);
            okuyucu = komut.ExecuteReader();
            if (okuyucu.Read())
            {
                a.HataMesaj("Daha Önce Böyle Kayıt Girildi!");
                baglanti.Close();
                baglanti.Dispose();
                okuyucu.Close();
            }
            else
            {
                baglanti.Close();
                okuyucu.Close();
                komut = new SqlCommand("insert into Bolumler values (@bolumad)", baglanti);
                komut.Parameters.AddWithValue("bolumad", blm.Bolum_ad);
                baglanti.Open();
                komut.ExecuteNonQuery();
                a.TamamlandiMesaj("Ekleme Başarılı.");
                admin.BolumListele();
                baglanti.Close();
                baglanti.Dispose();
            }
        }

        public override void Sil(Interface1 varlik)
        {           
            Baglan();
            Bolumler gelen = (Bolumler)varlik;
            komut = new SqlCommand("Delete From Bolumler where bolum_ad = @ad", baglanti);
            komut.Parameters.AddWithValue("ad", gelen.Bolum_ad);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }
        public override void Guncelle(Interface1 varlik)
        {
            Bolumler veriler = (Bolumler)varlik;
            Baglan();
            komut = new SqlCommand("Update Bolumler set bolum_ad  ='" + veriler.Bolum_ad + "' where bolum_id='" + veriler.Bolum_id + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }
        public override void Giris(Interface1 varlik)
        {
        }
        internal object Listele()
        {
            Baglan();
            komut = new SqlCommand("Select * from Bolumler", baglanti);
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }
        public override void Arama(Interface1 varlik)
        {          
        }
        internal object Listele(Bolumler b)
        {
            Baglan();
            komut = new SqlCommand("Select * from Bolumler where bolum_ad like'%" + b.Bolum_ad + "%'", baglanti);
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }
    }
}