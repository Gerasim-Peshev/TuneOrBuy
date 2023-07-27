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
        Task<bool> UserIsCarServiceOwner(Guid userId);
        Task<bool> ExistsById(Guid userId);
        Task<bool> ExistsByPhoneNumber(string phoneNumber);
        Task CreateSeller(Guid userId, string phoneNumber);
        Task<Buyer> GetBuyerAsync(Guid userId);
    }
}
