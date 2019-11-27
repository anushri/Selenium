using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.Dropdown
{
    [TestClass]
    public class TestDropdown
    {

        [TestMethod]
        public void TestDropdownList()
        {
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ButtonHelper.ClickButton(By.XPath("//*[@id='culture-info']/button/div"));
            //IWebElement elemet = ObjectRepository.Driver.FindElement(By.Id("culture-selector-locale"));
            //SelectElement select = new SelectElement(elemet);
            //select.SelectByIndex(2);
            //select.SelectByValue("el-GR"); //this works only when the value attribute is populated in the html
            //select.SelectByText("English (United States)");
            //Console.WriteLine("Selected value : {0}", select.SelectedOption.Text);
            //IList<IWebElement> list = select.Options;
            //foreach (IWebElement item in list)
            //{
            //    Console.WriteLine("Value: {0}, Text :{1}", item.GetAttribute("value"), item.Text);

            //}

            ComboboxHelper.SelectElement(By.Id("culture-selector-locale"),4);
            ComboboxHelper.SelectElement(By.Id("culture-selector-locale"), "el-GR");
            foreach (string item in ComboboxHelper.GetAllItem(By.Id("culture-selector-locale")))
            {
                Console.WriteLine("Text: {0}", item);


            }


        }

    }
}
