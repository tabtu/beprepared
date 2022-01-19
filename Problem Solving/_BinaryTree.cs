using System;
using System.Linq;
using System.Collections.Generic;

namespace coding
{
    /// <summary>
    /// Binary Tree, BST, AVL
    /// </summary>
    public class _BinaryTree
    {
        public class Node
        {
            public int data;
            public Node left, right;
            public Node(int d, Node l = null, Node r = null)
            {
                data = d;
                left = l;
                right = r;
                size = 1;
                // AVL
                height = 0;
                // BFS
                level = -1;
            }

            // AVL
            public int height;  // height differacne between left and right child
            public int size;  // sub-tree node count
            public Node(int d, int s, int h, Node l = null, Node r = null)
            {
                data = d;
                left = l;
                right = r;
                size = s;
                // AVL
                height = h;
                // BFS
                level = -1;
            }

            // BFS
            public int level;  // node level, root is 1

            // Red-Black
            public bool color;  // color of parent

            public Node(int[] preorder, int[] inorder, bool isPre = true)
            {
                Node root = new Node(0);

                if (isPre)
                {

                }
                else
                {

                }

                return root;
            }
        }


        //// root
        //private static Node root;
        //// node numbers_
        //private int count;

        public int[] preorderTraversal(Node node)
        {
            traversal = new List<int>();
            preorderRecursion(node);
            return traversal.ToArray();
        }
        public int[] inorderTraversal(Node node)
        {
            traversal = new List<int>();
            inorderRecursion(node);
            return traversal.ToArray();
        }
        public int[] postorderTraversal(Node node)
        {
            traversal = new List<int>();
            postorderRecursion(node);
            return traversal.ToArray();
        }
        private IList<int> traversal;
        private void preorderRecursion(Node node)
        {
            if (node != null)
            {
                traversal.Add(node.data);
                preorderRecursion(node.left);
                preorderRecursion(node.right);
            }
        }
        private void inorderRecursion(Node node)
        {
            if (node != null)
            {
                inorderRecursion(node.left);
                traversal.Add(node.data);
                inorderRecursion(node.right);
            }
        }
        private void postorderRecursion(Node node)
        {
            if (node != null)
            {
                postorderRecursion(node.left);
                postorderRecursion(node.right);
                traversal.Add(node.data);
            }
        }

        public Node swapLeftRight(Node node)
        {
            if (node.left != null)
            {
                node.left = swapLeftRight(node.left);
            }
            if (node.right != null)
            {
                node.right = swapLeftRight(node.right);
            }
            Node tmp = node.left;
            node.left = node.right;
            node.right = tmp;
            return node;
        }

        public int[] levelorderTraversal(Node node)
        {
            Queue<int> queue = new Queue<int>();
            if (node != null)
            {
                Queue<Node> queue2 = new Queue<Node>();
                queue2.Enqueue(node);
                while (queue2.Count > 0)
                {
                    Node x = queue2.Dequeue();
                    queue.Enqueue(x.data);
                    if (x.left != null)
                    {
                        queue2.Enqueue(x.left);
                    }
                    if (x.right != null)
                    {
                        queue2.Enqueue(x.right);
                    }
                }
            }
            return queue.ToArray();
        }

        /// <summary>
        /// Level traversal a binary tree. (BFS, double Queue)
        /// fill node. level value
        /// </summary>
        /// <param name="node">root</param>
        /// <returns></returns>
        public void markLevel(Node node)
        {
            Queue<Node> que1 = new Queue<Node>();
            Queue<Node> que2 = new Queue<Node>();

            bool isQ1 = true;
            que1.Enqueue(node);

            int cur_level = 0;

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

                // fill level into a node
                nd.level = cur_level;

                if (isQ1 == true && que1.Count == 0)
                {
                    isQ1 = false;
                    cur_level++;
                }
                if (isQ1 == false && que2.Count == 0)
                {
                    isQ1 = true;
                    cur_level++;
                }
            }
        }

