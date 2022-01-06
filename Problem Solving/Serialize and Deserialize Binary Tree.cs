/**
 * https://leetcode.com/problems/serialize-and-deserialize-binary-tree/
 * 
 * BFS
 * 
 * 
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec
{

    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        if (root == null) return "";

        IList<int?> lst = new List<int?>();

        Queue<TreeNode> queue = new Queue<TreeNode>();
        lst.Add(root.val);
        queue.Enqueue(root);

        int lvl = 0;
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            if (node != null)
            {
                TreeNode left = node.left;
                if (left == null) lst.Add(null);
                else lst.Add(left.val);
                queue.Enqueue(left);

                TreeNode right = node.right;
                if (right == null) lst.Add(null);
                else lst.Add(right.val);
                queue.Enqueue(right);

                lvl++;
            }
        }

        string result = "";
        foreach (var i in lst)
        {
            if (i == null) result += "null,";
            else result += i + ",";
        }
        return result.Substring(0, result.Length - 1);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        if (data == "") return null;

        string[] str = data.Split(",");
        IList<int?> arr = new List<int?>();
        foreach (string s in str)
        {
            if (s == "null") arr.Add(null);
            else arr.Add(int.Parse(s));
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();

        TreeNode root = new TreeNode((int)arr[0], null, null);
        queue.Enqueue(root);

        int i = 0;
        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            if (node != null && i * 2 + 2 < arr.Count)
            {
                if (arr[i * 2 + 1] != null)
                {
                    TreeNode left = new TreeNode((int)arr[i * 2 + 1], null, null);
                    node.left = left;
                    queue.Enqueue(left);
                }

                if (arr[i * 2 + 2] != null)
                {
                    TreeNode right = new TreeNode((int)arr[i * 2 + 2], null, null);
                    node.right = right;
                    queue.Enqueue(right);
                }
            }
            i++;
        }
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));