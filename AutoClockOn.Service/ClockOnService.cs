using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoClockOn.ViewModel;
using LINQtoCSV;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutoClockOn.Service
{
   public  interface IClockOnService
    {
       bool ClockOn(string id);
    }

    public class ClockOnService:IClockOnService
    {

        #region IClockOnService 成員

        public bool ClockOn(string id)
        {
            try
            {
                Staff staff = FindMatchStaffs(id);

                if (staff != null)
                {

                    using (ChromeDriver driver = new ChromeDriver())
                    {
                        driver.Navigate().GoToUrl("http://erp.liontravel.com");
                        driver.FindElement(By.Name("sStfn")).Clear();
                        driver.FindElement(By.Name("sStfn")).SendKeys(staff.id);
                        driver.FindElement(By.Name("sPswd")).Clear();
                        driver.FindElement(By.Name("sPswd")).SendKeys(staff.password);
                        driver.FindElement(By.Name("btn_login")).Click();
                        driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                        driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
                        driver.FindElementByLinkText("打卡").SendKeys(Keys.Delete);
                        driver.FindElementByLinkText("打卡").Click();
                        driver.FindElement(By.Name("sStfnPassword")).SendKeys(staff.id + staff.password);
                        driver.FindElement(By.Name("btnFirst")).Click();
                    }
                    return true;
                }
            }
            catch(Exception)
            {
                throw new Exception("打卡失敗!");
            }

            return false;
        }

        /// <summary>
        /// 取得符合的員工
        /// </summary>
        /// <param name="id">員工編號</param>
        /// <returns>符合的員工</returns>
        private Staff FindMatchStaffs(string id)
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

            var matchStaff = staffs.Where(x => x.id == id).FirstOrDefault();

            return matchStaff;
        }
        #endregion
    }
}
