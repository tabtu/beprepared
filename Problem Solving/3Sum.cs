/* https://leetcode.com/problems/3sum/
 * https://leetcode.com/problems/4sum/
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



    int len = 0;
    public List<List<Integer>> fourSum(int[] nums, int target)
    {
        len = nums.Length;
        Array.Sort(nums);
        return kSum(nums, target, 4, 0);
    }

    private List<List<int>> kSum(int[] nums, int target, int k, int index = 0)
    {
        List<List<int>> res = new List<List<int>>();
        if (index >= len)
        {
            return res;
        }
        if (k == 2)
        {
            int i = index, j = len - 1;
            while (i < j)
            {
                //find a pair
                if (target - nums[i] == nums[j])
                {
                    List<int> temp = new List<int>();
                    temp.Add(nums[i]);
                    temp.Add(target - nums[i]);
                    res.Add(temp);
                    //skip duplication
                    while (i < j && nums[i] == nums[i + 1]) i++;
                    while (i < j && nums[j - 1] == nums[j]) j--;
                    i++;
                    j--;
                    //move left bound
                }
                else if (target - nums[i] > nums[j])
                {
                    i++;
                    //move right bound
                }
                else
                {
                    j--;
                }
            }
        }
        else
        {
            for (int i = index; i < len - k + 1; i++)
            {
                //use current number to reduce ksum into k-1sum
                List<List<int>> temp = kSum(nums, target - nums[i], k - 1, i + 1);
                if (temp != null)
                {
                    //add previous results
                    foreach (List<int> t in temp)
                    {
                        t.Insert(0, nums[i]);
                    }
                    res.AddRange(temp);
                }
                while (i < len - 1 && nums[i] == nums[i + 1])
                {
                    //skip duplicated numbers
                    i++;
                }
            }
        }
        return res;
    }
}