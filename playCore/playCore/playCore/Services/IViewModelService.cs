using FishTank.ViewModels;

namespace FishTank.Services
{
    public interface IViewModelService
    {
        DashboardViewModel GetDashboardViewModel();
    }
}