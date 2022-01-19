/* ------------------------------------------------------------------
 * Dynamic Programming
 * 
 * 1, Declare the defination of matrix/array, the meaning of subscript. 
 * 2, Initialize values. 
 * 3, Find the derivation formula / conversion function. 
 * 
 * 
 * 1, 确定dp数组及下标含义
 *    - 根据结果需要寻找定义
 *    - 运算结果一般在dp[m-1,n-1]位置
 * 2, 数组初始化
 *    - 初始化首行/首列
 *    - 若寻求结果定义为列参数, 则需要定义+1列存放计算结果
 *    - 可能有特殊, 尽可能找出所有初始化
 * 3, 寻找推导公式
 *    - 画图填表
 *    - 模拟初始计算递推到复杂结果
 * 
 * 算法模板:
 * ---------------------------------
T func_DP (T target, T[] options) {

    int m = options.Length;
    int n = target;  // basic target can be initialized

    TR[,] dp = new TR[m, n];  // TR stand for result type

    for (int i = 0; i < m; i++) {
        dp[i, 0] = 1;
    }
    for (int j = 0; j < n; j++) {
        dp[0, j] = 1;
    }

    // fn(i, j) <- fn(i-x, j) & fn(i, j-y)
    // fn(i, j, k) <- fn(i-x, j, k) & fn(i, j-y, k) & fn(i, j, k-z)
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
        }
    }

    return dp[m - 1, n - 1];
}
 * ---------------------------------
 * 
 * Problems:
 * - Minimum Path Sum
 * - Change in a Foreign Currency
 * - UniquePaths
 * 
 */

using System;
using System.Collections.Generic;

namespace coding
{
    public class _DynamicProgramming
    {
        private static int fibonacciDP(int n)
        {
            if (n < 1) return 0;
            if (n == 1) return 1;
            else if (n == 2) return 1;
            else
            {
                return fibonacciDP(n - 1) + fibonacciDP(n - 2);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(fibonacciDP(7));
        }
    }
}
