using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("currencies")]
    [ApiController]

    //Add ve Update metotlarını Hangfire yapacak
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly IExchangeRateService _exchangeRateService;
        public CurrenciesController(ICurrencyService currencyService, IExchangeRateService exchangeRateService)
        {
            _currencyService = currencyService;
            _exchangeRateService = exchangeRateService;
        }

        [HttpGet]
        public IActionResult GetAllCurrencies()
        {
            var result = _currencyService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCurrencyById(int id)
        {
            var result = _currencyService.GetById(id);
            if (result is null)
            {
                return NotFound("Currency does not exist!!!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCurrencyType(int id)
        {
            var result = _currencyService.Delete(id);
            if (result is false)
            {
                return NotFound("Currency already does not exist!!!");
            }
            return Ok("Currency deleted.");
        }
        /*[HttpPost]
        public async Task<IActionResult> CreateOrUpdate()
        {
            //Bütün döviz kurları çekilip Currency listesinde tutuluyor
            var data = _exchangeRateService.GetAllExchangeRates();
            //Her bir para birimi döngüyle dolaşılıyor
            foreach (var obj in data)
            {
                //İlgili para birimi database de aranıyor
                var currency = _currencyService.GetByTypeId(obj.TypeId);

                if (currency is null)
                {
                    //Databasede yoksa ilgili servisle ekleniyor
                    await _currencyService.Create(obj);
                }
                else
                    //Databasede varsa güncelleniyor
                    await _currencyService.Edit(currency.Id, obj);
            }
            return Ok();
        }*/
    }
}
