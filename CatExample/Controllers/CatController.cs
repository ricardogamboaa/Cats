using System.Collections.Generic;
using CatExample.Models;
using Microsoft.AspNetCore.Mvc;
using Api = CatsAPI.Controllers;
using Newtonsoft.Json;

namespace CatExample.Controllers
{
    public class CatController : Controller
    {
        public CatController()
        {
            request = new Api.CatController();
        }

        private Api.CatController request;

        // GET: CatController
        public ActionResult Index()
        {
            return View(JsonConvert.DeserializeObject<List<Cat>>(request.GetCats()));
        }

        // GET: CatController/Details/5
        public ActionResult Details(string name)
        {
            return View(JsonConvert.DeserializeObject<Cat>(request.GetCatByName(name)));
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
            request.AddCat(JsonConvert.SerializeObject(cat));
            return RedirectToAction(nameof(Index));
        }

        // GET: CatController/Edit/5
        public ActionResult Edit(string name)
        {
            return View(JsonConvert.DeserializeObject<Cat>(request.GetCatByName(name)));
        }

        // POST: CatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cat cat)
        {
            request.EditCat(JsonConvert.SerializeObject(cat));
            return RedirectToAction(nameof(Index));
        }

        // GET: CatController/Delete/5
        public ActionResult Delete(string name)
        {
            return View(JsonConvert.DeserializeObject<Cat>(request.GetCatByName(name)));
        }

        // POST: CatController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(string name)
        {
            request.RemoveCat(name);
            return RedirectToAction(nameof(Index));
        }
    }
}
