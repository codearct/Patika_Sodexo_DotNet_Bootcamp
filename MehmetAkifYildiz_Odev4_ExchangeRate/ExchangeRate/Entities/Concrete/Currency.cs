using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Currency:IEntity
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public decimal Purchase { get; set; }
        public decimal Sale { get; set; }
        public string Time { get; set; }
        public bool Status { get; set; }
    }
}
