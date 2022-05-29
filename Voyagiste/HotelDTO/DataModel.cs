using CommonDataDTO;
namespace HotelDTO
{

    public record Room(Guid RoomId, Hotel Hotel, string RoomName);
    public record Hotel(Guid HotelId, Address HotelAddress);
    public record HotelBooking(Guid HotelBookingId, Room Room, Person Guest, DateTime BookedWhen) : Booking(HotelBookingId, Guest, BookedWhen);

    //Ajouté le 2022-05-28 par Nicolas St-Arnault
    public record HotelAvailability(Guid HotelAvailabilityId, Room room, DateTime From, DateTime To);

}