using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hastaaa
{
    public class Hastalar : Interface1
    {
        private string h_tc;
        private string h_ad;
        private string h_soyad;
        private string h_cinsiyet;
        private string h_dyeri;
        private DateTime h_dtarih;
        private string h_annead;
        private string h_babad;
        private string h_tel;
        private string h_sifre;
        private string h_eposta;
        private string h_adres;
        private string h_resim;

        public string H_tc
        {
            get
            {
                return h_tc;
            }

            set
            {
                h_tc = value;
            }
        }

        public string H_ad
        {
            get
            {
                return h_ad;
            }

            set
            {
                h_ad = value;
            }
        }

        public string H_soyad
        {
            get
            {
                return h_soyad;
            }

            set
            {
                h_soyad = value;
            }
        }

        public string H_cinsiyet
        {
            get
            {
                return h_cinsiyet;
            }

            set
            {
                h_cinsiyet = value;
            }
        }

        public string H_dyeri
        {
            get
            {
                return h_dyeri;
            }

            set
            {
                h_dyeri = value;
            }
        }

        public string H_annead
        {
            get
            {
                return h_annead;
            }

            set
            {
                h_annead = value;
            }
        }

        public string H_babad
        {
            get
            {
                return h_babad;
            }

            set
            {
                h_babad = value;
            }
        }

        public string H_tel
        {
            get
            {
                return h_tel;
            }

            set
            {
                h_tel = value;
            }
        }

        public string H_sifre
        {
            get
            {
                return h_sifre;
            }

            set
            {
                h_sifre = value;
            }
        }

        public string H_eposta
        {
            get
            {
                return h_eposta;
            }

            set
            {
                h_eposta = value;
            }
        }

    

        public DateTime H_dtarih
        {
            get
            {
                return h_dtarih;
            }

            set
            {
                h_dtarih = value;
            }
        }

        public string H_adres
        {
            get
            {
                return h_adres;
            }

            set
            {
                h_adres = value;
            }
        }

        public string H_resim
        {
            get
            {
                return h_resim;
            }

            set
            {
                h_resim = value;
            }
        }

        public Hastalar()
        {
            h_tc = "";
            h_ad = "";
            h_soyad = "";
            h_cinsiyet = "";
            h_dyeri = "";
            H_dtarih = new DateTime();
            h_annead = "";
            h_babad = "";
            h_tel = "";
            h_sifre = "";
            h_eposta = "";
            h_adres = "";
            h_resim = "";
        }
    }
}