using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Data;

namespace TuneOrBuy.Services.CarServiceOwners
{
    public class CarServiceOwnerService : ICarServiceOwner
    {
        private readonly TuneOrBuyDbContext context;

        public CarServiceOwnerService(TuneOrBuyDbContext data)
        {
            this.context = data;
        }

        public async Task<bool> UserIsCarServiceOwner(Guid userId)
        {
            return await context.CarServiceOwners.AnyAsync(c => c.BuyerId == userId);
        }
    }
}
