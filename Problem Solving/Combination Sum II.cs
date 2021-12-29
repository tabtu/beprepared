/* https://leetcode.com/problems/combination-sum-ii/
 * 
 * Sort array;
 * do recursive function from 0;
 * recursive MatchTarget from elements in list, ONLY add pairs when targ == 0;
 */

public class Solution
{
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
                if (candidates[i] > targ) break;
                if (i > index && candidates[i] == candidates[i - 1]) continue;
                ls.Add(candidates[i]);
                var temptar = targ - candidates[i];
                MatchTarget(temptar, i + 1, ls);
                ls.RemoveAt(ls.Count - 1);
            }
        }

        MatchTarget(target, 0, new List<int>());

        return result;
    }
}