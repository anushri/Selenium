using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ExcelReader
{
    public class ExcelReader
    {
        private static IDictionary<string,IExcelDataReader> _cache;
        private static FileStream stream;
        private static IExcelDataReader reader;


        static ExcelReader()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }
        public static string GetCellData(string xlpath, string sheetName, int row, int column) //for stringtype data in the excel file
        {
            if (_cache.ContainsKey(sheetName))
            {

                reader = _cache[sheetName];//returns obj of type reader
            }
            else
            {
                stream = new FileStream(xlpath,FileMode.Open,FileAccess.Read);
                //returns Iexcelreaderobject
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                _cache.Add(sheetName,reader);
            }

            DataTable table = reader.AsDataSet().Tables[sheetName];
            return table.Rows[row][column].ToString();
        }



    }
}
