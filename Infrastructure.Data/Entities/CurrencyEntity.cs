using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Entities
{
    public class CurrencyEntity
    {
        public CurrencyEntity(
            int id,
            string name,
            bool baseCurrency)
        {
            Id = id;
            Name = name;
            BaseCurrency = baseCurrency;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool BaseCurrency { get; set; }
    }
}
