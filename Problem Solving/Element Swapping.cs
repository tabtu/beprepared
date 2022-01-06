/*
 * Element Swapping
 * Given a sequence of n integers arr, determine the lexicographically smallest sequence which may be obtained from it after performing at most k element swaps, each involving a pair of consecutive elements in the sequence.
 * Note: A list x is lexicographically smaller than a different equal-length list y if and only if, for the earliest index at which the two lists differ, x's element at that index is smaller than y's element at that index.
 * Signature
 * int[] findMinArray(int[] arr, int k)
 * Input
 * n is in the range [1, 1000].
 * Each element of arr is in the range [1, 1,000,000].
 * k is in the range [1, 1000].
 * Output
 * Return an array of n integers output, the lexicographically smallest sequence achievable after at most k swaps.
 * Example 1
 * n = 3
 * k = 2
 * arr = [5, 3, 1]
 * output = [1, 5, 3]
 * We can swap the 2nd and 3rd elements, followed by the 1st and 2nd elements, to end up with the sequence [1, 5, 3]. This is the lexicographically smallest sequence achievable after at most 2 swaps.
 * Example 2
 * n = 5
 * k = 3
 * arr = [8, 9, 11, 2, 1]
 * output = [2, 8, 9, 11, 1]
 * We can swap [11, 2], followed by [9, 2], then [8, 2].
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
class Element_Swapping
{
    static void Main(string[] args)
    {
        // Call findMinArray() with test cases here

        int[] arr = { 8, 9, 11, 2, 1 };
        int k = 3;
        arr = findMinArray(arr, k);
        foreach (int i in arr)
        {
            Console.Write(i + " ");
        }
    }

    private static int[] findMinArray(int[] arr, int k)
    {
        // Write your code here
        int i = 0;
        while (k > 0 && i < arr.Length)
        {
            if (i >= 0 && arr[i] > arr[i + 1])
            {
                arr = swap(arr, i, i + 1);
                k--;
                i--;
            }
            else
            {
                i++;
            }
        }
        return arr;
    }

    private static int[] swap(int[] arr, int i, int j)
    {
        if (i != j && i >= 0 && i < arr.Length && j >= 0 && j < arr.Length)
        {
            int tmp = arr[i];
            arr[i] = arr[j];
            arr[j] = arr[i];
        }
        return arr;
    }
}