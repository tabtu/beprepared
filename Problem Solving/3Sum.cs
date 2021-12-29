/* https://leetcode.com/problems/3sum/
 * 
 * Sort array and start from begin;
 * Skip when meet same numbers, avoid duplicate;
 * Search pairs in sub-strings (3 numbers):
 * - left = i + 1;
 * - right = length - 1;
 * - skip numbers on left/right;
 * 
 * 
 */

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        int sum;
        IList<IList<int>> list = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0) return list;  // will not have any result that equals to 0;
            if (i > 0 && nums[i] == nums[i - 1]) continue;  // skip when nums[i] == num[i - 1];
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right)  // find pairs;
            {
                if (nums[i] + nums[left] + nums[right] > 0)
                {
                    right--;
                }
                else if (nums[i] + nums[left] + nums[right] < 0)
                {
                    left++;
                }
                else
                {
                    IList<int> triplet = new List<int>();
                    triplet.Add(nums[i]);
                    triplet.Add(nums[left]);
                    triplet.Add(nums[right]);
                    list.Add(triplet);
                    while (left < right && nums[right - 1] == nums[right]) right--;  // skip same numbers on right;
                    while (left < right && nums[left + 1] == nums[left]) left++;  // skip same numbers on left;
                    right--;
                    left++;
                }
            }
        }
        return list;
    }
}