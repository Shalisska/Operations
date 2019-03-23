using Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Opeartions.Tests
{
    public class OperationServiceTests
    {
        [Fact]
        public void DoOperationIncomeFewResources()
        {
            //Arrange
            var operationService = new OperationService();
            var storage = new Storage();

            //Act
            operationService.DoOperation(storage, 0, 10, 1, TransactionDirection.Income);
            operationService.DoOperation(storage, 1, 10, 2, TransactionDirection.Income);

            var actualCurrenciesCount = storage.Currencies.Where(c => c.Quantity > 0).ToList().Count;

            //Assert
            Assert.Equal(2, actualCurrenciesCount);
        }

        [Fact]
        public void DoOperationIncomeOneResourceDifferenetPrice()
        {
            //Arrange
            var operationService = new OperationService();
            var storage = new Storage();

            var quantity1 = 10;
            var price1 = 1m;
            var quantity2 = 5;
            var price2 = 2m;

            var quantityExpected = quantity1 + quantity2;
            var totalCostExpected = quantity1 * price1 + quantity2 * price2;
            var priceExpected = totalCostExpected / quantityExpected;

            //Act
            operationService.DoOperation(storage, 0, 10, 1, TransactionDirection.Income);
            operationService.DoOperation(storage, 0, 5, 2, TransactionDirection.Income);

            var actualCurrency = storage.Currencies.FirstOrDefault(c => c.Id == 0);

            //Assert
            Assert.Equal(quantityExpected, actualCurrency.Quantity);
            Assert.Equal(totalCostExpected, actualCurrency.TotalCost);
            Assert.Equal(priceExpected, actualCurrency.Price);
        }
    }
}
