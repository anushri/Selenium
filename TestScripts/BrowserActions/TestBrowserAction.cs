using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.BrowserActions
{
    [TestClass]
    public class TestBrowserAction
    {

        [TestMethod]
        public void TestAction()
        {
            NavigationHelper.NavigateToUrl("https://google.com");
            //ObjectRepository.Driver.Manage().Window.Maximize();
            //ObjectRepository.Driver.Navigate().Forward();
            //ObjectRepository.Driver.Navigate().Back();
            //ObjectRepository.Driver.Navigate().Refresh();

            BrowserHelper.GoBack();
            BrowserHelper.GoForward();
            BrowserHelper.GoRefresh();
        }
    }
}
