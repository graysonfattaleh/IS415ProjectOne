using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IS415ProjectOne.Models;
using IS415ProjectOne.Models.ViewModels;

namespace IS415ProjectOne.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IGroupRepository _repository;

        //Defaulting pagesize to 12 since there are 12 possible appointments in a day, which makes 12 days.
        private int PageSize = 12;

        public HomeController(ILogger<HomeController> logger, IGroupRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //returns sign up page
        public IActionResult SignUp()
        {
            return View();
        }

        //returns appointments page
        public IActionResult Appointments(int pageNum = 1)
        {
            AppointmentListViewModel viewModel = new AppointmentListViewModel
            {
                SchedulableAppointments = SeedData.GetDefaultListAppointmentTimes(),
                PagingInfo = new AppointmentPagingInfo
                {
                    ItemsPerPage = PageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = SeedData.GetDefaultListAppointmentTimes().Count()
                },
                Groups = _repository.Groups
            };
            Console.Out.WriteLine("here stuff");
            return View(
                viewModel
                );
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
