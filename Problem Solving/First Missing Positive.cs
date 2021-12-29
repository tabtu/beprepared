/* https://leetcode.com/problems/first-missing-positive/
 * 
 * marks zero or negative numbers as infinitive positive numbers;
 * use index start with zero;
 * mark `x` as visited by marking `nums[x]` as negative;
 * if nums[i] is positive -> number (i+1) is not visited;
 * 
 */

public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        int n = nums.Length, INF = n + 1;

        // no negative numbers
        for (int i = 0; i < n; i++)
            if (nums[i] <= 0)
                nums[i] = INF;

        // mark `x` as visited by marking `nums[x]` as negative
        for (int i = 0; i < n; i++)
        {
            int x = Math.Abs(nums[i]) - 1;
            if (x < n)
                nums[x] = -Math.Abs(nums[x]);
        }

        // i+1 is not visited when nums[i] is positive
        for (int i = 0; i < n; i++)
            if (nums[i] > 0)
                return i + 1;
        return n + 1;
    }
}