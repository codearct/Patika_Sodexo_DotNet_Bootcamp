using AutoMapper;
using GCS.Domain.Concrete;
using GCS.Service.DTO.Container;
using GCS.Service.DTO.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Service.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Vehicle, QueryVehicleDto>();
            CreateMap<CreateVehicleDto, Vehicle>();

            CreateMap<Container, QueryContainerDto>()
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => $"Enlem : {src.Latitude} - Boylam : {src.Longitude}"));

            CreateMap<CreateContainerDto, Container>();
        }
    }
}
