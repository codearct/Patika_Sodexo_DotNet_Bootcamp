using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IUnitOfWork _uow;

        public CurrencyService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Create(Currency currency)
        {
            var model = _uow.Currency.Get(c => c.TypeId == currency.TypeId);

            if (model != null || currency.TypeId==0)
            {
                return false;
            }

            _uow.Currency.Add(currency);
            _uow.Commit();
            return true;
        }

        public bool Delete(int id)
        {
            var currency = _uow.Currency.Get(c => c.Id == id);
            if (currency is null)
            {
                return false;
            }
            _uow.Currency.Delete(currency);
            _uow.Commit();
            return true;
        }

        public async  Task<bool> Edit(int id, Currency currency)
        {
            var existingCurrency = _uow.Currency.Get(c => c.Id == id);
            if (existingCurrency is null)
            {
                return false;
            }

            existingCurrency.TypeId = currency.TypeId==default ? existingCurrency.TypeId: currency.TypeId;
            existingCurrency.Purchase = currency.Purchase == default ? existingCurrency.Purchase : currency.Purchase;
            existingCurrency.Sale = currency.Sale == default ? existingCurrency.Sale : currency.Sale;
            existingCurrency.Time = string.IsNullOrEmpty(currency.Time) ? existingCurrency.Time : currency.Time;
            existingCurrency.Status = currency.Status == default ? existingCurrency.Status : currency.Status;

            _uow.Currency.Update(existingCurrency);
            _uow.Commit();

            return true;
        }

        public List<Currency> GetAll()
        {
            var currencies = _uow.Currency.GetAll() as List<Currency>;
            return currencies;
        }

        public Currency GetById(int id)
        {
            var currency = _uow.Currency.Get(c => c.Id == id);
            return currency;
        }
        public Currency GetByTypeId(int typeId)
        {
            var currency = _uow.Currency.Get(c => c.TypeId == typeId);
            return currency;
        }
    }
}
