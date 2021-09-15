using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace hastaaa
{
    public class DoktorlarDb : Temel
    {
        public override void Ekle(Interface1 varlik)
        {
            Baglan();
            Hastakayit a = new Hastakayit();
            Doktorlar gelen = (Doktorlar)varlik;
            komut = new SqlCommand("select * from Doktorlar where D_tc = @tc", baglanti);
            komut.Parameters.AddWithValue("tc",gelen.D_tc);
            okuyucu = komut.ExecuteReader();
            if (okuyucu.Read())
            {
                a.HataMesaj("Daha Önce Böyle Bir Doktor Kayıt Edildi!");
                baglanti.Close();
                baglanti.Dispose();
                okuyucu.Close();
            }
            else
            {
                baglanti.Close();
                okuyucu.Close();
                komut = new SqlCommand("insert into Doktorlar (D_tc,D_ad,D_soyad,D_cinsiyet,D_dyeri,D_dtarih,D_adres,D_tel,D_bolumid) values (@tc,@ad,@soyad,@cinsiyet,@dyeri,@dtarih,@adres,@tel,@id)", baglanti);
                komut.Parameters.AddWithValue("@tc", gelen.D_tc);
                komut.Parameters.AddWithValue("@ad", gelen.D_ad);
                komut.Parameters.AddWithValue("@soyad", gelen.D_soyad);
                komut.Parameters.AddWithValue("@cinsiyet", gelen.D_cinsiyet);
                komut.Parameters.AddWithValue("@dyeri", gelen.D_dyeri);
                komut.Parameters.AddWithValue("@dtarih", gelen.D_dtarih1);
                komut.Parameters.AddWithValue("@adres", gelen.D_adres);
                komut.Parameters.AddWithValue("@tel", gelen.D_tel);
                komut.Parameters.AddWithValue("@id", Convert.ToInt16(gelen.Bolum_No.Bolum_id));
                baglanti.Open();
                komut.ExecuteNonQuery();
                baglanti.Close();
                baglanti.Dispose();
                a.TamamlandiMesaj("Kayıt Başarılı!");  
            }          
        }
        public override void Sil(Interface1 varlik)
        {
            Doktorlar veriler = (Doktorlar)varlik;
            Baglan();
            komut = new SqlCommand("Delete From Doktorlar where D_id=@id", baglanti);
            komut.Parameters.AddWithValue("id", veriler.D_id);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        public override void Guncelle(Interface1 varlik)
        {
            Baglan();
            Doktorlar veriler = (Doktorlar)varlik;
            komut = new SqlCommand("Update Doktorlar set D_ad=@ad,D_soyad=@soyad,D_cinsiyet=@cinsiyet,D_dyeri=@dyeri,D_dtarih=@tarih,D_adres=@adres,D_tel=@tel,D_bolumid=@bolumid where D_tc=@tc",baglanti);
            komut.Parameters.AddWithValue("tc", veriler.D_tc);
            komut.Parameters.AddWithValue("ad",veriler.D_ad);
            komut.Parameters.AddWithValue("soyad", veriler.D_soyad);
            komut.Parameters.AddWithValue("cinsiyet",veriler.D_cinsiyet);
            komut.Parameters.AddWithValue("dyeri",veriler.D_dyeri);
            komut.Parameters.AddWithValue("tarih",veriler.D_dtarih1);
            komut.Parameters.AddWithValue("adres", veriler.D_adres);
            komut.Parameters.AddWithValue("tel", veriler.D_tel);
            komut.Parameters.AddWithValue("bolumid", veriler.Bolum_No.Bolum_id);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        public override void Giris(Interface1 varlik)
        {
            throw new NotImplementedException();
        }
        public override void Arama(Interface1 varlik)
        {
            throw new NotImplementedException();
        }
        internal object DoktorListele()
        {
            Baglan();
            komut = new SqlCommand("Select * from Doktorlar", baglanti);
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }

        internal object Listele(Doktorlar doktor,string a)
        {
            Baglan();
            komut = new SqlCommand("Select * from doktorlar where D_bolumid = "+a+" and  D_tc like '%"+doktor.D_tc+"%'", baglanti);
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }
        internal object A(Doktorlar doktor)
        {
            Baglan();
            komut = new SqlCommand("Select * from doktorlar where D_tc like '%" + doktor.D_tc + "%'", baglanti);
            komut.ExecuteNonQuery();
            tablo = new System.Data.DataTable();
            adaptor = new SqlDataAdapter(komut);
            adaptor.Fill(tablo);
            baglanti.Close();
            baglanti.Dispose();
            return tablo;
        }
        internal object Getir(string a)
        {
            Baglan();
            komut = new SqlCommand("Select * from doktorlar where D_bolumid like'%" + a + "%'", baglanti);
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