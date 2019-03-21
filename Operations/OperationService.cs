﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operations
{
    public class OperationService
    {
        public void DoOperation(Storage storage, int resourceId, decimal value, decimal price)
        {
            var transactionId = DateTime.Now.Ticks;
            var currTransaction = new TransactionNote(resourceId, transactionId, value, price);

            var storageResource = storage.Currencies.FirstOrDefault(r => r.Id == resourceId);

            storageResource.CurrencyTransactions.Add(currTransaction);

            storageResource.Update(currTransaction);
        }
    }

    public class Transaction
    {

    }

    public enum TransactionType
    {
        Income = 0,
        Outcome = 1
    }

    public class Account
    {

    }

    public class Storage
    {
        public Storage()
        {
            Currencies = SetStartCurrencies();
        }

        public List<StorageResource> Currencies { get; set; }

        private List<StorageResource> SetStartCurrencies()
        {
            var currencyRepository = new CurrencyRepository();

            var storageResources = new List<StorageResource>();
            var dataResources = currencyRepository.Currencies;

            foreach (var resource in dataResources)
                storageResources.Add(new StorageResource(resource.Id));

            return storageResources;
        }
    }

    public class StorageResource
    {
        public StorageResource(int id)
        {
            Id = id;
            CurrencyTransactions = new List<TransactionNote>();
        }

        public int Id { get; set; }

        public decimal Value { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        public List<TransactionNote> CurrencyTransactions { get; set; }

        public void Update(TransactionNote transaction)
        {
            Value += transaction.Value;
            Total += transaction.Total;
            Price = Total / Value;
        }
    }

    public class TransactionNote
    {
        public TransactionNote(
            int resourceId,
            long transactionId,
            decimal value,
            decimal price)
        {
            ResourceId = resourceId;
            TransactionId = transactionId;
            DateOfCreation = DateTime.Now;
            Value = value;
            Price = price;
            Total = value * price;
        }

        public int ResourceId { get; set; }
        public long TransactionId { get; set; }
        public DateTime DateOfCreation { get; set; }
        public decimal Value { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }

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
}
