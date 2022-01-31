using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ICurrencyRepository Currency { get; }
        ICurrencyTypeRepository CurrencyType { get; }
        void Commit();
    }
}
