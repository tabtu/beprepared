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
     * https://www.hackerrank.com/challenges/append-and-delete
     * 
     * 
     * 
     * Complete the 'appendAndDelete' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. STRING t
     *  3. INTEGER k
     */

    public static string appendAndDelete(string s, string t, int k)
    {
        int c = 0;
        int n = s.Length;
        if (t.Length < s.Length) { n = t.Length; }
        while(c < n) {
            if (s[c] == t[c]) c++;
            else break;
        }
        if (c == 0)
        {
            if (k >= s.Length + t.Length) return "Yes";
        }
        else
        {
            int ext = k - s.Length + c - t.Length + c;
            if (ext == 0) return "Yes";
            if (s.Length < t.Length && ext > 0 && ext % 2 == 0) return "Yes";
            if (s.Length >= t.Length && ext > 0) return "Yes";
        }
        return "No";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string t = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.appendAndDelete(s, t, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
