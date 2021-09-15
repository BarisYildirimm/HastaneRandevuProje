using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

namespace hastaaa
{
    public class HastalarDb : Temel
    {
        public static string ad, soyad, cinsiyet, tc, annead, babaad, sifre, eposta, resim,dyeri,dtarih,adres,tel;
        public override void Arama(Interface1 varlik)
        {
            Hastakayit a = new Hastakayit();
            Hastalar grs = (Hastalar)varlik;
            Baglan();
            komut = new SqlCommand("select * from HastaKayit where H_tc='" + grs.H_tc + "' and H_sifre='" + grs.H_sifre + "'", baglanti);
            okuyucu = komut.ExecuteReader();
            if (okuyucu.Read())
            {
                ad = okuyucu["H_ad"].ToString();
                soyad = okuyucu["H_soyad"].ToString();
                cinsiyet = okuyucu["H_cinsiyet"].ToString();
                dyeri = okuyucu["H_dyeri"].ToString();
                dtarih = okuyucu["H_dtarih"].ToString();
                tc = okuyucu["H_tc"].ToString();
                annead = okuyucu["H_annead"].ToString();
                babaad = okuyucu["H_babad"].ToString();
                tel = okuyucu["H_tel"].ToString();
                sifre = okuyucu["H_sifre"].ToString();
                eposta = okuyucu["H_eposta"].ToString();
                adres = okuyucu["H_adres"].ToString();
                resim = okuyucu["H_resim"].ToString();
                Randevuislemleri randevu = new Randevuislemleri();
                randevu.Show();
            }
            else if (grs.H_tc == "123456789" && grs.H_sifre == "Admin1234")
            {
                Admin admin = new Admin();
                admin.Show(); 
            }
            else
            { a.HataMesaj("Tc Veya Şifre Yanlış Tekrar Deneyiniz!"); }
            baglanti.Close();
            baglanti.Dispose();
        }

