using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.KeywordDriven;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.CW_TestScripts.KD
{
    [TestClass]
    public class ClinicianLanding
    {
        [TestMethod, TestCategory("Regression")]
        public void ClinicianLanding_TC()
        {
            DataEngine keyDataEngine = new DataEngine();

            //http://jira.auscare.local:8080/secure/Tests.jspa#/testCase/CHS-T832
            keyDataEngine.ExecuteScript(@"C:\Users\anushri.mundada\source\repos\SeleniumProject\TestData\KD.xlsx", "ClinicianLanding");
            
            Thread.Sleep(3333);
        
        }

        //[TestMethod]
        //public void NEw()
        //{
        //    NavigationHelper.NavigateToUrl("http://support.charmhealth.com.au:492/login?returnUrl=%2F");
        //    TextboxHelper.TypeInTextbox(By.CssSelector("[formcontrolname='Username']"),"chadmin");
        //    TextboxHelper.TypeInTextbox(By.CssSelector("[formcontrolname='Password']"), "j06");
        //    ButtonHelper.ClickButton(By.CssSelector(".btn.btn-lg.btn-outline-primary"));

        //    var firstRow = ObjectRepository.Driver.FindElement(By.XPath("(//app-pathway-diary//infinite-scroll-table//table//tbody//tr[1]//td[2]//span)[1]"));
        //     Assert.AreNotEqual(firstRow, null, "Couldn't find a patient");
        //    firstRow.Click();

        //}
    }
}
