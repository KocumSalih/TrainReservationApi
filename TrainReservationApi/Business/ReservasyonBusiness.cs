using System;
using System.Threading.Tasks;
using TrainReservationApi.Models.RequestModels;
using TrainReservationApi.Models.ResponseModels;

namespace TrainReservationApi.Business
{
    public class ReservasyonBusiness
    {
        private RezervasyonBiletResponse _rezervasyonResponse;
        private RezervasyonBiletRequest _rezervasyonRequest { get; set; }
        public ReservasyonBusiness(RezervasyonBiletRequest rezervasyonRequest)
        {
            _rezervasyonRequest = rezervasyonRequest;
            _rezervasyonResponse = new RezervasyonBiletResponse();

        }
        public RezervasyonBiletResponse RezervasyonAlgoritmasi()
        {
            _rezervasyonResponse.RezervasyonYapilabilir = _rezervasyonRequest.KisilerFarkliVagonlaraYerlestirilebilir ?
                ReservasyonPartial() :
                ReservasyonNotPartial();
            return _rezervasyonResponse;

        }

        private bool ReservasyonNotPartial()
        {
            int rezervasyonSayisi = _rezervasyonRequest.RezervasyonYapilacakKisiSayisi;
            foreach (var vagon in _rezervasyonRequest.Tren.Vagonlar)
            {
                if (vagon.RezervasyonYapilabilirmi(rezervasyonSayisi))
                {
                    _rezervasyonResponse.YerlesimAyrinti.Add(new YerlesimAyrinti() { KisiSayisi = rezervasyonSayisi, VagonAdi = vagon.Ad });
                    return true;
                }
            };
            return false;
        }

        private bool ReservasyonPartial()
        {
            bool result = false;
            int rezervasyonSayisi = _rezervasyonRequest.RezervasyonYapilacakKisiSayisi;
            int trendekiDoldurulabilirKoltukAdedi = 0;

            _rezervasyonRequest.Tren.Vagonlar.ForEach(vagon => trendekiDoldurulabilirKoltukAdedi += vagon.DoldurulabilirKoltukHesapla());

            if (trendekiDoldurulabilirKoltukAdedi >= rezervasyonSayisi)
            {
                int kalanRezervasyonSayisi = _rezervasyonRequest.RezervasyonYapilacakKisiSayisi;
                foreach (var vagon in _rezervasyonRequest.Tren.Vagonlar)
                {
                    int vagonDoldurulabilirKoltukAdedi = vagon.DoldurulabilirKoltukHesapla();
                    if (vagonDoldurulabilirKoltukAdedi != 0 && kalanRezervasyonSayisi > 0)
                    {
                        if (vagonDoldurulabilirKoltukAdedi <= kalanRezervasyonSayisi)
                        {
                            _rezervasyonResponse.YerlesimAyrinti.Add(new YerlesimAyrinti() { KisiSayisi = vagonDoldurulabilirKoltukAdedi, VagonAdi = vagon.Ad });                           
                        }
                        else
                        {
                            _rezervasyonResponse.YerlesimAyrinti.Add(new YerlesimAyrinti() { KisiSayisi = kalanRezervasyonSayisi, VagonAdi = vagon.Ad });
                        }
                        result = true;
                        kalanRezervasyonSayisi -= vagonDoldurulabilirKoltukAdedi;
                    }
                }
            }
            return result;
        }
    }
}