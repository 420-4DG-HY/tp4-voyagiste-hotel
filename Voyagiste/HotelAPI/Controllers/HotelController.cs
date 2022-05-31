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

        [HttpGet("GetAllHotel")]
        public Hotel[] GetHotel()
        {
            return _bll.GetHotel();
        }

        [HttpGet("Room/GetAllRoomAvailabilities")]
        public Hotel[] GetAllHotelAvailabilities()
        {
            var hotel = _bll.GetAllHotelAvailabilities();
            if (hotel is null)
                return null;

            return hotel;
        }

        [HttpPost("Book")]
        public HotelBooking Book(Guid HotelId, Guid RoomId, DateTime From, DateTime To, DateTime rentedTo, Person guest)
        {
            return _bll.Book(HotelId, RoomId, From, To, rentedTo, guest);
        }

        [HttpGet("{HotelId}")]
        public Hotel? GetHotel(Guid HotelId)
        {
            var hotel = _bll.GetHotel(HotelId);
            if (hotel is null)
                return null;
            return hotel;
        }

        [HttpGet("Room/{HotelId}/{RoomId}")]
        public Room? GetRoom(Guid HotelId, Guid RoomId)
        {
            var hotel = _bll.GetHotel(HotelId);
            if (hotel is null)
                return null;

            var room = _bll.GetRoom(hotel, RoomId);
            if (room is null)
                return null;

            return room;
        }
    }
}