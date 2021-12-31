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
     * https://www.hackerrank.com/challenges/matrix-rotation-algo
     * 
     * - select circles in matrix;
     * - calculate next position;
     * - execute n<=m and n>m seperately;
     * 
     * 
     * Complete the 'matrixRotation' function below.
     *
     * The function accepts following parameters:
     *  1. 2D_INTEGER_ARRAY matrix
     *  2. INTEGER r
     */

    public static void matrixRotation(List<List<int>> matrix, int r)
    {
        int n = matrix.Count;
        int m = matrix[0].Count;
        int[,] result = new int[n, m];

        // always start from 0,0 in sub-matrix
        int sp = 0;
        // loop number of circles
        if (n <= m)  // height <= length
        {
            int n_m = m - n;
            for (int i = n; i > 0; i -= 2)
            {
                int j = i + n_m;
                int rd = 2 * (i + j - 2);
                int r0 = r % rd;
                for (int x = 0; x < i; x++)
                {
                    for (int y = 0; y < j; y++)
                    {
                        // find circle in a sub-matrix
                        if (x == 0 || x == i - 1 || y == 0 || y == j - 1)
                        {
                            // fix real location
                            var next = GetTargetLocation(x, y, i, j, r0);
                            result[next.Key + sp, next.Value + sp] = matrix[x + sp][y + sp];
                        }
                    }
                }
                sp++;
            }
        }
        else  // height > length
        {
            int n_m = n - m;
            for (int j = m; j > 0; j -= 2)
            {
                int i = j + n_m;
                int rd = 2 * (i + j - 2);
                int r0 = r % rd;
                for (int y = 0; y < j; y++)
                {

                    for (int x = 0; x < i; x++)
                    {
                        if (x == 0 || x == i - 1 || y == 0 || y == j - 1)
                        {
                            // fix real location
                            var next = GetTargetLocation(x, y, i, j, r0);
                            result[next.Key + sp, next.Value + sp] = matrix[x + sp][y + sp];
                        }
                    }
                }
                sp++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(result[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public static KeyValuePair<int, int> GetTargetLocation(int i, int j, int n, int m, int r)
    {
        while (r > 0)
        {
            if (j == 0 && i < n - 1)
            {
                i++;
            }
            else if (i == n - 1 && j < m - 1)
            {
                j++;
            }
            else if (j == m - 1 && i > 0)
            {
                i--;
            }
            else if (i == 0 && j > 0)
            {
                j--;
            }
            r--;
        }
        return new KeyValuePair<int, int>(i, j);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int m = Convert.ToInt32(firstMultipleInput[0]);

        int n = Convert.ToInt32(firstMultipleInput[1]);

        int r = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < m; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        Result.matrixRotation(matrix, r);
    }
}
