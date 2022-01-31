using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CurrencyRepository : EfRepository<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ExchangeRateDbContext context) : base(context)
        {
        }
    }
}
