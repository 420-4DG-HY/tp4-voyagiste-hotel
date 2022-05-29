using System;

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

        public CarBusinessLogic(IHotelDataAccess DataAccess, ILogger<HotelBusinessLogic> Logger)
        {
            _dal = DataAccess;
            _logger = Logger;
        }

        public HotelBooking Book(Guid CarId, DateTime From, DateTime To, Person rentedTo)
        {
            Hotel? hotel = _dal.GetHotel(HotelId);
            if (hotel == null)
            {
                string message = "Invalid Car GUID : " + CarId;
                _logger.LogError(message);
                throw new Exception(message);
            }
            return _dal.Book(hotel, From, To, rentedTo);
        }

        public BookingCancellation CancelBooking(HotelBooking hb)
        {
            // Libère la plage horaire de cette réservation
            _dal.AddCarAvailability(hb.Car, hb.From, hb.To);
            CleanupAvailabilities(hb.Car);

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

        public HotelModel[] GetAvailableCarModels()
        {
            return _dal.GetAvailableCarModels();
        }

        public BookingCancellation? GetBookingCancellation(HotelBooking carBooking)
        {
            return _dal.GetBookingCancellation(carBooking);
        }

        public BookingConfirmation? GetBookingConfirmation(HotelBooking carBooking)
        {
            return _dal.GetBookingConfirmation(carBooking);
        }

        public HotelAvailability[] GetCarAvailabilities(HotelModel model)
        {
            return _dal.GetCarAvailabilities(model);
        }

        public CarBooking? GetCarBooking(Guid CarBookingId)
        {
            return _dal.GetCarBooking(CarBookingId);
        }

        public HotelBooking[] GetHotelBookings(Hotel hotel)
        {
            return _dal.GetHotelBookings(hotel);
        }

        public Hotel? GetHotel(Guid CarId)
        {
            return _dal.GetHotel(CarId);
        }

        public HotelModel? GetCarModel(Guid HotelModelId)
        {
            return _dal.GetHotelModel(HotelModelId);
        }
        #endregion
    }
}