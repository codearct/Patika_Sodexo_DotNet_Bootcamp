using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICurrencyService
    {
        List<Currency> GetAll();
        Currency GetById(int id);
        Currency GetByTypeId(int typeId);
        Task<bool> Create(Currency currency);
        Task<bool> Edit(int id, Currency currency);
        bool Delete(int id);
    }
}
