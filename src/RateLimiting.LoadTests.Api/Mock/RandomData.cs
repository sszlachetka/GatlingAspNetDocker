using System.Collections.Generic;
using System.Linq;
using Bogus;
using RateLimiting.LoadTests.Api.Contract;

namespace RateLimiting.LoadTests.Api.Mock
{
    public class RandomData
    {
        private readonly Faker _faker;
        private readonly Faker<ItemDto> _itemDtoFaker;

        public RandomData()
        {
            _itemDtoFaker = new Faker<ItemDto>()
                .RuleFor(x => x.Id, faker => faker.Random.Long(1, 100000))
                .RuleFor(x => x.Name, faker => faker.Commerce.ProductName());

            _faker = new Faker();
        }

        public List<ItemDto> GenerateItemDtoCollection(int count)
        {
            return _itemDtoFaker.Generate(count);
        }

        public ItemDto GenerateItemDto(long? itemId = null)
        {
            return _itemDtoFaker
                .FinishWith((faker, item) => item.Id = itemId ?? item.Id)
                .Generate(1)
                .First();
        }

        public int Int(int? min = null, int? max = null)
        {
            return _faker.Random.Int(min ?? int.MinValue, max ?? int.MaxValue);
        }
    }
}