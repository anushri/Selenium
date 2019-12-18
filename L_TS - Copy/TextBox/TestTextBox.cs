using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.TextBox
{
    [TestClass]
    public class TestTextBox
    {
        [TestMethod]
        public void TextBox()
        {

            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            LinkHelper.ClickLink(By.XPath("//*[@id='authentication-link' and @class='login']"));
            LinkHelper.ClickLink(By.XPath("//div[@class='Qk3sp3k23b-uqHOY6J1-E']"));
            //IWebElement ele = ObjectRepository.Driver.FindElement(By.XPath("//*[@id='email' and @type='email']"));
            //ele.SendKeys(ObjectRepository.Config.GetUserName());
            //ele = ObjectRepository.Driver.FindElement(By.XPath("//*[@id='password' and @type='password']"));
            //ele.SendKeys(ObjectRepository.Config.GetPassword());

            //when using helpers we will not write the above commented code and write the one mentioned below
            TextboxHelper.TypeInTextbox(By.XPath("//*[@id='email']"), ObjectRepository.Config.GetUserName());
            TextboxHelper.TypeInTextbox(By.XPath("//*[@id='password']"), ObjectRepository.Config.GetPassword());
           

        }
    }
}
