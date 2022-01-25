using Dapper;
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
    public class DprContainerRepository:DprRepository<Container>,IContainerRepository
    {
        public DprContainerRepository(IDbConnection connection):base(connection)
        {

        }

        public List<Container> GetAllByVehicleId(long id)
        {
            var sql = $"SELECT * FROM Containers c INNER JOIN Vehicles v on c.vehicleId = v.Id AND v.Id={id}";
            var containers = _connection.Query<Container, Vehicle, Container>(sql,
            (container, vehicle) => { container.Vehicle = vehicle; return container; }, splitOn: "vehicleId").ToList();
            return containers;
        }
    }
}
