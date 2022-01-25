using GCS.Repository.Abstract;
using GCS.Repository.Concrete.EntityFramework;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Repository.Concrete.Dapper
{
    public class DprUnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public IVehicleRepository Vehicles { get; private set; }
        public IContainerRepository Containers { get; private set; }

        public DprUnitOfWork(IDbConnection connection, IVehicleRepository vehicles, IContainerRepository containers)
        {
            _connection = connection;
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            Vehicles = vehicles;
            Containers = containers;
        }
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception)
            {
                Dispose();
                throw new Exception("An error occured during saving!!!");
            }
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }
    }
}
