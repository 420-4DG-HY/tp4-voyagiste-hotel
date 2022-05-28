using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using HotelDTO;
using CommonDataDTO;
using HotelDAL;

namespace HotelDAL
{
    public interface IHotelDataAccess
    {
        public Hotel GetHotel(Guid HotelId);
        public HotelAvailability[] GetHotelAvailabilities(Hotel hotel);
        public HotelAvailability AddHotelAvailability(Hotel hotel, DateTime From, DateTime To);
        public HotelBooking? GetHotelBooking(Guid HotelBookingId);
        public HotelBooking[] GetHotelBookings(Person rentedTo);
        public HotelBooking[] GetHotelBookings(Hotel hotel);
        public HotelBooking Book(Room room, Person guest, DateTime bookedWhen);

        public BookingConfirmation ConfirmBooking(HotelBooking booking);
        public BookingConfirmation? GetBookingConfirmation(HotelBooking booking);

        public BookingCancellation CancelBooking(HotelBooking booking);
        public BookingCancellation? GetBookingCancellation(HotelBooking booking);
    }

    public class HotelDataAccess : IHotelDataAccess
    {
        private IConfiguration _configuration;
        private ILogger _logger;

        public HotelDataAccess(IConfiguration configuration, ILogger<HotelDataAccess> logger)
        {
            _configuration = configuration; // Permet éventuellement de recevoir ici la connexion string pour la base de données
            _logger = logger;
        }

        /// <summary>
        /// Enregistre une réservation de voiture
        /// 
        /// Attention, les disponibilités ne sont pas gérés par le DAL
        /// </summary>
        public HotelBooking Book(Room room, Person guest, DateTime bookedWhen)
        {
            var booking = new HotelBooking(new Guid(), room, guest, bookedWhen);
            FakeData.GetInstance().hotelBookings.Add(booking);
            return booking;
        }

        /// <summary>
        /// Enregistre une cancellation de voiture
        /// 
        /// Attention, la gestion du retrait de booking et les remises en disponibilités ne sont pas gérés par le DAL
        /// </summary>
        public BookingCancellation CancelBooking(HotelBooking booking)
        {
            BookingCancellation bc = new BookingCancellation(new Guid(), booking, new DateTime());
            FakeData.GetInstance().bookingCancellations.Add(bc);
            return bc;
        }

        public BookingConfirmation ConfirmBooking(HotelBooking booking)
        {
            BookingCancellation? bBancel = GetBookingCancellation(booking);
            if (bBancel != null)
            {
                string message = "Cannot confirm booking : \n" + booking + " \nBecause it has been cancelled by : \n" + bBancel;
                _logger.LogError(message);
                throw new Exception(message);
            }
            else
            {
                BookingConfirmation bc = new BookingConfirmation(new Guid(), booking, new DateTime());
                FakeData.GetInstance().bookingConfirmations.Add(bc);
                return bc;
            }
        }

        public HotelBooking? GetHotelBooking(Guid HotelBookingId)
        {
            return FakeData.GetInstance().hotelBookings?.Where(cb => cb.HotelBookingId == HotelBookingId).FirstOrDefault();
        }

        public HotelBooking[] GetHotelBookings(Hotel hotel)
        {
            return FakeData.GetInstance().hotelBookings.Where(cb => cb.Room.Hotel == hotel).ToArray();
        }

        public BookingConfirmation? GetBookingConfirmation(HotelBooking booking)
        {
            return FakeData.GetInstance().bookingConfirmations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }

        public BookingCancellation? GetBookingCancellation(HotelBooking booking)
        {
            return FakeData.GetInstance().bookingCancellations.Where(bc => bc.Booking == booking).FirstOrDefault();
        }

        public HotelBooking[] GetHotelBookings(Person guest)
        {
            return FakeData.GetInstance().hotelBookings.Where(cb => cb.Guest == guest).ToArray();
        }

        public Hotel? GetHotel(Guid HotelId)
        {
            return FakeData.hotel.Where(hotel => hotel.HotelId == HotelId).FirstOrDefault();
        }

        public HotelAvailability[] GetHotelAvailabilities(Hotel hotel)
        {
            return FakeData.GetInstance().hotelAvailabilities.Where(ca => ca.Hotel == hotel).ToArray();
        }

        public HotelAvailability AddHotelAvailability(Hotel hotel, DateTime From, DateTime To)
        {
            HotelAvailability ca = new HotelAvailability(new Guid(), hotel, From, To);
            FakeData.GetInstance().hotelAvailabilities.Add(ca);
            return ca;
        }

    }
}
