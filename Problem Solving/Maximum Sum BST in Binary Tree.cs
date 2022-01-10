/**
 *
 * https://leetcode.com/problems/maximum-sum-bst-in-binary-tree/
 * 
 * Binary Tree Traversal
 * - 
 * 
 * 
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
    private int max;
    public int maxSumBST2(TreeNode root)
    {
        max = 0;
        findMaxSum(root);
        return max;
    }

    //int[]{isBST(0/1), largest, smallest, sum}
    public int[] findMaxSum(TreeNode node)
    {
        if (node == null)
        {
            return new int[] { 1, Integer.MIN_VALUE, Integer.MAX_VALUE, 0 };
        }
        int[] left = findMaxSum(node.left);
        int[] right = findMaxSum(node.right);
        boolean isBST = left[0] == 1 && right[0] == 1 && node.val > left[1] && node.val < right[2];
        int sum = node.val + left[3] + right[3];
        if (isBST)
        {
            max = Math.max(max, sum);
        }
        return new int[] { isBST ? 1 : 0, Math.max(node.val, right[1]), Math.min(node.val, left[2]), sum };
    }



    public int MaxSumBST(TreeNode root)
    {
        sums = new List<int>();
        preorderCalculate(root);
        if (sums.Count == 0) return 0;
        foreach (int i in sums) Console.Write(i + " ");
        return sums.Max();
    }

    private IList<int> sums;
    private void preorderCalculate(TreeNode root)
    {
        if (root != null)
        {
            preorderCalculate(root.left);
            preorderCalculate(root.right);
            sums.Add(biggestBST(root));
        }
    }

    private int biggestBST(TreeNode node)
    {
        var inorder = inorderList(node);
        if (isSorted(inorder))
        {
            var postorder = postorderList(node);
            return sumList(postorder);
        }
        return 0;
    }

    private IList<int> inorderList(TreeNode node)
    {
        traversal = new List<int>();
        inorderTraversal(node);
        return traversal;
    }
    private IList<int> postorderList(TreeNode node)
    {
        traversal = new List<int>();
        postorderTraversal(node);
        return traversal;
    }
    private IList<int> traversal;
    private void inorderTraversal(TreeNode node)
    {
        if (node != null)
        {
            inorderTraversal(node.left);
            traversal.Add(node.val);
            inorderTraversal(node.right);
        }
    }
    private void postorderTraversal(TreeNode node)
    {
        if (node != null)
        {
            postorderTraversal(node.left);
            postorderTraversal(node.right);
            traversal.Add(node.val);
        }
    }
    private bool isSorted(IList<int> arr)
    {
        for (int i = 1; i <= arr.Count - 1; i++)
        {
            if (arr[i - 1] >= arr[i]) return false;
        }
        return true;
    }
    private int sumList(IList<int> arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Count; i++)
        {
            sum += arr[i];
        }
        return sum;
    }



    // BFS mark levels
    /*
    class Node
    {
        public int value;
        public int level;
        public Node left;
        public Node right;
        public Node(int v) {
            value = v;
            left = right = null;
        }
    }
    */
    private static void markLevel(Node node)
    {
        Queue<Node> que1 = new Queue<Node>();
        Queue<Node> que2 = new Queue<Node>();

        bool isQ1 = true;
        que1.Enqueue(node);

        int curl = 0;

        while (isQ1 == true && que1.Count > 0 || isQ1 == false && que2.Count > 0)
        {
            Node nd;
            if (isQ1 == true)
            {
                nd = que1.Dequeue();
                if (nd.left != null) que2.Enqueue(nd.left);
                if (nd.right != null) que2.Enqueue(nd.right);
            }
            else
            {
                nd = que2.Dequeue();
                if (nd.left != null) que1.Enqueue(nd.left);
                if (nd.right != null) que1.Enqueue(nd.right);
            }

            nd.level = curl;
            Console.Write(nd.level + " ");

            if (isQ1 == true && que1.Count == 0)
            {
                isQ1 = false;
                curl++;
            }
            if (isQ1 == false && que2.Count == 0)
            {
                isQ1 = true;
                curl++;
            }
        }
    }
}