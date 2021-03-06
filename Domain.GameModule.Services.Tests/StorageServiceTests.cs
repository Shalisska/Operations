﻿using Domain.GameModule.Entities;
using Domain.GameModule.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Domain.GameModule.Services.Tests
{
    public class StorageServiceTests
    {
        private ResourcePool<Resource> CreateResourcePool(decimal startQuantity, decimal startCostPrice)
        {
            var resource = new ResourcePool<Resource>(0)
            {
                Quantity = startQuantity,
                CostPrice = startCostPrice
            };

            return resource;
        }

        [Fact]
        public void AddResource()
        {
            var service = new StorageService();

            var startQuantity = 20m;
            var startCostPrice = 2m;

            var quantity = 10m;
            var price = 5m;

            var resourceExpected = CreateResourcePool(startQuantity, startCostPrice);

            resourceExpected.Quantity += quantity;
            resourceExpected.TotalCost = resourceExpected.GetTotalCost() + (quantity * price);
            resourceExpected.CostPrice = resourceExpected.TotalCost / resourceExpected.Quantity;

            var resourceActual = CreateResourcePool(startQuantity, startCostPrice);
            service.AddResource(resourceActual, quantity, price);

            Assert.Equal(resourceExpected.Quantity, resourceActual.Quantity);
            Assert.Equal(resourceExpected.CostPrice, resourceActual.CostPrice);
            Assert.Equal(resourceExpected.GetTotalCost(), resourceActual.GetTotalCost());
        }

        [Fact]
        public void RemoveResource()
        {
            var service = new StorageService();

            var startQuantity = 20m;
            var startCostPrice = 2m;

            var resourceExpected = CreateResourcePool(startQuantity, startCostPrice);
            var resourceActual = CreateResourcePool(startQuantity, startCostPrice);

            var quantity = 10m;

            resourceExpected.Quantity -= quantity;
            resourceExpected.TotalCost = resourceExpected.GetTotalCost();

            service.RemoveResource(resourceActual, quantity);

            Assert.Equal(resourceExpected.Quantity, resourceActual.Quantity);
            Assert.Equal(resourceExpected.GetTotalCost(), resourceActual.GetTotalCost());
        }

        [Fact]
        public void RemoveResourceAllQuantity()
        {
            var service = new StorageService();

            var startQuantity = 20m;
            var startCostPrice = 2m;

            var resourceActual = CreateResourcePool(startQuantity, startCostPrice);

            var quantity = startQuantity;

            service.RemoveResource(resourceActual, quantity);

            Assert.Equal(0m, resourceActual.Quantity);
            Assert.Equal(0m, resourceActual.CostPrice);
            Assert.Equal(0m, resourceActual.GetTotalCost());
        }

        [Fact]
        public void RemoveResourceMore()
        {
            var service = new StorageService();

            var startQuantity = 5m;
            var startCostPrice = 2m;

            var resourceActual = CreateResourcePool(startQuantity, startCostPrice);

            var quantity = 10m;
            var messageExpected = $"More than {startQuantity}\r\nParameter name: quantity";

            Action action = () => service.RemoveResource(resourceActual, quantity);

            Assert.Throws<ArgumentOutOfRangeException>(action);

            try
            {
                action();
            }
            catch(ArgumentOutOfRangeException ex)
            {
                var message = ex.Message;
                Assert.Equal(messageExpected, message);
            }
        }
    }
}
