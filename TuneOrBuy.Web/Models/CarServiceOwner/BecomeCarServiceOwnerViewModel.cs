using System.ComponentModel.DataAnnotations;
using static TuneOrBuy.Data.DataConstants.CarServiceOwner;

namespace TuneOrBuy.Web.Models.CarServiceOwner
{
    public class BecomeCarServiceOwnerViewModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength)]
        [RegularExpression(PhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;
    }
}
