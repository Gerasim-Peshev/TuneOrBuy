using System.ComponentModel.DataAnnotations;
using TuneOrBuy.Data;
using static TuneOrBuy.Data.DataConstants.Part;

namespace TuneOrBuy.Web.Models.Part
{
    public class EditPartViewModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = "Incorrect name")]
        public string Name { get; set; } = null!;

        [Required]
        public string Manufacturer { get; set; } = null!;

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public int Year { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue, ErrorMessage = "Incorrect price")]
        public decimal Price { get; set; }

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = "Incorrect description")]
        public string? Description { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength, MinimumLength = 0, ErrorMessage = "Incorrect image")]
        public string ImageUrl { get; set; } = null!;

        public string SellerId { get; set; } = null!;

        public IEnumerable<EquipmentAndService>? Manufactures { get; set; }
    }
}
