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
     * https://www.hackerrank.com/challenges/short-palindrome
     * 
     * 
     * 
     * Complete the 'shortPalindrome' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int shortPalindrome(string s)
    {
        long mod = 1000000007;
        long[] C1 = new long[26];
        long[] C2 = new long[26 * 26];
        long[] C3 = new long[26 * 26 * 26];
        long count = 0;
        foreach (char c in s)
        {
            int k = c - 97;
            long p = 26 * k - 1;
            int q = k - 26;
            for (int i = 0; i < 26; i++)
            {
                q += 26;
                p += 1;
                count += C3[q];
                C3[p] += C2[p];
                C2[p] += C1[i];
            }
            C1[k] += 1;
        }
        return (int)(count % mod);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = Result.shortPalindrome(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
