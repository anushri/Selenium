using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
    public class ExcelReaderHelper
    {
        private static IDictionary<string,IExcelDataReader> _cache;
        private static FileStream stream;
        private static IExcelDataReader reader;


        static ExcelReaderHelper()
        {
            _cache = new Dictionary<string, IExcelDataReader>();
        }//adding it to cache makes the data driving much faster
       
        
        public static object GetCellData(string xlpath, string sheetName, int row, int column) //obj is the return type of the data in the excel file
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
            return GetData(table.Rows[row][column].GetType(), table.Rows[row][column]);
        }

        //type class gives us detail about the object type which we are retriving from the excel
        private static object GetData(Type type, object data)
        {//based on the data type returns us the tpe of object
            switch(type.Name)
            {
                case "String":
                    return data.ToString();
                case "Double":
                    return Convert.ToDouble(data);
                case "DateTime":
                    return Convert.ToDateTime(data);
                default:
                    return data.ToString();
            
            }
        }



    }
}
