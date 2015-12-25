using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClockOn.ViewModel
{
    namespace Common
    {
        public enum ValidateLevel
        {
            none = -1,
            success = 0,
            info = 1,
            warning = 2,
            danger = 3
        }
        public class ValidateResult
        {
            public ValidateResult() {
                this.Level = ValidateLevel.none;
            }
            public ValidateResult(string member, string message)
            {
                this.Level = ValidateLevel.none;
                this.MemberName = member;
                this.Message = message;
            }
            public ValidateResult(string member, string message, ValidateLevel level = ValidateLevel.none)
            {
                this.MemberName = member;
                this.Message = message;
                this.Level = level;
            }

            public static ValidateResult create(string member, string message, ValidateLevel level = ValidateLevel.none)
            {
                return new ValidateResult(member, message, level);
            }

            public static ValidateResult success(string member, string message)
            {
                return new ValidateResult(member, message, ValidateLevel.success);
            }

            public static ValidateResult info(string member, string message)
            {
                return new ValidateResult(member, message, ValidateLevel.info);
            }

            public static ValidateResult warning(string member, string message)
            {
                return new ValidateResult(member, message, ValidateLevel.warning);
            }

            public static ValidateResult danger(string member, string message)
            {
                return new ValidateResult(member, message, ValidateLevel.danger);
            }

            public string MemberName { get; set; }
            public string Message { get; set; }
            public ValidateLevel Level { get; set; }

        }
    }
}
