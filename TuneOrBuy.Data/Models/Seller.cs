using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [RegularExpression(PhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; } = null!;

        public virtual IEnumerable<Car> CarsForSell { get; set; }
        public virtual IEnumerable<Part> PartsForSell { get; set; }
    }
}
