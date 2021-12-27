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
     * https://www.hackerrank.com/challenges/bomber-man
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING_ARRAY grid
     */

    public static List<string> bomberMan(int n, List<string> grid)
    {
        char[][] map = Convert2Map(grid);
        if (n == 1)
        {
            DumpMap(map);
            return Convert2Grid(map);
        }
        
        if (n % 2 == 0)
        {
            for (int i = 0; i < map.Length; ++i)
                for (int j = 0; j < map[0].Length; ++j)
                    map[i][j] = 'O';
            DumpMap(map);
            return Convert2Grid(map);
        }
        
        IterateMap(map);
        if (n % 4 == 1) { IterateMap(map); }
        DumpMap(map);
        return Convert2Grid(map);
    }

    private static List<string> Convert2Grid(char[][] map)
    {
        List<string> grid = new List<string>();
        foreach(char[] row in map)
        {
            grid.Add(new string(row));
        }
        return grid;
    }

    private static char[][] Convert2Map(List<string> grid)
    {
        IList<char[]> matrix = new List<char[]>();
        foreach (string row in grid)
        {
            matrix.Add(row.ToArray());
        }
        return matrix.ToArray();
    }

    private static void IterateMap(char[][] map)
    {
        // Blow up the bombs
        for (int i = 0; i < map.Length; ++i)
        {
            for (int j = 0; j < map[i].Length; ++j)
            {
                if (map[i][j] == 'O')
                {
                    map[i][j] = ' ';
                    ClearCell(map, i - 1, j);
                    ClearCell(map, i + 1, j);
                    ClearCell(map, i, j - 1);
                    ClearCell(map, i, j + 1);
                }
            }
        }
        for (int i = 0; i < map.Length; ++i)
        {
            for (int j = 0; j < map[i].Length; ++j)
            {
                if (map[i][j] == '.')
                    map[i][j] = 'O';
                else
                    map[i][j] = '.';
            }
        }
    }
    
    private static void DumpMap(char[][] map)
    {
        for (int i = 0; i < map.Length; ++i)
        {
            Console.Out.WriteLine(String.Join("", map[i]));
        }
    }
    
    private static void ClearCell(char[][] map, int r, int c)
    {
        if (r < 0) return;
        if (r >= map.Length) return;
        if (c < 0) return;
        if (c >= map[r].Length) return;
        if (map[r][c] == 'O') return;
        map[r][c] = ' ';
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        List<string> grid = new List<string>();

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.bomberMan(n, grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
