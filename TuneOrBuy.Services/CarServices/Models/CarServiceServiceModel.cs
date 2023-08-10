using TuneOrBuy.Data.Models;

namespace TuneOrBuy.Services.CarServices.Models
{
    public class CarServiceServiceModel
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string CarServiceOwnerId { get; set; }

        public string Address { get; set; } = null!;

        public int TownId { get; set; }

        public Town Town { get; set; }

        public string PhoneNumber { get; set; } = null!;

        public string Services { get; set; }

        public DateTime OpenHour { get; set; }

        public DateTime CloseHour { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string? Description { get; set; }
    }
}
