using System;
using House.Core.Domain;
using House.Core.Dtos;
using System.Threading.Tasks;

namespace House.Core.ServiceInterface
{
    public interface IHouseService : IApplicationService
    {
        Task<House_Fix> Add(HouseDto dto);

        Task<House_Fix> Delete(Guid id);

        Task<House_Fix> Update(HouseDto dto);

        Task<House_Fix> GetAsync(Guid id);

    }
}
