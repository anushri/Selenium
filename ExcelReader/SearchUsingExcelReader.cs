using ExcelDataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.IO;

namespace SeleniumProject.ExcelReader
{

    [TestClass]
    public class SearchUsingExcelReader
    {
        [TestMethod]
        public void TestReadExcel()
        {
            string xlPath = @"C:\Users\anushri.mundada\source\repos\SeleniumProject\TestData\FlightSearch.xlsx";
            Console.WriteLine(ExcelReader.GetCellData(xlPath, "Search", 2, 0));
            Console.WriteLine(ExcelReader.GetCellData(xlPath, "Search", 2, 1));

        }
    }
}
