using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoClockOn.Web.Controllers
{
    public class ClockOffController : Controller
    {
        //
        // GET: /ClockOff/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /ClockOff/Details/5
        public ActionResult Details(string id)
        {
            return View();
        }

        //
        // GET: /ClockOff/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClockOff/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ClockOff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ClockOff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /ClockOff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ClockOff/Delete/5
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
