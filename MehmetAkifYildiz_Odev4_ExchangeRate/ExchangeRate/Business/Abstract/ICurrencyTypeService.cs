using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICurrencyTypeService
    {
        List<CurrencyType> GetAll();
        CurrencyType GetById(int id);
        CurrencyType GetByName(string name);
        bool Create(CurrencyType currencyType);
        bool Edit(int id,CurrencyType currencyType);
        bool Delete(int id);
    }
}
