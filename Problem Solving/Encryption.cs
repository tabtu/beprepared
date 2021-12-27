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
     * https://www.hackerrank.com/challenges/encryption
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        double sqrt = Math.Sqrt(s.Length);
        int col = (int)sqrt;
        if ((int)(sqrt * 10) % 10 != 0) col++;
        int row = (int)s.Length / col;
        if(s.Length > row * col) row++;
        int xyz = s.Length % col;
        Console.WriteLine(s.Length + " --- " + row + " : " + col + " : " + xyz);
        
        string result = "";
        for(int i = 0; i < col; i++)
        {
            string tr = "";
            for(int j = 0; j < row; j++)
            {
                if (j * col + i < s.Length)
                {
                    tr += s[j * col + i];
                }
            }
            result += tr + " ";
        }
        result = result.Substring(0, result.Length - 1);
        Console.WriteLine(result);
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
