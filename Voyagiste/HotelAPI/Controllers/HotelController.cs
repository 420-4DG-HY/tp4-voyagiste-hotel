using Microsoft.AspNetCore.Mvc;
using HotelBLL;
using HotelDTO;
using CommonDataDTO;

namespace HotelAPI.Controllers
{
    //!!!!!!!!!!!!!!!!!!!!!!!!!POUR INFO, IL N'EST PAS SENSÉ Y AVOIR QUOIQUE CE SOIT ICI À LA BASE!!!!!!!!!
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        readonly ILogger<HotelController> _logger;
        readonly IHotelBusinessLogic _bll;

        public HotelController(IHotelBusinessLogic BusinessLogic, ILogger<HotelController> Logger)
        {
            _bll = BusinessLogic;
            _logger = Logger;
        }

        [HttpGet("GetAvailableHotelModels")]
        public HotelModel[] GetAvailableHotelModels()
        {
            return _bll.GetAvailableHotelModels();
        }

        [HttpGet("HotelAvailabilities/{HotelModelGuid}")]
        public HotelAvailability[] GetHotelAvailabilities(Guid HotelModelGuid)
        {
            if (HotelModelGuid != null)
            {
                HotelModel? cm = _bll.GetHotelModel(HotelModelGuid);
                if (cm != null)
                {
                    return _bll.GetHotelAvailabilities(cm);
                }
            }

            // Aucun résultat
            return new List<HotelAvailability>().ToArray();
        }

        [HttpGet("Hotel/{HotelId}")]
        public Hotel? GetHotel(Guid HotelId)
        {
            var hotel = _bll.GetHotel(HotelId);
            return hotel;
        }

        [HttpPost("Book")]
        public HotelBooking Book(Guid HotelId, DateTime From, DateTime To, Person rentedTo)
        {
            return _bll.Book(HotelId, From, To, rentedTo);
        }
    }
}