using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.ComponentHelper;
using SeleniumProject.KeywordDriven;
using SeleniumProject.Settings;
using System;
using System.Threading;

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
            keyDataEngine.ExecuteScript(@"C:\dev\charmweb\CW_Automation\TestData\MedicalLanding.xlsx", "MedicalLanding");
            
            Thread.Sleep(3333);
        
        }

        [TestMethod]
        public void NEw()
        {
            NavigationHelper.NavigateToUrl("http://support.charmhealth.com.au:492/login?returnUrl=%2F");
            TextboxHelper.TypeInTextbox(By.CssSelector("[formcontrolname='Username']"),"chadmin");
            TextboxHelper.TypeInTextbox(By.CssSelector("[formcontrolname='Password']"), "j06");
            ButtonHelper.ClickButton(By.CssSelector(".btn.btn-lg.btn-outline-primary"));
            GenericHelper.GetElement(By.CssSelector(".card-pf.flex-column.full-height"));
            ButtonHelper.ClickButton(By.XPath("//ng-sidebar[1]/aside[1]//div[1]/control-daterange[1]/form[1]/div[1]/input[1]"));
            TextboxHelper.ClearTextBody(By.XPath("//ng-sidebar[1]/aside[1]//div[1]/control-daterange[1]/form[1]/div[1]/input[1]"));
            TextboxHelper.TypeInTextbox(By.XPath("//ng-sidebar[1]/aside[1]//div[1]/control-daterange[1]/form[1]/div[1]/input[1]"),"02-02-2020");
            GenericHelper.ComapreIfNull(By.CssSelector(".card-pf.flex-column.full-height"));
            // ButtonHelper.ClickButton(By.XPath("//div[contains(text(),'TESTANI, Chandra')]"));
            // ButtonHelper.ClickButton(By.CssSelector(".list-pf-container > div > .list-pf-content.list-pf-content-flex"));
            //foreach (string item in ComboboxHelper.GetAllItem(By.XPath("//div[3]/input-wrapper[1]//ng-select[@role='listbox']//input[@role='combobox']")))
            //{
            //    Console.WriteLine("Text: {0}", item);//this prints all th eoptions in the dropdown
            //}
            //  ComboboxHelper.SelectElement(By.CssSelector("[formcontrolname='cboRelatedDiagnosis'] input"), 1);


            //ObjectRepository.Driver.FindElement(By.CssSelector("[formcontrolname='cboRelatedDiagnosis'] input")).Click();
            //ObjectRepository.Driver.FindElement(By.ClassName("ng-arrow-wrapper")).Click();
            //string from_sys = ObjectRepository.Driver.FindElement(By.CssSelector("input#doseDate")).GetAttribute("value");

            //DateTime today = DateTime.Now;
            //string today_date = today.ToString("dd-MMM-yyyy");

            //Assert.AreEqual(today_date, from_sys);


           // ButtonHelper.ClickButton(By.CssSelector("div:nth-of-type(3) > input-wrapper:nth-of-type(1) ng-select[role='listbox']  .ng-arrow-wrapper"));
           // ComboboxHelper.SelectElement(By.CssSelector("div[role='option'] > .ng-option-label.ng-star-inserted"), "- Hodgkins disease");
           //// ComboboxHelper.SelectElement(By.XPath("//div[3]/input-wrapper[1]//ng-select[@role='listbox']//input[@role='combobox']"), "el-GR");
          





           // IWebElement element = ObjectRepository.Driver.FindElement(By.CssSelector(".list-pf-main-content .row [class='flex-1 padding-sides-5']:nth-of-type(2)"));
           // //Assert.IsTrue(BrowserHelper.MatchWildcardString("?01-Feb-1995", element.Text));
           // Console.WriteLine(element.Text.Contains("STB 15476"));
           // Assert.IsTrue(element.Text.Contains("STB 15476"));

           // IWebElement element1 = ObjectRepository.Driver.FindElement(By.XPath("//div[@class='flex-column']/div[@class='row']/div[3]/div/div[1]/span[@class='flex-1']"));
           // Console.WriteLine(element1.Text.Contains("706459858"));
		



           // GenericHelper.ComapreIfNull(By.XPath("//div[@class='flex-5']"));//alerts
           // Console.WriteLine(ButtonHelper.GetButtonText(By.XPath("//*[@id='pfng-list11-item0']/div/div[1]/div[2]/div[1]/div[2]/div/div[1]/text()")));

           // GenericHelper.GetTextAndCompare(By.ClassName("ng-tns-c31-26"),"MRN");

            //TextboxHelper.TypeInTextbox(By.CssSelector("input[name='search']"), "smithee");
            //ButtonHelper.ClickButton(By.CssSelector(".iconic.iconic-magnifying-glass"));
            //ButtonHelper.ClickButton(By.XPath("(//infinite-scroll-table-inner/table//tbody//tr[1]/td[3]//span)[1]"));
            //ButtonHelper.ClickButton(By.XPath("(//infinite-scroll-table-inner/table//tbody//tr[1]/td[3]//span)[1]"));
            //ButtonHelper.ClickButton(By.XPath("(//infinite-scroll-table-inner/table//tbody//patient-search-display-details/div[1]/form)[1]"));
            //LinkHelper.ClickLink(By.XPath("//div[@class='list-pf-title padding-sides-5']"));//opens the patient banner
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'Address')]"),"Address");//checks the address label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'Home')]"), "Home");//checks the Home label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'Medicare')]"), "Medicare");//checks the Medicare label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'Concession')]"), "Concession");//checks the Concession  label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'DVA')]"), "DVA");//checks the DVA  label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'Saftey Net')]"), "Saftey Net");//checks the Saftey Net  label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'Health Fund')]"), "Health Fund");//checks the Health Fund   label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'Next of Kin')]"), "Next of Kin");//checks the Next of Kin label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'Alerts')]"), "Alerts");//checks the Alerts label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'Reactions')]"), "Reactions");//checks the Reactions label
            //GenericHelper.GetTextAndCompare(By.XPath("//strong[contains(text(),'DoB')]"),"DoB");//checks the date of birth label
            //GenericHelper.ComapreIfNull(By.CssSelector(".list-pf-container .row > div:nth-of-type(2)"));//checks MRN is populated with some data
            //GenericHelper.GetTextAndCompare(By.CssSelector(".list-pf-container .row > div:nth-of-type(3)"),"Sex sF");//checks mrn value is present
            



        }
    }
}
