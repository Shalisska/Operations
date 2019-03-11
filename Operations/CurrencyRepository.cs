using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operations
{
    public class CurrencyRepository
    {
        public CurrencyRepository(List<Currency> currencies)
        {
            Currencies = currencies;
        }

        List<Currency> Currencies { get; set; }

        public Currency GetCurrency(int id)
        {
            return Currencies.FirstOrDefault(c => c.Id == id);
        }

        public List<Currency> GetCurrencies()
        {
            return Currencies;
        }
    }

    public class Currency
    {
        public Currency(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
