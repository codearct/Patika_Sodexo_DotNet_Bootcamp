using AutoMapper;
using GCS.Domain.Concrete;
using GCS.Repository.Abstract;
using GCS.Service.Abstract;
using GCS.Service.DTO.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Service.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public VehicleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public bool Create(CreateVehicleDto vehicleDto)
        {
            var vehicle = _uow.Vehicles.Get(v => v.Plate == vehicleDto.Plate);
            if (vehicle is not null)
            {
                return false;
            }
            vehicle = _mapper.Map<Vehicle>(vehicleDto);
            _uow.Vehicles.Add(vehicle);
            _uow.Commit();
            return true;
        }

        public bool Delete(long id)
        {
            var vehicle = _uow.Vehicles.Get(v => v.Id == id);
            if (vehicle is null)
            {
                return false;
            }
            var containers = _uow.Containers.GetAllByVehicleId(vehicle.Id);
            _uow.Vehicles.Delete(vehicle);
            _uow.Containers.DeleteAll(containers);
            _uow.Commit();
            return true;
        }

        public bool Edit(long id, EditVehicleDto vehicleDto)
        {
            var vehicle = _uow.Vehicles.Get(v => v.Id ==id);
            if (vehicle is null)
            {
                return false;
            }
            vehicle.Name = string.IsNullOrEmpty(vehicleDto.Name) ? vehicle.Name : vehicleDto.Name;
            vehicle.Plate = string.IsNullOrEmpty(vehicleDto.Plate) ? vehicle.Plate : vehicleDto.Plate;
            _uow.Vehicles.Update(vehicle);
            _uow.Commit();
            return true;
        }

        public List<QueryVehicleDto> GetAll()
        {
            var vehicles = _uow.Vehicles.GetAll();
            List<QueryVehicleDto> vehicleDTOs = _mapper.Map<List<QueryVehicleDto>>(vehicles);
            return vehicleDTOs;

        }

        public QueryVehicleDto GetById(long id)
        {
            var vehicle = _uow.Vehicles.Get(v => v.Id == id);
            QueryVehicleDto vehicleDTO = _mapper.Map<QueryVehicleDto>(vehicle);
            return vehicleDTO;
        }
    }
}
