using CommonDataDTO;
using HotelDTO;

namespace HotelDAL
{
    public class FakeData
    {
        private static FakeData? Singleton;

        //À compléter ici les list
        #region Titles
        internal static readonly Title[] titles = {
            new Title("M."),
            new Title("Mme")
        };
        #endregion

        #region BirthDates
        internal static readonly BirthDate[] birthDates = {
            new BirthDate(new DateTime(2000, 1, 1)),
            new BirthDate(new DateTime(2003, 5, 1))
        };
        #endregion

        #region Countries
        internal static readonly Country[] countries = {
        new Country("Canada"),
            new Country("France")

        };
        #endregion

        #region Regions
        internal static readonly Region[] regions = {
        new Region("Oussa"),
            new Region("Saitou"),
            new Region("Somewhere")
        };
        #endregion

        #region Cities
        internal static readonly City[] cities = {
            new City("Laval"),
            new City("Marseille")
            };
        #endregion

        #region PostalCodes
        internal static readonly PostalCode[] postalCodes = {
        new PostalCode("B3RR3B"),
         new PostalCode("D4SS4D"),
         new PostalCode("F5TT5F")
        };
        #endregion

        #region Passports
        internal static readonly Passport[] passports = {
        new Passport(new Guid("5e8fea4d-9f74-42fc-9556-03cfecc30849"), countries[0], "12CS12345", new DateTime(2033, 5, 13)),
        new Passport(new Guid("bbf643ec-cf56-4e96-a15a-2da78999d553"), countries[1], "13AM20035", new DateTime(2036, 10, 14))
        };
        #endregion

        #region Guests (Persons)
        internal static readonly Person[] guests = {
        new Person(new Guid("37275592-4c5b-4d16-a1a2-5ffac17ffd15"), titles[0], "Cassian", "Stan", "Scarlet", birthDates[0], passports[0]),
            new Person(new Guid("b184de97-d0be-413a-b4f5-bbdba601e9c2"), null, "Kaimi", null, "Inanis", null, null),
            new Person(new Guid("40bda044-9891-4c3a-8dde-fc8133590405"), titles[1], "Angelica", "Maria", "Marika", birthDates[1], passports[1])
        };
        #endregion

        #region Addresses
        internal static readonly Address[] addresses =
        {

        new Address(new Guid("6e746e0d-1b8d-494a-9359-34bfc155f58f"), countries[0], regions[0], cities[0], postalCodes[0], "404, rue Chezpasou"),
           new Address(new Guid("72f403bd-3906-4928-a384-c815e6131f93"), countries[0], regions[1], cities[1], postalCodes[1], "405, rue Chuiou"),
           new Address(new Guid("639137dc-650c-4f09-96a0-67573aa6e05d"), countries[1], regions[2], cities[2], postalCodes[2], "505, rue Chuiperdu")
        };
        #endregion

        #region Hotels
        internal static readonly Hotel[] hotels = {
        new Hotel(new Guid("54973543-6cf3-4c88-8b47-f48d87bcf392"), addresses[0]),
        new Hotel(new Guid("d223bea0-a58a-46dd-8463-0c9727d33071"), addresses[1]),
        new Hotel(new Guid("1fa4aa21-d1fb-417b-b207-59d219b1a582"), addresses[2])
        };

        #endregion

        #region Rooms
        internal static readonly Room[] rooms = {
        new Room(new Guid("207602ae-fb7f-4e8f-954e-c906b37bd40d"), hotels[0], "Chambre101"),
        new Room(new Guid("e5f4bb57-b6aa-4c64-932c-d54a0a860dbe"), hotels[1], "Chambre202"),
        new Room(new Guid("f98befd5-7a4a-44bb-9043-1090ad405644"), hotels[2], "Chambre303")
        };
        #endregion

        //  /!\ À supprimer /!\ Je le garde seulement pour un back-up si jamais on a besoin de ça - Nicolas
        //#region HotelBookings
        //internal static readonly HotelBooking[] hotelBookings = {
        //new HotelBooking(new Guid(" "), rooms[0], guests[0], new DateTime(2022, 5, 11)),
        //new HotelBooking(new Guid(" "), rooms[1], guests[1], new DateTime(2023, 10, 12)),
        //new HotelBooking(new Guid(" "), rooms[2], guests[3], new DateTime(2024, 12, 13))
        //};
        //#endregion

        internal List<HotelAvailability> hotelAvailabilities;
        internal List<HotelBooking> hotelBookings;
        internal List<BookingConfirmation> bookingConfirmations;
        internal List<BookingCancellation> bookingCancellations;
        private FakeData()
        {
            hotelAvailabilities = new List<HotelAvailability>();
            hotelAvailabilities.Add(new HotelAvailability(new Guid("d3062793-8a01-4e8a-beba-2db3a9cf0871"), rooms[0],  new DateTime(2022, 5, 11), new DateTime(2022, 7, 1)));
            hotelAvailabilities.Add(new HotelAvailability(new Guid("c901d3e7-17ee-44f8-8787-842a5e72184f"), rooms[1],  new DateTime(2023, 5, 12), new DateTime(2022, 7, 2)));
            hotelAvailabilities.Add(new HotelAvailability(new Guid("52b54352-7415-4723-bc11-5caebaba9f8c"), rooms[2], new DateTime(2024, 5, 13), new DateTime(2022, 7, 3)));

            hotelBookings = new List<HotelBooking>();
            bookingConfirmations = new List<BookingConfirmation>();
            bookingCancellations = new List<BookingCancellation>();
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