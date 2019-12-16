using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;

namespace SeleniumProject.PageObject
{
    public class MapPageUsingPafeFactory
    {
        #region Webelement

        //[FindsBy(How = How.CssSelector, Using = "div#searchpanel  .origin > .input-wrapper > .origin-input.tt-input")]
        [FindsBy(How = How.CssSelector, Using = "div#searchpanel > .elevated.search-bar .input-wrapper .origin-input.tt-input")]
        private IWebElement Flying_from_txtbox;
        [FindsBy(How = How.CssSelector, Using = "div#identity")]
        private IWebElement BackTo_btn;
        [FindsBy(How = How.CssSelector, Using = "div#searchpanel > .elevated.search-bar .date-input.outbound-date")]
      
        private IWebElement Depart_date_cmb;
      

        #endregion

        public MapPageUsingPafeFactory()
        {
            PageFactory.InitElements(ObjectRepository.Driver, this);
        }

        #region Action
        public void SearchandReturn(string depart, int value1)
        {
            Flying_from_txtbox.Clear();
            TextboxHelper.ClearTextBody(Flying_from_txtbox);
            Flying_from_txtbox.SendKeys(depart);
  //          ComboboxHelper.SelectElement(Depart_date, value1);
            ComboboxHelper.SelectElement(Depart_date_cmb,value1);
        }

        #endregion
    }
}
