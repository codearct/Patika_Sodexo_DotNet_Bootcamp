using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("currencytypes")]
    [ApiController]
    public class CurrencyTypesController : ControllerBase
    {
        private readonly ICurrencyTypeService _currencyTypeService;

        public CurrencyTypesController(ICurrencyTypeService currencyTypeService)
        {
            _currencyTypeService = currencyTypeService;
        }

        [HttpGet]
        public IActionResult GetAllCurrencyTypes()
        {
            var result = _currencyTypeService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCurrencyTypeById(int id)
        {
            var result = _currencyTypeService.GetById(id);
            if (result is null)
            {
                return NotFound("Currency Type does not exist!!!");
            }
            return Ok(result);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetCurrencyTypeByName(string name)
        {
            var result = _currencyTypeService.GetByName(name);
            if (result is null)
            {
                return NotFound("Currency Type does not exist!!!");
            }
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCurrencyType([FromBody] CurrencyType currencyType)
        {
            var result = _currencyTypeService.Create(currencyType);
            if (result is false)
            {
                return BadRequest("Currency Type already exists!!!");
            }
            return Ok("Currency Type Added.");
        }
        [HttpPut("{id}")]
        public IActionResult EditCurrencyType(int id,[FromBody] CurrencyType currencyType)
        {
            var result = _currencyTypeService.Edit(id, currencyType);
            if (result is false)
            {
                return NotFound("Currency Type does not exist!!!");
            }
            return Ok("Currency Type updated.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCurrencyType(int id)
        {
            var result = _currencyTypeService.Delete(id);
            if (result is false)
            {
                return NotFound("Currency Type already does not exist!!!");
            }
            return Ok("Currency Type deleted.");
        }
    }
}
