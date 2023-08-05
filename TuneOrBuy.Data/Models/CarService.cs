using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TuneOrBuy.Data.DataConstants.CarService;

namespace TuneOrBuy.Data.Models
{
    public class CarService
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(CarServiceOwner))]
        public Guid CarServiceOwnerId { get; set; }
        public CarServiceOwner CarServiceOwner { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Incorrect name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = "Incorrect address")]
        public string Address { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Incorrect phone number")]
        [RegularExpression(PhoneNumberRegEx, ErrorMessage = "Incorrect phone number")]
        public string PhoneNumber { get; set; } = null!;

        public string Services { get; set; }

        [Required]
        [Range(HourMin, HourMax, ErrorMessage = "Incorrect hour")]
        public DateTime OpenHour { get; set; }

        [Required]
        [Range(HourMin, HourMax, ErrorMessage = "Incorrect hour")]
        public DateTime CloseHour { get; set; }

        [StringLength(ImageUrlMaxLength, ErrorMessage = "Incorrect image url")]
        public string ImageUrl { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Incorrect description")]
        public string? Description { get; set; }
    }
}
