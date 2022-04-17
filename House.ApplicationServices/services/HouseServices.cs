using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using House.Core.ServiceInterface;
using House.Core.Dtos;
using House.Core.Domain;
using House.Data;

namespace House.ApplicationServices.services
{
    public class HouseServices : IHouseService
    {
        private readonly HouseDbContext _context;

        public HouseServices
            (
            HouseDbContext context
            )
        {
            _context = context;
        }

        public async Task<House_Fix> Add(HouseDto dto)
        {
            House_Fix house = new House_Fix();

            house.Id = Guid.NewGuid();
            house.Price = dto.Price;
            house.Rooms = dto.Rooms;    
            house.Year = dto.Year;
            house.Floors = dto.Floors;
            house.Address = dto.Address;
            house.Information = dto.Information;

            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }


        public async Task<House_Fix> Delete(Guid id)
        {
            var houseId = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.House.Remove(houseId);
            await _context.SaveChangesAsync();

            return houseId;
        }


        public async Task<House_Fix> Update(HouseDto dto)
        {
            House_Fix house = new House_Fix();

            house.Id = dto.Id;
            house.Price = dto.Price;
            house.Rooms = dto.Rooms;
            house.Year = dto.Year;
            house.Floors = dto.Floors;
            house.Address = dto.Address;
            house.Information = dto.Information;

            _context.House.Update(house);
            await _context.SaveChangesAsync();
            return house;
        }

        public async Task<House_Fix> GetAsync(Guid id)
        {
            var result = await _context.House
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
