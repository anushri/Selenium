using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.Hyperlink
{
    [TestClass]
     public class TestHyperLink
    {

        [TestMethod]
        public void ClickLink()
        {
            //using link text
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            //IWebElement map = ObjectRepository.Driver.FindElement(By.LinkText("Map"));
            //map.Click();

            //OR

            //using partiallink text
            //NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            //IWebElement P_map = ObjectRepository.Driver.FindElement(By.PartialLinkText("ap"));
            //P_map.Click();

            //instead of the above lines we can use below code as we have created helper classes of all webelemest
            //can use partial link text mechanism as well
            LinkHelper.ClickLink(By.LinkText("Map"));
        }
    }
}
