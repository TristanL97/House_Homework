using House.Core.Dtos;
using House.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace House.HouseTest
{
    public class HouseTests : TestBase
    {
        [Fact]
        public async Task AddHouseShuldNotReturnNull()
        {
            string guid = "295b67bb-c1e5-4b0b-9aaa-b6325e2b42e1";

            HouseDto house = new HouseDto();

            house.Id = Guid.Parse(guid);
            house.Address = "Tallinn";
            house.Price = 129999;
            house.Rooms = 2;
            house.Floors = 2;
            house.Information = "A House in Tallinn";
            house.Year = 2022;

            var result = await Svc<IHouseService>().Add(house);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task ShouldBeEqualGuid()
        {
            string guid = "295b67bb-c1e5-4b0b-9aaa-b6325e2b42e1";
            string guidEqual = "295b67bb-c1e5-4b0b-9aaa-b6325e2b42e1";

            var guidParsed = Guid.Parse(guid);
            var guidParsedEqual = Guid.Parse(guidEqual);

            await Svc<IHouseService>().GetAsync(guidParsed);
            Assert.Equal(guidParsed, guidParsedEqual);
        }

        [Fact]
        public async Task ShouldNotBeEqualGuid()
        {
            string guid = "295b67bb-c1e5-4b0b-9aaa-b6325e2b42e1";
            string guidNotEqual = "0ef3cf72-fdfe-4015-9ad1-8f1c48dca53e";

            var guidParsed = Guid.Parse(guid);
            var guidParsedNotEqual = Guid.Parse(guidNotEqual);

            await Svc<IHouseService>().GetAsync(guidParsed);
            Assert.NotEqual(guidParsed, guidParsedNotEqual);
        }

        [Fact]
        public async Task UpdateHouseShouldNotReturnNull()
        {
            var guid = new Guid("295b67bb-c1e5-4b0b-9aaa-b6325e2b42e1");

            HouseDto house = new HouseDto();

            house.Id = guid;
            house.Address = "Tallinn";
            house.Price = 159000;
            house.Floors = 3;
            house.Rooms = 3;
            house.Information = "A House in Tallinn";
            house.Year = 2022;

            var houseToUpdate = new HouseDto()
            {
                Price = 158000,
                Information = "A new House in Tallinn"
            };

            var result = await Svc<IHouseService>().Update(houseToUpdate);

            Assert.NotNull(result);
        }

    }
}
