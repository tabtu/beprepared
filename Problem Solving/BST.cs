
public class BinarySearchTree
{
    public static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        Node root = null;
        root = tree.insert(root, 4);
        tree.Insert(root, 2);
        tree.Insert(root, 1);
        tree.Insert(root, 3);
        tree.Insert(root, 6);
        tree.Insert(root, 5);

        Console.WriteLine("Minimum value of BST is " + tree.minvalue(root));
    }

    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int d)
        {
            data = d;
            left = right = null;
        }
    }

    public static Node head;

    // root, data
    public virtual Node Insert(Node node, int data)
    {

        // If the tree is empty, return a new, single node 
        if (node == null)
        {
            return (new Node(data));
        }
        else
        {
            // Otherwise, recur down the tree
            if (data <= node.data)
            {
                node.left = insert(node.left, data);
            }
            else
            {
                node.right = insert(node.right, data);
            }

            // return the (unchanged) node pointer
            return node;
        }
    }

    public virtual int MinValue(Node node)
    {
        Node current = node;

        // loop down to find the leftmost leaf
        while (current.left != null)
        {
            current = current.left;
        }
        return (current.data);
    }


}