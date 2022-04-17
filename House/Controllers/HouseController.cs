using House.Core.Dtos;
using House.Core.ServiceInterface;
using House.Data;
using House.Models.House;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace House.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseDbContext _context;
        private readonly IHouseService _houseService;

        public HouseController
            (
            HouseDbContext context,
            IHouseService houseService
            )
        {
            _context = context;
            _houseService = houseService;
        }

        //ListItem
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.House
                .Select(x => new HouseListItem
                {
                    Id = x.Id,
                    Address = x.Address,
                    Information = x.Information,
                    Price = x.Price,
                    Year = x.Year,
                    Floors = x.Floors,
                    Rooms = x.Rooms
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel model = new HouseViewModel();

            return View("Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Information = model.Information,
                Address = model.Address,
                Floors = model.Floors,
                Year = model.Year,
                Price = model.Price,
                Rooms = model.Rooms
            };

            var result = await _houseService.Add(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var house = await _houseService.Delete(id);
            if (house == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseService.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var model = new HouseViewModel();

            model.Id = house.Id;
            model.Address = house.Address;
            model.Information = house.Information;
            model.Year = house.Year;
            model.Price = house.Price;
            model.Floors = house.Floors;
            model.Rooms = house.Rooms;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HouseViewModel model)
        {
            var dto = new HouseDto()
            {
                Id = model.Id,
                Information = model.Information,
                Address = model.Address,
                Price = model.Price,
                Floors = model.Floors,
                Year = model.Year,
                Rooms = model.Rooms
            };

            var result = await _houseService.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), model);
        }

    }
}
