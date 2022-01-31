using BackgroundJobs.Services.RecurringJobServices;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Jobs
{
    public static class RecurringJobs
    {
        //Pazartesiden cumaya kadar saat 8 ile 18 arasında her 15 dk da bir çalıştırılacak
        public static void CreateOrUpdateCurrency()
        {
            RecurringJob.RemoveIfExists(nameof(CreateOrUpdateCurrenciesByWebParsing));
            RecurringJob.AddOrUpdate<CreateOrUpdateCurrenciesByWebParsing>(
                nameof(CreateOrUpdateCurrenciesByWebParsing),
                job=>job.Handle(), 
                "0-59/15 8-18 * * 1-5",
                TimeZoneInfo.Local
                );
        }
        //Pazartesiden cumaya kadar 18:01 de çalıştırılacak
        public static void ChangeSatus()
        {
            RecurringJob.RemoveIfExists(nameof(ChangeStatusAtEndOfDay));
            RecurringJob.AddOrUpdate<ChangeStatusAtEndOfDay>(
                nameof(ChangeStatusAtEndOfDay),
                job => job.Handle(),
                "1 18 * * 1-5",
                TimeZoneInfo.Local
                );
        }
    }
}
