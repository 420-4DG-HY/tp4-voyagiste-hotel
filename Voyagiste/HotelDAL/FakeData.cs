using HotelDTO;

using CommonDataDTO;


namespace HotelDAL
{
    internal class FakeData
    {
        private static FakeData? Singleton;



        internal static readonly Hotel[] hotel = {
            new Hotel(new Guid("4293f4da-f7c8-4998-aa41-f0c05aab2cfb"),hotelRentalCompanies[0],hotelModels[0], hotelSpecifications[0],"BTP-01"),
            new Hotel(new Guid("54cf1439-a515-413e-a839-ae16717433d9"),hotelRentalCompanies[0],hotelModels[1], hotelSpecifications[1],"BFF-01"),
            new Hotel(new Guid("bea09eb2-dca6-4ad2-be61-28f341b5d424"),hotelRentalCompanies[1],hotelModels[2], hotelSpecifications[2],"ABX-01")
        };


        #region données dynamiques
        internal List<HotelAvailability> hotelAvailabilities;
        internal List<HotelBooking> hotelBookings;
        internal List<BookingConfirmation> bookingConfirmations;
        internal List<BookingCancellation> bookingCancellations;
        #endregion

        private FakeData()
        {
            hotelAvailabilities = new List<HotelAvailability>();
            hotelAvailabilities.Add(new HotelAvailability(new Guid("56f93c48-0922-42d7-bddd-a3edd154685d"), hotel[0], new DateTime(2022, 2, 12), new DateTime(2022, 7, 1)));
            hotelAvailabilities.Add(new HotelAvailability(new Guid("aceff190-c2cb-47a7-b773-a150173eb89f"), hotel[1], new DateTime(2022, 2, 12), new DateTime(2022, 7, 1)));
            hotelAvailabilities.Add(new HotelAvailability(new Guid("10e9721a-2a9a-4d45-a86d-54dea2dce15b"), hotel[2], new DateTime(2022, 2, 12), new DateTime(2022, 7, 1)));

            hotelBookings = new List<HotelBooking>();
            bookingConfirmations = new List<BookingConfirmation>();
            bookingCancellations = new List<BookingCancellation>();
        }





        internal static FakeData GetInstance()
        {
            if (Singleton == null) Singleton = new FakeData();
            return Singleton;
        }
    }
}