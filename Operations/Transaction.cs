using System;
using System.Collections.Generic;
using System.Text;

namespace Operations
{
    public class Transaction
    {
        public Transaction(
            TransactionPart leftPart,
            TransactionPart rightPart,
            OperationType operationType,
            decimal value,
            decimal exchangeRate)
        {
            Id = DateTime.Now.Ticks;
            Date = DateTime.Now;
            LeftPart = leftPart;
            RightPart = rightPart;
            OperationType = operationType;
            Value = value;
            ExchangeRate = exchangeRate;
        }

        long Id { get; set; }
        public DateTime Date { get; private set; }
        public TransactionPart LeftPart { get; set; }
        public TransactionPart RightPart { get; set; }
        public OperationType OperationType { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Value { get; set; }
    }

    public class TransactionPart
    {
        public TransactionPart(
            Bank bank,
            int currencyId)
        {
            Bank = bank;
            CurrencyId = currencyId;
        }

        public Bank Bank { get; set; }
        public int CurrencyId { get; set; }
    }
}
