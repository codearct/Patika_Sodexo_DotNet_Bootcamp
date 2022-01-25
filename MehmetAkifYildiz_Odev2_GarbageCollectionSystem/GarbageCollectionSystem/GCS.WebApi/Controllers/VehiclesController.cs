using GCS.Service.Abstract;
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _vehicleService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _vehicleService.GetById(id);
            if (result is null)
            {
                return NotFound("Vehicle is not exist!!!");
            }
            return Ok(result);
        }
        [HttpGet("{vehicleId}/containers")]
        public async Task<IActionResult> GetContainersByVehicleId(long vehicleId)
        {
            var result = await _containerService.GetAllByVehicleId(vehicleId);
            return Ok(result);
        }
        [HttpGet("{vehicleId}/routes")]
        public async Task<IActionResult> GetRoutesByVehicleId(long vehicleId,int numOfClusters)
        {
            var result = await _routeService.AssignRoute(vehicleId, numOfClusters);
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateVehicleDto vehicleDTO)
        {
            var result = await _vehicleService.Create(vehicleDTO);
            if (result is false )
            {
                return BadRequest("Vehicle already exists!!!");
            }
            return Ok("The vehicle added.");
        }
        [HttpPut("{id}/edit")]
        public async Task<IActionResult> Edit(long id,[FromBody] EditVehicleDto vehicleDTO)
        {
            var result = await _vehicleService.Edit(id,vehicleDTO);
            if (result is false)
            {
                return NotFound("Vehicle is not exist!!!");
            }
            return Ok("The vehicle updated.");
        }
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _vehicleService.Delete(id);
            if (result is false)
            {
                return NotFound("Vehicle is not exist already!!!");
            }
            return Ok("The vehicle was removed.");
        }
    }
}
