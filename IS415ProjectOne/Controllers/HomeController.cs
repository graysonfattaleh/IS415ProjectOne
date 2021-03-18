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
        public TempleAppointmentDbContext _context;

        //Defaulting pagesize to 12 since there are 12 possible appointments in a day, which makes 12 days.
        private int PageSize = 12;

        public HomeController(ILogger<HomeController> logger, IGroupRepository repository, TempleAppointmentDbContext context)
        {
            _logger = logger;
            _repository = repository;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUpForm(DateTime hiddenInput, int hiddenHour)
        {

            Group group = new Group
            {
                StartTime = new DateTime(hiddenInput.Year, hiddenInput.Month, hiddenInput.Day, hiddenHour, 0, 0)
            };

            return View(group);
        }

        // gets called when creating group

        public IActionResult MakeAppointment(int GroupSize, int hiddenTimeHour, DateTime hiddenTime, string GroupName, string Email, string PhoneNumber, int pageNum = 1)
        {
            // make object
            Group new_group = new Group
            {
                Email = Email,
                GroupName = GroupName,
                Size = GroupSize,
                PhoneNumber = PhoneNumber,
                StartTime = new DateTime(hiddenTime.Year, hiddenTime.Month, hiddenTime.Day, hiddenTimeHour, 0, 0)
            };

            // add group to context and save

            try
            {
                _context.Groups.Add(new_group);
                _context.SaveChanges();
            }
            catch
            {
                return Redirect("SignUp");
            }
            // make new view model for the appointments
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

            viewModel.addTakenTime(new_group.StartTime);
            //return View("Appointments", viewModel);
            return View("Index");




        }


        //returns sign up page
        public IActionResult SignUp(int pageNum = 1)
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

            List<DateTime> apptListTaken = new List<DateTime>();

            foreach (Group taken in viewModel.Groups)
            {
                apptListTaken.Add(taken.StartTime);
            }
            viewModel.takenTimes = apptListTaken;


            return View(viewModel);
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
