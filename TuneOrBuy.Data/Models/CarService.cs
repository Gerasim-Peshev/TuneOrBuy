using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TuneOrBuy.Data.DataConstants.CarService;

namespace TuneOrBuy.Data.Models
{
    public class CarService
    {
        public CarService()
        {
            this.Services = new List<EquipmentAndService>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(CarServiceOwner))]
        public Guid CarServiceOwnerId { get; set; }
        public CarServiceOwner CarServiceOwner { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [RegularExpression(PhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;

        public virtual IEnumerable<EquipmentAndService> Services { get; set; }

        [Required]
        public DateTime OpenHour { get; set; }

        [Required]
        public DateTime CloseHour { get; set; }

        public string? Description { get; set; } = null!;
    }
}
