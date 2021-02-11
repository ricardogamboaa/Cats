using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatExample.Models;
using CatExample.Repository;
using ApiController = CatsAPI.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatExample.Controllers
{
    public class CatController : Controller
    {
        public CatController()
        {
            repository = new CatRepository(new ApiController.CatController());
        }

        private CatRepository repository;

        // GET: CatController
        public ActionResult Index()
        {
            return View(repository.GetCats());
        }

        // GET: CatController/Details/5
        public ActionResult Details(string name)
        {
            return View(repository.GetCatByName(name));
        }

        // GET: CatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cat cat)
        {
            repository.AddCat(cat);
            return RedirectToAction(nameof(Index));
        }

        // GET: CatController/Edit/5
        public ActionResult Edit(string name)
        {
            return View(repository.GetCatByName(name));
        }

        // POST: CatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cat cat)
        {
            repository.EditCat(cat);
            return RedirectToAction(nameof(Index));
        }

        // GET: CatController/Delete/5
        public ActionResult Delete(string name)
        {
            return View(repository.GetCatByName(name));
        }

        // POST: CatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string name, Cat cat)
        {
            repository.RemoveCat(name);
            return RedirectToAction(nameof(Index));
        }
    }
}
