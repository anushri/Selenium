using OpenQA.Selenium;
using SeleniumProject.Settings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.ComponentHelper
{
    public class BrowserHelper
    {
        public static void BroswerMaximise()
        {
            ObjectRepository.Driver.Manage().Window.Maximize();
        }

        public static void GoBack()
        {
            ObjectRepository.Driver.Navigate().Back();
        }

        public static void GoForward()
        {
            ObjectRepository.Driver.Navigate().Forward();
        }
        public static void GoRefresh()
        {
            ObjectRepository.Driver.Navigate().Refresh();
        }

        public static void SwitchToWindow(int index=0)//def 0 as it will be pointing to the parent window
        {

            ReadOnlyCollection<string> windows = ObjectRepository.Driver.WindowHandles;
            BroswerMaximise(); 
            if (windows.Count<index)//suppose there are only 4 browser windows and user is supplying index as 5 tehn its wrong and this will alert the user
            {
                throw new NoSuchWindowException("Invald browser window index"+ index);

            }
            ObjectRepository.Driver.SwitchTo().Window(windows[index]);
            BroswerMaximise();
        }

        public static void SwitchToParent()
        {
            var windowIds = ObjectRepository.Driver.WindowHandles;

            for (int i = windowIds.Count-1; i >0;)
            {
                ObjectRepository.Driver.Close();
                i = i - 1;
                ObjectRepository.Driver.SwitchTo().Window(windowIds[i]);
            }
            ObjectRepository.Driver.SwitchTo().Window(windowIds[0]);

        }

        public static void SwitchToFrame(By locator)
        {
            ObjectRepository.Driver.SwitchTo().Frame(ObjectRepository.Driver.FindElement(locator));
        }



        public static Boolean MatchWildcardString(String pattern, String input)
        {
            if (String.Compare(pattern, input) == 0)
            {
                return true;
            }
            else if (String.IsNullOrEmpty(input))
            {
                if (String.IsNullOrEmpty(pattern.Trim(new Char[1] { '*' })))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (pattern.Length == 0)
            {
                return false;
            }
            else if (pattern[0] == '?')
            {
                return MatchWildcardString(pattern.Substring(1), input.Substring(1));
            }
            else if (pattern[pattern.Length - 1] == '?')
            {
                return MatchWildcardString(pattern.Substring(0, pattern.Length - 1),
                                           input.Substring(0, input.Length - 1));
            }
            else if (pattern[0] == '*')
            {
                if (MatchWildcardString(pattern.Substring(1), input))
                {
                    return true;
                }
                else
                {
                    return MatchWildcardString(pattern, input.Substring(1));
                }
            }
            else if (pattern[pattern.Length - 1] == '*')
            {
                if (MatchWildcardString(pattern.Substring(0, pattern.Length - 1), input))
                {
                    return true;
                }
                else
                {
                    return MatchWildcardString(pattern, input.Substring(0, input.Length - 1));
                }
            }
            else if (pattern[0] == input[0])
            {
                return MatchWildcardString(pattern.Substring(1), input.Substring(1));
            }
            return false;

        }

    }
}
