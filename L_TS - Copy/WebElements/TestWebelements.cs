using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using System.Collections.ObjectModel;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.TestScripts.WebElements
{
    [TestClass]
   public class TestWebelements
    {
        [TestMethod]
        public void GetElement()
        {
            //open the webpage
            NavigationHelper.NavigateToUrl(ObjectRepository.Config.GetWebsite());


            //all themetods are static in the By class so we need to use the classname to use them
            try
            {
                //returns single element

                //ObjectRepository.Driver.FindElement(By.TagName("input"));
                //ObjectRepository.Driver.FindElement(By.ClassName("CultureSelectorButton_CultureSelectorButton__labels__QT4Rk"));
                //ObjectRepository.Driver.FindElement(By.CssSelector("#fsc-origin-search"));
                //ObjectRepository.Driver.FindElement(By.LinkText("Add nearby airports"));
                //ObjectRepository.Driver.FindElement(By.PartialLinkText("Add"));
                //ObjectRepository.Driver.FindElement(By.Name("trip-type-selector"));
                //ObjectRepository.Driver.FindElement(By.Id("fsc-destination-search"));
                //ObjectRepository.Driver.FindElement(By.XPath("//span[@class='login']"));

                //returns a list of elements
                //    IList<string> list = new List<string>();
                //    list.Add("Task 1");
                //    list.Add("Task 2");
                //    list.Add("Task 3");
                //    //gives size of list
                //    Console.WriteLine("size: {0}", list.Count);
                //    list.Remove("Task 2");
                //    Console.WriteLine("size after removing: {0}", list.Count);
                //    Console.WriteLine("List second element value : {0}", list[1]);
                //    list.Clear();
                //    Console.WriteLine("size: {0}", list.Count);

                ReadOnlyCollection<IWebElement> coll = ObjectRepository.Driver.FindElements(By.TagName("input"));
                Console.WriteLine("size: {0}", coll.Count);
                Console.WriteLine("size: {0}", coll.ElementAt(1));




            }
            catch (NoSuchElementException e)
            {

                Console.WriteLine(e);
            }

        }
    }
}
