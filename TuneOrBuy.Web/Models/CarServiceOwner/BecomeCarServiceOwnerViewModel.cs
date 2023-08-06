using System.ComponentModel.DataAnnotations;
using static TuneOrBuy.Data.DataConstants.CarServiceOwner;

namespace TuneOrBuy.Web.Models.CarServiceOwner
{
    public class BecomeCarServiceOwnerViewModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Phone is invalid")]
        [RegularExpression(PhoneNumberRegEx, ErrorMessage = "Phone is invalid")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;
    }
}
