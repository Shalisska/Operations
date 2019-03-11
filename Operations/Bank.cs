using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operations
{
    public class Bank
    {
        public Wallet Wallet { get; set; }

        public string GetAccountInfo()
        {
            return $"{Wallet.GetCurrenciesInfo()}\n\n{Wallet.GetTotalCurrenciesInfo()}";
        }
    }

    public class Wallet
    {
        public Wallet(
            CurrencyRepository currencyRepository,
            List<WalletItem> currencies)
        {
            _currencyRepository = currencyRepository;
            Currencies = currencies;
        }

        private CurrencyRepository _currencyRepository { get; set; }
        public List<WalletItem> Currencies { get; set; }

        public string GetCurrenciesInfo()
        {
            var result = new List<string>();
            foreach(var currency in Currencies)
            {
                var currentCurrency = _currencyRepository.GetCurrency(currency.CurrencyId);
                result.Add($"{currentCurrency.Name}: {currency.Value}: {currency.ItemType}: {currency.Status}");
            }

            return string.Join("\n", result);
        }

        public string GetTotalCurrenciesInfo()
        {
            var result = new List<string>();
            var totalCurrencies = GetTotalCurrencyValues();
            foreach (var currency in totalCurrencies)
            {
                var currentCurrency = _currencyRepository.GetCurrency(currency.CurrencyId);
                result.Add($"{currentCurrency.Name}: {currency.Value}");
            }

            return string.Join("\n", result);
        }

        public List<WalletItem> GetCurrentCurrencyItems(int id)
        {
            var result = Currencies.Where(c => c.CurrencyId == id).ToList();
            return result;
        }

        public List<WalletItem> GetCurrentCurrencyItems(int id, WalletItemType walletItemType)
        {
            var result = Currencies
                .Where(c => c.CurrencyId == id)
                .Where(c => c.ItemType == walletItemType).ToList();
            return result;
        }

        public List<WalletItem> GetCurrentCurrencyItems(int id, WalletItemStatus walletItemStatus)
        {
            var result = Currencies
                .Where(c => c.CurrencyId == id)
                .Where(c => c.Status == walletItemStatus).ToList();
            return result;
        }

        public List<WalletItem> GetCurrentCurrencyItems(int id, WalletItemType walletItemType, WalletItemStatus walletItemStatus)
        {
            var result = Currencies
                .Where(c => c.CurrencyId == id)
                .Where(c => c.ItemType == walletItemType)
                .Where(c => c.Status == walletItemStatus).ToList();
            return result;
        }

        public List<WalletItem> GetTotalCurrencyValues()
        {
            var allCurrencies = _currencyRepository.GetCurrencies();
            var totalCurrencies = new List<WalletItem>();

            foreach (var item in allCurrencies)
                totalCurrencies.Add(GetTotalCurrencyItem(item.Id));

            return totalCurrencies;
        }

        private WalletItem GetTotalCurrencyItem(int id)
        {
            var items = GetCurrentCurrencyItems(id);
            var totalValue = 0m;

            foreach(var item in items)
            {
                switch (item.ItemType)
                {
                    case WalletItemType.Income:
                        totalValue += item.Value;
                        break;
                    case WalletItemType.Outcome:
                        totalValue -= item.Value;
                        break;
                }
            }

            return new WalletItem(id, totalValue);
        }

        public string AddCurrencyItem(WalletItem item)
        {
            Currencies.Add(item);
            return "success";
        }

        //public string RemoveCurrencyItem(int id, decimal value, long transactionId)
        //{
        //    var currentItems = GetCurrentCurrencyItems(id, WalletItemType.Income);

        //    if (currentItems == null)
        //        return "fail";

        //    var transactionItems = GetTransactionItems(currentItems, transactionId);
        //    if (transactionItems != null)
        //    {
        //        foreach(var item in transactionItems)
        //        {
        //            if (item.Value > value)
        //            {

        //            }
        //        }
        //    }

        //    foreach(var item in currentItems)
        //    {
        //        if (item.Value >= value)
        //        {

        //        }
        //    }
        //}

        private List<WalletItem> GetTransactionItems(List<WalletItem> walletItems, long transactionId)
        {
            var result = walletItems.Where(c => c.TransactionId == transactionId).ToList();
            return result;
        }

        //public List<WalletItem> GetCurrency(int id)
        //{

        //}
    }

    public class WalletItem
    {
        public WalletItem(int currencyId, decimal value) : this(0, 0, currencyId, value, 1) {}

        public WalletItem(
            WalletItemType walletItemType,
            WalletItemStatus walletItemStatus,
            int currencyId,
            decimal value,
            decimal costPrice)
        {
            Id = DateTime.Now.Ticks;
            Date = DateTime.Now;

            ItemType = walletItemType;
            Status = walletItemStatus;

            CurrencyId = currencyId;
            Value = value;
            CostPrice = costPrice;
        }

        long Id { get; set; }
        DateTime Date { get; set; }

        public WalletItemType ItemType { get; set; }
        public WalletItemStatus Status { get; set; }
        public long TransactionId { get; set; }

        public int CurrencyId { get; set; }
        public decimal Value { get; set; }
        public decimal CostPrice { get; set; }
    }

    public enum WalletItemType
    {
        Income = 0,
        Outcome = 1
    }

    public enum WalletItemStatus
    {
        Free = 0,
        InOrder = 1,
        Reserved = 2,
        Closed = 3
    }
}
