using GCS.Repository.Abstract;
using GCS.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Concrete.EntityFramework
{
    public class EfVehicleRepository:EfRepository<Vehicle>,IVehicleRepository
    {
        public EfVehicleRepository(GarbageCollectionSystemDbContext context):base(context)
        {
        }
    }
}
