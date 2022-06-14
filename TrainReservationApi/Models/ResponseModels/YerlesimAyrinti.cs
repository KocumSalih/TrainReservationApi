namespace TrainReservationApi.Models.ResponseModels
{
    /// <summary>
    /// Tren rezervasyon apisinde temel response sınıfı içerisinde kullanılacak YerlesimAyrinti sınıfı 
    /// </summary>
    public class YerlesimAyrinti
    {
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
