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
     * https://www.hackerrank.com/challenges/countingsort4
     * Complete the 'countSort' function below.
     *
     * The function accepts 2D_STRING_ARRAY arr as parameter.
     */

    public static void countSort(List<List<string>> arr)
    {
        arr[0][1] = "-";
        for (int i = 1; i < arr.Count; i++)
        {
            if (i < arr.Count / 2) { arr[i][1] = "-"; }
            List<string> item = arr[i];
            int j = i - 1;
            while (j >= 0 && int.Parse(item[0]) < int.Parse(arr[j][0]))
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = item;
        }
        string result = "";
        foreach (List<string> ls in arr)
        {
            result += ls[1] + " ";
        }
        Console.WriteLine(result);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<string>> arr = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        }

        Result.countSort(arr);
    }
}
