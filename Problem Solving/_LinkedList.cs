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



        /*
         * https://leetcode.com/problems/merge-k-sorted-lists/
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



        /* 
         * https://leetcode.com/problems/linked-list-cycle-ii/
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

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (fast == slow)
                {
                    Node slow2 = head;
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



        /* 
         * https://leetcode.com/problems/rotate-list
         * 
         * Given the head of a linked list, rotate the list to the right by k places.
         * 
         * Example 1:
         * Input: head = [1,2,3,4,5], k = 2
         * Output: [4,5,1,2,3]
         * 
         */
        public Node RotateRight(Node head, int k)
        {
            if (head == null || k == 0)
            {
                return head;
            }
            Node p = head;
            int len = 1;
            while (p.next != null)
            {
                p = p.next;
                len++;
            }
            p.next = head;
            k %= len;
            for (int i = 0; i < len - k; i++)
            {
                p = p.next;
            }
            head = p.next;
            p.next = null;
            return head;
        }



        /*
         * https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
         * 
         * Remove duplicates elements in a sorted array, only leave maximum 2 same numbers. 
         * Example 1:
         * Input: nums = [1,1,1,1,1,1,2,2,2,2,2,2,2,3,4,4,4,5,5]
         * Output: 5, nums = [1,1,2,2,3,4,4,5,5]
         * 
         */
        public int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            foreach (int num in nums)
            {
                if (i < 2 || nums[i - 2] < num)
                {
                    nums[i] = num;
                    i++;
                }
            }
            return i;
        }


        /*
         * https://leetcode.com/problems/minimum-size-subarray-sum/
         * 
         * Minimum length of a sub-array, when sum is greater than target
         * 
         */
        public int MinSubArrayLen(int target, int[] nums)
        {
            if (nums.Length == 0) return 0;
            int result = int.MaxValue;
            int i = 0, j = 0;
            int cur = 0;
            while (j < nums.Length)
            {
                cur += nums[j++];
                while (cur >= target)
                {
                    result = Math.Min(result, j - i);
                    cur -= nums[i++];
                }
            }
            return result == int.MaxValue ? 0 : result;
        }


        /*
         * https://leetcode-cn.com/problems/interval-list-intersections/
         * 
         * 区间列表的交集
         * 
         */
        public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
        {
            List<int[]> res = new List<int[]>();
            int a = 0, b = 0;
            while (a < firstList.Length && b < secondList.Length)
            {
                // 确定左边界，两个区间左边界的最大值
                int left = Math.Max(firstList[a][0], secondList[b][0]);
                // 确定右边界，两个区间右边界的最小值
                int right = Math.Min(firstList[a][1], secondList[b][1]);
                // 左边界小于右边界则加入结果集
                if (left <= right)
                    res.Add(new int[] { left, right });
                // 右边界更大的保持不动，另一个指针移动，继续比较
                if (firstList[a][1] < secondList[b][1]) a++;
                else b++;
            }
            // 将结果转为数组
            return res.ToArray();
        }


        /* 
         * https://leetcode.com/problems/merge-intervals/
         * 
         * 合并区间
         * 
         */
        public int[][] MergeIntervals(int[][] intervals)
        {
            if (intervals.Length <= 1) return intervals;

            // Sort by ascending starting point
            Array.Sort<int[]>(intervals, (x, y) => x[0].CompareTo(y[0]));

            List<int[]> result = new List<int[]>();
            int[] newInterval = intervals[0];
            result.Add(newInterval);
            foreach (int[] interval in intervals)
            {
                // Overlapping intervals, move the end if needed
                if (interval[0] <= newInterval[1])
                {
                    newInterval[1] = Math.Max(newInterval[1], interval[1]);
                }
                // Disjoint intervals, add the new interval to the list
                else
                {
                    newInterval = interval;
                    result.Add(newInterval);
                }
            }

            return result.ToArray();
        }




        /* 
         * https://leetcode.com/problems/pancake-sorting/
         * 
         * 烧饼排序
         * 
         */
        public IList<int> PancakeSort(int[] arr)
        {
            res = new List<int>();
            pancakeSort(arr, arr.Length);
            return res;
        }
        // 记录反转操作序列
        private List<int> res;
        void pancakeSort(int[] arr, int n)
        {
            // base case
            if (n == 1) return;

            // 寻找最大饼的索引
            int maxCake = 0;
            int maxCakeIndex = 0;
            for (int i = 0; i < n; i++)
                if (arr[i] > maxCake)
                {
                    maxCakeIndex = i;
                    maxCake = arr[i];
                }

            // 第一次翻转，将最大饼翻到最上面
            pancakeReverse(arr, 0, maxCakeIndex);
            res.Add(maxCakeIndex + 1);
            // 第二次翻转，将最大饼翻到最下面
            pancakeReverse(arr, 0, n - 1);
            res.Add(n);

            // 递归调用
            pancakeSort(arr, n - 1);
        }
        void pancakeReverse(int[] arr, int i, int j)
        {
            while (i < j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++; j--;
            }
        }


        // --------------------------------- Main ---------------------------------
        //static void Main(string[] args)
        //{
        //}
    }
}
