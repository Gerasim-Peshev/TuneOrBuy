using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuneOrBuy.Data.Models;

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
    }
}
