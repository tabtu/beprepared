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
     * https://www.hackerrank.com/challenges/the-grid-search
     * Complete the 'gridSearch' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING_ARRAY G
     *  2. STRING_ARRAY P
     */
    public static string gridSearch(List<string> G, List<string> P)
    {
        if (P == null || G == null) return "NO";
        List<int> list = new List<int>();
        for (int i = 0; i < G.Count - P.Count + 1; i++)
        {
            int pos = G[i].IndexOf(P[0]);
            list.Clear();
            list.Add(pos);
            while (pos > -1)
            {
                if (pos >= G[i].Length) break;
                pos = G[i].IndexOf(P[0], pos + 1);
                if (pos > -1) list.Add(pos);
            }
            if (list[0] > -1)
            {
                for (int k = 0; k < list.Count; k++)
                {
                    for (int j = 1; j < P.Count; j++)
                    {
                        string t = G[i + j].Substring(list[k], P[j].Length);
                        if (t != P[j])
                        {
                            break;
                        }
                        if (j == P.Count - 1) return "YES";
                    }
                }
            }
        }
        return "NO";
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int R = Convert.ToInt32(firstMultipleInput[0]);

            int C = Convert.ToInt32(firstMultipleInput[1]);

            List<string> G = new List<string>();

            for (int i = 0; i < R; i++)
            {
                string GItem = Console.ReadLine();
                G.Add(GItem);
            }

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int r = Convert.ToInt32(secondMultipleInput[0]);

            int c = Convert.ToInt32(secondMultipleInput[1]);

            List<string> P = new List<string>();

            for (int i = 0; i < r; i++)
            {
                string PItem = Console.ReadLine();
                P.Add(PItem);
            }

            string result = Result.gridSearch(G, P);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
