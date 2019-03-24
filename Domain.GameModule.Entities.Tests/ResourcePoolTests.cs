using System;
using Xunit;
using Domain.GameModule.Entities;
using Domain.GameModule.Entities.Resources;

namespace Domain.GameModule.Entities.Tests
{
    public class ResourcePoolTests
    {
        [Fact]
        public void GetTotalCost()
        {
            var quantity = 10m;
            var price = 5m;

            var resource = new ResourcePool<Resource>(0)
            {
                Quantity = quantity,
                CostPrice = price
            };

            var totalCostExpected = quantity * price;
            var totalCostActual = resource.GetTotalCost();

            Assert.Equal(totalCostExpected, totalCostActual);
        }
    }
}
