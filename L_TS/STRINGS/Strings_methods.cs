using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.L_TS.STRINGS
{
    public class Strings_methods
    {

        public void CompareStrings()
        {
            String matchSubString = "ababac";
            String inputABmC = (new String('A', 10000)) +
            (new String('B', 10000)) + matchSubString + (new String('C', 10000));
            String inputABm = (new String('A', 10000)) + (new String('B', 10000)) + matchSubString;
            String inputmBC = matchSubString + (new String('B', 10000)) + (new String('C', 10000));

            Assert.IsFalse(MatchWildcardString(matchSubString, inputABmC));
            Assert.IsFalse(MatchWildcardString(matchSubString + "*", inputABmC));
            Assert.IsFalse(MatchWildcardString("*" + matchSubString, inputABmC));
            Assert.IsTrue(MatchWildcardString("*" + matchSubString + "*", inputABmC));
            Assert.IsTrue(MatchWildcardString("*" + matchSubString, inputABm));
            Assert.IsTrue(MatchWildcardString(matchSubString + "*", inputmBC));
            Assert.IsTrue(MatchWildcardString(inputABmC, inputABmC));


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

