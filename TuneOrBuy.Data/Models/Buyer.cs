using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TuneOrBuy.Data.DataConstants.Buyer;

namespace TuneOrBuy.Data.Models
{
    public class Buyer : IdentityUser<Guid>
    {
        
    }
}
