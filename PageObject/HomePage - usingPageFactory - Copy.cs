using OpenQA.Selenium;
using SeleniumProject.Settings;
using System;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageObject
{

    //mapping class for homepage
    public class HomePageUsingPageFactory
    {
        //inorder to intilise these elemenst we need to call methos-- init elements
        #region Webelement
        [FindsBy(How = How.Id,Using = "fsc-origin-search")]
        private IWebElement Origin;

        [FindsBy(How = How.Id, Using = "fsc-destination-search")]
        private IWebElement Destination;

        [FindsBy(How = How.XPath, Using = "//*[@id='flights-search-controls-root']/div/div/form/div[3]/button")]
        private IWebElement SearchButton;

        [FindsBy(How = How.LinkText, Using = "Map")]
        private IWebElement MapLink;

        #endregion

        public HomePageUsingPageFactory()//this initialses our webelements
        {
            //this constr initialises all the webelemnts
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        #region Action

        public void QuickSearch(string origin, string destination)
        {

            Origin.SendKeys(origin);
            Destination.SendKeys(destination);
            SearchButton.Click();
        }
        #endregion

        #region Navigation
        
        public MapPageUsingPafeFactory NavigatetoMap()
        {
            MapLink.Click();
            return new MapPageUsingPafeFactory(); //the navigate to map takes us to the mappage i.e it returns a type of object of the mappage

        }
        #endregion
    }
}
