/* https://leetcode.com/problems/unique-binary-search-trees-ii/
 * 
 * DP + recursive
 * 
 */

/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public IList<TreeNode> GenerateTrees(int n)
    {
        if (n == 0)
        {
            return new List<TreeNode>();
        }
        return generateTrees(1, n);
    }

    private List<TreeNode> generateTrees(int lo, int hi)
    {
        int n = hi - lo + 1;
        if (n == 0)
        {
            List<TreeNode> L = new List<TreeNode>();
            L.Add(null);
            return L;
        }
        List<TreeNode> result = new List<TreeNode>();
        for (int i = lo; i <= hi; ++i)
        {
            List<TreeNode> leftSubtrees = generateTrees(lo, i - 1);
            List<TreeNode> rightSubtrees = generateTrees(i + 1, hi);
            foreach (TreeNode leftSub in leftSubtrees)
            {
                foreach (TreeNode rightSub in rightSubtrees)
                {
                    TreeNode newTree = new TreeNode(i);
                    newTree.left = leftSub;
                    newTree.right = rightSub;
                    result.Add(newTree);
                }
            }
        }
        return result;
    }
}