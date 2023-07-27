using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Cars.Models;

namespace TuneOrBuy.Services.Contracts
{
    public interface ICarService
    {
        Task<Seller> GetSeller(string userId);
        Task<CarServiceModel> GetCar(string carId);
        Task<List<CarServiceModel>> AllCarsAsync();
        Task<IEnumerable<CarServiceModel>> MyCarsAsync(string userId);
        Task CreateCarAsync(string manufacturer, string brand, string bodyType, string vin, string fuel, int horsePower, int year, int firstRegistrationYear, decimal price, int traveledDistance, string sellerId, string imageUrl, string gearType, string color, string numberOfDoors, string numberOfSeats, IEnumerable<string> equipments, string description, bool serviceHistory);
        Task<CarServiceModel> CarDetailsByIdAsync(string carId);

        Task EditCarAsync(string id, string manufacturer, string brand, string bodyType, string vin, string fuel, int horsePower,
                       DateTime year, DateTime firstRegistrationYear, decimal price, int traveledDistance,
                       string sellerId, string imageUrl, string gearType, string color, string numberOfDoors, string numberOfSeats,
                       IEnumerable<string> equipments, string description, bool serviceHistory);

        Task DeleteCar(string  carId);
    }
}
