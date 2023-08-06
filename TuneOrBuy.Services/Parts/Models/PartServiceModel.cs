namespace TuneOrBuy.Services.Parts.Models
{
    public class PartServiceModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Manufacturer { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public DateTime Year { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string SellerId { get; set; } = null!;

        public string? Description { get; set; }
    }
}
