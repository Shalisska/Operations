using Domain.GameModule.Entities;
using Domain.GameModule.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.GameModule.Services
{
    public class StorageService
    {
        public void AddResource<T>(ResourcePool<T> resource, decimal quantity, decimal price) where T : class
        {
            resource.Quantity += quantity;
            resource.TotalCost = resource.GetTotalCost() + quantity * price;
            resource.CostPrice = resource.TotalCost / resource.Quantity;
        }

        public void RemoveResource<T>(ResourcePool<T> resource, decimal quantity) where T : class
        {
            if (resource.Quantity < quantity)
                throw new ArgumentOutOfRangeException("quantity", $"More than {resource.Quantity}");

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

        public (bool isAvailable, decimal quantityAvailable) CheckResourceAvalability<T>(ResourcePool<T> resource, decimal quantity) where T : class
        {
            throw new NotImplementedException();
        }

        public ResourcePool<T> GetResource<T>(ResourcePool<T> resource, decimal quantity) where T : class
        {
            throw new NotImplementedException();
        }

        public ResourcePool<T> GetAllResource<T>(ResourcePool<T> resource, decimal quantity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
