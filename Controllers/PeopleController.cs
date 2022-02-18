using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC2.Facades;
using MVC2.InterFaces;
using MVC2.Models;
using MVC2.Utilities;

namespace RK_A6.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ILogger<PeopleController> _logger;
        private IPeopleFacade _facade;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
            _facade = new PeopleFacade();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Members()
        {
            var data = _facade.GetAllPeople();
            return View(data);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(PersonModel model)
        {
            DateTime inputDate = DateAgeUtility.ParseDate(model.DateOfBirth);
            model.DateOfBirth = inputDate.ToString("dd/MM/yyyy");
            _facade.AddPerson(model);

            return RedirectToAction("Members");
        }

        public IActionResult Edit(uint id)
        {
            PersonModel data = new PersonModel();
            if (id > 0)
            {
                data = _facade.GetPerson(id);
            }
            data.Id = id;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(PersonModel model)
        {
            DateTime inputDate = DateAgeUtility.ParseDate(model.DateOfBirth);
            model.DateOfBirth = inputDate.ToString("dd/MM/yyyy");
            _facade.EditPerson(model);

            return RedirectToAction("Members");
        }

        public IActionResult Delete(PersonModel model)
        {
            _facade.DeletePerson(model);

            return RedirectToAction("Members");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}