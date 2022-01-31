using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Services.RecurringJobServices
{
    public class ChangeStatusAtEndOfDay
    {
        private readonly ICurrencyService _currencyService;

        public ChangeStatusAtEndOfDay(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task Handle()
        {
            //Databasedeki bütün para birimlerini çek
            var currencies = _currencyService.GetAll();
            foreach (var currency in currencies)
            {
                //Bütün para birimlerinin statüslerini false yap
                currency.Status = false;
                //Statusleri değişen para birimlerini güncelle
                await _currencyService.Edit(currency.Id, currency);
            }
        }
    }
}
