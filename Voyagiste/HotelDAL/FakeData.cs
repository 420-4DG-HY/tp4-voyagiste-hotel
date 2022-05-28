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
            public record Country(string countryName); // Devrait éventuellement avoir un code ISO correspondant et supporter multilinguisme...
          
            public record Passport(Guid PassportId, Country country, string passportNumber, DateTime expiration);
            public record Title(string title); // M., Mme, Dr, ... Devrait être multilingue, mais on garde ça simple :-)
            public record BirthDate(DateTime birthDate); // Éventuellement changer le setter pour arrondir et fournir les méthodes pour l'âge
            public record Person(Guid PersonId, Title? title, string firstName, string? middleName, string lastName, BirthDate? birthDate, Passport? passport);
            
            #region Titles
            var titles = new List<Title>();
            titles.Add(new Title("M."));
            titles.Add(new Title("Mme"));
            #endregion
            
            #region BirthDates
            var birthDates = new List<BirthDate>();
            birthDates.Add(new BirthDate(new DateTime (2000, 1, 1)));
            birthDates.Add(new BirthDate(new DateTime (2003, 5, 1)));
            #endregion
            
            #region Countries
            var countries = new List<Country>();
            countries.Add(new Country("Canada"));
            countries.Add(new Country("France"));
            #endregion

            #region Regions

            #endregion

            #region Cities

            #endregion

            #region CodePostals

            #endregion

            #region Passports
            var passports = new List<Passport>();
            passports.Add(new Passport(new Guid(""), countries[0], "12CS12345", new DateTime(2033, 5, 13)));
            passports.Add(new Passport(new Guid(""), countries[0], "13AM20035", new DateTime (2036, 10, 14)));
            #endregion
            
            #region Guests (Persons)
            var guests = new List<Person>();
            guests.Add(new Person(new Guid(""), titles[0], "Cassian", "Stan", "Scarlet", birthDates[0], passports[0]));
            guests.Add(new Person(new Guid(""), null, "Kaimi", null, "Inanis", null, null));
            guests.Add(new Person(new Guid(""), titles[1], "Angelica", "Maria", "Marika", birthDates[1], passports[1]));
            #endregion

            #region Addresses
            var addresses = new List<Address>();
            addresses.Add(new Address(new Guid(""), countries[0], regions[0], cities[0], postalCodes[0], "404, rue Chezpasou"));
            addresses.Add(new Address(new Guid(""), countries[0], regions[1], cities[1], postalCodes[1], "405, rue Chuiou"));
            addresses.Add(new Address(new Guid(""), countries[1], regions[2], cities[2], postalCodes[2], "505, rue Chuiperdu"));
            #endregion

            #region Hotels
            var hotels = new List<Hotel>();
            hotels.Add(new Hotel(new Guid(""), addresses[0]));
            hotels.Add(new Hotel(new Guid(""), addresses[1]));
            hotels.Add(new Hotel(new Guid(""), addresses[2]));

            #endregion

            #region Rooms
            var rooms = new List<Room>();
            rooms.Add(new Room(new Guid(""), hotels[0],"Chambre101"));
            rooms.Add(new Room(new Guid(""), hotels[1],"Chambre202"));
            rooms.Add(new Room(new Guid(""), hotels[2],"Chambre303"));
            #endregion
            #region HotelBookings
            var hotelBookings = new List<HotelBooking>();
            hotelBookings.Add(new HotelBooking(new Guid(""), rooms[0], guests[0], new DateTime(2022, 5, 11)));
            hotelBookings.Add(new HotelBooking(new Guid(""), rooms[1], guests[1], new DateTime(2023, 10, 12)));
            hotelBookings.Add(new HotelBooking(new Guid(""), rooms[2], guests[3], new DateTime(2024, 12, 13)));
            #endregion
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