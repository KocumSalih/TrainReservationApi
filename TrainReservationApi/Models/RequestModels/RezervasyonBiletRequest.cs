namespace TrainReservationApi.Models.RequestModels
{
    /// <summary>
    /// Tren rezervayonu içerisinde gelen istekleri karşılayacak olan temel sınıf
    /// </summary>
    public class RezervasyonBiletRequest
    {
        public RezervasyonBiletRequest() => this.Tren = new Tren();

        public Tren Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }
}
