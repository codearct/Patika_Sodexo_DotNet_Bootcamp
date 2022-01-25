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
        List<QueryVehicleDto> GetAll();
        QueryVehicleDto GetById(long id);
        bool Create(CreateVehicleDto vehicleDto);
        bool Edit(long id, EditVehicleDto vehicleDto);
        bool Delete(long id);
    }
}
