using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TuneOrBuy.Data;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Services.Parts.Models;
using TuneOrBuy.Web.Models.Part;

namespace TuneOrBuy.Web.Controllers
{
    public class PartController : Controller
    {
        private readonly IPartService partService;

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public PartController(IPartService service)
        {
            this.partService = service;
        }

        public async Task<IActionResult> All()
        {
            var enumerableOfParts = new List<PartServiceModel>();

            enumerableOfParts = await partService.AllPartsAsync();

            if (enumerableOfParts == null)
            {
                enumerableOfParts = new List<PartServiceModel>();
            }
            return View(enumerableOfParts);
        }

        [HttpGet]
        public async Task<IActionResult> AddPart()
        {
            var viewToReturn = new AddPartViewModel();

            return View(CreateAddPartViewModel(viewToReturn));
        }

        [HttpPost]
        public async Task<IActionResult> AddPart(AddPartViewModel partToAdd)
        {
            if (!ModelState.IsValid)
            {
                return View(CreateAddPartViewModel(partToAdd));
            }

            await partService.CreatePartAsync(partToAdd.Name, partToAdd.Manufacturer, partToAdd.Brand, partToAdd.Year,
                                              partToAdd.Price, UserId(), partToAdd.ImageUrl, partToAdd.Description);

            return RedirectToAction("All", "Part");
        }

        public async Task<IActionResult> PartDetails(string partId)
        {
            var partToReturn = await partService.PartDetailsByIdAsync(partId);

            return View(partToReturn);
        }

        [HttpGet]
        public async Task<IActionResult> EditPart(string partId)
        {
            var part = await partService.GetPart(partId);

            var modelToReturn = new EditPartViewModel()
            {
                Id = part.Id,
                Name = part.Name,
                Manufacturer = part.Manufacturer,
                Brand = part.Brand,
                Year = part.Year.Year,
                Price = part.Price,
                ImageUrl = part.ImageUrl,
                SellerId = part.SellerId,
                Description = part.Description
            };

            return View(CreateEditPartViewModel(modelToReturn));
        }

        [HttpPost]
        public async Task<IActionResult> EditPart(EditPartViewModel partToEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(CreateEditPartViewModel(partToEdit));
            }

            await partService.EditPartAsync(partToEdit.Id, partToEdit.Name, partToEdit.Manufacturer, partToEdit.Brand,
                                            partToEdit.Year, partToEdit.Price, partToEdit.SellerId, partToEdit.ImageUrl,
                                            partToEdit.Description);

            return RedirectToAction("All", "Part");
        }

        public async Task<IActionResult> DeletePart(string partId)
        {
            await partService.DeletePart(partId);

            return RedirectToAction("All", "Part");
        }

        public async Task<IActionResult> PartToFavourite(string partId)
        {
            var userId = UserId();

            await partService.ToFavouriteParts(partId, userId);

            return RedirectToAction("All", "Part");
        }

        public async Task<IActionResult> MyParts()
        {
            var favoriteParts = await partService.MyFavoritePartsAsync(UserId());
            return View(favoriteParts);
        }

        private AddPartViewModel CreateAddPartViewModel(AddPartViewModel model)
        {
            var manufacturers = new List<EquipmentAndService>();

            int id = 1;

            foreach (var manufacturer in PartConstants.Manufacturers)
            {
                manufacturers.Add(new EquipmentAndService() { Id = id, Name = manufacturer });
                id++;
            }

            model.Manufactures = manufacturers;

            return model;
        }
        private EditPartViewModel CreateEditPartViewModel(EditPartViewModel model)
        {
            var manufacturers = new List<EquipmentAndService>();

            int id = 1;

            foreach (var manufacturer in PartConstants.Manufacturers)
            {
                manufacturers.Add(new EquipmentAndService() { Id = id, Name = manufacturer });
                id++;
            }

            model.Manufactures = manufacturers;

            return model;
        }
    }
}
