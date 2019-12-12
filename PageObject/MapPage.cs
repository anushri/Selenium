using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;

namespace SeleniumProject.PageObject
{
    public class MapPage
    {
        #region Webelement

        private By Flying_from = By.CssSelector("div#searchpanel  .origin > .input-wrapper > .origin-input.tt-input");
        private By Depart_date = By.CssSelector("div#searchpanel > .elevated.search-bar .date-input.outbound-date");
        //private By Deprat = By.CssSelector("#searchpanel .depart [value='2020-02']");
        private By BackTo = By.CssSelector("div#identity");

        #endregion
        #region Action
        public void SearchandReturn(string depart, string value1)
        {
            
          TextboxHelper.ClearTextBody(Flying_from); ///>>>not clearing the text box
          ObjectRepository.Driver.FindElement(Flying_from).SendKeys(depart);
          ComboboxHelper.SelectElement(Depart_date, value1);

            //// SelectElement select = new SelectElement(Depart);
            ////select.SelectByIndex(2);
            ////select.SelectByValue("el-GR"); //this works only when the value attribute is populated in the html
            ////select.SelectByText("English (United States)");
            ////Console.WriteLine("Selected value : {0}", select.SelectedOption.Text);
            ////IList<IWebElement> list = select.Options;

            //ObjectRepository.Driver.FindElement(Deprt_new).SendKeys("gh");
            //ObjectRepository.Driver.FindElement(BackTo).Click();
        }

        #endregion
    }
}
