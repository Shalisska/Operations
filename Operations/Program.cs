using System;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var curr = new StorageResource(0);
            var operationService = new OperationService();

            operationService.DoOperation(curr, 0, 10, 1);

            operationService.DoOperation(curr, 0, 5, 2);

            var value = curr.GetValue();
            var price = curr.GetPrice();

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
