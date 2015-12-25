using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoClockOn.ViewModel;
using LINQtoCSV;

namespace AutoClockOn.Utility
{
    public class CsvHelper
    {
        public static IEnumerable<Staff> ReadStaffFile() 
        {
            //讀取員工檔
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = false,
                EnforceCsvColumnAttribute = true
            };

            CsvContext cc = new CsvContext();
            //將CSV檔案轉成物件
            IEnumerable<Staff> staffs =
                cc.Read<Staff>(ConfigurationManager.AppSettings["StaffFilePath"], inputFileDescription);

            return staffs;
        }

        public static void AddStaffToFile(Staff staff)
        {

        }
    }
}
