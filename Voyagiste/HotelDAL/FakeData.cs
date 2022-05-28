using CommonDataDTO;
using HotelDTO;

namespace HotelDAL
{
    public class FakeData
    {
        private static FakeData? Singleton;

        private FakeData()
        {
            public record Room(Guid RoomId, Hotel Hotel, string RoomName);
            public record Hotel(Guid HotelId, Address HotelAddress);
            public record HotelBooking(Guid HotelBookingId, Room Room, Person Guest, DateTime BookedWhen) : Booking(HotelBookingId, Guest, BookedWhen);
    public record Address(Guid AddressId, Country country, Region region, City city, PostalCode postalCode, string streetAddress);

            List<Hotel> hotel = new List<Hotel>(new Hotel(new Guid(""), address[0]));
            new Room(new Guid(""), hotel[0], "Chambre101");
            new HotelBooking(new Guid(""), country[0], guest[0], new DateTime(2022, 5, 13));
        }
        internal static FakeData GetInstance()
        {
            if (Singleton == null) Singleton = new FakeData();
            return Singleton;
        }
        // TODO Faites des hotels simples avec peu d'étages/chambres, juste pour tester!
        // 
        // Utilisez des GUID statiques (fake) pour les distinguer
        // https://www.guidgenerator.com/online-guid-generator.aspx

        // TODO Simuler de la disponibilité. Attention, les disponibilités (Availability)
        // ne doivent pas être statiques puisqu'on doit voir 
        // la disponibilité changer après une réservation
    }
}