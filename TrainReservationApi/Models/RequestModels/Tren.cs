using System.Collections.Generic;

namespace TrainReservationApi.Models
{
    /// <summary>
    /// Tren rezervasyon apisi için oluşturulan tren sınıfı
    /// </summary>
    public class Tren
    {
        public Tren() => this.Vagonlar = new List<Vagon>();

        public string Name { get; set; }
        public List<Vagon> Vagonlar { get; set; }
    }
}
