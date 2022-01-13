/* https://leetcode.com/problems/permutations/
 * 
 * Permutations
 * 
 * backtrack -> for with recursive inside
 * 
 * Func Recursion (elements, options):
 *      set return condition
 *      for opt in options:
 *          - dismiss value/opt if it can be skipped
 *          select choice (eg: opt.Append())
 *          recursive into next level
 *          remove choice (eg: opt.RemoveLast())
 * 
 * 
 */

public class Solution
{

    public IList<IList<int>> Permute(int[] nums)
    {
        Permutations p = new Permutations();
        p.CalculatePermute(nums);
        return p.GetResult();
    }

    class Permutations
    {
        private IList<IList<int>> result;

        public Permutations()
        {
            result = new List<IList<int>>();
        }

        public IList<IList<int>> GetResult()
        {
            return result;
        }

        public void CalculatePermute(int[] nums)
        {
            IList<int> track = new List<int>();
            permute_Backtrack(nums, track);
        }

        public void permute_Backtrack(int[] nums, IList<int> opts)
        {
            if (opts.Count == nums.Length)
            {
                // create a new instance from opts, then add into result
                // MARK: result is an global variable
                result.Add(new List<int>(opts));
            }

            for (int i = 0; i < nums.Length; i++)
            {
                // dismiss when repeated
                if (opts.Contains(nums[i]))
                {
                    continue;
                }

                // add an option / do the choice
                opts.Add(nums[i]);
                // recursive into next level
                permute_Backtrack(nums, opts);
                // remove the last option / remove the last choice
                opts.RemoveAt(opts.Count - 1);
            }
        }
    }
}