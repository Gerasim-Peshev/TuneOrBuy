using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TuneOrBuy.Data.DataConstants.CarServiceOwner;

namespace TuneOrBuy.Data.Models
{
    public class CarServiceOwner
    {
        public CarServiceOwner()
        {
            this.CarServices = new List<CarService>();
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

        public IEnumerable<CarService> CarServices { get; set; }
    }
}
