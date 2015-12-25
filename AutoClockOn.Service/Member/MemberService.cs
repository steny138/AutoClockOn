using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClockOn.Utility;
using AutoClockOn.ViewModel;
using AutoClockOn.ViewModel.Common;
using AutoClockOn.ViewModel.Member;

namespace AutoClockOn.Service.Member
{
    public interface IMemberService
    {
        IEnumerable<ValidateResult> canAdd(AddViewModel model);
        IEnumerable<ValidateResult> canEdit(AddViewModel model);
        bool add(AddViewModel model);
        bool edit(EditViewModel model);
        List<Staff> getStaffs();
    }
    public class MemberService : IMemberService
    {
        #region IMemberService 成員

        public bool add(AddViewModel model)
        {
            var staffs = CsvHelper.ReadStaffFile().ToList();
            throw new NotImplementedException();
        }

        public bool edit(EditViewModel model)
        {

            throw new NotImplementedException();
        }

        public List<Staff> getStaffs()
        {
            return CsvHelper.ReadStaffFile().ToList();
        }


        public IEnumerable<ValidateResult> canAdd(AddViewModel model)
        {
            List<ValidateResult> errors = new List<ValidateResult>();
            if (string.IsNullOrWhiteSpace(model.account)) errors.Add(ValidateResult.danger("account", "請輸入員工編號"));
            if (string.IsNullOrWhiteSpace(model.password)) errors.Add(ValidateResult.danger("password", "請輸入密碼"));
            if (string.IsNullOrWhiteSpace(model.account)) errors.Add(ValidateResult.danger("repassword", "請重新確認密碼"));

            if (errors.Count == 0)
            {
                var staffs = getStaffs();
                if (staffs.Exists(x => x.id == model.account))
                {
                    errors.Add(ValidateResult.create("account", "此員工編號已經存在"));
                }
            }

            return errors.Count > 0 ? errors : null;
        }

        public IEnumerable<ValidateResult> canEdit(AddViewModel model)
        {
            List<ValidateResult> errors = new List<ValidateResult>();
            if (string.IsNullOrWhiteSpace(model.account)) errors.Add(ValidateResult.create("account", "請輸入員工編號"));
            if (!string.IsNullOrWhiteSpace(model.password) && 
                string.IsNullOrWhiteSpace(model.account)) errors.Add(ValidateResult.create("repassword", "請重新確認密碼"));

            if (errors.Count == 0)
            {
                var staffs = getStaffs();
                if (!staffs.Exists(x => x.id == model.account))
                {
                    errors.Add(ValidateResult.create("account", "此員工編號不存在"));
                }
            }

            return errors.Count > 0 ? errors : null;
        }

        #endregion
    }
}
