using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TuneOrBuy.Data.Models;

namespace TuneOrBuy.Services.Contracts
{
    public interface ISellerService
    {
        Task<bool> UserIsSeller(Guid userId);
        Task<bool> ExistsById(Guid userId);
        Task<bool> ExistsByPhoneNumber(string phoneNumber);
        Task CreateSeller(Guid userId, string phoneNumber, int townId, string imageUrl);
        Task<IEnumerable<Town>> GetAllTowns();
        Task<Buyer> GetBuyerAsync(Guid userId);
        Task<Town> GetTownByIdAsync(int townId);
    }
}
