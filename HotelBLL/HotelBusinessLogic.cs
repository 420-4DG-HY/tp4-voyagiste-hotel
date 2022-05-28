using System;
using CommonDataDTO;
using HotelDTO;
using HotelDAL;
using Microsoft.Extensions.Logging;

namespace HotelBLL
{
    public interface IHotelBusinessLogic
    {
        public HotelModel[] GetAvailableHotelModels();
        public HotelAvailability[] GetHotelAvailabilities(HotelModel hotelModel);
        public HotelBooking? GetHotelBooking(Guid HotelBookingId);
        public HotelModel? GetHotelModel(Guid HotelModelId);
        public Hotel? GetHotel(Guid HotelId);


        public HotelBooking Book(Guid HotelId, DateTime From, DateTime To, Person rentedTo);

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

        public HotelBooking Book(Guid HotelId, DateTime From, DateTime To, Person rentedTo)
        {
            Hotel? hotel = _dal.GetHotel(HotelId);
            if (hotel == null)
            {
                string message = "Invalid Hotel GUID : " + HotelId;
                _logger.LogError(message);
                throw new Exception(message);
            }
            return _dal.Book(hotel, From, To, rentedTo);
        }

        public BookingCancellation CancelBooking(HotelBooking hb)
        {
            // Libère la plage horaire de cette réservation
            _dal.AddHotelAvailability(hb.Hotel, hb.From, hb.To);
            CleanupAvailabilities(hb.Hotel);

            return _dal.CancelBooking(hb);
        }

        void CleanupAvailabilities(Hotel hotel)
        {
            // ici on devrait éventuellement fusionner les disponibilités adjacentes
            // Une forme de défragmentation du calendrier après une annulation ou un retour prématuré de véhicule...

            HotelAvailability[]? availabilities = _dal.GetHotelAvailabilities(hotel);

            // On identifie les disponibilités adjacentes 
            // On les supprime et crée une nouvelle disponibilité qui les remplace
        }

        #region Les autres méthodes sont simplement des délégations au DAL
        public BookingConfirmation ConfirmBooking(HotelBooking hb)
        {
            return _dal.ConfirmBooking(hb);
        }

        public HotelModel[] GetAvailableHotelModels()
        {
            return _dal.GetAvailableHotelModels();
        }

        public BookingCancellation? GetBookingCancellation(HotelBooking hotelBooking)
        {
            return _dal.GetBookingCancellation(hotelBooking);
        }

        public BookingConfirmation? GetBookingConfirmation(HotelBooking hotelBooking)
        {
            return _dal.GetBookingConfirmation(hotelBooking);
        }

        public HotelAvailability[] GetHotelAvailabilities(HotelModel model)
        {
            return _dal.GetHotelAvailabilities(model);
        }

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

        public HotelModel? GetHotelModel(Guid HotelModelId)
        {
            return _dal.GetHotelModel(HotelModelId);
        }
        #endregion
    }
}