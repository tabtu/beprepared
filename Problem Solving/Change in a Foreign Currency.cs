/*
 * Change in a Foreign Currency
 *
 * You likely know that different currencies have coins and bills of different denominations. In some currencies, it's actually impossible to receive change for a given amount of money. For example, Canada has given up the 1-cent penny. If you're owed 94 cents in Canada, a shopkeeper will graciously supply you with 95 cents instead since there exists a 5-cent coin.
 * Given a list of the available denominations, determine if it's possible to receive exact change for an amount of money targetMoney. Both the denominations and target amount will be given in generic units of that currency.
 * Signature
 * boolean canGetExactChange(int targetMoney, int[] denominations)
 * Input
 * 1 ≤ |denominations| ≤ 100
 * 1 ≤ denominations[i] ≤ 10,000
 * 1 ≤ targetMoney ≤ 1,000,000
 * Output
 * Return true if it's possible to receive exactly targetMoney given the available denominations, and false if not.
 * Example 1
 * denominations = [5, 10, 25, 100, 200]
 * targetMoney = 94
 * output = false
 * Every denomination is a multiple of 5, so you can't receive exactly 94 units of money in this currency.
 * Example 2
 * denominations = [4, 17, 29]
 * targetMoney = 75
 * output = true
 * You can make 75 units with the denominations [17, 29, 29].
 * 
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;

// We don’t provide test cases in this language yet, but have outlined the signature for you. Please write your code below, and don’t forget to test edge cases!
class ForeignCurrency
{
    static void Main(string[] args)
    {
        // Call canGetExactChange() with test cases here

        int[] denominations = { 5, 10, 25, 100, 200 };
        int targetMoney = 94;

        Console.WriteLine(canGetExactChange(targetMoney, denominations));
    }

    private static bool canGetExactChange(int targetMoney, int[] denominations)
    {

        //int paths = pathExactChange_BT(t, denominations);
        //int paths = pathExactChange_DFS(t, denominations);
        int paths = pathExactChange_DP(t, denominations);
        return paths > 0 ? true : false;
    }

    // BT(DFS with optimize option list)
    private static int pathExactChange_BT(int targetMoney, int[] denominations)
    {
        // distinct with hash
        path = new HashSet<string>();
        IList<int> pts = new List<int>();

        // distinct with arrange
        Array.Sort(denominations);

        // Do backtrack call
        pathExactChange_Backtrack(targetMoney, pts, denominations);

        return path.Count;
    }
    private static HashSet<string> path;
    private static void pathExactChange_Backtrack(int target, IList<int> pts, int[] denom)
    {
        // Success Cases
        if (target == 0)
        {
            // distinct by Hash
            //int[] ar = pts.ToArray();
            //Array.Sort(ar);
            //string tmp = intArr2str(ar);
            //path.Add(tmp);

            // distinct by cutting branches
            path.Add(intArr2str(pts.ToArray()));
            return;
        }
        // Boundary
        if (target < 0)
        {
            return;
        }

        // For all options
        for (int i = 0; i < denom.Length; i++)
        {
            // Do Choice
            pts.Add(denom[i]);
            target -= denom[i];

            // Cut Branches Recursive, find the array for next generation
            int[] next = (from st in denom where st >= denom[i] select st).ToArray();
            getExactChange_Backtrack(target, pts, next);
            // Normal Recursive Call
            //getExactChange_Backtrack(target, pts, denom);

            // Backtrack Choice
            target += denom[i];
            pts.RemoveAt(pts.Count - 1);
        }
    }

    // DFS, with cache
    private static int[,] cache;
    public static int pathExactChange_DFS(int target, int[] denominations)
    {
        //int[] values = { 25, 10, 5, 1 };
        cache = new int[target + 1, denominations.Length + 1];
        return dfs(denominations, target, 0);
    }

    private static int dfs(int[] values, int n, int cur)
    {
        if (n >= 0 && cache[n, cur] != 0)
            return cache[n, cur];
        if (n < 0)
        {
            return 0;
        }
        if (n == 0)
        {
            return 1;
        }
        int res = 0;

        for (int i = cur; i < values.Length; i++)
        {
            if (n - values[i] >= 0)
            {
                res += cache[n - values[i], i] != 0 ? cache[n - values[i], i] : dfs(values, n - values[i], i);
            }
        }
        cache[n, cur] = res;
        return res;
    }

    // DP
    // f(i, j) = f(i - 1, j) + f(i, j - denominations[i])
    private static int pathExactChange_DP(int targetMoney, int[] denominations)
    {
        int gcd = Gcd(denominations);
        if (targetMoney % gcd != 0) return 0;
        // find the Greatest Common Divisor, decrease the number level.
        List<int> tmp = new List<int>();
        for (int i = 0; i < denominations.Length; i++)
        {
            // only calculate case when less than an option value
            if (denominations[i] <= targetMoney)
            {
                tmp.Add(denominations[i] / gcd);
            }
        }
        // do minimum number problem
        denominations = tmp.ToArray();
        targetMoney = targetMoney / gcd;

        // DP, m->option length, n->target value
        int m = denominations.Length;  // kinds of coins
        int n = targetMoney;

        // target value list start from 0
        int[,] dp = new int[m, n + 1];

        // initial first row and first column
        for (int i = 0; i < m; i++)
        {
            dp[i, 0] = 1;
        }
        for (int i = 0; i <= n; i++)
        {
            dp[0, i] = 1;
        }

        // f(i, j) = f(i - 1, j) + f(i, j - denominations[i])
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j <= n; j++)
            {
                //dp[i, j] = dp[i - 1, j] + dp[i, j - denominations[i]];
                int a, b;
                a = dp[i - 1, j];
                b = j - denominations[i] >= 0 ? dp[i, j - denominations[i]] : 0;
                dp[i, j] = a + b;
                //Console.Write(String.Format("{0,4}", dp[i, j]) + ",");
            }
            //Console.WriteLine();
        }

        // bottom right is the answer
        return dp[m - 1, n];
    }

    private static int Gcd(int[] arr)
    {
        int maxGcd = int.MaxValue;
        for (int i = 1; i < arr.Length; i++)
        {
            int gcd = Gcd(arr[i - 1], arr[i]);
            maxGcd = gcd < maxGcd ? gcd : maxGcd;
        }
        return maxGcd;
    }

    private static int Gcd(int a, int b)
    {
        if (b == 0) return a;
        return Gcd(b, a % b);
    }
}