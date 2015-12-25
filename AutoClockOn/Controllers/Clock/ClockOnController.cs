using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoClockOn.Service.Clock;
using AutoClockOn.ViewModel;

namespace AutoClockOn.Controllers
{
    public class ClockOnController : Controller
    {
        private IClockOnService _clockOnService;
        private string _viewname = "ClockOn";
        public ClockOnController(IClockOnService service)
        {
            this._clockOnService = service;
        }

        // GET: /Index/ 首頁
        public ActionResult Index()
        {
            return View();
        }

        // GET: /ClockOn/Staff 打卡上班by default
        public ActionResult Default()
        {
            return Staff(new ClockOnViewModel(ConfigurationManager.AppSettings["DefaultStaff"]));
        }

        public ActionResult Staff(string id )
        {
            if(!string.IsNullOrWhiteSpace  (id))
            {
                return Staff(new ClockOnViewModel(id));
            }
            return View();
        }

        //
        // GET: /ClockOn/Staff/5 打卡上班by 員編
        [HttpPost]
        public ActionResult Staff(ClockOnViewModel viewmodel)
        {
            if (!_clockOnService.ClockOn(viewmodel.id))
            {
                ViewData["ViewMessage"] = "打卡失敗";
                return View(_viewname);
            }
            ViewData["ViewMessage"] = "打卡成功";
            return View(_viewname);
        }

        protected override void OnException(ExceptionContext filterContext) 
        {
           
        }
    }
}
