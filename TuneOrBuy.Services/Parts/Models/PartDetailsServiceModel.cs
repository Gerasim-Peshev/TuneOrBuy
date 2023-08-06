namespace TuneOrBuy.Services.Parts.Models
{
    public class PartDetailsServiceModel
    {
        public string Name { get; set; }

        public string Manufacturer { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public DateTime Year { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public TuneOrBuy.Data.Models.Seller Seller { get; set; } = null!;

        public string? Description { get; set; }
    }
}
