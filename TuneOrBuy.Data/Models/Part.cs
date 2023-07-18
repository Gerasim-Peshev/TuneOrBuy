using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TuneOrBuy.Data.DataConstants.Part;

namespace TuneOrBuy.Data.Models
{
    public class Part
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Manufacturer { get; set; } = null!;

        [Required]
        public string Brand { get; set; } = null!;

        [Required]
        public DateTime Year { get; set; }

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [ForeignKey(nameof(Seller))]
        public Guid SellerId { get; set; }
        public Seller Seller { get; set; } = null!;
    }
}
