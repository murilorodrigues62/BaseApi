using BaseApi.Model;
using System;
using Xunit;

namespace BaseApi.UnitTests
{
    public class ItemTest
    {

        [Fact]
        [Trait("Category", "Item")]
        public void ShouldCreateItem()
        {
            Guid id = Guid.NewGuid();
            const bool isActive = true;
            const string description = "Description";
            const decimal price = 1.99m;

            Item item = new Item()
            {
                Id = id,
                IsActive = isActive,
                Description = description,
                Price = price
            };

            Assert.True(item != null);
            Assert.Equal(item.Id, id);
            Assert.Equal(item.IsActive, isActive);
            Assert.Equal(item.Description, description);
            Assert.Equal(item.Price, price);
        }
    }
}
