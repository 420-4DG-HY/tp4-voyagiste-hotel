using Microsoft.AspNetCore.Mvc;
using HotelBLL;
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

        [HttpGet("Hotel/{HotelId}")]
        public Hotel? GetHotel(Guid HotelId)
        {
            var hotel = _bll.GetHotel(HotelId);
            return hotel;
        }

        [HttpGet("Hotel/{HotelId}/{RoomId}")]
        public Room? GetRoom(Guid HotelId, Guid RoomId)
        {
            var hotel = _bll.GetHotel(HotelId);
            var room = _bll.GetRoom(hotel, RoomId);
            return room;
        }

        [HttpGet("Hotel/{HotelBookingId}")]
        public HotelBooking? GetHotelBooking(Guid HotelBookingId)
        {
            var hotel = _bll.GetHotelBooking(HotelBookingId);
            return hotel;
        }

        [HttpPost("Book")]
        public HotelBooking Book(Guid HotelId, Guid RoomId, DateTime From, DateTime To, DateTime rentedTo, Person guest)
        {
            return _bll.Book(HotelId, RoomId, From, To, rentedTo, guest);
        }
    }

}