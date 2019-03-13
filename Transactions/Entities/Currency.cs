using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Transactions.Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }

        public List<CurrencyTransactionItem> CurrencyTransactions { get; set; }

        public decimal GetValueByType(TransactionItemType transactionItemType)
        {
            var result = 0m;
            var currencies = CurrencyTransactions.Where(c => c.TransactionItemType == transactionItemType).ToList();
            foreach(var item in currencies)
            {
                result += item.Value;
            }

            return result;
        }

        public decimal GetValue()
        {
            var incomeValue = GetValueByType(TransactionItemType.Income);
            var outcomeValue = GetValueByType(TransactionItemType.Outcome);

            return incomeValue - outcomeValue;
        }

        public decimal GetCostPriceByType(TransactionItemType transactionItemType)
        {
            var result = GetCostPriceByType(CurrencyTransactionItemStatus.Open, transactionItemType);

            return result;
        }

        public decimal GetCostPriceByType(CurrencyTransactionItemStatus itemStatus, TransactionItemType transactionItemType)
        {
            var result = 0m;
            var currencies = CurrencyTransactions.Where(c => c.ItemStatus == itemStatus).Where(c => c.TransactionItemType == transactionItemType).ToList();

            foreach (var item in currencies)
            {
                result += item.CostPrice;
            }

            return result / currencies.Count;
        }

        public decimal GetTotalCostByType(TransactionItemType transactionItemType)
        {
            var result = 0m;
            var currencies = CurrencyTransactions.Where(c => c.TransactionItemType == transactionItemType).ToList();
            foreach (var item in currencies)
            {
                result += item.TotalCost;
            }

            return result;
        }

        public decimal GetTotalCost()
        {
            var incomeValue = GetValueByType(TransactionItemType.Income);
            var outcomeValue = GetValueByType(TransactionItemType.Outcome);

            return incomeValue - outcomeValue;
        }
    }

    public class CurrencyTransactionItem
    {
        public int Id { get; set; }
        public long TransactionId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Value { get; set; }
        public decimal CostPrice { get; set; }
        public decimal TotalCost { get; set; }
        public TransactionItemType TransactionItemType { get; set; }
        public CurrencyTransactionItemStatus ItemStatus { get; set; }
    }

    public enum CurrencyTransactionItemStatus
    {
        Close = 0,
        Open = 1
    }
}
