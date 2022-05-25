using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
//using HotelDTO;
//using CommonDataDTO;

namespace CarDAL
{
    public interface IHotalDataAccess
    {
        //public HotelModel[] GetAvailableCarModels();
        //public HotelModel? GetCarModel(Guid HotelModelId);
        //public Hotel? GetCar(Guid HotelId);
        //public HotelAvailability[] GetCarAvailabilities(HotelModel model);
        //public HotelAvailability[] GetCarAvailabilities(Hotel hotel);
        //public HotelAvailability AddCarAvailability(Hotel car, DateTime From, DateTime To);
        //public HotelBooking? GetCarBooking(Guid HotelBookingId);
        //public HotelBooking[] GetCarBookings(Person rentedTo);
        //public HotelBooking[] GetCarBookings(Hotel hotel);
        //public HotelBooking Book(Hotel hotel, DateTime From, DateTime To, Person rentedTo);

        //public BookingConfirmation ConfirmBooking(HotelBooking booking);
        //public BookingConfirmation? GetBookingConfirmation(HotelBooking booking);

        //public BookingCancellation CancelBooking(HotelBooking booking);
        //public BookingCancellation? GetBookingCancellation(CarBooking booking);
    }

    public class HotelDataAccess : IHotalDataAccess
    {
        private IConfiguration _configuration;
        private ILogger _logger;

        public HotelDataAccess(IConfiguration configuration, ILogger<HotelDataAccess> logger)
        {
            _configuration = configuration; // Permet éventuellement de recevoir ici la connexion string pour la base de données
            _logger = logger;
        }

        ///// <summary>
        ///// Enregistre une réservation de voiture
        ///// 
        ///// Attention, les disponibilités ne sont pas gérés par le DAL
        ///// </summary>
        //public HotelBooking Book(Hotel Hotel, DateTime From, DateTime To, Person rentedTo)
        //{
        //    var booking = new HotelBooking(new Guid(), Hotel, From, To, rentedTo, new DateTime());
        //    FakeData.GetInstance().carBookings.Add(booking);    
        //    return booking;
        //}

        ///// <summary>
        ///// Enregistre une cancellation de voiture
        ///// 
        ///// Attention, la gestion du retrait de booking et les remises en disponibilités ne sont pas gérés par le DAL
        ///// </summary>
        //public BookingCancellation CancelBooking(HotelBooking booking)
        //{
        //    BookingCancellation bc = new BookingCancellation(new Guid(), booking , new DateTime());
        //    FakeData.GetInstance().bookingCancellations.Add(bc);
        //    return bc;
        //}

        //public BookingConfirmation ConfirmBooking(HotelBooking booking)
        //{
        //    BookingCancellation? bBancel = GetBookingCancellation(booking);
        //    if (bBancel != null)
        //    {
        //        string message = "Cannot confirm booking : \n" + booking +" \nBecause it has been cancelled by : \n" + bBancel;
        //        _logger.LogError(message);
        //        throw new Exception(message);
        //    }
        //    else
        //    {
        //        BookingConfirmation bc = new BookingConfirmation(new Guid(), booking, new DateTime());
        //        FakeData.GetInstance().bookingConfirmations.Add(bc);
        //        return bc;
        //    }
        //}

        //public HotelAvailability[] GetHotelAvailabilities(HotelModel model)
        //{
        //    return FakeData.GetInstance().hotelAvailabilities.Where(ha => ha.Hotel.model == model).ToArray();
        //}

        //public HotelBooking? GetHotelBooking(Guid HotelBookingId)
        //{
        //    return FakeData.GetInstance().hotelBookings.Where(hb => hb.HotelBookingId == HotelBookingId).FirstOrDefault();
        //}

        //public HotelBooking[] GetHotelBookings(Hotel car)
        //{
        //    return FakeData.GetInstance().hotelBookings.Where(hb => hb.Hotel == hotel).ToArray();
        //}

        //public HotelModel[] GetAvailableHotelModels()
        //{
        //    return FakeData.hotel.Select(hm => hm.model).Distinct().ToArray();
        //}

        //public BookingConfirmation? GetBookingConfirmation(HotelBooking booking)
        //{
        //    return FakeData.GetInstance().bookingConfirmations.Where(bc => bc.Booking == booking).FirstOrDefault();
        //}

        //public BookingCancellation? GetBookingCancellation(HotelBooking booking)
        //{
        //    return FakeData.GetInstance().bookingCancellations.Where(bc => bc.Booking == booking).FirstOrDefault();
        //}

        //public HotelBooking[] GetHotelBookings(Person rentedTo)
        //{
        //    return FakeData.GetInstance().hotelBookings.Where(hb => hb.rentedTo == rentedTo).ToArray();
        //}

        //public Hotel? GetHotel(Guid HotelId)
        //{
        //    return FakeData.car.Where(hotel => hotel.HotelId == HotelId).FirstOrDefault();
        //}

        //public HotelAvailability[] GetHotelAvailabilities(Hotel hotel)
        //{
        //    return FakeData.GetInstance().carAvailabilities.Where(ha => ha.Hotel == Hotel).ToArray();
        //}

        //public HotelAvailability AddHotelAvailability(Hotel hotel, DateTime From, DateTime To)
        //{
        //    HotelAvailability ha = new HotelAvailability(new Guid(), hotel, From, To);
        //    FakeData.GetInstance().hotelAvailabilities.Add(ha);
        //    return ha;
        //}

        //public HotelModel? GetHotelModel(Guid HotelModelId)
        //{
        //    return FakeData.hotelModels.Where(cm=>cm.HotelModelId == HotelModelId).FirstOrDefault();
        //}
    }
}
