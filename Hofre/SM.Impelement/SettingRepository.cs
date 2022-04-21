using SM.Impelement.SettingViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.Impelement
{
    public class SettingRepository : ISettingRepository
    {
        public Task Build(SettingViewModel commend)
        {
            throw new NotImplementedException();
        }

        public Task Edit(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<SettingViewModel> GetBy(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
