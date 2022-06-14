using System;

namespace TrainReservationApi.Models
{
    /// <summary>
    /// Tren rezervasyon apisi için oluşturulan Vagon sınıfı 
    /// </summary>
    public class Vagon
    {
        public string Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }

        public bool RezervasyonYapilabilirmi(int rezervasyonSayisi)
        {
            decimal sayi = Convert.ToDecimal(Convert.ToDecimal(DoluKoltukAdet + rezervasyonSayisi) / Kapasite) * 100m;
            return sayi <= 70;
        }

        public int DoldurulabilirKoltukHesapla()
        {
            int doldurulabilirBosKoltukSayisi = Convert.ToInt32(Kapasite * 0.7m) - DoluKoltukAdet;
            return doldurulabilirBosKoltukSayisi;
        }
    }
}
