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
     * https://www.hackerrank.com/challenges/find-strings
     * 
     * 
     * 
     * Complete the 'findStrings' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING_ARRAY w
     *  2. INTEGER_ARRAY queries
     */

    public static List<string> findStrings(List<string> w, List<int> queries)
    {
        List<string> result = new List<string>();
        SortedSet<string> source = new SortedSet<string>();
        for (int i = 0; i < w.Count; i++)
        {
            foreach (char c in w[i])
            {
                string cp = c.ToString();
                source.Add(cp);
            }
            source.Add(w[i]);
            for (int j = 1; j < w[i].Length; j++)
            {
                for (int k = 0; k < w[i].Length - j; k++)
                {
                    string w0 = w[i].Substring(k, j);
                    source.Add(w0);
                    string w1 = w[i].Substring(k + j, w[i].Length - j - k);
                    source.Add(w1);
                }
            }
        }
        List<string> list = source.ToList();
        for (int i = 0; i < queries.Count; i++)
        {
            if (queries[i] > source.Count)
            {
                result.Add("INVALID");
            }
            else
            {
                result.Add(list[queries[i] - 1]);
            }
        }
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int wCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> w = new List<string>();

        for (int i = 0; i < wCount; i++)
        {
            string wItem = Console.ReadLine();
            w.Add(wItem);
        }

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> queries = new List<int>();

        for (int i = 0; i < queriesCount; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<string> result = Result.findStrings(w, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
