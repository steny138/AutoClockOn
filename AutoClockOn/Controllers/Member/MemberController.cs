using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoClockOn.Service.Member;
using AutoClockOn.ViewModel.Common;
using AutoClockOn.ViewModel.Member;
using AutoClockOn.Web.Extensions;

namespace AutoClockOn.Web.Controllers.Member
{
    public class MemberController : Controller
    {
        private IMemberService memberService;
        public MemberController(IMemberService service)
        {
            memberService = service;
        }
        
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Add/
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddViewModel model)
        {
            var errors = memberService.canAdd(model);
            this.AddModelErrors(errors);

            if (ModelState.IsValid)
            {
                bool result = memberService.add(model);
                if (!result)
                    return View(model);
                else
                    return RedirectToAction("List");
            }
            else
            {
                return View(model);
            }
        }

        //
        // GET: /Edit/
        public ActionResult Edit(string id)
        {
            return View();
        }

        //
        // GET: /List/
        public ActionResult List()
        {
            var staffs = memberService.getStaffs();
            return View(staffs);
        }

        //
        // GET: /PassWord/
        public ActionResult PassWord()
        {
            return View();
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var errors = new List<ValidateResult>();
            errors.Add(ValidateResult.danger("出錯了!!" ,filterContext.Exception.ToString()));
            this.AddModelErrors(errors);
            filterContext.ExceptionHandled = false;
        }
	}
}