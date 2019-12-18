using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts
{
    [TestClass]
    public class TestCheckbox
    {
        [TestMethod]
        public void TestCheckox()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.XPath("//*[@id='authentication-link' and @class='login']"));
            LinkHelper.ClickLink(By.XPath("//div[@class='Qk3sp3k23b-uqHOY6J1-E']"));
            TextboxHelper.TypeInTextbox(By.XPath("//*[@id='email']"), ObjectRepository.Config.GetUserName());
            TextboxHelper.TypeInTextbox(By.XPath("//*[@id='password']"), ObjectRepository.Config.GetPassword());
            //IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//*[@class='_2gszK83qNMGLVmjY81wTD-']"));
            //ele.Click();
            Console.WriteLine(CheckboxHelper.IsCheckboxchecked(By.XPath("//*[@class='_2gszK83qNMGLVmjY81wTD-']")));
            CheckboxHelper.CheckedCheckbox(By.XPath("//*[@class='_2gszK83qNMGLVmjY81wTD-']"));
            Console.WriteLine(CheckboxHelper.IsCheckboxchecked(By.XPath("//*[@class='_2gszK83qNMGLVmjY81wTD-']")));
        }
    }
}
