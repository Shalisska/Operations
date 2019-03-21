using System;

namespace Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var curr = new StorageResource(0);
            var operationService = new OperationService();

            var currTransaction1 = operationService.DoOperation(curr, 0, 10, 1);

            var currTransaction2 = operationService.DoOperation(curr, 0, 5, 2);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
