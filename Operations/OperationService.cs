using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operations
{
    public class OperationService
    {
        public Transaction Transaction { get; private set; }

        public Transaction CreateTransaction(
            TransactionPart leftPart,
            TransactionPart rightPart,
            OperationType operationType,
            decimal value,
            decimal exchangeRate)
        {
            return new Transaction(leftPart, rightPart, operationType, value, exchangeRate);
        }

        public void DoOperation(Transaction transaction)
        {
            DoOperation(
                transaction.LeftPart.Bank,
                transaction.LeftPart.CurrencyId,
                transaction.RightPart.Bank,
                transaction.RightPart.CurrencyId,
                transaction.OperationType,
                transaction.ExchangeRate,
                transaction.Value);
        }

        public void DoOperation(Bank bank1,
            int currencyId1,
            Bank bank2,
            int currencyId2,
            OperationType operationType,
            decimal exchangeRate,
            decimal value)
        {
            switch (operationType)
            {
                case OperationType.Buy:
                    BaseOperation(bank1, bank2, currencyId1, value, exchangeRate, OperationType.Buy);
                    BaseOperation(bank1, bank2, currencyId2, value * exchangeRate, exchangeRate, OperationType.Sell);
                    break;
                case OperationType.Sell:
                    BaseOperation(bank1, bank2, currencyId1, value, exchangeRate, OperationType.Sell);
                    BaseOperation(bank1, bank2, currencyId2, value * exchangeRate, exchangeRate, OperationType.Buy);
                    break;
            }
        }

        void BaseOperation(Bank bank1, Bank bank2, int currencyId, decimal value, decimal exchangeRate, OperationType operationType)
        {
            var currency1 = bank1.Wallet.Currencies.FirstOrDefault(c => c.CurrencyId == currencyId);
            var currency2 = bank2.Wallet.Currencies.FirstOrDefault(c => c.CurrencyId == currencyId);

            switch (operationType)
            {
                case OperationType.Buy:
                    bank1.Wallet.AddCurrencyItem(new WalletItem(WalletItemType.Income, WalletItemStatus.Free, currencyId, value, exchangeRate));
                    bank2.Wallet.AddCurrencyItem(new WalletItem(WalletItemType.Outcome, WalletItemStatus.Free, currencyId, value, exchangeRate));
                    break;
                case OperationType.Sell:
                    bank1.Wallet.AddCurrencyItem(new WalletItem(WalletItemType.Outcome, WalletItemStatus.Free, currencyId, value, exchangeRate));
                    bank2.Wallet.AddCurrencyItem(new WalletItem(WalletItemType.Income, WalletItemStatus.Free, currencyId, value, exchangeRate));
                    break;
            }
        }
    }

    public enum OperationType
    {
        Buy = 1,
        Sell = 2
    }
}
