using SM.Impelement.SettingViewModels;
using System;
using System.Threading.Tasks;

namespace SM.Impelement
{
    public interface ISettingRepository
    {
        Task Build(SettingViewModel commend);
        Task<SettingViewModel> GetBy(long Id);
        Task Edit(long Id);


    }
}
