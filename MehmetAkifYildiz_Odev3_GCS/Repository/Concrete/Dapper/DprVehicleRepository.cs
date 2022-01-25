using GCS.Domain.Concrete;
using GCS.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Concrete.Dapper
{
    public class DprVehicleRepository: DprRepository<Vehicle>, IVehicleRepository
    {
        public DprVehicleRepository(IDbConnection connection):base(connection)
        {
        }
    }
}
