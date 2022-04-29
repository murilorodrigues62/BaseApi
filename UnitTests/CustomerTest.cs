using Project.Model;
using System;
using Xunit;

namespace UnitTests
{
    public class CustomerTest
    {
        [Fact]
        [Trait("Category", nameof(Customer))]
        public void ShouldCreateCustomer()
        {
            Guid id = Guid.NewGuid();
            const bool isActive = true;
            const string name = "Name";

            Customer customer = new Customer()
            {
                Id = id,
                IsActive = isActive,
                Name = name
            };

            Assert.True(customer != null);
            Assert.Equal(customer.Id, id);
            Assert.Equal(customer.IsActive, isActive);
            Assert.Equal(customer.Name, name);
        }
    }
}
