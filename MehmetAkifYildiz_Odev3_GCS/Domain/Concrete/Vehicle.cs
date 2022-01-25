using GCS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Domain.Concrete
{
    public class Vehicle:IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Plate { get; set; }
        public ICollection<Container> Containers { get; set; }
    }
}
