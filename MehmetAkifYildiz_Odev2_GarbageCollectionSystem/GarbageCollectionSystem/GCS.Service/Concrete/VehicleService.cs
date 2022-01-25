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
        public async Task<bool> Create(CreateVehicleDto vehicleDto)
        {
            var vehicle = await _uow.Vehicles.Get(v => v.Plate == vehicleDto.Plate);
            if (vehicle is not null)
            {
                return false;
            }
            vehicle = _mapper.Map<Vehicle>(vehicleDto);
            await _uow.Vehicles.Add(vehicle);
            await _uow.CommitAsync();
            return true;
        }

        public async Task<bool> Delete(long id)
        {
            var vehicle = await _uow.Vehicles.Get(v => v.Id == id);
            if (vehicle is null)
            {
                return false;
            }
            var containers = await _uow.Containers.GetAllByVehicleId(vehicle.Id);
            await _uow.Vehicles.Delete(vehicle);
            await _uow.Containers.DeleteAll(containers);
            await _uow.CommitAsync();
            return true;
        }

        public async Task<bool> Edit(long id, EditVehicleDto vehicleDto)
        {
            var vehicle = await _uow.Vehicles.Get(v => v.Id ==id);
            if (vehicle is null)
            {
                return false;
            }
            vehicle.Name = string.IsNullOrEmpty(vehicleDto.Name) ? vehicle.Name : vehicleDto.Name;
            vehicle.Plate = string.IsNullOrEmpty(vehicleDto.Plate) ? vehicle.Plate : vehicleDto.Plate;
            await _uow.Vehicles.Update(vehicle);
            await _uow.CommitAsync();
            return true;
        }

        public async Task<List<QueryVehicleDto>> GetAll()
        {
            var vehicles = await _uow.Vehicles.GetAll();
            List<QueryVehicleDto> vehicleDTOs = _mapper.Map<List<QueryVehicleDto>>(vehicles);
            return vehicleDTOs;

        }

        public async Task<QueryVehicleDto> GetById(long id)
        {
            var vehicle = await _uow.Vehicles.Get(v => v.Id == id);
            QueryVehicleDto vehicleDTO = _mapper.Map<QueryVehicleDto>(vehicle);
            return vehicleDTO;
        }
    }
}
