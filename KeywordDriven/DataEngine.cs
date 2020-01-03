using OpenQA.Selenium;
using SeleniumProject.ComponentHelper;
using SeleniumProject.CustomException;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.KeywordDriven
{
   public class DataEngine
    {
        private readonly int _keywordCol;
        private readonly int _locatorTypeCol;
        private readonly int _locatorValueCol;
        private readonly int _parameterCol;



        public DataEngine(int keywordCol = 2, int locatorTypeCol = 3, int locatorValueCol = 4, int parameterCol = 5)
        {//initialising these variables
            this._keywordCol = keywordCol;//points to the var and initialse with the value supplied
            this._locatorTypeCol = locatorTypeCol;
            this._locatorValueCol = locatorValueCol;
            this._parameterCol = parameterCol;
        }

        //return type is BY as it helps to create the locator
        private By GetElementLocator(string locatorType, string locatorValue)
        {
            switch (locatorType)
            {
                case "ClassName":
                    return By.ClassName(locatorValue);
                case "CssSelector":
                    return By.CssSelector(locatorValue);
                case "Id":
                    return By.Id(locatorValue);
                case "PartialLinkText":
                    return By.PartialLinkText(locatorValue);
                case "Name":
                    return By.Name(locatorValue);
                case "XPath":
                    return By.XPath(locatorValue);
                case "TagName":
                    return By.TagName(locatorValue);
                default:
                    return By.Id(locatorValue);
            }
        }
        //last param means  parameter with variable length
        public void PerformAction(string keyword, string locatorType, string locatorValue, params string[] args)
        {
            try
            {
                switch (keyword)
                {
                    case "Quit":
                        ObjectRepository.Driver.Close();
                        ObjectRepository.Driver.Quit();
                        break;

                    case "Startup":
                        BaseClass.BaseClass.Startup();
                        break;

                    case "Click":
                        ButtonHelper.ClickButton(GetElementLocator(locatorType, locatorValue));
                        break;
                    case "SendKeys":
                        TextboxHelper.TypeInTextbox(GetElementLocator(locatorType, locatorValue), args[0]);
                        break;
                    case "Select":
                        ComboboxHelper.SelectElement(GetElementLocator(locatorType, locatorValue), args[0]);
                        break;
                    case "WaitForElement":
                        GenericHelper.WaitforWebElementInPage(GetElementLocator(locatorType, locatorValue),
                            TimeSpan.FromSeconds(50));
                        break;
                    case "Navigate":
                        NavigationHelper.NavigateToUrl(args[0]);
                        break;
                    case "GetLinkText":
                        ButtonHelper.GetButtonText(GetElementLocator(locatorType, locatorValue));
                        break;
                    case "GetField_Text":
                        ButtonHelper.GetButtonText_alt(GetElementLocator(locatorType, locatorValue));
                        break;

                    case "Compare":
                        GenericHelper.GetTextAndCompare(GetElementLocator(locatorType, locatorValue), args[0]);
                        break;

                    case "CheckWhetherPopulated":
                        GenericHelper.ComapreIfNull(GetElementLocator(locatorType, locatorValue));
                        break;

                    case "IsElementPresesnt":
                        GenericHelper.GetElement(GetElementLocator(locatorType, locatorValue));
                        break;

                    case "IsButtonEnabled":
                        ButtonHelper.GetButton_Enabled(GetElementLocator(locatorType, locatorValue));
                        break;

                    case "ClearText":
                        TextboxHelper.ClearTextBody(GetElementLocator(locatorType, locatorValue));
                        break;

                    case "StringSearch":
                        GenericHelper.StringSearch(GetElementLocator(locatorType, locatorValue), args[0]);
                        break;

                    default:
                        throw new NoSuchKeywordFoundException("Keyword Not Found : " + keyword);
                }
            } catch (Exception e)
            {
                Console.Write("Something went wrong: Keyword" + keyword + ", locator: " + locatorType);
            }
        }

        public void ExecuteScript(string xlPath, string sheetName)
        {
            int totalRows = ExcelReaderHelper_KD.GeTotalRows(xlPath, sheetName);
            for (int i = 1; i < totalRows; i++)
            {
                var lctType = ExcelReaderHelper_KD.GetCellData(xlPath, sheetName, i, _locatorTypeCol).ToString();
                var lctValue = ExcelReaderHelper_KD.GetCellData(xlPath, sheetName, i, _locatorValueCol).ToString();
                var keyword = ExcelReaderHelper_KD.GetCellData(xlPath, sheetName, i, _keywordCol).ToString();
                var param = ExcelReaderHelper_KD.GetCellData(xlPath, sheetName, i, _parameterCol).ToString();
                PerformAction(keyword, lctType, lctValue, param);
            }
        }

    }
}
