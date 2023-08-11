using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.CarServices.Models;

namespace TuneOrBuy.Services.Contracts
{
    public interface ICarServiceOwnerService
    {
        Task<bool> UserIsCarServiceOwner(string userId);
        Task<CarServiceOwner> GetCarServiceOwner(string userId);


        Task<bool> ExistsById(string userId);
        Task<bool> ExistsByPhoneNumber(string phoneNumber);
        Task CreateCarServiceOwner(string userId, string phoneNumber);
        Task<Buyer> GetBuyerAsync(string userId);
        Task<List<CarServiceServiceModel>> GetAllCarServicesForManage(string userId);
    }
}
