using System;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var storage = new Storage();

            var operationService = new OperationService();

            operationService.DoOperation(storage, 0, 10, 1);

            operationService.DoOperation(storage, 1, 10, 2);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
