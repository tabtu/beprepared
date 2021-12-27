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
     * https://www.hackerrank.com/challenges/acm-icpc-team
     * 
     * 
     * 
     * Complete the 'acmTeam' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING_ARRAY topic as parameter.
     */

    public static List<int> acmTeam(List<string> topic)
    {
                int a = 0;
        int b = 0;
        for (int i = 0; i < topic.Count - 1; i++)
        {
            for (int j = i + 1; j < topic.Count; j++)
            {
                int sub = 0;
                for (int k = 0; k < topic[i].Length; k++)
                {
                    if (topic[i][k] == '0' && topic[j][k] == '0') sub++;
                }
                int aa = topic[i].Length - sub;
                if (aa > a)
                {
                    a = aa;
                    b = 0;
                }
                if (aa == a)
                {
                    b++;
                }
            }
        }
        List<int> re = new List<int>();
        re.Add(a);
        re.Add(b);
        return re;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<string> topic = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string topicItem = Console.ReadLine();
            topic.Add(topicItem);
        }

        List<int> result = Result.acmTeam(topic);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
