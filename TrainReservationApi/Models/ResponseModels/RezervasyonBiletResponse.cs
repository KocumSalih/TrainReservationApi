using System.Collections.Generic;

namespace TrainReservationApi.Models.ResponseModels
{
    /// <summary>
    ///  Tren rezervasyon apisinde kullanılacak olan temel response sınıfı
    /// </summary>
    public class RezervasyonBiletResponse
    {
        public RezervasyonBiletResponse() => this.YerlesimAyrinti = new List<YerlesimAyrinti>();

        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
}
