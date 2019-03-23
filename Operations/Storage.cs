using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operations
{
    public class Storage
    {
        public Storage()
        {
            Currencies = new List<StorageResource>();
        }

        public List<StorageResource> Currencies { get; set; }

        public void DoIncomeOperation(int resourceId, decimal quantity, decimal price)
        {
            var resource = Currencies.FirstOrDefault(c => c.Id == resourceId);

            if (resource == null)
            {
                resource = new StorageResource(resourceId);
                Currencies.Add(resource);
            }

            resource.AddResource(quantity, price);
        }

        public void DoOutcomeOperation(int resourceId, decimal quantity, decimal price)
        {
            var resource = Currencies.FirstOrDefault(c => c.Id == resourceId);

            if (resource == null)
                Currencies.Add(new StorageResource(resourceId));


        }
    }

    public class StorageResource
    {
        public StorageResource(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalCost { get; set; }

        public void AddResource(decimal quantity, decimal price)
        {
            Quantity += quantity;
            TotalCost += quantity * price;
            Price = TotalCost / Quantity;
        }
    }
}
