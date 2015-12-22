using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LINQtoCSV;

namespace AutoClockOn.ViewModel
{
    public class Staff
    {
        [CsvColumn(FieldIndex = 1, CanBeNull = true)]
        public string id { get; set; }
        [CsvColumn(FieldIndex = 2, CanBeNull = true)]
        public string password { get; set; }
    }
}
