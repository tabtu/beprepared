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
     * https://www.hackerrank.com/challenges/absolute-permutation
     * Complete the 'absolutePermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     */

    public static List<int> absolutePermutation(int n, int k)
    {
        int[] err = { -1 };
        List<int> arr = new List<int>();
        for (int i = 0; i < n; i++)
        {
            arr.Add(i+1);
        }
        if (k == 0) return arr;
        if (n < 3 && k < 2)
        {
            arr.RemoveAt(0);
            arr.Add(1);
            return arr;
        }
        if (k < n && n > 3)
        {
            List<int> arr0 = new List<int>();
            List<int> arr1 = new List<int>();
            for (int i = 0; i < n; i++)
            {
                if (i < k)
                {
                    arr0.Add(arr[i]);
                }
                else
                {
                    arr1.Add(arr[i]);
                }
            }
            if (Math.Abs(arr0.Last() - arr.Last()) != k) return err.ToList();
            return arr1.Union(arr0).ToList();
        }
        return err.ToList();
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

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> result = Result.absolutePermutation(n, k);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
