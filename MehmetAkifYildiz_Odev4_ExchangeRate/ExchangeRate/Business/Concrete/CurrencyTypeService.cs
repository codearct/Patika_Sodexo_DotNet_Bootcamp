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
    public class CurrencyTypeService : ICurrencyTypeService
    {
        private readonly IUnitOfWork _uow;

        public CurrencyTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public bool Create(CurrencyType currencyType)
        {
            var model = _uow.CurrencyType.Get(c => c.Name == currencyType.Name);

            if (model != null )
            {
                return false;
            }

            _uow.CurrencyType.Add(currencyType);
            _uow.Commit();
            return true;
        }

        public bool Delete(int id)
        {
            var currencyType = _uow.CurrencyType.Get(c => c.Id == id);
            if (currencyType is null)
            {
                return false;
            }
            _uow.CurrencyType.Delete(currencyType);
            _uow.Commit();
            return true;
        }

        public List<CurrencyType> GetAll()
        {
            var currencyTypes= _uow.CurrencyType.GetAll() as List<CurrencyType>;
            return currencyTypes;
        }

        public CurrencyType GetById(int id)
        {
            var currencyType = _uow.CurrencyType.Get(c => c.Id == id);
            return currencyType;
        }
        public CurrencyType GetByName(string name)
        {
            var currencyType = _uow.CurrencyType.Get(c => c.Name == name);
            return currencyType;
        }

        public bool Edit(int id ,CurrencyType currencyType)
        {
            var existingType = _uow.CurrencyType.Get(c => c.Id == id);
            if (existingType is null)
            {
                return false;
            }

            existingType.Name = string.IsNullOrEmpty(currencyType.Name) 
                                ? existingType.Name 
                                : currencyType.Name;

            _uow.CurrencyType.Update(existingType);
            _uow.Commit();

            return true;
        }
    }
}
