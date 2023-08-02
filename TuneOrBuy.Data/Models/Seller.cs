using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static TuneOrBuy.Data.DataConstants.Seller;

namespace TuneOrBuy.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            this.CarsForSell = new List<Car>();
            this.PartsForSell = new List<Part>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Buyer))]
        public Guid BuyerId { get; set; }
        public Buyer Buyer { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Phone does not match length")]
        [RegularExpression(PhoneNumberRegEx, ErrorMessage = "Phone does not match patern")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; } = null!;

        public List<Car> CarsForSell { get; set; }
        public List<Part> PartsForSell { get; set; }
    }
}
