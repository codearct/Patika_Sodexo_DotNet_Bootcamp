using AutoMapper;
using GCS.Domain.Concrete;
using GCS.Repository.Abstract;
using GCS.Service.DTO.Container;
using GCS.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Service.Concrete
{
    public class ContainerService : IContainerService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ContainerService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public bool Create(CreateContainerDto containerDTO)
        {
            var container = _uow.Containers.Get(c => c.Name == containerDTO.Name);
            if (container is not null)
            {
                return false;
            }
            container = _mapper.Map<Container>(containerDTO);
             _uow.Containers.Add(container);
            _uow.Commit();
            return true;
        }

        public bool Delete(long id)
        {
            var container =_uow.Containers.Get(c => c.Id == id);
            if (container is null)
            {
                return false;
            }
            _uow.Containers.Delete(container);
            _uow.Commit();
            return true;
        }

        public bool Edit(long id, EditContainerDto containerDTO)
        {
            var container = _uow.Containers.Get(c => c.Id == id);
            if (container is null)
            {
                return false;
            }
            container.Name = string.IsNullOrEmpty(containerDTO.Name) ? container.Name : containerDTO.Name;
            container.Latitude = containerDTO.Latitude == default ? container.Latitude : containerDTO.Latitude;
            container.Longitude = containerDTO.Longitude == default ? container.Longitude : containerDTO.Longitude;
            if (container.VehicleId == default)
                container.VehicleId = containerDTO.VehicleId;
            _uow.Containers.Update(container);
            _uow.Commit();
            return true;
        }

        public List<QueryContainerDto> GetAll()
        {
            var containers = _uow.Containers.GetAll();
            List<QueryContainerDto> containerDTOs = _mapper.Map<List<QueryContainerDto>>(containers);
            return containerDTOs;
        }

        public List<QueryContainerDto> GetAllByVehicleId(long id)
        {
            var containers = _uow.Containers.GetAllByVehicleId(id);
            List<QueryContainerDto> containerDTOs = _mapper.Map<List<QueryContainerDto>>(containers);
            return containerDTOs;
        }

        public QueryContainerDto GetById(long id)
        {
            var container = _uow.Containers.Get(c => c.Id == id);
            QueryContainerDto containerDTO = _mapper.Map<QueryContainerDto>(container);
            return containerDTO;

        }
    }
}
