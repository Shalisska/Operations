using System;
using System.Collections.Generic;
using System.Linq;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyRepository currencyRepository = new CurrencyRepository(
                new List<Currency>
                {
                    new Currency(0, "rubles"),
                    new Currency(1, "clonero")
                });

            var bank1 = new Bank
            {
                Wallet = new Wallet(
                    currencyRepository,
                    new List<WalletItem>
                    {
                        //new WalletItem(0, 0m),
                        //new WalletItem(1, 0m)
                    })
            };

            var bank2 = new Bank
            {
                Wallet = new Wallet(
                    currencyRepository,
                    new List<WalletItem>
                    {
                        //new WalletItem(0, 0m),
                        //new WalletItem(1, 0m)
                    })
            };

            Console.WriteLine($"bank1\n{bank1.GetAccountInfo()}\n");
            Console.WriteLine($"bank2\n{bank2.GetAccountInfo()}\n");

            var operationService = new OperationService();

            var transaction = operationService.CreateTransaction(
                new TransactionPart(bank1, 1),
                new TransactionPart(bank2, 0),
                OperationType.Buy,
                3m,
                2m);

            var transaction2 = operationService.CreateTransaction(
                new TransactionPart(bank1, 1),
                new TransactionPart(bank2, 0),
                OperationType.Buy,
                5m,
                2m);

            operationService.DoOperation(transaction);

            Console.WriteLine($"bank1\n{bank1.GetAccountInfo()}\n");
            Console.WriteLine($"bank2\n{bank2.GetAccountInfo()}\n");

            operationService.DoOperation(transaction2);

            Console.WriteLine($"bank1\n{bank1.GetAccountInfo()}\n");
            Console.WriteLine($"bank2\n{bank2.GetAccountInfo()}\n");

            Console.ReadKey();
        }
    }
}
