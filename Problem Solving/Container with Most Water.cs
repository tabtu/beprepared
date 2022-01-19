

/* https://leetcode.com/problems/container-with-most-water/
 * 
 * Container with Most Water
 * 
 */

public class Solution
{
    public int MaxArea(int[] height)
    {
        int max = 0, left = 0, right = height.Length - 1;
        while (left < right)
        {
            int area = (right - left) * Math.Min(height[left], height[right]);
            max = Math.Max(max, area);

            if (height[left] < height[right])
            {
                int i = left;
                while (height[left] <= height[i] && left < right) left++;
            }
            else
            {
                int j = right;
                while (height[j] >= height[right] && left < right) right--;
            }
        }

        return max;
    }
}