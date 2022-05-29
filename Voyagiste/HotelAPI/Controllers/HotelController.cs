using Microsoft.AspNetCore.Mvc;
//using HotelBLL;
using HotelDTO;
using CommonDataDTO;

namespace HotelAPI.Controllers
{
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

        //[HttpGet("GetAvailableHotelModels")]
        //public HotelModel[] GetAvailableHotelModels()
        //{
        //    return _bll.GetAvailableHotelModels();
        //}

        //[HttpGet("CarAvailabilities/{CarModelGuid}")]
        //public HotelAvailability[] GetHotelAvailabilities(Guid HotelModelGuid)
        //{
        //    if (HotelModelGuid != null)
        //    {
        //        HotelModel? hm = _bll.GetCarModel(HotelModelGuid);
        //        if (hm != null)
        //        {
        //            return _bll.GetCarAvailabilities(hm);
        //        }
        //    }

        //    // Aucun résultat
        //    return new List<HotelAvailability>().ToArray();
        //}

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