/* https://leetcode.com/problems/minimum-path-sum/
 * 
 * DP
 * start at 0,0 and end at m-1,n-1;
 * initialize values when i = 0 or j = 0;
 * - the value should be accumulated with previous value.
 * dp[i, j] = Min(dp[i - 1, j], dp[i, j - 1]) + value[i, j]
 * 
 * RC
 * start at 0,0
 * calculate values when i == 0 or j == 0;
 * - recursive begin
 * when value[i - 1, j] < value[i, j - 1] : move right(j++);
 * when value[i, j - 1] < value[i - 1, j] : move down(i++);
 * sum and log values;
 * - recursive end
 */

public class Solution
{

    // DP
    public int MinPathSum(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[,] dp = new int[m, n];

        // initialize result matrix
        dp[0, 0] = grid[0][0];
        for (int i = 1; i < m; i++)
        {
            // accumulate values when j = 0;
            dp[i, 0] = dp[i - 1, 0] + grid[i][0];
        }
        for (int j = 1; j < n; j++)
        {
            // accumulate values when i = 0;
            dp[0, j] = dp[0, j - 1] + grid[0][j];
        }

        // DP calculate
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
            }
        }

        // return result
        return dp[m - 1, n - 1];
    }

    // RC
    private static int MinPathSum_RC(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        // MARK: i < m, j < n;
        return ChoosePathMin(grid, m - 1, n - 1);
    }
    // RC, method
    private static int ChoosePathMin(int[][] grid, int i, int j)
    {
        // start point;
        if (i == 0 && j == 0)
        {
            return grid[0][0];
        }
        // first(one) row loop, only have 1 row and path;
        if (i == 0)
        {
            return grid[0][j] + ChoosePathMin(grid, 0, j - 1);
        }
        // first(one) column loop, only have 1 column and path;
        if (j == 0)
        {
            return grid[i][0] + ChoosePathMin(grid, i - 1, 0);
        }
        // any other points, start from 1,1 and end at i,j;
        int minRow = ChoosePathMin(grid, i - 1, j);
        int minCol = ChoosePathMin(grid, i, j - 1);
        return grid[i][j] + Math.Min(minRow, minCol);
    }


    // DP with path log
    private struct Node
    {
        public int i;
        public int j;

        public Node(int _i, int _j)
        {
            i = _i;
            j = _j;
        }
    }

    private static string MiniSumPath(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        KeyValuePair<int, IList<Node>>[,] path = new KeyValuePair<int, IList<Node>>[m, n];

        // i ==0 && j == 0;
        IList<Node> p0 = new List<Node>();
        p0.Add(new Node(0, 0));
        path[0, 0] = new KeyValuePair<int, IList<Node>>(grid[0][0], p0);

        // j == 0;
        for (int i = 1; i < m; i++)
        {
            int sum = path[i - 1, 0].Key + grid[i][0];
            IList<Node> p = path[i - 1, 0].Value;
            p.Add(new Node(i, 0));
            path[i, 0] = new KeyValuePair<int, IList<Node>>(sum, p);
        }

        // i == 0;
        for (int j = 1; j < n; j++)
        {
            int sum = path[0, j - 1].Key + grid[0][j];
            IList<Node> p = path[0, j - 1].Value;
            p.Add(new Node(0, j));
            path[0, j] = new KeyValuePair<int, IList<Node>>(sum, p);
        }

        // i > 0 && j > 0
        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                int sum;
                IList<Node> p;
                if (path[i - 1, j].Key <= path[i, j - 1].Key)
                {
                    sum = path[i - 1, j].Key + grid[i][j];
                    p = path[i - 1, j].Value;

                }
                else
                {
                    sum = path[i, j - 1].Key + grid[i][j];
                    p = path[i, j - 1].Value;
                }
                p.Add(new Node(i, j));
                path[i, j] = new KeyValuePair<int, IList<Node>>(sum, p);
            }
        }

        // result should be at m-1,n-1
        string result = path[m - 1, n - 1].Key + " : ";
        foreach (Node node in path[m - 1, n - 1].Value)
        {
            result += "(" + node.i + "," + node.j + ")";
        }
        return result;
    }
}