using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Cars.Models;
using TuneOrBuy.Services.Parts.Models;

namespace TuneOrBuy.Services.Contracts
{
    public interface ICarService
    {
        Task<Seller> GetSellerByBuyerIdAsync(string userId);
        Task<Seller> GetSellerBySellerIdAsync(string userId);
        Task<Buyer> GetBuyerByIdAsync(string userId);
        Task<Town> GetTownByIdAsync(int townId);
        Task<CarServiceModel> GetCarAsync(string carId);
        Task<List<CarServiceModel>> AllCarsAsync();
        Task CreateCarAsync(string manufacturer, string brand, string bodyType, string vin, string fuel, int horsePower, int year, int firstRegistrationYear, decimal price, int traveledDistance, string sellerId, string imageUrl, string gearType, string color, string numberOfDoors, string numberOfSeats, List<string> equipments, string description, bool serviceHistory);
        Task<CarDetailsServiceModel> CarDetailsByIdAsync(string carId);
        Task EditCarAsync(string id, string manufacturer, string brand, string bodyType, string vin, string fuel, int horsePower,
                          int year, int firstRegistrationYear, decimal price, int traveledDistance,
                          string sellerId, string imageUrl, string gearType, string color, string numberOfDoors, string numberOfSeats,
                          string equipments, string description, bool serviceHistory);
        Task DeleteCarAsync(string  carId);
        Task ToFavouriteCarsAsync(string carId, string userId);
        Task<Tuple<bool, Buyer, Car>> ContainsCarAsync(string carId, string userId);
        Task<List<CarServiceModel>> MyFavoriteCarsAsync(string userId);
    }
}
