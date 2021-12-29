/* https://leetcode.com/problems/string-to-integer-atoi
 *
 *
 *
 */

public class Solution
{
    public int MyAtoi(string s)
    {
        s = s.TrimStart();
        string result = "";
        foreach (char c in s)
        {
            if (c == 0x2b || c == 0x2d)
            {
                if (result.Length == 0) result += c.ToString();
                else if (result[result.Length - 1] >= 0x30 && result[result.Length - 1] <= 0x39) break;
                else return 0;
            }
            else if (c >= 0x30 && c <= 0x39)
            {
                result += c.ToString();
            }
            else
            {
                break;
            }
        }
        if (result.Length == 0) return 0;
        if (result.Length == 1 && result == "+" || result == "-") return 0;
        if (result[0] == '+') result = result.Substring(1, result.Length - 1);

        if (result[0] != '-')
        {
            int j = 0;
            for (j = 0; j < result.Length; j++)
            {
                if (result[j] != '0') break;
            }
            if (j == result.Length) return 0;
            if (j > 0) result = result.Substring(j, result.Length - j);
            string intmax = int.MaxValue.ToString();
            if (result.Length > intmax.Length) return int.MaxValue;
            if (result.Length == intmax.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] < intmax[i]) break;
                    else if (result[i] == intmax[i]) continue;
                    else
                    {
                        Console.WriteLine(result[i] + ": " + intmax[i]);
                        return int.MaxValue;
                    }
                }
            }
        }
        if (result[0] == '-')
        {
            result = result.Substring(1, result.Length - 1);
            int j = 0;
            for (j = 0; j < result.Length; j++)
            {
                if (result[j] != '0') break;
            }
            if (j == result.Length) return 0;
            if (j > 0) result = result.Substring(j, result.Length - j);
            result = "-" + result;
            string intmin = int.MinValue.ToString();
            if (result.Length > intmin.Length) return int.MinValue;
            if (result.Length == intmin.Length)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i] < intmin[i]) break;
                    else if (result[i] == intmin[i]) continue;
                    else return int.MinValue;
                }
            }
        }
        return int.Parse(result);
    }
}