using GCS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Domain.Concrete
{
    public class Container:IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public long? VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
