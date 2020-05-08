using FamilyCalendar.Models;
using FamilyCalendar.Security;
using FamilyCalendar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyCalendar.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IDataProtector protector;

        public HomeController(IEventRepository eventRepository, IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger,
                                IDataProtectionProvider dataProtectionProvider, DataProtectionPurposeStrings dataProtectionPurposeStrings, UserManager<IdentityUser> userManager)
        {
            _eventRepository = eventRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
            this.userManager = userManager;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.EmployeeIdRouteValue);
        }

        [HttpGet]
        public async Task<ViewResult> Index(string uN, int? page)
        {
            // dayNumer from 1 to 7
            int dayNumber = (int)DateTime.Today.DayOfWeek == 0 ? 7 : (int)DateTime.Today.DayOfWeek;

            int indexWeek = page.HasValue ? page.Value : 0;

            IndexViewModel model = new IndexViewModel
            {
                eventsInWeek = new SortedList<int, IEnumerable<Event>>(),
                page = indexWeek
            };

            if (uN != null)
            {
                var user = await userManager.FindByNameAsync(uN);

                if (user != null)
                {
                    model.eventsInWeek = _eventRepository.GetWeekEventsPerUser(dayNumber, indexWeek, user.Id);
                }

            }

            ViewBag.Today = dayNumber;
            ViewBag.Monday = DateTime.Today.AddDays(-dayNumber);
            return View(model);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateEvent(IndexViewModel model)
        {
            if ((ModelState.IsValid) )
            {
                EventCrateViewModel eModel = model.eventCreate;

                DateTime fromModel = eModel.Date.AddHours(eModel.FromHour).AddMinutes(eModel.FromMinutes);
                DateTime toModel = eModel.Date.AddHours(eModel.ToHour).AddMinutes(eModel.ToMinutes);

                if (toModel < fromModel)
                {
                    toModel = fromModel;
                }
                if (model.uN != null)
                {
                    var user = await userManager.FindByNameAsync(model.uN);

                    Event newEvent = new Event
                    {
                        Name = eModel.Name,
                        UserId = user.Id,
                        From = fromModel,
                        To = toModel,
                        Priority = eModel.Priority
                    };

                    _eventRepository.Add(newEvent);

                }
                
                return RedirectToAction("index", new { uN = model.uN, page = model.page });
            }

            return RedirectToAction("index", new { uN = model.uN, page = model.page });
        }

        [HttpPost]
        //[Authorize]
        public IActionResult EditEvent(IndexViewModel model)
        {
            if ((ModelState.IsValid))
            {
                EventEditViewModel eModel = model.eventEdit;

                Event editEvent = _eventRepository.GetEvent(eModel.Id);
                editEvent.Name = eModel.Name;

                DateTime fromModel = eModel.Date.AddHours(eModel.FromHour).AddMinutes(eModel.FromMinutes);
                DateTime toModel = eModel.Date.AddHours(eModel.ToHour).AddMinutes(eModel.ToMinutes);

                if (toModel < fromModel)
                {
                    toModel = fromModel;
                }

                editEvent.From = fromModel;
                editEvent.To = toModel;
                editEvent.Priority = eModel.Priority;

                _eventRepository.Update(editEvent);
                return RedirectToAction("index", new { uN = model.uN, page = model.page });
            }

            return RedirectToAction("index", new { uN = model.uN, page = model.page });
        }

        [HttpPost]
        //[Authorize]
        public IActionResult DeleteEvent(IndexViewModel model)
        {
            _eventRepository.Delete(model.deleteId);
            return RedirectToAction("index", new { uN = model.uN, page = model.page });
        }
    }
}
