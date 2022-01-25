using GCS.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Concrete.EntityFramework
{
    public class EfUnitOfWork : IUnitOfWork
    {
        private readonly GarbageCollectionSystemDbContext _context;

        public IVehicleRepository Vehicles { get; private set; }
        public IContainerRepository Containers { get; private set; }

        public EfUnitOfWork(GarbageCollectionSystemDbContext context, IVehicleRepository vehicles, IContainerRepository containers)
        {
            _context = context;
            Vehicles = vehicles;
            Containers = containers;
        }
        public async Task<bool> CommitAsync ()
        {
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                Dispose();
                throw new Exception("An error occured during saving!!!");
            }
            
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
