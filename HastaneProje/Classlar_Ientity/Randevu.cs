using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hastaaa
{
    public class Randevu : Interface1
    {
        private int islem_no;
        private string d_ad;
        private string h_tc;
        private DateTime tarih;
        private string poliklinik;
        private string saat;

        public int Islem_no
        {
            get
            {
                return islem_no;
            }

            set
            {
                islem_no = value;
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

        public string Poliklinik
        {
            get
            {
                return poliklinik;
            }

            set
            {
                poliklinik = value;
            }
        }

        public string Saat
        {
            get
            {
                return saat;
            }

            set
            {
                saat = value;
            }
        }

        public DateTime Tarih
        {
            get
            {
                return tarih;
            }

            set
            {
                tarih = value;
            }
        }

        public Randevu()
        {
             islem_no = 0;
             D_ad = "";
             H_tc = "";
             Tarih = new DateTime();
             Poliklinik = "";
             Saat = "";
        }
    }
}