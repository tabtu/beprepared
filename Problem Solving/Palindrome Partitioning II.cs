/* https://leetcode.com/problems/palindrome-partitioning-ii/
 *
 * (BFS) 
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;

public class Solution
{
    private static int MinCut(string s)
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);
        int cuts = 0;
        // bfs
        bool[] visited = new bool[s.Length];
        for (int i = 0; i < visited.Length; i++) visited[i] = false;
        while (true)
        {
            Queue<int> tmp = new Queue<int>();
            while (queue.Count > 0)
            {
                int cur = queue.Dequeue();
                for (int i = s.Length - 1; i >= cur; i--)
                {
                    if (visited[i] == false && isPalindrome(s, cur, i))
                    {
                        if (i == s.Length - 1) return cuts;
                        tmp.Enqueue(i + 1);
                    }
                }
                visited[cur] = true;
            }
            cuts++;
            queue = tmp;
        }
    }

    private static bool isPalindrome(string s, int l, int r)
    {
        if (l == r) return true;
        while (l < r)
        {
            if (s[l] != s[r]) return false;
            l++;
            r--;
        }
        return true;
    }
}