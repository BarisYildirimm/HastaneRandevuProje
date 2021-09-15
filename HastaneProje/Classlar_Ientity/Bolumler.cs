using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hastaaa
{
    public class Bolumler : Interface1
    {
        private int bolum_id;
        private string bolum_ad;
        public int Bolum_id
        {
            get
            {
                return bolum_id;
            }

            set
            {
                bolum_id = value;
            }
        }

        public string Bolum_ad
        {
            get
            {
                return bolum_ad;
            }

            set
            {
                bolum_ad = value;
            }
        }

        public Bolumler()
        {
            Bolum_ad = "";
            Bolum_id = 0;
        }
        
    }
}