using GCS.Service.Abstract;
using GCS.Service.DTO.Container;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GCS.WebApi.Controllers
{
    [Route("containers")]
    [ApiController]
    public class ContainersController : ControllerBase
    {
        private readonly IContainerService _containerService;

        public ContainersController(IContainerService containerService)
        {
            _containerService = containerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _containerService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = await _containerService.GetById(id);
            if (result is null)
            {
                return NotFound("Container is not exist!!!");
            }
            return Ok(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateContainerDto containerDTO)
        {
            var result = await _containerService.Create(containerDTO);
            if (result is false)
            {
                return BadRequest("Container already exists!!!");
            }
            return Ok("Container added.");
        }
        [HttpPut("{id}/edit")]
        public async Task<IActionResult> Edit(long id, [FromBody] EditContainerDto containerDTO)
        {
            var result = await _containerService.Edit(id, containerDTO);
            if (result is false)
            {
                return NotFound("Container is not exist or Cannot edit vehicle!!!");
            }
            return Ok("The container updated.");
        }
        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(long id)
        {
            var result = await _containerService.Delete(id);
            if (result is false)
            {
                return BadRequest("Container is not exist already!!!");
            }
            return Ok("The container was removed.");
        }
    }
}
