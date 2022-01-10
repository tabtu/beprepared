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
     * https://www.hackerrank.com/challenges/almost-sorted/
     * 
     * scan array, find increase/decrease point;
     * return yes if arr.Length == 2
     * 2 points or 4 points
     * - 2 (swap or reverse)
     * - 4 (reverse)
     * 
     * pointer location is the most diffcult part.
     * 
     * Complete the 'almostSorted' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void almostSorted(List<int> arr)
    {
        if (arr.Count == 2)
        {
            Console.WriteLine("yes");
            Console.WriteLine("swap 1 2");
            return;
        }
        int cur = 0;
        List<int> pos = new List<int>();
        for (int i = 0; i < arr.Count - 1; i++)
        {
            if (cur > 0 && arr[i + 1] - arr[i] < 0)
            {
                pos.Add(i);
                cur = -1;
            }
            else if (cur < 0 && arr[i + 1] - arr[i] > 0)
            {
                pos.Add(i);
                cur = 1;
            }
            else cur = arr[i + 1] - arr[i];
        }


        // foreach (int i in pos)
        // {
        //     Console.Write(i + " ");
        // }

        // Console.WriteLine();

        List<int> test;

        if (pos.Count == 4)
        {
            test = swap(arr, pos[0], pos[3]);
            if (isSorted(test) == true)
            {
                Console.WriteLine("yes");
                Console.WriteLine("swap " + pos[1].ToString() + " " + (pos[3] + 1).ToString());
                return;
            }
        }

        if (pos.Count == 2)
        {
            test = swap(arr, pos[0], pos[1]);
            if (isSorted(test) == true)
            {
                Console.WriteLine("yes");
                Console.WriteLine("swap " + (pos[0] + 1).ToString() + " " + (pos[1] + 1).ToString());
                return;
            }

            test = reverse(arr, pos[0], pos[1]);
            if (isSorted(test) == true)
            {
                Console.WriteLine("yes");
                Console.WriteLine("reverse " + (pos[0] + 1).ToString() + " " + (pos[1] + 1).ToString());
                return;
            }
        }

        Console.WriteLine("no");
    }


    private static List<int> swap(List<int> arr, int i, int j)
    {
        int tmp = arr[i];
        arr[i] = arr[j];
        arr[j] = tmp;
        return arr;
    }

    private static List<int> reverse(List<int> arr, int i, int j)
    {
        List<int> res = new List<int>();
        for (int k = 0; k < arr.Count; k++)
        {
            if (k <= i) res.Add(arr[k]);
            else if (k >= j) res.Add(arr[k]);
            else
            {
                res.Add(arr[j - k + i]);
            }
        }
        return res;
    }

    private static bool isSorted(List<int> arr)
    {
        for (int i = 0; i < arr.Count - 1; i++)
        {
            if (arr[i] > arr[i + 1]) return false;
        }
        return true;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.almostSorted(arr);
    }
}
