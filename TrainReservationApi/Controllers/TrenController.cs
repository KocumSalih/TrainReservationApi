using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TrainReservationApi.Business;
using TrainReservationApi.Models.RequestModels;

namespace TrainReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrenController : ControllerBase
    {

        [HttpPost("ReservasyonYap")]
        public IActionResult ReservasyonYap(RezervasyonBiletRequest request)
        {
            return request == null ?
                BadRequest("Rezarvasyon isteginiz parametrelerini kontrol edip tekrar deneyin") :
                Ok(new ReservasyonBusiness(request).RezervasyonAlgoritmasi()
                );
        }
    }
}
