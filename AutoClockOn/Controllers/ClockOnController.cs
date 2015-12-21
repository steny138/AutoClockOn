using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenQA.Selenium.Chrome;

namespace AutoClockOn.Controllers
{
    public class ClockOnController : Controller
    {
        //
        // GET: /ClockOn/ 打卡上班by default
        public ActionResult Index()
        {
            Details("B401");
            ChromeDriver
            return View();
        }

        //
        // GET: /ClockOn/Details/5 打卡上班by id
        public ActionResult Details(string id)
        {
            return View();
        }

        //
        // GET: /ClockOn/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ClockOn/Create
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
        // GET: /ClockOn/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /ClockOn/Edit/5
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
        // GET: /ClockOn/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ClockOn/Delete/5
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
