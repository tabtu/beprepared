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
     * https://www.hackerrank.com/challenges/picking-numbers
     * 
     * 
     * 
     * Complete the 'pickingNumbers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int pickingNumbers(List<int> a)
    {
        IList<int> dist = a.ToList();
        dist.Distinct();
        int sum = 0;
        for (int i = 0; i < dist.Count; i++)
        {
            int round0 = 0;
            int round1 = 0;
            for (int j = 0; j < a.Count; j++)
            {
                if (Math.Abs(a[j] - dist[i]) <= 1 && a[j] >= dist[i]) round0++;
                if (Math.Abs(a[j] - dist[i]) <= 1 && a[j] <= dist[i]) round1++;
            }
            int round = Math.Max(round0, round1);
            if (sum < round) { sum = round; }
        }
        return sum;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.pickingNumbers(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
