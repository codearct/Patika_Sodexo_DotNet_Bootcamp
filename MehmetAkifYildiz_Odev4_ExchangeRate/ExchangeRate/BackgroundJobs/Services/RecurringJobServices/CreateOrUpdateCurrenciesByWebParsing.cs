using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Services.RecurringJobServices
{
    public class CreateOrUpdateCurrenciesByWebParsing
    {
        private readonly ICurrencyService _currencyService;
        private readonly IExchangeRateService _exchangeRateService;
        public CreateOrUpdateCurrenciesByWebParsing(ICurrencyService currencyService, IExchangeRateService exchangeRateService)
        {
            _currencyService = currencyService;
            _exchangeRateService = exchangeRateService;
        }

        public async Task Handle()
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
        }

    }
}
