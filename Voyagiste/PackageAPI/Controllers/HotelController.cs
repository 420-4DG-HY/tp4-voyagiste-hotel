using Microsoft.AspNetCore.Mvc;
using HotelDTO;

namespace PackageAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelController : ControllerBase
    {
        readonly ILogger<HotelController> _logger;
        readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService, ILogger<HotelController> logger)
        {
            _hotelService = hotelService;
            _logger = logger;
        }

        /// <summary>
        /// Permet de connaitre la voiture incluse dans le forfait
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPackageHotel")]
        public Hotel GetPackageHotel()
        {
            bool useStub = true;

            // Données bidon pour tester
            if (useStub)
            {
                _logger.LogInformation("useStub activé : GetPackageHotel envoie une donnée bidon.");
                return new Hotel(new Guid(),
                 new HotelRentalCompany(new Guid(), "Hertz"),
                 new HotelModel(new Guid(),
                     new VehicleSize(6, "Intermediate"),
                     new HotelManufacturer(new Guid(), "Toyota"),
                     "Prius",
                     2022)
                 , "Donnée bidon de l'API forfait");
            }
            else
            {
                // TODO consulter le package et retourner les détails de la voiture du forfait
                throw new NotImplementedException();
            }
        }
    }
}