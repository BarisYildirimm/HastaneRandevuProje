using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hastaaa
{
    public class Doktorlar : Interface1
    {
        private int d_id;
        private string d_tc;
        private string d_ad;
        private string d_soyad;
        private string d_cinsiyet;
        private string d_dyeri;
        private DateTime d_dtarih;
        private string d_adres;
        private string d_tel;
        private Bolumler bolum_No;

        public int D_id
        {
            get
            {
                return d_id;
            }

            set
            {
                d_id = value;
            }
        }

        public string D_tc
        {
            get
            {
                return d_tc;
            }

            set
            {
                d_tc = value;
            }
        }

        public string D_ad
        {
            get
            {
                return d_ad;
            }

            set
            {
                d_ad = value;
            }
        }

        public string D_soyad
        {
            get
            {
                return d_soyad;
            }

            set
            {
                d_soyad = value;
            }
        }

        public string D_cinsiyet
        {
            get
            {
                return d_cinsiyet;
            }

            set
            {
                d_cinsiyet = value;
            }
        }

        public string D_dyeri
        {
            get
            {
                return d_dyeri;
            }

            set
            {
                d_dyeri = value;
            }
        }
        public string D_adres
        {
            get
            {
                return d_adres;
            }

            set
            {
                d_adres = value;
            }
        }

        public string D_tel
        {
            get
            {
                return d_tel;
            }

            set
            {
                d_tel = value;
            }
        }   
        public DateTime D_dtarih1
        {
            get
            {
                return d_dtarih;
            }

            set
            {
                d_dtarih = value;
            }
        }

        public Bolumler Bolum_No
        {
            get
            {
                return bolum_No;
            }

            set
            {
                bolum_No = value;
            }
        }

        public Doktorlar()
        {
            d_id = 0;
            d_tc = "";
            d_ad = "";
            d_soyad = "";
            d_cinsiyet = "";
            d_dyeri = "";
            d_dtarih = new DateTime();
            d_adres = "";
            d_tel = "";
            bolum_No = new Bolumler();
        }
    }
}