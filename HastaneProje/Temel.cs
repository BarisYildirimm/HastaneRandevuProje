using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace hastaaa
{
    public abstract class Temel
    {
        string yol;
        public SqlConnection baglanti;
        public SqlDataReader okuyucu;
        public SqlDataAdapter adaptor;
        public DataTable tablo;
        public SqlCommand komut;
        public SqlCommand sorgula;
        public Temel()
        {
           // yol = ConfigurationManager.ConnectionStrings["Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HastaKayit;Integrated Security=True"].ConnectionString;
        }

        public void Baglan()
        {
            baglanti = new SqlConnection("Data Source=LAPTOP-LHOO29TP;Initial Catalog=HastaKayit;Integrated Security=True");
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
        }
        abstract public void Ekle(Interface1 varlik);
        abstract public void Sil(Interface1 varlık);
        abstract public void Guncelle(Interface1 varlik);
        abstract public void Arama(Interface1 varlik);
        abstract public void Giris(Interface1 varlik);
      
    }
}