        internal void EpostaKontrol(Hastalar h)
        {
            Baglan();
            if (h.H_eposta == "") { new SifremiUnuttum().TamamlanidMesaj("Lütfen Boş Bırakmayınız!!"); }
            else
            {
                komut = new SqlCommand("select * from HastaKayit where H_eposta ='" + h.H_eposta + "' ", baglanti);
                okuyucu = komut.ExecuteReader();
                if (okuyucu.Read())
                {
                    okuyucu.Close(); baglanti.Close();
                    string yenis = new SifremiUnuttum().SifreOlustur();
                    MailMessage EPosta = new MailMessage();
                    EPosta.From = new MailAddress("yildirimhastane@outlook.com");
                    EPosta.To.Add(h.H_eposta);
                    EPosta.Subject = "YENI SIFRE TALEBI";
                    EPosta.Body = "Yeni Şifreniz: " + yenis + "\n\n\n Barış Yıldırım#";

                    SmtpClient smtp = new SmtpClient();
                    smtp.Credentials = new System.Net.NetworkCredential("yildirimhastane@outlook.com", "hastaneproje1234");
                    smtp.Port = 587;
                    smtp.Host = "smtp.live.com";
                    smtp.EnableSsl = true;
                    try
                    {
                        baglanti.Open();
                        smtp.SendAsync(EPosta, (object)EPosta);
                        SqlCommand sorgula = new SqlCommand("update HastaKayit set H_sifre='" + yenis + "' where H_eposta='" + h.H_eposta + "' ", baglanti);
                        sorgula.ExecuteNonQuery();
                        new SifremiUnuttum().TamamlanidMesaj("Yeni Şifreniz Gönderilmiştir.\nE-Posta'nızı Kontrol Ediniz.");
                    }
                    catch (Exception)
                    {
                        new SifremiUnuttum().TamamlanidMesaj("Yeni Şifre Talebi Gerçekleşmedi.\nİnternet Bağlantınızı Kontrol Ediniz.");
                    }
                    finally
                    {
                        baglanti.Close();
                    }
                }
                else
                {
                    new SifremiUnuttum().TamamlanidMesaj("Bu E-Posta'ya Ait Kayıt Bulunamadı.\nE-Posta'nızı Kontrol Ediniz.");
                    baglanti.Close();
                }
            }
        }           
        public override void Ekle(Interface1 varlik)
        {
            Hastalar veriler = (Hastalar)varlik;
            Admin admn = new Admin();
            Hastakayit a = new Hastakayit();
            Baglan();
            sorgula = new SqlCommand("select * from HastaKayit where H_tc=@tc or H_eposta=@eposta or H_tel=@tel", baglanti);
            sorgula.Parameters.AddWithValue("@tc", veriler.H_tc);
            sorgula.Parameters.AddWithValue("@eposta", veriler.H_eposta);
            sorgula.Parameters.AddWithValue("@tel", veriler.H_tel);
            okuyucu = sorgula.ExecuteReader();           
            if (okuyucu.Read())
            {               
                a.HataMesaj("Aynı Kayıt Var Lütfen Tekrar Deneyin!");
                baglanti.Close();
                baglanti.Dispose();
                okuyucu.Close();            
            }
            else
            {         
                baglanti.Close();
                okuyucu.Close();
                komut = new SqlCommand("insert into HastaKayit (H_tc,H_ad,H_soyad,H_cinsiyet,H_dyeri,H_dtarih,H_annead,H_babad,H_tel,H_sifre,H_eposta,H_adres,H_resim) values (@tc,@ad,@soyad,@cinsiyet,@dyeri,@dtarih,@annead,@babaad,@tel,@sifre,@eposta,@adres,@resim)", baglanti);
                komut.Parameters.AddWithValue("tc", veriler.H_tc);
                komut.Parameters.AddWithValue("tel", veriler.H_tel);
                komut.Parameters.AddWithValue("eposta", veriler.H_eposta);
                komut.Parameters.AddWithValue("ad", veriler.H_ad);
                komut.Parameters.AddWithValue("soyad", veriler.H_soyad);
                komut.Parameters.AddWithValue("cinsiyet", veriler.H_cinsiyet);
                komut.Parameters.AddWithValue("sifre", veriler.H_sifre);
                komut.Parameters.AddWithValue("dyeri", veriler.H_dyeri);
                komut.Parameters.AddWithValue("dtarih", veriler.H_dtarih);
                komut.Parameters.AddWithValue("annead", veriler.H_annead);
                komut.Parameters.AddWithValue("babaad", veriler.H_babad);
                komut.Parameters.AddWithValue("adres", veriler.H_adres);
                komut.Parameters.AddWithValue("resim", veriler.H_resim);
                baglanti.Open();
                komut.ExecuteNonQuery();
                
                a.TamamlandiMesaj("Kayıt Başarılı");
                baglanti.Close();
                baglanti.Dispose();
            }     
                  
        }
        public override void Sil(Interface1 varlik)
        {
            Hastalar veriler = (Hastalar)varlik;
            Baglan();
            komut = new SqlCommand("Delete From HastaKayit where H_tc=@tc", baglanti);
            komut.Parameters.AddWithValue("tc", veriler.H_tc.ToString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }

        public override void Guncelle(Interface1 varlik)
        {
            Baglan();
            Hastalar veriler = (Hastalar)varlik;
            komut = new SqlCommand("Update HastaKayit set H_ad=@ad,H_soyad=@soyad,H_cinsiyet=@cinsiyet,H_dyeri=@dyeri,H_dtarih=@dtarih,H_annead=@annead,H_babad=@babaad,H_tel=@tel,H_sifre=@sifre,H_eposta=@eposta,H_adres=@adres,H_resim=@resim where H_tc=@tc", baglanti);
            komut.Parameters.AddWithValue("tc", HastalarDb.tc.ToString());
            komut.Parameters.AddWithValue("tel", veriler.H_tel);
            komut.Parameters.AddWithValue("eposta", veriler.H_eposta);
            komut.Parameters.AddWithValue("ad", veriler.H_ad);
            komut.Parameters.AddWithValue("soyad", veriler.H_soyad);
            komut.Parameters.AddWithValue("cinsiyet", veriler.H_cinsiyet);
            komut.Parameters.AddWithValue("sifre", veriler.H_sifre);
            komut.Parameters.AddWithValue("dyeri", veriler.H_dyeri);
            komut.Parameters.AddWithValue("dtarih", veriler.H_dtarih);
            komut.Parameters.AddWithValue("annead", veriler.H_annead);
            komut.Parameters.AddWithValue("babaad", veriler.H_babad);
            komut.Parameters.AddWithValue("adres", veriler.H_adres);
            komut.Parameters.AddWithValue("resim", veriler.H_resim);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Dispose();
        }
        public override void Giris(Interface1 varlik)
        {
            
        }
        internal object HastaListele()
        {
            Baglan();
            komut = new SqlCommand("Select* from HastaKayit", baglanti);
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
            komut = new SqlCommand("Select * from HastaKayit where H_tc like '%" + a + "%'", baglanti);
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