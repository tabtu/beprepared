/* https://leetcode.com/problems/palindrome-partitioning/
 * 
 * Palindrome Partitioning
 * (DFS) backtrack, cutting, Permutations
 * 
 * -> focus on the problem: design backtrack function with problem asked.
 * -> be careful at the rest numbers in one path.
 * -> do not forget to draw the solution before coding.
 * -> do not add parameters which is not necessary.
 * 
 * Given a string s, partition s such that every substring of the partition is a palindrome. Return all possible palindrome partitioning of s.
 * A palindrome string is a string that reads the same backward as forward.
 * Example 1:
 * Input: s = "aab"
 * Output: [["a","a","b"],["aa","b"]]
 * Example 2:
 * Input: s = "a"
 * Output: [["a"]]
 * Constraints:
 * 1 <= s.length <= 16
 * s contains only lowercase English letters.
 * 
 */

public class Solution
{
    public IList<IList<string>> Partition(string s)
    {
        paths = new List<IList<string>>();
        pts = new List<string>();

        partition_backTrack(s, 0);

        return paths;
    }

    private static IList<IList<string>> paths;
    private static IList<string> pts;
    private static void partition_backTrack(string s)
    {
        if (s.Length == 0)
        {
            IList<string> newpts = new List<string>(pts);
            if (s.Length > 0)
            {
                //Console.WriteLine(s.Length + " : " +s);
                newpts.Add(s);  // add the rest elements into path
            }
            paths.Add(newpts);
            return;
        }

        for (int i = 1; i <= s.Length; i++)
        {
            string tmp = s.Substring(0, i);
            if (isPalindrome(tmp))
            {
                pts.Add(tmp);
                string ret = s.Substring(i, s.Length - i);

                partition_backTrack(ret);

                pts.RemoveAt(pts.Count - 1);
            }
        }
    }

    private static bool isPalindrome(string s)
    {
        int l = 0, r = s.Length - 1;
        while (l < r)
        {
            if (s[l] != s[r]) return false;
            l++;
            r--;
        }
        return true;
    }
}