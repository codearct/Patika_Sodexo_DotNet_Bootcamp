using GCS.Service.DTO.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Service.Abstract
{
    public interface IVehicleService
    {
        Task<List<QueryVehicleDto>> GetAll();
        Task<QueryVehicleDto> GetById(long id);
        Task<bool> Create(CreateVehicleDto vehicleDto);
        Task<bool> Edit(long id, EditVehicleDto vehicleDto);
        Task<bool> Delete(long id);
    }
}
