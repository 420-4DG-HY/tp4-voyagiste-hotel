using CommonDataDTO;
using HotelDTO;
using HotelDAL;

using Microsoft.Extensions.Logging;

namespace HotelBLL
{
    public interface IHotelBusinessLogic
    {
        //public HotelModel[] GetAvailableHotelModels();
        public Hotel? GetHotel(Guid HotelId);
        public Room? GetRoom(Hotel hotel, Guid RoomId);
        //public HotelAvailability[] GetHotelAvailabilities(HotelModel hotelModel);
        public HotelBooking? GetHotelBooking(Guid HotelBookingId);
        //public HotelModel? GetHotelModel(Guid HotelModelId);


        public HotelBooking Book(Guid HotelId, Guid RoomId, DateTime From, DateTime To, DateTime rentedTo, Person guest);

        public BookingConfirmation ConfirmBooking(HotelBooking hotelBooking);
        public BookingConfirmation? GetBookingConfirmation(HotelBooking hotelBooking);

        public BookingCancellation CancelBooking(HotelBooking hotelBooking);
        public BookingCancellation? GetBookingCancellation(HotelBooking hotelBooking);
    }


    public class HotelBusinessLogic : IHotelBusinessLogic
    {
        readonly ILogger<HotelBusinessLogic> _logger;
        readonly IHotelDataAccess _dal;

        public HotelBusinessLogic(IHotelDataAccess DataAccess, ILogger<HotelBusinessLogic> Logger)
        {
            _dal = DataAccess;
            _logger = Logger;
        }

        public HotelBooking Book(Guid HotelId, Guid RoomId, DateTime From, DateTime To, DateTime rentedTo, Person guest)
        {
            Hotel? hotel = _dal.GetHotel(HotelId);
            if (hotel == null)
            {
                string message = "Invalid Hotel GUID : " + HotelId;
                _logger.LogError(message);
                throw new Exception(message);
            }
            Room? room = _dal.GetRoom(hotel, RoomId);
            return _dal.Book(room, guest, From, To, rentedTo);
        }

        public BookingCancellation CancelBooking(HotelBooking hb)
        {
            // Libère la plage horaire de cette réservation
            _dal.AddHotelAvailability(hb.Room, hb.From, hb.To);
            CleanupAvailabilities(hb.Room);

            return _dal.CancelBooking(hb);
        }

        void CleanupAvailabilities(Room room)
        {
            // ici on devrait éventuellement fusionner les disponibilités adjacentes
            // Une forme de défragmentation du calendrier après une annulation ou un retour prématuré de véhicule...

            HotelAvailability[]? availabilities = _dal.GetHotelAvailabilities(room);

            // On identifie les disponibilités adjacentes 
            // On les supprime et crée une nouvelle disponibilité qui les remplace
        }

        #region Les autres méthodes sont simplement des délégations au DAL
        public BookingConfirmation ConfirmBooking(HotelBooking hb)
        {
            return _dal.ConfirmBooking(hb);
        }

        //public HotelModel[] GetAvailableHotelModels()
        //{
        //    return _dal.GetAvailableCarModels();
        //}

        public BookingCancellation? GetBookingCancellation(HotelBooking hotelBooking)
        {
            return _dal.GetBookingCancellation(hotelBooking);
        }

        public BookingConfirmation? GetBookingConfirmation(HotelBooking hotelBooking)
        {
            return _dal.GetBookingConfirmation(hotelBooking);
        }

        //public HotelAvailability[] GetHotelAvailabilities(HotelModel model)
        //{
        //    return _dal.GetHotelAvailabilities(model);
        //}

        public HotelBooking? GetHotelBooking(Guid HotelBookingId)
        {
            return _dal.GetHotelBooking(HotelBookingId);
        }

        public HotelBooking[] GetHotelBookings(Hotel hotel)
        {
            return _dal.GetHotelBookings(hotel);
        }

        public Hotel? GetHotel(Guid HotelId)
        {
            return _dal.GetHotel(HotelId);
        }

        //public HotelModel? GetHotelModel(Guid HotelModelId)
        //{
        //    return _dal.GetHotelModel(HotelModelId);
        //}

        public Room? GetRoom(Hotel hotel, Guid RoomId)
        {
            return _dal.GetRoom(hotel, RoomId);
        }
        #endregion
    }
}