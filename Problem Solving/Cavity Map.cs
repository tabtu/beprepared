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
     * https://www.hackerrank.com/challenges/cavity-map
     * 
     * 
     * 
     * Complete the 'cavityMap' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static List<string> cavityMap(List<string> grid)
    {
        for (int j = 0; j < grid.Count; j++)
        {
            char[] cc = grid[j].ToCharArray();
            for (int i = 0; i < cc.Length; i++)
            {
                if (j >= 1 && j <= grid.Count - 2 && i >= 1 && i <= cc.Length - 2)
                {
                    if (grid[j][i - 1] < grid[j][i] && grid[j][i + 1] < grid[j][i] && 
                            grid[j - 1][i] < grid[j][i] && grid[j + 1][i] < grid[j][i])
                    {
                        cc[i] = 'X';
                    }
                }
            }
            grid[j] = new string(cc);
        }
        return grid;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.cavityMap(grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
