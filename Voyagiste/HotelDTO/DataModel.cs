using CommonDataDTO;

namespace HotelDTO
{
    public record Room(Guid RoomId, Hotel Hotel, string RoomName);
    public record Hotel(Guid HotelId, Address HotelAddress);

    public record HotelAvailability(Guid HotelAvailabilityId, Room room, DateTime From, DateTime To);
    public record HotelBooking(Guid HotelBookingId, Room Room, DateTime From, DateTime To, Person Guest, DateTime BookedWhen) : Booking(HotelBookingId, Guest, BookedWhen);

}