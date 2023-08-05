using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Cars.Models;
using TuneOrBuy.Services.CarServices.Models;
using CarDetailsServiceModel = TuneOrBuy.Services.Cars.Models.CarDetailsServiceModel;

namespace TuneOrBuy.Services.Contracts
{
    public interface ICarServiceService
    {
        Task<CarServiceOwner> GetOwnerByBuyerIdAsync(string userId);
        Task<CarServiceOwner> GetOwnerByOwnerIdAsync(string userId);
        Task<Buyer> GetBuyerByIdAsync(string userId);
        Task<Town> GetTownByIdAsync(int townId);
        Task<CarServiceServiceModel> GetCarServiceAsync(string carServiceId);
        Task<IEnumerable<Town>> GetAllTowns();


        Task<List<CarServiceServiceModel>> AllCarServicesAsync();
        Task CreateCarServiceAsync(string name, string address, string ownerId, int townId, string phoneNumber, string services, int openHour, int closeHour, string imageUrl, string description);
        Task<CarServiceDetailsServiceModel> CarServiceDetailsByIdAsync(string carServiceId);
        Task EditCarServiceAsync(string id, string name, string address, string ownerId, int townId, string phoneNumber, string services, int openHour, int closeHour, string imageUrl, string description);
        Task DeleteCarServiceAsync(string carServiceId);
        Task ToFavouriteCarsAsync(string carServiceId, string userId);
        Task<Tuple<bool, Buyer, CarService>> ContainsCarServiceAsync(string carServiceId, string userId);
        Task<List<CarServiceServiceModel>> MyFavoriteCarServicesAsync(string userId);
    }
}
