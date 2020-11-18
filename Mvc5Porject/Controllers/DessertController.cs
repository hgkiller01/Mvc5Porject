using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5Porject.Adapter.InterFace;
using Mvc5Porject.Models;

namespace Mvc5Porject.Controllers
{
    public class DessertController : Controller
    {
        IDessertAdapter _dessertAdapter;
        public DessertController(IDessertAdapter dessertAdapter)
        {
            _dessertAdapter = dessertAdapter;
        }
        // GET: Dessert
        public ActionResult Index()
        {
            var Desserts = _dessertAdapter.GetList();
            return View(Desserts);
        }

        // GET: Dessert/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dessert/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dessert dessert)
        {
            if(_dessertAdapter.Get(dessert.DessertID) != null)
            {
                return View(dessert);
            }
            if (ModelState.IsValid)
            {
                _dessertAdapter.Create(dessert);
                return RedirectToAction("Index");
            }
            else
            {
                return View(dessert);
            }
        }

        // GET: Dessert/Edit/5
        public ActionResult Edit(string id)
        {
            var dessert = _dessertAdapter.Get(id);
            return View(dessert);
        }

        // POST: Dessert/Edit/5
        [HttpPost]
        public ActionResult Edit(Dessert dessert)
        {
            if (ModelState.IsValid)
            {
                _dessertAdapter.Update(dessert);
                return RedirectToAction("Index");
            }
            else
            {
                return View(dessert);
            }
        }

        // GET: Dessert/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dessert/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
