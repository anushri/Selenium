using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.FindElements
{
    [TestClass]
    public class HandleElements
    {
        [TestMethod]
        public void GetAllElements()
        {
            //gets a list of allelemst on webpage
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());
            ReadOnlyCollection<IWebElement> elements = ObjectRepository.Driver.FindElements(By.XPath("//input"));
            foreach (var item in elements)//var keyword sets the datatype of element based on the assignment in this case datatype of the item is iWebElement
            {

                Console.WriteLine("ID: {0}", item.GetAttribute("id"));
            }
        }
    }
}
