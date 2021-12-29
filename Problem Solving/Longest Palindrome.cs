/* https://leetcode.com/problems/longest-palindromic-substring/
 * 
 * 
 * 
 */

public class Solution
{
    public string LongestPalindrome(string s)
    {
        int len = s.Length;
        string maxPalindrome = "";
        for (int i = 0; i < len; i++)
        {
            var result0 = GetPalindrome(i, i, s);
            var result1 = GetPalindrome(i, i + 1, s);

            if (result1.Length > result0.Length) result0 = result1;
            if (result0.Length > maxPalindrome.Length) maxPalindrome = result0;
        }
        return maxPalindrome;
    }

    public string GetPalindrome(int left, int right, string s, string carry = "")
    {
        if (left < 0 || right >= s.Length || s[left] != s[right]) return carry;
        carry = (left == right) ? (s[left] + carry) : (s[left] + carry + s[right]);
        return GetPalindrome(left - 1, right + 1, s, carry);
    }
}