using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using playCore.Services;

namespace playCore.Controllers
{
    public class HomeController : Controller
    {
        private IViewModelService viewModelService;

        public HomeController(IViewModelService viewModelService) {
            this.viewModelService = viewModelService;

        }

        public IActionResult Feed(int foodAmount)
        {
            var model = viewModelService.GetDashboardViewModel();
            model.LastFed = $"{DateTime.Now.Hour}:{DateTime.Now.Minute}. Amount: {foodAmount}";
            return View("Index", model);
        }


        public IActionResult Index()
        {
            ViewBag.Title = "Fish tank dashboard";
            return View(viewModelService.GetDashboardViewModel());
        }

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}
