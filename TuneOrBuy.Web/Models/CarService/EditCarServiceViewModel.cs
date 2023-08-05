using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TuneOrBuy.Data;
using TuneOrBuy.Data.Models;
using static TuneOrBuy.Data.DataConstants.CarService;

namespace TuneOrBuy.Web.Models.CarService
{
    public class EditCarServiceViewModel
    {
        public string Id { get; set; }

        public string CarServiceOwnerId { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Incorrect name")]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = "Incorrect address")]
        [Display(Name = "Address of car service")]
        public string Address { get; set; } = null!;

        [Required]
        [Display(Name = "Town of car service")]
        public int TownId { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Incorrect phone number")]
        [RegularExpression(PhoneNumberRegEx, ErrorMessage = "Incorrect phone number")]
        [Display(Name = "Phone Number of car service")]
        public string PhoneNumber { get; set; } = null!;

        [NotMapped]
        public virtual List<string> Services { get; set; }

        [Required]
        [Range(HourMin, HourMax, ErrorMessage = "Incorrect open hour")]
        [Display(Name = "Open in")]
        public int OpenHour { get; set; }

        [Required]
        [Range(HourMin, HourMax, ErrorMessage = "Incorrect close hour")]
        [Display(Name = "Close in")]
        public int CloseHour { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength, ErrorMessage = "Incorrect image url")]
        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Incorrect description")]
        public string? Description { get; set; }



        public IEnumerable<Town>? Towns { get; set; }
        public IEnumerable<CheckBoxOption>? ServicesToChooseFrom { get; set; }
    }
}
