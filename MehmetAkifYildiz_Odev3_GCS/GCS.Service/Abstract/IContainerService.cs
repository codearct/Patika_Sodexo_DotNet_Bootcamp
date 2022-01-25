using GCS.Service.DTO.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Service.Abstract
{
    public interface IContainerService
    {
        List<QueryContainerDto> GetAll();
        List<QueryContainerDto> GetAllByVehicleId(long id);
        QueryContainerDto GetById(long id);
        bool Create(CreateContainerDto containerDTO);
        bool Edit(long id, EditContainerDto containerDTO);
        bool Delete(long id);

    }
}
