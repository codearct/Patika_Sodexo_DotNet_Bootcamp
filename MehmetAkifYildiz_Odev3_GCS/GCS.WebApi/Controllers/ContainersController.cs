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
        public  List<QueryContainerDto> GetAll()
        {
            var result = _containerService.GetAll();
            return result;
        }
        [HttpGet("{id}")]
        public ActionResult<QueryContainerDto> GetById(long id)
        {
            var result = _containerService.GetById(id);
            if (result is null)
            {
                return NotFound("Container is not exist!!!");
            }
            return result;
        }
        [HttpPost("create")]
        public string Create([FromBody] CreateContainerDto containerDTO)
        {
            var result = _containerService.Create(containerDTO);
            if (result is false)
            {
                return "Container already exists!!!";
            }
            return "Container added.";
        }
        [HttpPut("{id}/edit")]
        public string Edit(long id, [FromBody] EditContainerDto containerDTO)
        {
            var result =_containerService.Edit(id, containerDTO);
            if (result is false)
            {
                return "Container is not exist or Cannot edit vehicle!!!";
            }
            return "The container updated.";
        }
        [HttpDelete("{id}/delete")]
        public string Delete(long id)
        {
            var result = _containerService.Delete(id);
            if (result is false)
            {
                return "Container is not exist already!!!";
            }
            return "The container was removed.";
        }
    }
}
