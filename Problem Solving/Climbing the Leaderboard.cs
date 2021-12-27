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
     * https://www.hackerrank.com/challenges/climbing-the-leaderboard
     * 
     * 
     * 
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        List<int> result = new List<int>();
        ranked = ranked.Distinct().ToList();
        int i = 0;
        int j = player.Count - 1;
        while (j >= 0)
        {
            if (i == 0 && player[j] > ranked[i])
            {
                // The first position in ranked, add the very top ranking.
                result.Insert(0, 1);
                j--;
            }
            else if (i == ranked.Count - 1)
            {
                // The last position in ranked, do not add rank number anymore.
                if (player[j] < ranked[i])
                {
                    result.Insert(0, ranked.Count + 1);
                }
                else
                {
                    result.Insert(0, ranked.Count);
                }
                j--;
            }
            else if (player[j] >= ranked[i])
            {
                // ignore the first position in player
                if (j + 1 < player.Count)
                {
                    // move i to next only when j value is not repeated in player
                    if (player[j] > player[j + 1])
                    {
                        i++;
                    }
                }
                result.Insert(0, i + 1);
                j--;
            }
            else
            {
                i++;
            }
        }
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
