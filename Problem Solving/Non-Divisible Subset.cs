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
     * https://www.hackerrank.com/challenges/non-divisible-subset
     * 
     * 
     * 
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */
    public static int nonDivisibleSubset(int k, List<int> s)
    {
        int count = 0;
        Dictionary<int, int> clst = new Dictionary<int, int>();
        foreach (int ss in s)
        {
            int c = ss % k;
            int tmp;
            bool rd = clst.TryGetValue(c, out tmp);
            if (rd == true)
            {
                clst.Remove(c);
                clst.Add(c, tmp + 1);
            }
            else
            {
                clst.Add(c, 1);
            }
        }
        clst = (from st in clst orderby st.Value descending select st).ToDictionary(item => item.Key, item => item.Value);
        List<int> hs = new List<int>();
        foreach (KeyValuePair<int, int> kvp in clst)
        {
            if ((k % 2 == 0 && kvp.Key == k / 2) || kvp.Key == 0)
            {
                count++;
            }
            else if (!hs.Contains(k - kvp.Key))
            {
                count += kvp.Value;
                hs.Add(kvp.Key);
            }
            else
            {

            }
        }
        return count;
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

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Result.nonDivisibleSubset(k, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
