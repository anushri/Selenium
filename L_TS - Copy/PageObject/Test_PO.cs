using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumProject.ComponentHelper;
using SeleniumProject.PageObject;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.PageObject
{
    [TestClass]
    public class Test_PO
    {
        [TestMethod]
        public void TestPage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePage homePage = new HomePage();
            homePage.QuickSearch("Sydney", "Darwin");
            MapPage mapPage = homePage.NavigatetoMap();//you need to equate the detaination page to the initiating page
            mapPage.SearchandReturn("Sydney","3");
            
                
        }

    }
}