        /// <summary>
        /// Encodes a tree to a string. (Queue)
        /// </summary>
        /// <param name="node">root</param>
        /// <returns></returns>
        public string serialize(Node root)
        {
            if (root == null) return "";

            IList<int?> lst = new List<int?>();

            Queue<Node> queue = new Queue<Node>();
            lst.Add(root.data);
            queue.Enqueue(root);

            int lvl = 0;
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                if (node != null)
                {
                    Node left = node.left;
                    if (left == null) lst.Add(null);
                    else lst.Add(left.data);
                    queue.Enqueue(left);

                    Node right = node.right;
                    if (right == null) lst.Add(null);
                    else lst.Add(right.data);
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

        /// <summary>
        /// Decodes your encoded data to tree. (Queue)
        /// </summary>
        /// <param name="node">root</param>
        /// <returns></returns> 
        public Node deserialize(string data)
        {
            if (data == "") return null;

            string[] str = data.Split(",");
            IList<int?> arr = new List<int?>();
            foreach (string s in str)
            {
                if (s == "null") arr.Add(null);
                else arr.Add(int.Parse(s));
            }

            Queue<Node> queue = new Queue<Node>();

            Node root = new Node((int)arr[0], null, null);
            queue.Enqueue(root);

            int i = 0;
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                if (node != null && i * 2 + 2 < arr.Count)
                {
                    if (arr[i * 2 + 1] != null)
                    {
                        Node left = new Node((int)arr[i * 2 + 1], null, null);
                        node.left = left;
                        queue.Enqueue(left);
                    }

                    if (arr[i * 2 + 2] != null)
                    {
                        Node right = new Node((int)arr[i * 2 + 2], null, null);
                        node.right = right;
                        queue.Enqueue(right);
                    }
                }
                i++;
            }
            return root;
        }

        public Node buildTree_preIn(int[] preorder, int[] inorder)
        {
            if (preorder == null || preorder.Length == 0)
            {
                return null;
            }
            Node root = new Node(preorder[0]);
            Stack<Node> stack = new Stack<Node>();
            stack.Push(root);
            int inorderIndex = 0;
            for (int i = 1; i < preorder.Length; i++)
            {
                int preorderVal = preorder[i];
                Node node = stack.Peek();
                if (node.data != inorder[inorderIndex])
                {
                    node.left = new Node(preorderVal);
                    stack.Push(node.left);
                }
                else
                {
                    while (stack.Count > 0 && stack.Peek().data == inorder[inorderIndex])
                    {
                        node = stack.Pop();
                        inorderIndex++;
                    }
                    node.right = new Node(preorderVal);
                    stack.Push(node.right);
                }
            }
            return root;
        }

        private Dictionary<int, int> memo = new Dictionary<int, int>();
        private int[] post;
        public Node buildTree_postIn(int[] inorder, int[] postorder)
        {
            for (int i = 0; i < inorder.Length; i++) memo.Add(inorder[i], i);
            post = postorder;
            Node root = buildTree(0, inorder.Length - 1, 0, post.Length - 1);
            return root;
        }
        public Node buildTree(int ii, int ie, int ps, int pe)
        {
            if (ie < ii || pe < ps) return null;
            // create root
            int root = post[pe];
            int ri = memo.GetValueOrDefault(root);
            // recursive creation
            Node node = new Node(root);
            node.left = buildTree(ii, ri - 1, ps, ps + ri - ii - 1);
            node.right = buildTree(ri + 1, ie, ps + ri - ii, pe - 1);
            return node;
        }




        // --------------------------------- BST ---------------------------------
        /// <summary>
        /// Insert node into BST
        /// </summary>
        /// <param name="node">root</param>
        /// <param name="data">value</param>
        /// <returns></returns>
        public Node insertBST(Node node, int data)
        {
            if (node == null) return new Node(data, 1, 0);
            if (data < node.data) node.left = insertBST(node.left, data);
            else if (data > node.data) node.right = insertBST(node.right, data);
            else node.data = data;
            node.size = 1 + size(node.left) + size(node.right);
            return node;
        }

        /// <summary>
        /// Delete node from BST
        /// </summary>
        /// <param name="node">root</param>
        /// <param name="data">value</param>
        /// <returns></returns>
        public Node deleteBST(Node node, int data)
        {
            if (node == null) return null;
            if (data < node.data) node.left = deleteBST(node.left, data);
            else if (data > node.data) node.right = deleteBST(node.right, data);
            else
            {
                if (node.right == null) return node.left;
                if (node.left == null) return node.right;
                Node next = node;
                node.right = minNode(next.right);
                node.left = next.left;
            }
            node.size = 1 + size(node.left) + size(node.right);
            return node;
        }

        /// <summary>
        /// Search node in a BST
        /// </summary>
        /// <param name="node">root</param>
        /// <param name="data">data</param>
        /// <returns></returns>
        public Node search(Node node, int data)
        {
            if (node != null)
            {
                if (node.data < data)
                {
                    search(node.left, data);
                }
                else if (node.data > data)
                {
                    search(node.right, data);
                }
                else  // (node.data == data)
                {
                    return node;
                }
            }
            return null;
        }

        public int minValue(Node node)
        {
            Node current = node;
            // loop down to the left most leaf
            while (current.left != null)
            {
                current = current.left;
            }
            return current.data;
        }

        public int maxValue(Node node)
        {
            Node current = node;
            // loop down to the right most leaf
            while (current.right != null)
            {
                current = current.right;
            }
            return current.data;
        }

        public Node minNode(Node node)
        {
            if (node.left == null) return node;
            return minNode(node.left);
        }

        public Node maxNode(Node node)
        {
            if (node.right == null) return node;
            return maxNode(node.right);
        }

        public bool isBST(Node node, int? min, int? max)
        {
            if (node == null) return true;
            if (min != null && node.data <= min) return false;
            if (max != null && node.data >= max) return false;
            return isBST(node.left, min, node.data) && isBST(node.right, node.data, max);
        }

        private int size(Node node)
        {
            if (node == null) return 0;
            return node.size;
        }

        public bool contains(Node node, int data)
        {
            return get(node, data) != null;
        }

        public Node get(Node node, int data)
        {
            if (node == null) return null;
            if (data < node.data) return get(node.left, data);
            else if (data > node.data) return get(node.right, data);
            else return node;
        }

        /// <summary>
        /// Returns the node in the subtree with the largest node.data less than or equal to data.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node floor(Node node, int data)
        {
            if (node == null) return null;
            if (data == node.data) return node;
            if (data < node.data) return floor(node.left, data);
            Node next = floor(node.right, data);
            if (next != null) return next;
            else return node;
        }

        /// <summary>
        /// Returns the node in the subtree with the smallest node.data greater than or equal to data.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node ceiling(Node node, int data)
        {
            if (node == null) return null;
            if (data == node.data) return node;
            if (data > node.data) return ceiling(node.right, data);
            Node next = ceiling(node.left, data);
            if (next != null) return next;
            else return node;
        }

        /// <summary>
        /// Returns the node, the kth smallest data in the subtree.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public Node select(Node node, int k)
        {
            if (node == null) return null;
            int t = size(node.left);
            if (t > k) return select(node.left, k);
            else if (t < k) return select(node.right, k - t - 1);
            else return node;
        }

        /// <summary>
        /// Returns the number of nodes in the subtree less than key.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public int rank(Node node, int data)
        {
            if (node == null) return 0;
            if (data < node.data) return rank(node.left, data);
            else if (data > node.data) return 1 + size(node.left) + rank(node.right, data);
            else return size(node.left);
        }

        /// <summary>
        /// Returns the number of keys in the symbol table in the given range.
        /// </summary>
        /// <param name="lo"></param>
        /// <param name="hi"></param>
        /// <returns></returns>
        public int size(Node node, int lo, int hi)
        {
            if (lo > hi) return 0;
            if (contains(node, hi)) return rank(node, hi) - rank(node, lo) + 1;
            else return rank(node, hi) - rank(node, lo);
        }


        // --------------------------------- AVL ---------------------------------

        private int height(Node node)
        {
            if (node == null) return -1;
            return node.height;
        }

        /// <summary>
        /// insert a node into AVL tree
        /// </summary>
        /// <param name="node">root</param>
        /// <param name="data">data</param>
        /// <returns>root</returns>
        public Node insertAVL(Node node, int data)
        {
            if (node == null) return new Node(data, 1, 0);
            if (data < node.data) node.left = insertAVL(node.left, data);
            else if (data > node.data) node.right = insertAVL(node.right, data);
            else
            {
                node.data = data;
                return node;
            }
            node.size = 1 + size(node.left) + size(node.right);
            node.height = 1 + Math.Max(height(node.left), height(node.right));

            return balance(node);
        }

        /// <summary>
        /// delete a note in AVL tree
        /// </summary>
        /// <param name="node">root</param>
        /// <param name="data">data</param>
        /// <returns>root</returns>
        public Node deleteAVL(Node node, int data)
        {
            if (node == null) return null;
            if (data < node.data) node.left = deleteAVL(node.left, data);
            else if (data > node.data) node.right = deleteAVL(node.right, data);
            else
            {
                if (node.left == null) return node.right;
                else if (node.right == null) return node.left;
                else
                {
                    Node next = node;
                    node = minNode(next.right);
                    node.right = deleteMin(next.right);
                    node.left = next.left;
                }
            }
            node.size = 1 + size(node.left) + size(node.right);
            node.height = 1 + Math.Max(height(node.left), height(node.right));
            return balance(node);
        }

        private Node balance(Node node)
        {
            int balF = balanceFactor(node);
            if (balF < -1)
            {
                if (balanceFactor(node.right) > 0)
                {
                    node.right = rotateRight(node.right);
                }
                node = rotateLeft(node);
            }
            else if (balF > 1)
            {
                if (balanceFactor(node.left) < 0)
                {
                    node.left = rotateLeft(node.left);
                }
                node = rotateRight(node);
            }
            return node;
        }

        private int balanceFactor(Node node)
        {
            return height(node.left) - height(node.right);
        }

        public Node rotateRight(Node node)
        {
            Node next = node.left;
            node.left = next.right;
            next.right = node;
            next.size = node.size;
            node.size = 1 + size(node.left) + size(node.right);
            next.height = 1 + Math.Max(height(next.left), height(next.right));
            node.height = 1 + Math.Max(height(node.left), height(node.right));
            return next;
        }

        public Node rotateLeft(Node node)
        {
            Node next = node.right;
            node.right = next.left;
            next.left = node;
            next.size = node.size;
            node.size = 1 + size(node.left) + size(node.right);
            next.height = 1 + Math.Max(height(next.left), height(next.right));
            node.height = 1 + Math.Max(height(node.left), height(node.right));
            return next;
        }

        public Node deleteMin(Node node)
        {
            if (node.left == null) return node.right;
            node.left = deleteMin(node.left);
            node.size = 1 + size(node.left) + size(node.right);
            node.height = 1 + Math.Max(height(node.left), height(node.right));
            return balance(node);
        }

        public Node deleteMax(Node node)
        {
            if (node.right == null) return node.left;
            node.right = deleteMax(node.right);
            node.size = 1 + size(node.left) + size(node.right);
            node.height = 1 + Math.Max(height(node.left), height(node.right));
            return balance(node);
        }

        /// <summary>
        /// Checks if AVL property is consistent in the subtree.
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public bool isAVL(Node node)
        {
            if (node == null) return true;
            int bf = balanceFactor(node);
            if (bf > 1 || bf < -1) return false;
            return isAVL(node.left) && isAVL(node.right);
        }

        /// <summary>
        /// Checks if the size of the subtree is consistent.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public bool isSizeConsistent(Node x)
        {
            if (x == null) return true;
            if (x.size != size(x.left) + size(x.right) + 1) return false;
            return isSizeConsistent(x.left) && isSizeConsistent(x.right);
        }

        /// <summary>
        /// Checks if rank is consistent.
        /// </summary>
        /// <returns></returns>
        public bool isRankConsistent(Node node)
        {
            for (int i = 0; i < node.size; i++)
                if (i != rank(node, select(node, i).data)) return false;

            int[] keys = levelorderTraversal(node);
            foreach (int key in keys)
                if (key != select(node, rank(node, key)).data) return false;
            return true;
        }





        // --------------------------------- Red-Black ---------------------------------











        //--------------------------------- SOLUTIONS ---------------------------------

        /*
         * Find the max sum path in a binary tree.
         */
        public int MaxPathSum(Node root)
        {
            MaxPathSum_DFS(root);
            return sum;
        }
        private int sum = int.MinValue;
        private int MaxPathSum_DFS(Node node)
        {
            if (node == null) return 0;

            int left = MaxPathSum_DFS(node.left);
            if (left < 0) left = 0;  // dismiss if < 0

            int right = MaxPathSum_DFS(node.right);
            if (right < 0) right = 0;  // dismiss if < 0

            // case : left + parent + right
            int lnr_sum = left + node.data + right;

            // sum to result
            sum = Math.Max(sum, lnr_sum);

            int ret = node.data + Math.Max(left, right);
            return ret;
        }



        /*
         * Check balance for a tree
         */
        bool isBalanced(Node root)
        {
            return heightDiff_DFS(root) >= 0;
        }
        public int heightDiff_DFS(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            // height of left tree
            int left_height = heightDiff_DFS(root.left);
            // height of right tree
            int right_height = heightDiff_DFS(root.right);

            // height difference between left and right should be less than 1
            if (Math.Abs(left_height - right_height) > 1 || left_height == -1 || right_height == -1)
            {
                return -1;
            }

            // return the maximum height
            return 1 + Math.Max(left_height, right_height);
        }



        /*
         * Find a sub tree which have the maximum sum value in BST
         */
        private int maxSumValue;
        public int maxSumBST(Node root)
        {
            maxSumValue = 0;
            findMaxSumBST(root);
            return maxSumValue;
        }
        //int[]{isBST(0/1), largest, smallest, sum}
        public int[] findMaxSumBST(Node node)
        {
            if (node == null)
            {
                return new int[] { 1, int.MinValue, int.MaxValue, 0 };
            }
            int[] left = findMaxSumBST(node.left);
            int[] right = findMaxSumBST(node.right);
            bool isBST = left[0] == 1 && right[0] == 1 && node.data > left[1] && node.data < right[2];
            int sum = node.data + left[3] + right[3];
            if (isBST)
            {
                maxSumValue = Math.Max(maxSumValue, sum);
            }
            return new int[] { isBST ? 1 : 0, Math.Max(node.data, right[1]), Math.Min(node.data, left[2]), sum };
        }



        /*
         * Return a right side view for a tree (DFS)
         */
        public List<int> rightSideView(Node root)
        {
            List<int> result = new List<int>();
            rightView(root, result, 0);
            return result;
        }
        public void rightView(Node curr, List<int> result, int currDepth)
        {
            if (curr == null)
            {
                return;
            }
            if (currDepth == result.Count)
            {
                result.Add(curr.data);
            }

            rightView(curr.right, result, currDepth + 1);
            rightView(curr.left, result, currDepth + 1);

        }



        /* https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/
         * LCA 最近公共祖先
         */
        public Node LowestCommonAncestor(Node root, Node p, Node q)
        {
            if (root == null || root.Equals(p) || root.Equals(q)) return root;
            Node left = LowestCommonAncestor(root.left, p, q);
            Node right = LowestCommonAncestor(root.right, p, q);
            if (left == null) return right;
            if (right == null) return left;
            return root;
        }



        //static void Main(string[] args)
        //{
        //    Node root = new Node(0);
        //    Node l = new Node(1);
        //    Node r = new Node(2);
        //    root.left = l;
        //    root.right = r;
        //    Node ll = new Node(3);
        //    l.left = ll;
        //    Node lr = new Node(4);
        //    l.right = lr;
        //    Node lll = new Node(9);
        //    lr.left = lll;


        //    postorderTraversal(root);
        //    Console.WriteLine();
        //    markLevel(root);

        //}
    }
    /* 
     * 交换左右子树 --- swapLeftRight
     * 层序遍历 --- levelorderTraversal
     * 标记层数 --- markLevel
     * 二叉树序列化 --- serialize, deserialize
     * 前序中序构造 --- buildTree_preIn
     * 后序中序构造 --- buildTree_postIn
     * 
     * --- BST ---
     * 二分查询 --- search, get, contains
     * 是否是BST --- isBST
     * 小于等于data的最大值节点 --- floor
     * 大于等于data的最小值节点 --- ceiling
     * 查找第k个最小值 --- select
     * 比data小的节点个数 --- rank
     * lo和hi之间的节点个数 --- size
     * 
     * --- AVL ---
     *  --- balance
     * 右旋转 --- rotateRight
     * 左旋转 --- rotateLeft
     * 是否是AVL --- isAVL
     *  --- isSizeConsistent
     *  --- isRankConsistent
     * 
     * 二叉树最大路径 --- MaxPathSum_DFS
     * 二叉树是否平衡 --- heightDiff_DFS
     * 最大二叉树子树 --- findMaxSumBST
     * 二叉树右视图 --- rightSideView
     * LCA 最近公共祖先 --- LowestCommonAncestor
     */
}
