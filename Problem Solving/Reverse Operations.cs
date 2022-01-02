/*
 * Reverse Operations
 * 
 * You are given a singly-linked list that contains N integers. A subpart of the list is a contiguous set of even elements, bordered either by either end of the list or an odd element. For example, if the list is [1, 2, 8, 9, 12, 16], the subparts of the list are [2, 8] and [12, 16].
 * Then, for each subpart, the order of the elements is reversed. In the example, this would result in the new list, [1, 8, 2, 9, 16, 12].
 * Implementation detail:
 * You must use the following definition for elements in the linked list:
 * class Node {
 *     int data;
 *     Node next;
 * }
 * 
 *
 *
*/

public class Solution
{
    static void Main(string[] args)
    {
        //Console.WriteLine(findEncryptedWord("123456"));
        test_ReverseNodeList();
    }

    public static void test_ReverseNodeList()
    {
        int[] input = { 1, 2, 4, 6, 8, 9, 10 };
        RNode head = new RNode(input[0]);
        RNode node = head;
        for (int i = 1; i < input.Length; i++)
        {
            RNode nd = new RNode(input[i]);
            node.next = nd;
            node = nd;
        }


        RNode p = ReverseNodeList(head);
        while (p != null)
        {
            Console.Write(p.data + " ");
            p = p.next;
        }
    }

    public class RNode
    {
        public int data;
        public RNode next;
        public RNode() { }
        public RNode(int d)
        {
            data = d;
            next = null;
        }
    }

    // double pointer
    // =,1,5,3,2,4,6,8,9,10
    // =,1,5,3,8,6,4,2,9,10
    // i,j:
    // i == j
    // - i++,j++  // when odd
    // - j++  // when even
    // i != j
    // j.next % 2 == 1 : i++  // link i to subtail
    // j.next % 2 == 0 : j++  //

    public static RNode ReverseNodeList(RNode head)
    {
        // put 1 empty node and 2 odd nodes before head, fit for point i,j 
        RNode root = new RNode();
        RNode first = new RNode(1);
        RNode second = new RNode(1);
        root.next = first;
        first.next = second;
        second.next = head;

        // real node locate at the next node at second.
        if (second.next != null)
        {
            RNode i = root.next;
            RNode j = i.next;
            while (j.next != null)
            {
                if (j.next.data % 2 == 1 && i.next == j)
                {
                    j = j.next;
                    i = i.next;
                }
                else
                {
                    if (j.next.data % 2 == 1)
                    {
                        i = i.next;
                        RNode c = j.next;
                        // put i.next to j.next, partial reverse.
                        while (i.next != j)
                        {
                            RNode k = i.next;
                            i.next = k.next;
                            k.next = j.next;
                            j.next = k;
                        }
                        i = c;
                        j = i.next;
                    }
                    else { j = j.next; }
                }
            }
        }
        return root.next.next.next;
    }
}