using Microsoft.Extensions.Logging;
using CarDTO;

namespace CarService
{
    public interface ICarService
    {
        public Task<IEnumerable<VehicleSize>> GetVehicleSizes();
    }

    public class CarServiceProxy : ICarService
    {
        private readonly ILogger _logger;

        public CarServiceProxy(ILogger<CarServiceProxy> logger)
        {
            _logger=logger;
        }

#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone. Utilisez l'opérateur 'await' pour attendre les appels d'API non bloquants ou 'await Task.Run(…)' pour effectuer un travail utilisant le processeur sur un thread d'arrière-plan.
        public async Task<IEnumerable<VehicleSize>> GetVehicleSizes()
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone. Utilisez l'opérateur 'await' pour attendre les appels d'API non bloquants ou 'await Task.Run(…)' pour effectuer un travail utilisant le processeur sur un thread d'arrière-plan.
        {
            // TODO Appeler le CarAPI
            int itemCount=0;

            _logger.LogInformation("GetVehicleSizes() => "+ itemCount + " items");
            return new List<VehicleSize>();
        }
    }
}