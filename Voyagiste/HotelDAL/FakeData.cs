namespace HotelDAL
{
    public class FakeData
    {
        private static FakeData? Singleton;

        private FakeData()
        { 
        
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