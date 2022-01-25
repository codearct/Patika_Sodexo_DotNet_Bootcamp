using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Abstract
{
    public interface IUnitOfWork:IDisposable
    {
        IVehicleRepository Vehicles { get; }
        IContainerRepository Containers { get; }
        Task<bool> CommitAsync();
    }
}
