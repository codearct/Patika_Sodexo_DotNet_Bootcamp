using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundJobs.Jobs.Abstract
{
    public interface IRecurringJobs
    {
        void CreateOrUpdateCurrency();
        void ChangeSatus();
    }
}
