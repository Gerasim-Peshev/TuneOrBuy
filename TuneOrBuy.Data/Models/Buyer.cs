using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TuneOrBuy.Data.DataConstants.Buyer;

namespace TuneOrBuy.Data.Models
{
    public class Buyer : IdentityUser<Guid>
    {
        public Buyer()
        {
            this.FavouriteCars = new List<Car>();
            this.FavouriteParts = new List<Part>();
        }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string LastName { get; set; } = null!;

        public List<Car> FavouriteCars { get; set; }
        public List<Part> FavouriteParts { get; set; }
        public List<CarService> FavouriteCarServices { get; set; }
    }
}
