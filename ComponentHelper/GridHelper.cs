using OpenQA.Selenium;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
   public class GridHelper
    {
        public static string GetTableXpath(string locator, int row, int col)//for col headers
        {
            return $"{locator}//thead/tr/td[" + col + "]/div/span[@class='pull-left']";
        }

        public static string GetTableBodyXpath(string locator, int row, int col)//for col data
        {
            return $"{locator}/tbody//div["+row+"]//td[" + col + "]/div[@class='form-inline']/span[1]";
        }

        public static string GetColValue(string @locator, int @row, int @col)
        {
            //    string tableSpath = GetTableXpath(locator, row, col);
            //    string value = string.Empty;

            //    if(GenericHelper.IsElementPresent(By.XPath(tableSpath)))
            //    {
            //        value = ObjectRepository.Driver.FindElement(By.XPath(tableSpath)).Text;

            //    }

            //    return value;

            //easier way to do than above
            return GetGridElement(locator,row,col).Text;    
        }

        ////not a very useful way of dealing
        //public static void GetAllValues(string @locator)
        //{
        //    var row = 1;
        //    var col = 2;//just in my example otherwse 1

        //    while(GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator,row,col))))
        //    {//iterates over row
        //        while(GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator, row, col))))
        //        {//iterates over col
        //            Console.WriteLine(GetColValue(locator, row, col));
        //            col++;
        //        }
        //        row++;
        //        col=1;//for every row the col idex will strt at 1

        //    }

        //}

        public static IList<string> GetAllValues(string @locator)
        {
            IList<string> list = new List<string>();
            var row = 1;
            var col = 2;//just in my example otherwse 1

            while (GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator, row, col))))
            {//iterates over row
                while (GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator, row, col))))
                {//iterates over col
                    list.Add(GetColValue(locator,row,col)) ;
                        col++;
                }
                row++;
                col = 1;//for every row the col idex will strt at 1

            }
            return list;

        }


        public static void ClickLinkonGrid(string @locator, int @row, int @col)
        {
            GetGridElement(locator,row,col).Click();

        }


        public static IList<string> GetValues(string @locator, int column) // Column starts from 1; retrives vales from a aspecific coleumn
        {
            List<string> list = new List<string>();

            var row = 1;

            while (GenericHelper.IsElementPresent(By.XPath(GetTableXpath(locator, row, column))))
            {
                list.Add(ObjectRepository.Driver.FindElement(By.XPath(GetTableXpath(locator, row, column))).Text);
                row++;
            }
            return list;
        }



        private static IWebElement GetGridElement(string locator, int row, int col)
        {
            var xpath = GetTableBodyXpath(locator, row, col);//for body
            if (GenericHelper.IsElementPresent(By.XPath(xpath+"//span")))
            {
                return ObjectRepository.Driver.FindElement(By.XPath(xpath+"//span"));

            }
            else
            {
                return ObjectRepository.Driver.FindElement(By.XPath(xpath));
            }
        }
    }
}
