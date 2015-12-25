using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoClockOn.ViewModel.Common;

namespace AutoClockOn.Web.Extensions
{
    public static class ControllerExtensions
    {
        public static void AddModelErrors(this Controller controller, IEnumerable<ValidateResult> validateResults, string defaultErrorKey = null)
        {
            if (validateResults != null)
            {
                //加入錯誤驗證的畫面顯示訊息
                controller.TempData["ValidateErrors"] = validateResults;

                foreach (var validateResult in validateResults)
                {
                    if (!string.IsNullOrEmpty(validateResult.MemberName))
                    {
                        controller.ModelState.AddModelError(validateResult.MemberName, validateResult.Message);
                    }
                    else if (defaultErrorKey != null)
                    {
                        controller.ModelState.AddModelError(defaultErrorKey, validateResult.Message);
                    }
                    else
                    {
                        controller.ModelState.AddModelError(string.Empty, validateResult.Message);
                    }
                }
            }
        }
        public static void AddModelErrors(this ModelStateDictionary modelState, IEnumerable<ValidateResult> validateResults, string defaultErrorKey = null)
        {
            if (validateResults == null) return;

            
            foreach (var validateResult in validateResults)
            {
                string key = validateResult.MemberName ?? defaultErrorKey ?? string.Empty;
                modelState.AddModelError(key, validateResult.Message);
            }
        }
    }
}