using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFAHamburgerTakip_02.Models
{
    public class Siparis
    {
        public Siparis()
        {
            Extramelzemeleri = new List<EkstraMalzeme>();
        }
        public Hamburger SeciliHamburger { get; set; }
        public Boyut SeciliBoyut { get; set; }
        public List<EkstraMalzeme> Extramelzemeleri
        { get; set; }
        public Icecek SeciliIcecek { get; set; }
        
        public int Adet { get; set; }

        public decimal ToplamTutar { get; set; }

        public void TutarHesapla()
        {
            ToplamTutar = 0;
            ToplamTutar += SeciliHamburger.Fiyati;
            switch (SeciliBoyut)
            {
                case Boyut.Kucuk:
                    break;
                case Boyut.Orta:
                    ToplamTutar += 1;
                    break;
                case Boyut.Buyuk:
                    ToplamTutar += 1.50m;
                    break; 
            }

            foreach (EkstraMalzeme item in Extramelzemeleri)
            {
                ToplamTutar += item.Fiyati;
            }

            ToplamTutar *= Adet;
        }

        public override string ToString()
        {
            // SteakHouse Menü,Orta Boy, Coca Cola,(....,....,....),x Adet,Tutar:
            if (Extramelzemeleri.Count < 1)
            {
                return $"{SeciliHamburger.Adi} Menü , {SeciliBoyut} Boy, {SeciliIcecek.Adi} , x {Adet} Adet , Toplam Tutar: {ToplamTutar} ";
            }
            else
            {
                string exMalz = null;
                foreach (EkstraMalzeme item in Extramelzemeleri)
                {
                    exMalz += item.Adi + ',';
                }
                exMalz=exMalz.TrimEnd(',');
                return $"{SeciliHamburger.Adi} Menü , {SeciliBoyut} Boy , {SeciliIcecek.Adi} ,({exMalz}) ,x {Adet} Adet , Toplam Tutar: {ToplamTutar} ";
            }
        }
    }
}
