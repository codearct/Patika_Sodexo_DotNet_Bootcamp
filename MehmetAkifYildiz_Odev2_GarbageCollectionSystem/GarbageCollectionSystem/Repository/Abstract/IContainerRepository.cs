using GCS.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Abstract
{
    public interface IContainerRepository:IRepository<Container>
    {
        Task<List<Container>> GetAllByVehicleId(long id);
    }
}
