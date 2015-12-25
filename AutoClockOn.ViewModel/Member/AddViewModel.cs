using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClockOn.ViewModel.Member
{
    public class AddViewModel
    {
        public string account { get; set; }
        public string password { get; set; }
        public string repassword { get; set; }
        public DateTime mdate { get; set; }
        public bool isDisabled { get; set; }

        public AddViewModel()
        {
            this.mdate = DateTime.Now;
            this.isDisabled = false;
        }
    }
}
