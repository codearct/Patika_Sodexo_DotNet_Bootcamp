using GCS.Service.Abstract;
using GCS.Service.DTO.Container;
using GCS.Service.DTO.Vehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCS.WebApi.Controllers
{
    [Route("vehicles")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IContainerService _containerService;
        private readonly IRouteService _routeService;
        public VehiclesController(IVehicleService vehicleService, IContainerService containerService, IRouteService routeService)
        {
            _vehicleService = vehicleService;
            _containerService = containerService;
            _routeService = routeService;
        }
        [HttpGet]
        public List<QueryVehicleDto> GetAll()
        {
            var result = _vehicleService.GetAll();
            return result;
        }
        [HttpGet("{id}")]
        public ActionResult<QueryVehicleDto> GetById(long id)
        {
            var result = _vehicleService.GetById(id);
            if (result is null)
            {
                return NotFound("Vehicle is not exist!!!");
            }
            return result;
        }
        [HttpGet("{vehicleId}/containers")]
        public List<QueryContainerDto> GetContainersByVehicleId(long vehicleId)
        {
            var result = _containerService.GetAllByVehicleId(vehicleId);
            return result;
        }
        [HttpGet("{vehicleId}/routes")]
        public IEnumerable<List<QueryContainerDto>> GetRoutesByVehicleId(long vehicleId,int numOfClusters)
        {
            var result = _routeService.AssignRoute(vehicleId, numOfClusters);
            return result;
        }
        [HttpPost("create")]
        public string Create([FromBody] CreateVehicleDto vehicleDTO)
        {
            var result = _vehicleService.Create(vehicleDTO);
            if (result is false )
            {
                return "Vehicle already exists!!!";
            }
            return "The vehicle added.";
        }
        [HttpPut("{id}/edit")]
        public string Edit(long id,[FromBody] EditVehicleDto vehicleDTO)
        {
            var result = _vehicleService.Edit(id,vehicleDTO);
            if (result is false)
            {
                return "Vehicle is not exist!!!";
            }
            return "The vehicle updated.";
        }
        [HttpDelete("{id}/delete")]
        public string Delete(long id)
        {
            var result = _vehicleService.Delete(id);
            if (result is false)
            {
                return "Vehicle is not exist already!!!";
            }
            return "The vehicle was removed.";
        }
    }
}
