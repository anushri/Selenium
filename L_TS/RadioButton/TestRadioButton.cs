using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.RadioButton
{
    [TestClass]
    public class TestRadioButton
    {
      
        [TestMethod]
        public void TestRadio()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            Console.WriteLine("Return buttons status is :{0}", RadioButtonHelper.IsRadioButtonchecked(By.Id("fsc-trip-type-selector-return")));
            Console.WriteLine("Return buttons text is :{0}", RadioButtonHelper.GetRadioButtonText(By.XPath("//*[@id='flights-search-controls-root']/div/div/form/div[1]/div/label[1]/span")));
 
            RadioButtonHelper.ClickRadioButton(By.Id("fsc-trip-type-selector-one-way"));
            //IWebElement ele = ObjectRepository.Driver.FindElement(By.Id("fsc-trip-type-selector-one-way"));
            //ele.Click();
            LinkHelper.ClickLink(By.XPath("//*[@id='authentication-link' and @class='login']"));
            LinkHelper.ClickLink(By.XPath("//div[@class='Qk3sp3k23b-uqHOY6J1-E']"));
            TextboxHelper.TypeInTextbox(By.XPath("//*[@id='email']"), ObjectRepository.Config.GetUserName());
            TextboxHelper.TypeInTextbox(By.XPath("//*[@id='password']"), ObjectRepository.Config.GetPassword());
            Console.WriteLine("Enabled : {0}", ButtonHelper.IsButonEnabled(By.XPath("//*[@class='bpk-button-IZE-J ProgressionButton__button-3U-H6']")));
            ButtonHelper.ClickButton(By.XPath("//*[@class='bpk-button-IZE-J ProgressionButton__button-3U-H6']"));

        }

    }
}
