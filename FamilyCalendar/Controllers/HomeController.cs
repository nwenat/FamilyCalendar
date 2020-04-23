using FamilyCalendar.Models;
using FamilyCalendar.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly ILogger logger;

        public HomeController(IEmployeeRepository employeeRepository, IEventRepository eventRepository, IHostingEnvironment hostingEnvironment, ILogger<HomeController> logger)
        {
            _employeeRepository = employeeRepository;
            _eventRepository = eventRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.logger = logger;
        }

        public ViewResult Index(int? page)
        {
            // dayNumer from 1 to 7
            int dayNumber = (int)DateTime.Today.DayOfWeek == 0 ? 7 : (int)DateTime.Today.DayOfWeek;

            int indexWeek = page.HasValue ? page.Value : 0;

            IndexViewModel model = new IndexViewModel
            {
                eventsInWeek = _eventRepository.GetWeekEvents(dayNumber, indexWeek),
                page = indexWeek
            };

            ViewBag.Today = dayNumber;
            ViewBag.Monday = DateTime.Today.AddDays(-dayNumber);
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateEvent(IndexViewModel model)
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

                Event newEvent = new Event
                {
                    Name = eModel.Name,
                    UserId = eModel.UserId,
                    From = fromModel,
                    To = toModel,
                    Priority = eModel.Priority
                };

                _eventRepository.Add(newEvent);
                return RedirectToAction("index", new { page = model.page });
            }

            return RedirectToAction("index", new { page = model.page });
        }

        [HttpPost]
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
                return RedirectToAction("index", new { page = model.page });
            }

            return RedirectToAction("index", new { page = model.page });
        }

        [HttpPost]
        public IActionResult DeleteEvent(IndexViewModel model)
        {
            _eventRepository.Delete(model.deleteId);
            return RedirectToAction("index", new { page = model.page });
        }







        







        public ViewResult Details(int? id)
        {
            //throw new Exception("Error in Details View");

            logger.LogTrace("Trace Log");
            logger.LogDebug("Debug Log");
            logger.LogInformation("Information Log");
            logger.LogWarning("Warning Log");
            logger.LogError("Error Log");
            logger.LogCritical("Critical Log");

            Employee employee = _employeeRepository.GetEmployee(id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };
            
            //ViewBag.Employee = model;
            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqeFileName = ProcessUploadedFile(model);
                    

                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqeFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }

            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepository.GetEmployee(model.Id);
                employee.Name = model.Name;
                employee.Email = model.Email;
                employee.Department = model.Department;

                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }

                _employeeRepository.Update(employee);
                return RedirectToAction("index");
            }

            return View();
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqeFileName = null;
            if (model.Photo != null)
            {
                string uploatsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                uniqeFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploatsFolder, uniqeFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqeFileName;
        }
    }
}
