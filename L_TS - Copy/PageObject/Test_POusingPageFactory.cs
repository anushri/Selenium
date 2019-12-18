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
    public class Test_POusingPageFactory
    {
        [TestMethod]
        public void TestPage()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            HomePageUsingPageFactory homePage = new HomePageUsingPageFactory();
            //homePage.QuickSearch("Sydney","Tokyo");
            MapPageUsingPafeFactory mapPage = homePage.NavigatetoMap();
            mapPage.SearchandReturn("Sydney",3);
            
                
        }

    }
}
