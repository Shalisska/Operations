using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public class CurrencyRepository
    {
        public CurrencyRepository()
        {
            Currencies = new List<CurrencyEntity>
                {
                    new CurrencyEntity(0, "rubles", false),
                    new CurrencyEntity(1, "clonero", false),
                    new CurrencyEntity(2, "gold", true)
                };
        }

        public List<CurrencyEntity> Currencies { get; set; }
    }
}
