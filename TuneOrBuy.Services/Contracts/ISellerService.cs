using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Cars.Models;
using TuneOrBuy.Services.Parts.Models;

namespace TuneOrBuy.Services.Contracts
{
    public interface ISellerService
    {
        Task<bool> UserIsSeller(string userId);
        Task<Seller> GetSeller(string userId);

        Task<bool> ExistsById(string userId);
        Task<bool> ExistsByPhoneNumber(string phoneNumber);
        Task CreateSeller(string userId, string phoneNumber, int townId, string imageUrl);
        Task<IEnumerable<Town>> GetAllTowns();
        Task<Buyer> GetBuyerAsync(string userId);
        Task<Town> GetTownByIdAsync(int townId);
        Task<List<CarServiceModel>> GetAllCarsForSell(string userId);
        Task<List<PartServiceModel>> GetAllPartsForSell(string userId);
    }
}
