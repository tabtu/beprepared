using System;
using System.Collections.Generic;

namespace coding
{
    public class _LinkedList
    {
        public class Node
        {
            public int val;
            public Node next;
            public Node(int val = 0, Node next = null)
            {
                this.val = val;
                this.next = next;
            }
        }



        /*  https://leetcode.com/problems/merge-k-sorted-lists/
         * 
         * Merge sorted linkedlist array, arrary length of K.
         * - use merge sort on array
         * - merge 2 sorted linkedlists
         * 
         */
        public Node MergeKLists(Node[] lists)
        {
            // Node result = null;
            // for (int i = 0; i < lists.Length; i++) {
            //     result = merge2Lists(lists[i], result);
            // }
            // return result;

            if (lists.Length == 0) return null;
            return mergeLists(lists, 0, lists.Length - 1);
        }
        public Node mergeLists(Node[] lists, int st, int ed)
        {
            if (st == ed) return lists[st];
            else if (st < ed)
            {
                int mid = (ed - st) / 2 + st;
                Node left = mergeLists(lists, st, mid);
                Node right = mergeLists(lists, mid + 1, ed);
                return merge2Lists(left, right);
            }
            else return null;
        }
        public Node merge2Lists(Node l0, Node l1)
        {
            Node head = new Node(0);
            Node cur = head;
            while (l0 != null && l1 != null)
            {
                if (l0.val < l1.val)
                {
                    cur.next = l0;
                    l0 = l0.next;
                    cur = cur.next;
                }
                else
                {
                    cur.next = l1;
                    l1 = l1.next;
                    cur = cur.next;
                }
            }
            while (l0 != null)
            {
                cur.next = l0;
                l0 = l0.next;
                cur = cur.next;
            }
            while (l1 != null)
            {
                cur.next = l1;
                l1 = l1.next;
                cur = cur.next;
            }
            return head.next;
        }

        /*
         * 最小堆(最小优先队列)完成算法
         * - 堆定义元数据为 <Node, Node.val> 最小堆
         * - 从堆顶取元数据, 将推出节点的下一位节点放回堆
         * - 每次从堆中取出元素均为K个链表最小值, 直到所有链表均为空
         */
        public Node MergeKLists2(Node[] lists)
        {
            if (lists.Length == 0) return null;
            // 虚拟头结点
            Node dummy = new Node(-1);
            Node p = dummy;
            // core 6.0
            PriorityQueue<Node, int> pq = new PriorityQueue<Node, int>();

            // 将 k 个链表的头结点加入最小堆
            foreach (Node head in lists)
            {
                if (head != null)
                    pq.Enqueue(head, head.val);
            }

            while (pq.Count > 0)
            {
                // 获取最小节点，接到结果链表中
                Node node = pq.Dequeue();
                p.next = node;
                if (node.next != null)
                {
                    pq.Enquque(node.next);
                }
                // p 指针不断前进
                p = p.next;
            }
            return dummy.next;
        }



        /* https://leetcode.com/problems/remove-nth-node-from-end-of-list/
         * 
         * Delete the Nth node from end of the list.
         * - move fast pointer N times
         * - return head.next if fast == null
         * - move fast/slow pointer when fast.next == null
         * - remove slow.next pointer
         * 
         */
        public Node RemoveNthFromEnd(Node head, int n)
        {
            Node fast = head, slow = head;
            for (int i = 0; i < n; i++) fast = fast.next;
            if (fast == null) return head.next;
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            slow.next = slow.next.next;
            return head;
        }



        /* https://leetcode.com/problems/linked-list-cycle-ii/
         * 
         * first X slow: found a circle
         * slow2 = head
         * slow2 == slow: found circle start index
         * 
         * Given the head of a linked list, return the node where the cycle begins. If there is no cycle, return null.
         * There is a cycle in a linked list if there is some node in the list that can be reached again by continuously following the next pointer. Internally, pos is used to denote the index of the node that tail's next pointer is connected to (0-indexed). It is -1 if there is no cycle. Note that pos is not passed as a parameter.
         * Do not modify the linked list.
         * 
         * Example 1:
         * Input: head = [3,2,0,-4], pos = 1
         * 3 -> 2 -> 0 -> -4 -> index(1)
         * Output: tail connects to node index 1
         * Explanation: There is a cycle in the linked list, where tail connects to the second node.
         * Example 2:
         * Input: head = [1,2], pos = 0
         * 1 -> 2 -> index(0)
         * Output: tail connects to node index 0
         * Explanation: There is a cycle in the linked list, where tail connects to the first node.
         */
        public Node DetectCycle(Node head)
        {
            Node slow = head;
            Node fast = head;
            // 快指针作为边界
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                // 第一次相遇
                if (fast == slow)
                {
                    Node slow2 = head;
                    // 调整为相同速度 第二次相遇
                    while (slow2 != slow)
                    {
                        slow = slow.next;
                        slow2 = slow2.next;
                    }
                    return slow;
                }
            }
            return null;
        }



        /* https://leetcode.com/problems/rotate-list
         * 
         * Given the head of a linked list, rotate the list to the right by k places.
         * Example 1:
         * Input: head = [1,2,3,4,5], k = 2
         * Output: [4,5,1,2,3]
         */
        public Node RotateRight(Node head, int k)
        {
            if (head == null || k == 0)
            {
                return head;
            }
            Node p = head;
            int len = 1;
            // 计算链表长度
            while (p.next != null)
            {
                p = p.next;
                len++;
            }
            // 回环连接切割点到头节点
            p.next = head;
            k %= len;
            // 移动到切割点
            for (int i = 0; i < len - k; i++)
            {
                p = p.next;
            }
            // 切割
            head = p.next;
            p.next = null;
            return head;
        }





        // --------------------------------- Main ---------------------------------
        //static void Main(string[] args)
        //{
        //}
    }

    /*
     * 合并多个链表 --- MergeKLists(Merge), MergeKLists2(Heap)
     * 删除末尾N个节点 --- RemoveNthFromEnd
     * 循环指针起点 --- DetectCycle
     * 向右回转 --- RotateRight
     */
}
