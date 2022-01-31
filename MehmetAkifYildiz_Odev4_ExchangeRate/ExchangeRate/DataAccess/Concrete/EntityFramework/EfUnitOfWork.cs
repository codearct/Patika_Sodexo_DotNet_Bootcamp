using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly ExchangeRateDbContext _context;
        public ICurrencyRepository Currency { get; private set; }

        public ICurrencyTypeRepository CurrencyType { get; private set; }

        public EfUnitOfWork(ExchangeRateDbContext context, ICurrencyRepository currency, ICurrencyTypeRepository currencyType)
        {
            _context = context;
            Currency = currency;
            CurrencyType = currencyType;
        }
        public void Commit()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                Dispose();
                throw new Exception("An error occured during saving!!!");
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
