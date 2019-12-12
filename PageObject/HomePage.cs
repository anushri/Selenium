using OpenQA.Selenium;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageObject
{

    //mapping class for homepage
    public class HomePage
    {
        #region Webelement
        private By Origin = By.Id("fsc-origin-search");
        private By Destination = By.Id("fsc-destination-search");
        private By SearchButton = By.XPath("//*[@id='flights-search-controls-root']/div/div/form/div[3]/button");
        private By MapLink = By.LinkText("Map");

        #endregion

        #region Action

        public void QuickSearch(string origin, string destination)
        {

            ObjectRepository.Driver.FindElement(Origin).SendKeys(origin);
            ObjectRepository.Driver.FindElement(Destination).SendKeys(destination);
            ObjectRepository.Driver.FindElement(SearchButton).Click();
        }
        #endregion

        #region Navigation
        
        public MapPage NavigatetoMap()
        {
            ObjectRepository.Driver.FindElement(MapLink).Click();
            return new MapPage(); //the navigate to map takes us to the mappage i.e it returns a type of object of the mappage

        }
        #endregion
    }
}
