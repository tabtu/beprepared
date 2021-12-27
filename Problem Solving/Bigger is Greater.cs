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
     * https://www.hackerrank.com/challenges/bigger-is-greater
     * 
     * 
     * 
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        int pos = 0;
        for (int j = w.Length - 2; j >= 0; j--)
        {
            if (w[j] < w[j + 1])
            {
                pos = j;
                break;
            }
        }

        if (w.Length < 2)
        {
            return "no answer";
        }
        else if (w.Length == 2)
        {
            if (w[0] < w[1]) return w[1].ToString() + w[0].ToString();
            else return "no answer";
        }
        else
        {
            string w0 = w.Substring(0, pos);
            string w1 = w.Substring(pos, w.Length - pos);
            List<char> w1s = w1.ToList();
            char cc = w1s[0];
            if (cc == w1s.Max()) return "no answer";
            char sc = cc;
            List<char> tmp = w1.Substring(1, w1.Length - 1).ToList();
            tmp.Sort();
            foreach (char csc in tmp)
            {
                if (sc > cc) break;
                else sc = csc;
            }
            w1s.Remove(sc);
            w1s.Sort();
            w1 = new String(w1s.ToArray());
            if (w == w0 + sc + w1) return "no answer";
            return w0 + sc + w1;
        }
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
