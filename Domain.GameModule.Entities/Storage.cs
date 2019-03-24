using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.GameModule.Entities
{
    public class Storage
    {
        public Storage()
        {
            Currencies = new List<ResourcePool>();
        }

        public List<ResourcePool> Currencies { get; set; }

        //public void DoIncomeOperation(int resourceId, decimal quantity, decimal price)
        //{
        //    var resource = Currencies.FirstOrDefault(c => c.Id == resourceId);

        //    if (resource == null)
        //    {
        //        resource = new StorageResource(resourceId);
        //        Currencies.Add(resource);
        //    }

        //    resource.AddResource(quantity, price);
        //}

        //public void DoOutcomeOperation(int resourceId, decimal quantity, decimal price)
        //{
        //    var resource = Currencies.FirstOrDefault(c => c.Id == resourceId);

        //    if (resource == null)
        //        Currencies.Add(new StorageResource(resourceId));


        //}
    }
}
