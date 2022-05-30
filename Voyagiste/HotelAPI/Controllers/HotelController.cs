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

        #region Récupérer tout les hotels
        [HttpGet("GetAllHotel")]
        public Hotel[] GetHotel()
        {
            return _bll.GetHotel();
        }
        #endregion


        //[HttpGet("{HotelBookingId}")]
        //public HotelBooking? GetHotelBooking(Guid HotelBookingId)
        //{
        //    var hotel = _bll.GetHotelBooking(HotelBookingId);
        //    if (hotel is null)
        //        return null;

        //    return hotel;
        //}

        [HttpGet("GetAllRoomAvailabilities")]
        public Hotel[] GetAllHotelAvailabilities()
        {
            var hotel = _bll.GetAllHotelAvailabilities();
            if (hotel is null)
                return null;

            return hotel;
        }

        //[HttpGet("Availabilities/{HotelGuid}/{RoomGuid}")]
        //public HotelAvailability[] GetHotelAvailabilities(Guid HotelGuid, Guid RoomGuid)
        //{
        //    if (HotelGuid != null && RoomGuid != null)
        //    {
        //        var hotel = _bll.GetHotel(HotelGuid);
        //        if (hotel is null)
        //            return null;

        //        var room = _bll.GetRoom(hotel, RoomGuid);
        //        if (room is null)
        //            return null;

        //        return _bll.GetHotelAvailabilities(room);
        //    }

        //    // Aucun résultat
        //    return new List<HotelAvailability>().ToArray();
        //}

        #region Réserver une chambre dans un hotel
        [HttpPost("Book")]
        public HotelBooking Book(Guid HotelId, Guid RoomId, DateTime From, DateTime To, DateTime rentedTo, Person guest)
        {
            return _bll.Book(HotelId, RoomId, From, To, rentedTo, guest);
        }
        #endregion

        #region Récupérer un hotel avec son Id
        [HttpGet("{HotelId}")]
        public Hotel? GetHotel(Guid HotelId)
        {
            var hotel = _bll.GetHotel(HotelId);
            if (hotel is null)
                return null;
            return hotel;
        }
        #endregion

        #region Récupérer une chambre dans un hotel avec leurs Id
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
        #endregion
    }
}