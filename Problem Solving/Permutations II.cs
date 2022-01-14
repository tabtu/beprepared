/* https://leetcode.com/problems/permutations/
 * 
 * Permutations
 * 
 */

public class Solution
{
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        result = new List<IList<int>>();
        seen = new HashSet<string>();
        CalculatePermute(nums);
        return result.ToList();
    }

    public void CalculatePermute(int[] nums)
    {
        IList<int> track = new List<int>();
        permute_Backtrack(nums.ToList(), track);
    }

    private IList<IList<int>> result;
    private HashSet<string> seen;
    public void permute_Backtrack(IList<int> nums, IList<int> opts)
    {
        if (nums.Count == 0)
        {
            // create a new instance from opts, then add into result
            // MARK: result is an global variable
            string str = arr2str(opts);
            if (!seen.Contains(str))
            {
                seen.Add(str);
                result.Add(new List<int>(opts));
            }
            return;
        }

        for (int i = 0; i < nums.Count; i++)
        {
            int tmp = nums[i];
            // add an option / do the choice
            opts.Add(tmp);
            IList<int> next = nums.ToList();
            next.RemoveAt(i);

            // recursive into next level
            permute_Backtrack(next, opts);


            //nums.Insert(i, tmp);
            // remove the last option / remove the last choice
            opts.RemoveAt(opts.Count - 1);
        }
    }

    public string arr2str(IList<int> arr)
    {
        string str = "";
        foreach (int i in arr)
        {
            str += i + " ";
        }
        return str;
    }
}