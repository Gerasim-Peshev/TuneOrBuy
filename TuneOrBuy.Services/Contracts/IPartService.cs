using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuneOrBuy.Data.Models;
using TuneOrBuy.Services.Cars.Models;
using TuneOrBuy.Services.Parts.Models;

namespace TuneOrBuy.Services.Contracts
{
    public interface IPartService
    {
        Task<Seller> GetSellerByBuyerIdAsync(string userId);
        Task<Seller> GetSellerBySellerIdAsync(string userId);
        Task<Buyer> GetBuyerByIdAsync(string userId);
        Task<Town> GetTownByIdAsync(int townId);
        Task<PartServiceModel> GetPart(string partId);
        Task<List<PartServiceModel>> AllPartsAsync();
        Task CreatePartAsync(string name, string manufacturer, string brand, int year, decimal price, string sellerId, string imageUrl,string description);
        Task<PartDetailsServiceModel> PartDetailsByIdAsync(string partId);
        Task EditPartAsync(string id, string name, string manufacturer, string brand, int year, decimal price, string sellerId, string imageUrl, string description);
        Task DeletePart(string partId);
        Task ToFavouriteParts(string partId, string userId);
        Task<Tuple<bool, Buyer, Part>> ContainsPart(string partId, string userId);
        Task<List<PartServiceModel>> MyFavoritePartsAsync(string userId);
    }
}
