using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using playCore.ViewModels;

namespace playCore.Services
{
    public class ViewModelService : IViewModelService
    {
        private readonly ISensorDataService sensorDataService;
        private readonly IUrlHelper urlHelper;

        public ViewModelService(ISensorDataService sensorDataService, IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
        {
            this.sensorDataService = sensorDataService;
            urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }

        public DashboardViewModel GetDashboardViewModel()
        {
            return new DashboardViewModel
            {
                LastFed = "unknown",

                WaterTemperatureTile = new SensorTileViewModel
                {
                    Title = "Water temperature",
                    Value = sensorDataService.GetWaterTemperatureFahrenheit().Value,
                    ColorCssClass = "panel-primary",
                    IconCssClass = "fa-sliders",
                    Url = urlHelper.Action("GetWaterTemperatureChart", "History")
                },
                FishMotionTile = new SensorTileViewModel
                {
                    Title = "Fish motion",
                    Value = sensorDataService.GetFishMotionPercentage().Value,
                    ColorCssClass = "panel-green",
                    IconCssClass = "fa-car",
                    Url = urlHelper.Action("GetFishMotionPercentageChart", "History")
                },
                WaterOpacityTile = new SensorTileViewModel
                {
                    Title = "Water opacity",
                    Value = sensorDataService.GetWaterOpacityPercentage().Value,
                    ColorCssClass = "panel-yellow",
                    IconCssClass = "fa-adjust",
                    Url = urlHelper.Action("GetWaterOpacityPercentageChart", "History")
                },
                LightIntensityTile = new SensorTileViewModel
                {
                    Title = "Light intensity",
                    Value = sensorDataService.GetLightIntensityLumens().Value,
                    ColorCssClass = "panel-red",
                    IconCssClass = "fa-lightbulb-o",
                    Url = urlHelper.Action("GetLightIntensityLumensChart", "History")
                }
            };
        }
    }
}
