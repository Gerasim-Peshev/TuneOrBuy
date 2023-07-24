using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuneOrBuy.Services.Contracts
{
    public interface ICarServiceOwner
    {
        Task<bool> UserIsCarServiceOwner(Guid userId);
    }
}
