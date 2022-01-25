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
        Task<List<QueryContainerDto>> GetAll();
        Task<List<QueryContainerDto>> GetAllByVehicleId(long id);
        Task<QueryContainerDto> GetById(long id);
        Task<bool> Create(CreateContainerDto containerDTO);
        Task<bool> Edit(long id, EditContainerDto containerDTO);
        Task<bool> Delete(long id);

    }
}
