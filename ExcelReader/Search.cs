using ExcelDataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.IO;

namespace SeleniumProject.ExcelReader
{

//    System.IO.FileNotFoundException
//  HResult = 0x80070002
//  Message=Could not find file 'C:\Users\anushri.mundada\source\repos\SeleniumProject\TestData\FlightSearch.xlsx;'.
//  Source=<Cannot evaluate the exception source>
//  StackTrace:
//<Cannot evaluate the exception stack trace>


    //1. create obj of filestream which points to excel file
    //2. open excel using excelreaderfactory; it consiers sheets in the form of table
    //3. use asdataset().tables[sheetname] that returns data in form of table
    //4. use rows[rowindex][colindex] to read
    [TestClass]
    public class Search
    {
        [TestMethod]
        public void TestReadExcel()
        {
            FileStream stream = new FileStream(@"C:\Users\anushri.mundada\source\repos\SeleniumProject\TestData\FlightSearch.xlsx", FileMode.Open, FileAccess.Read);
            IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(stream);//returns Iexceldata reader var is returned
            DataTable table = reader.AsDataSet().Tables["Search"];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                var origin_for = table.Rows[i];
                for (int j = 0; j < origin_for.ItemArray.Length; j++)
                {

                    Console.WriteLine("Data : {0}", origin_for.ItemArray[j]);
                }
                Console.WriteLine();

            }



        }
    }
}
