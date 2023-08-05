using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuneOrBuy.Data.Models;

namespace TuneOrBuy.Services.CarServices.Models
{
    public class CarServiceDetailsServiceModel
    {
        public string Name { get; set; } = null!;
        public CarServiceOwner CarServiceOwner { get; set; } = null!;

        public string Address { get; set; } = null!;

        public Town Town { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Services { get; set; }

        public DateTime OpenHour { get; set; }

        public DateTime CloseHour { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string? Description { get; set; }
    }
}
