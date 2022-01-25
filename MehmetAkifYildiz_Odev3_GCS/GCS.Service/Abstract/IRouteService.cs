using GCS.Service.DTO.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Service.Abstract
{
    public interface IRouteService
    {
        IEnumerable<List<QueryContainerDto>> AssignRoute(long vehicleId, int NumOfClusters);
    }
}
