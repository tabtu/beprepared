/* 
 * https://leetcode.com/problems/unique-paths/
 * https://leetcode.com/problems/unique-paths-ii/
 * 
 * UniquePaths
 * 
 * DP(Dynamic Programming)
 * f(i, j) = f(i-1, j) + f(i, j-1)
 *
 */

public class Solution
{
    public int UniquePaths(int m, int n)
    {
        int[,] dp = new int[m, n];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                // when initialize 
                if (i == 0 || j == 0)
                {
                    dp[i, j] = 1;
                }
                else
                {
                    dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                }
            }
        }

        // all posible cases
        return dp[m - 1, n - 1];
    }

    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        int[,] path = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            if (obstacleGrid[i][0] == 1)
            {
                path[i, 0] = 0;
                //on the first column, if there is an obstacle, the rest are blocked. 
                //no need to continue.
                break;
            }
            else
                path[i, 0] = 1;
        }

        for (int j = 0; j < n; j++)
        {
            if (obstacleGrid[0][j] == 1)
            {
                path[0, j] = 0;
                //First row, once obstacle found, the rest are blocked.
                break;
            }
            else
                path[0, j] = 1;
        }

        for (int i = 1; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (obstacleGrid[i][j] == 1)
                    path[i, j] = 0;
                else
                    path[i, j] = path[i - 1, j] + path[i, j - 1];
            }
        }
        return path[m - 1, n - 1];
    }
}