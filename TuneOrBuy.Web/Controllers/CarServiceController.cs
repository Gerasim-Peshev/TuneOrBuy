using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TuneOrBuy.Data;
using TuneOrBuy.Services.Contracts;
using TuneOrBuy.Web.Models.Car;
using TuneOrBuy.Web.Models;
using TuneOrBuy.Web.Models.CarService;

namespace TuneOrBuy.Web.Controllers
{
    public class CarServiceController : Controller
    {
        private readonly ICarServiceService carServiceService;

        private string UserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public CarServiceController(ICarServiceService service)
        {
            this.carServiceService = service;
        }

        public async Task<IActionResult> All()
        {
            var carServices = await carServiceService.AllCarServicesAsync();
            return View(carServices);
        }

        [HttpGet]
        public async Task<IActionResult> AddCarService()
        {
            var viewToReturn = new AddCarServiceViewModel()
            {
                Towns = await carServiceService.GetAllTowns()
            };

            return View(CreateAddCarViewModel(viewToReturn));
        }

        [HttpPost]
        public async Task<IActionResult> AddCarService(AddCarServiceViewModel carServiceToAdd)
        {
            if (!ModelState.IsValid && carServiceToAdd.CloseHour < carServiceToAdd.OpenHour)
            {
                return View(CreateAddCarViewModel(carServiceToAdd));
            }

            await carServiceService.CreateCarServiceAsync(carServiceToAdd.Name, carServiceToAdd.Address, UserId(), carServiceToAdd.TownId,
                                                          carServiceToAdd.PhoneNumber, String.Join(", ", carServiceToAdd.Services),
                                                          carServiceToAdd.OpenHour, carServiceToAdd.CloseHour,
                                                          carServiceToAdd.ImageUrl, carServiceToAdd.Description);

            return RedirectToAction("All", "CarService");
        }

        public async Task<IActionResult> CarServiceDetails(string carServiceId)
        {
            var carServiceToReturn = await carServiceService.CarServiceDetailsByIdAsync(carServiceId);

            return View(carServiceToReturn);
        }


        [HttpGet]
        public async Task<IActionResult> EditCarService(string carServiceId)
        {
            var carService = await carServiceService.GetCarServiceAsync(carServiceId);

            var modelToReturn = new EditCarServiceViewModel()
            {
                Id = carService.Id,
                CarServiceOwnerId = carService.CarServiceOwnerId,
                Name = carService.Name,
                TownId = carService.TownId,
                Towns = await carServiceService.GetAllTowns(),
                Address = carService.Address,
                PhoneNumber = carService.PhoneNumber,
                OpenHour = carService.OpenHour.Hour,
                CloseHour = carService.CloseHour.Hour,
                Services = carService.Services.Split(", ").ToList(),
                ImageUrl = carService.ImageUrl,
                Description = carService.Description,
            };

            return View(CreateEditCarViewModel(modelToReturn));
        }

        [HttpPost]
        public async Task<IActionResult> EditCarService(EditCarServiceViewModel carServiceToEdit)
        {
            if (!ModelState.IsValid && carServiceToEdit.CloseHour < carServiceToEdit.OpenHour)
            {
                return View(CreateEditCarViewModel(carServiceToEdit));
            }

            await carServiceService.EditCarServiceAsync(carServiceToEdit.Id, carServiceToEdit.Name, carServiceToEdit.Address,
                                                        carServiceToEdit.CarServiceOwnerId, carServiceToEdit.TownId,
                                                        carServiceToEdit.PhoneNumber, String.Join(", ", carServiceToEdit.Services),
                                                        carServiceToEdit.OpenHour, carServiceToEdit.CloseHour,
                                                        carServiceToEdit.ImageUrl, carServiceToEdit.Description);

            return RedirectToAction("All", "CarService");
        }

        public async Task<IActionResult> DeleteCarService(string carServiceId)
        {
            await carServiceService.DeleteCarServiceAsync(carServiceId);

            return RedirectToAction("All", "CarService");
        }

        public async Task<IActionResult> CarServiceToFavourite(string carServiceId)
        {
            var userId = UserId();

            await carServiceService.ToFavouriteCarsAsync(carServiceId, userId);

            return RedirectToAction("All", "CarService");
        }

        public async Task<IActionResult> MyCarServices()
        {
            var carServices = await carServiceService.MyFavoriteCarServicesAsync(UserId());

            return View(carServices);
        }

        private AddCarServiceViewModel CreateAddCarViewModel(AddCarServiceViewModel viewToReturn)
        {
            var servicesToChooseFrom = new List<CheckBoxOption>();

            int id = 1;

            foreach (var equipment in CarServiceConstants.Services)
            {
                servicesToChooseFrom.Add(new CheckBoxOption() { IsChecked = false, Description = equipment, Value = $"OPTION{id}" });
                id++;
            }

            viewToReturn.ServicesToChooseFrom = servicesToChooseFrom;

            return viewToReturn;
        }

        private EditCarServiceViewModel CreateEditCarViewModel(EditCarServiceViewModel viewToReturn)
        {

            var servicesToChooseFrom = new List<CheckBoxOption>();

            int id = 1;


            foreach (var equipment in CarServiceConstants.Services)
            {
                servicesToChooseFrom.Add(new CheckBoxOption() { IsChecked = false, Description = equipment, Value = $"OPTION{id}" });
                id++;
            }

            viewToReturn.ServicesToChooseFrom = servicesToChooseFrom;

            return viewToReturn;
        }
    }
}
