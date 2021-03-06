﻿using System;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new Storage();

            var operationService = new OperationService();

            operationService.DoOperation(storage, 0, 10, 1, TransactionDirection.Income);

            operationService.DoOperation(storage, 1, 10, 2, TransactionDirection.Income);
            operationService.DoOperation(storage, 0, 5, 2, TransactionDirection.Income);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
