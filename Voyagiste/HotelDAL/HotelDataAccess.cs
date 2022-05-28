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
        public HotelBooking Book(Hotel hotel, DateTime From, DateTime To, Person rentedTo);

        public BookingConfirmation ConfirmBooking(HotelBooking booking);
        public BookingConfirmation? GetBookingConfirmation(HotelBooking booking);

        public BookingCancellation CancelBooking(HotelBooking booking);
        public BookingCancellation? GetBookingCancellation(HotelBooking booking);
    }
}
