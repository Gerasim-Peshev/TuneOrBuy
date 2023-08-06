using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TuneOrBuy.Data.Models;
using static TuneOrBuy.Data.DataConstants.Seller;

namespace TuneOrBuy.Web.Models.Seller
{
    public class BecomeSellerViewModel
    {
        [Required]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = "Phone is invalid")]
        [RegularExpression(PhoneNumberRegEx, ErrorMessage = "Phone is invalid")]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        [Display(Name = "Url for your profile image")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Town))]
        [Display(Name = "Your town")]
        public int TownId { get; set; }
        public Town? Town { get; set; }
        public virtual IEnumerable<Town>? Towns { get; set; }
    }
}
