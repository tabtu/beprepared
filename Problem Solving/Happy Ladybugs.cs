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
     * https://www.hackerrank.com/challenges/happy-ladybugs
     * 
     * 
     * 
     * Complete the 'happyLadybugs' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING b as parameter.
     */

    public static string happyLadybugs(string b)
    {
        if (b.Count() == 0) return "NO";
        if (b.Count() == 1 && b[0] != '_') return "NO";
        char[] s = b.ToArray();
        if (b.Contains('_')) Array.Sort(s);
        for (int i = 0; i < s.Count(); i++)
        {
            if (i == 0)
            {
                if (s[i] != '_' && s[i + 1] != s[i]) return "NO";
            }
            else if (i == s.Count() - 1)
            {
                if (s[i] != '_' && s[i - 1] != s[i]) return "NO";
            }
            else
            {
                if (s[i - 1] != s[i] && s[i + 1] != s[i]) return "NO";
            }
        }
        return "YES";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string b = Console.ReadLine();

            string result = Result.happyLadybugs(b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
