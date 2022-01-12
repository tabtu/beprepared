using System;
using System.Collections.Generic;

namespace coding
{
    public class _LinkedList
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        /*
         * https://leetcode.com/problems/merge-k-sorted-lists/
         * 
         * Merge sorted linkedlist array, arrary length of K.
         * - use merge sort on array
         * - merge 2 sorted linkedlists
         * 
         */
        public ListNode MergeKLists(ListNode[] lists)
        {
            // ListNode result = null;
            // for (int i = 0; i < lists.Length; i++) {
            //     result = merge2Lists(lists[i], result);
            // }
            // return result;

            if (lists.Length == 0) return null;
            return mergeLists(lists, 0, lists.Length - 1);
        }

        public ListNode mergeLists(ListNode[] lists, int st, int ed)
        {
            if (st == ed) return lists[st];
            else if (st < ed)
            {
                int mid = (ed - st) / 2 + st;
                ListNode left = mergeLists(lists, st, mid);
                ListNode right = mergeLists(lists, mid + 1, ed);
                return merge2Lists(left, right);
            }
            else return null;
        }

        public ListNode merge2Lists(ListNode l0, ListNode l1)
        {
            ListNode head = new ListNode(0);
            ListNode cur = head;
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
         * https://leetcode.com/problems/remove-nth-node-from-end-of-list/
         * 
         * Delete the Nth node from end of the list.
         * - move fast pointer N times
         * - return head.next if fast == null
         * - move fast/slow pointer when fast.next == null
         * - remove slow.next pointer
         * 
         */
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            ListNode fast = head, slow = head;
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


        /* 
         * https://leetcode.com/problems/linked-list-cycle-ii/
         * 
         * first X slow: found a circle
         * slow2 = head
         * slow2 == slow: found circle start index
         * 
         */

        public ListNode DetectCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow)
                {
                    ListNode slow2 = head;
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


        //static void Main(string[] args)
        //{
        //}
    }
}
