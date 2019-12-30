using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.L_TS
{
    [TestClass]
   public class TestTable
    {
        [TestMethod]
        public void TestGrid()
        {


            NavigationHelper.NavigateToUrl("http://support.charmhealth.com.au:492/login?returnUrl=%2F");
            TextboxHelper.TypeInTextbox(By.CssSelector("[formcontrolname='Username']"), "chadmin");
            TextboxHelper.TypeInTextbox(By.CssSelector("[formcontrolname='Password']"), "j06");
            ButtonHelper.ClickButton(By.CssSelector(".btn.btn-lg.btn-outline-primary"));
            //   Console.WriteLine(ObjectRepository.Driver.FindElement(By.XPath("//infinite-scroll-table[@name='pathway_diary']//infinite-scroll-table-inner/table/tbody/div[1]/tr[@class='ng-star-inserted']/td[2]/div[@class='form-inline']")).Text);

            //for (int row = 2; row < 2; row++)//if i wanted to print the detail sof the srid as in all rows data as well..
            //{
            //for (int col = 2; col < 14; col++)//prints only the col headers
            //    {
            //        String xpath = "//infinite-scroll-table[@name='pathway_diary']//table[@class='infinite-table flex ng-star-inserted']//thead/tr/td["+col+"]/div/span[@class='pull-left']";
            //        Console.WriteLine(xpath);
            //        Console.WriteLine(ObjectRepository.Driver.FindElement(By.XPath(xpath)).Text);


            //    }

            ////}
            ///

            // works-- Console.WriteLine(GridHelper.GetColValue("//infinite-scroll-table[@name='pathway_diary']//infinite-scroll-table-inner", 1, 2));
            //  GridHelper.GetAllValues("//infinite-scroll-table[@name='pathway_diary']//infinite-scroll-table-inner");



            /*
            IList<string> data = GridHelper.GetAllValues("//infinite-scroll-table[@name='pathway_diary']//infinite-scroll-table-inner");
            foreach (var str in data)
            {
                Console.WriteLine(str);

            }*/

            GridHelper.ClickLinkonGrid("//infinite-scroll-table[@name='pathway_diary']//infinite-scroll-table-inner/table",2,2);



        }
    }   
}
