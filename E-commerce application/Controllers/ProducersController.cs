﻿using E_commerce_application.Data;
using E_commerce_application.Data.Services;
using E_commerce_application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_application.Controllers
{
    public class ProducersController : Controller
    {
        private IProducersService _service;
        public ProducersController(IProducersService service)
        {
            _service = service;

        }
        public IActionResult Index()
        {
            var allActors = _service.GetAll();
            return View(allActors);
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("ProfilePictureURL,FullName,Bio")] Producer producer)
        {
            if (ModelState.IsValid)
            {

                _service.Add(producer);
                return RedirectToAction(nameof(Index));



            }
            return View(producer);
        }
        public IActionResult Edit(int id)
        {
            var OldActor = _service.GetById(id);
            return View(OldActor);
        }
        [HttpPost]
        public IActionResult Edit(int id, Producer producer)
        {
            if (ModelState.IsValid)
            {
                _service.Update(id, producer);
                return RedirectToAction(nameof(Index));
            }
            return View(producer);
        }
        public IActionResult Delete(int id)
        {

            var OldActor = _service.GetById(id);
            return View(OldActor);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {

            var OldActor = _service.GetById(id);
            if (OldActor == null) return View("NotFound");
            _service.Delete(id);
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Details(int id)
        {
            var OldActor = _service.GetById(id);
            return View(OldActor);
        }

    }
}
