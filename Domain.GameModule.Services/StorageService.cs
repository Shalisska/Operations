using Domain.GameModule.Entities;
using Domain.GameModule.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.GameModule.Services
{
    public class StorageService
    {
        public void AddResource(ResourcePool<Resource> resource, decimal quantity, decimal price)
        {
            resource.Quantity += quantity;
            resource.TotalCost = resource.GetTotalCost() + quantity * price;
            resource.CostPrice = resource.TotalCost / resource.Quantity;
        }

        public void RemoveResource(ResourcePool<Resource> resource, decimal quantity)
        {
            if (resource.Quantity < quantity)
                throw new ArgumentOutOfRangeException($"More than {resource.Quantity}");

            if (resource.Quantity == quantity)
            {
                resource.Quantity = 0;
                resource.CostPrice = 0;
                resource.TotalCost = 0;
                return;
            }

            resource.Quantity -= quantity;
            resource.TotalCost -= resource.GetTotalCost();
        }
    }
}
