using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.GameModule.Entities
{
    public class ResourcePool
    {
        public ResourcePool(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

        public decimal Quantity { get; set; }
        public decimal CostPrice { get; set; }
        public decimal TotalCost { get; set; }

        public decimal GetTotalCost()
        {
            return Quantity * CostPrice;
        }
    }
}
