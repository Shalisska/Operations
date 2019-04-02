using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operations
{
    public class OperationService
    {
        public void DoOperation(Storage storage, int resourceId, decimal quantity, decimal price, TransactionDirection direction)
        {
            var transactionId = DateTime.Now.Ticks;

            if (direction == TransactionDirection.Income)
                storage.DoIncomeOperation(resourceId, quantity, price);
            else
            {

            }
        }
    }

    public class Transaction
    {

    }

    public enum TransactionDirection
    {
        Income = 0,
        Outcome = 1
    }

    public class Account
    {

    }

    //public class ResourcePool
    //{
    //    public ResourcePool(
    //        int resourceId)
    //    {
    //        ResourceId = resourceId;
    //        DateOfCreation = DateTime.Now;
    //    }

    //    public ResourcePool(
    //        int resourceId,
    //        long transactionId,
    //        decimal value,
    //        decimal price)
    //    {
    //        ResourceId = resourceId;
    //        TransactionId = transactionId;
    //        DateOfCreation = DateTime.Now;
    //        Value = value;
    //        Price = price;
    //        Total = value * price;
    //    }

    //    public int ResourceId { get; set; }
    //    public long TransactionId { get; set; }
    //    public DateTime DateOfCreation { get; set; }
    //    public decimal Value { get; set; }
    //    public decimal Price { get; set; }
    //    public decimal Total { get; set; }
    //}

    public class CurrencyRepository
    {
        public CurrencyRepository()
        {
            Currencies = new List<CurrencyData>
            {
                new CurrencyData(0, "gold", true),
                new CurrencyData(1, "clonero", false),
                new CurrencyData(2, "rubles", false)
            };
        }

        public List<CurrencyData> Currencies { get; set; }

        public CurrencyData GetCurrency(int id)
        {
            var currency = Currencies.FirstOrDefault(c => c.Id == id);

            if (currency == null)
                return null;

            return currency;
        }
    }

    public class CurrencyData
    {
        public CurrencyData(int id, string name, bool baseCurrency)
        {
            Id = id;
            Name = name;
            BaseCurrency = baseCurrency;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool BaseCurrency { get; set; }
    }

    public class ResourceRepository
    {
        public ResourceRepository()
        {
            Resources = new List<ResourceData>
            {
                new ResourceData(0, "woods"),
                new ResourceData(1, "stones"),
                new ResourceData(2, "irons"),
                new ResourceData(3, "cereals")
            };
        }

        public List<ResourceData> Resources { get; set; }

        public ResourceData GetResource(int id)
        {
            var resource = Resources.FirstOrDefault(c => c.Id == id);

            if (resource == null)
                return null;

            return resource;
        }
    }

    public class ResourceData
    {
        public ResourceData(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
