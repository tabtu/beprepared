using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * https://www.hackerrank.com/challenges/the-time-in-words
     * 
     * 
     * 
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
    {
        if (m == 0)
        {
            return number2English(h) + " o' clock";
        }
        if (m == 30)
        {
            return "half past " + number2English(h);
        }
        else if (m > 30)
        {
            h += 1;
            if (m % 15 == 0)
            {
                return "quarter to " + number2English(h);
            }
            else
            {
                if (m == 59) return "one minute to " + number2English(h);
                else return number2English(60 - m) + " minutes to " + number2English(h);
            }
        }
        else
        {
            if (m % 15 == 0)
            {
                return "quarter past " + number2English(h);
            }
            else
            {
                if (m == 1) return "one minute past " + number2English(h);
                else return number2English(m) + " minutes past " + number2English(h);
            }
        }
    }

    public static string number2English(int number)
    {
        if (number < 20)  //0 ~ 19
        {
            switch (number)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                case 10:
                    return "ten";
                case 11:
                    return "eleven";
                case 12:
                    return "twelve";
                case 13:
                    return "thirteen";
                case 14:
                    return "fourteen";
                case 15:
                    return "fifteen";
                case 16:
                    return "sixteen";
                case 17:
                    return "seventeen";
                case 18:
                    return "eighteen";
                case 19:
                    return "nineteen";
                default:
                    return "";
            }
        }
        else if (number < 60) // 20 ~ 59
        {
            if (number % 10 == 0)
            {
                switch (number)
                {
                    case 20:
                        return "twenty";
                    case 30:
                        return "thirty";
                    case 40:
                        return "forty";
                    case 50:
                        return "fifty";
                    default:
                        return "";
                }
            }
            else
            {
                return string.Format("{0} {1}", number2English(10 * (number / 10)),
                    number2English(number % 10));
            }
        }
        else
        {
            return "";
        }
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
