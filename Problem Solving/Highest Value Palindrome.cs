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
     * https://www.hackerrank.com/challenges/richie-rich
     * 
     * 
     * 
     * Complete the 'highestValuePalindrome' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER n
     *  3. INTEGER k
     */

    public static string highestValuePalindrome(string s, int n, int k)
    {
        char[] ss = s.ToArray();
        List<int> pos = new List<int>();
        for (int i = 0; i < n / 2; i++)
        {
            if (s[i] != s[n - 1 - i]) pos.Add(i);
        }
        if (pos.Count > k) return "-1";
        for (int i = 0; i < pos.Count; i++)
        {
            char a = s[pos[i]];
            char b = s[n - 1 - pos[i]];
            if (a < b) ss[pos[i]] = s[n - 1 - pos[i]];
            else ss[n - 1 - pos[i]] = s[pos[i]];
        }
        int rest = k - pos.Count;
        int cur = 0;
        while (rest > 1 && cur < n / 2)
        {
            if (ss[cur] != '9')
            {
                ss[cur] = '9';
                ss[n - 1 - cur] = '9';
                if (pos.IndexOf(cur) >= 0) rest -= 1;
                else rest -= 2;
            }
            cur++;
        }
        while (rest > 0 && cur < n / 2)
        {
            if (ss[cur] != '9' && pos.IndexOf(cur) >= 0)
            {
                ss[cur] = '9';
                ss[n - 1 - cur] = '9';
                rest -= 1;
            }
            cur++;
        }
        if (rest > 0 && n % 2 == 1) ss[(n - 1) / 2] = '9';
        return new string(ss);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string s = Console.ReadLine();

        string result = Result.highestValuePalindrome(s, n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
