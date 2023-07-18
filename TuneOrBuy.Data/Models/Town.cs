using System.ComponentModel.DataAnnotations;
using static TuneOrBuy.Data.DataConstants.Town;

namespace TuneOrBuy.Data.Models
{
    public class Town
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(RegionMaxLength, MinimumLength = RegionMinLength)]
        public string Region { get; set; } = null!;

        [Required]
        [StringLength(CountryMaxLength, MinimumLength = CountryMinLength)]
        public string Country { get; set; } = null!;
    }
}
