/* 
 * https://leetcode.com/problems/combination-sum/
 * https://leetcode.com/problems/combination-sum-ii/
 * https://leetcode.com/problems/combination-sum-iii/
 * 
 * Sort array;
 * do recursive function from 0;
 * recursive MatchTarget from elements in list, ONLY add pairs when targ == 0;
 * 
 * 
 * 
 * initialize result list;
 * sort options if needed;
 * backtrack (target, path, options):
 * - if (target matched) add copy to result, return;
 * - if (target brandary) return;
 * - foreach (options):
 *   - add choice into path, calculate in target;
 *   - fix options if needed;
 *   - recursive call backtrack;
 *   - remove choice from path, calculate in target;
 */

public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        paths = new List<IList<int>>();
        Array.Sort(candidates);
        backtrack(target, null, candidates);
        return paths;
    }
    public IList<IList<int>> paths;
    public void backtrack(int target, IList<int> pts, int[] candidates)
    {
        if (pts == null) pts = new List<int>();

        if (target == 0)
        {
            paths.Add(pts.ToList());
            return;
        }
        if (target <= 0) return;

        // for all options
        for (int i = 0; i < candidates.Length; i++)
        {
            // do a choice
            pts.Add(candidates[i]);
            target -= candidates[i];

            // optimize options
            int[] opts = (from st in candidates where st >= candidates[i] select st).ToArray();

            // recursive
            backtrack(target, pts, opts);

            // back track
            pts.RemoveAt(pts.Count - 1);
            target += candidates[i];
        }
    }





    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        var result = new List<IList<int>>();
        Array.Sort(candidates);

        // search sub-list which sum to target - index.
        void MatchTarget(int targ, int index, IList<int> ls)
        {
            if (targ == 0)
            {
                res.Add(new List<int>(ls));
                return;
            }
            if (targ < 0) return;
            for (int i = index; i < candidates.Length; i++)
            {
                // skip options
                if (candidates[i] > targ) break;
                if (i > index && candidates[i] == candidates[i - 1]) continue;
                // do choice
                ls.Add(candidates[i]);
                var temptar = targ - candidates[i];
                // recursive
                MatchTarget(temptar, i + 1, ls);
                // backtrack
                ls.RemoveAt(ls.Count - 1);
            }
        }

        MatchTarget(target, 0, new List<int>());

        return result;
    }



    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        paths = new List<IList<int>>();
        int[] options = new int[9];
        for (int i = 1; i <= 9; i++)
        {
            options[i - 1] = i;
        }
        backtrack(n, k, null, options);
        return paths;
    }
    private IList<IList<int>> paths;
    private void backtrack(int target, int nums, IList<int> pts, int[] options)
    {
        if (pts == null) pts = new List<int>();
        if (target == 0 && nums == 0)
        {
            paths.Add(pts.ToList());
            return;
        }
        if (target < 0 || nums < 0) return;
        // for recursive
        for (int i = 0; i < options.Length; i++)
        {
            // do once
            pts.Add(options[i]);
            target -= options[i];
            nums--;
            // fix options
            int[] newopts = (from st in options where st > options[i] select st).ToArray();

            // recursive
            backtrack(target, nums, pts, newopts);

            // backtrack
            nums++;
            target += options[i];
            pts.RemoveAt(pts.Count - 1);
        }
    }
}