using GCS.Repository.Abstract;
using GCS.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GCS.Repository.Concrete.EntityFramework
{
    public class EfContainerRepository:EfRepository<Container>,IContainerRepository
    {
        public EfContainerRepository(GarbageCollectionSystemDbContext context):base(context)
        {           
        }

        public List<Container> GetAllByVehicleId(long id)
        {
            var containers = _dbSet.Include(c => c.Vehicle)
                                        .Where(v => v.VehicleId == id)
                                        .OrderBy(c => c.Id)
                                        .ToList();

            return containers;
        }
    }
}
