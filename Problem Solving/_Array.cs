using System;
using System.Collections.Generic;

namespace coding
{
    public class _Arrays
    {



        /* https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/
         * (滑动窗口) Remove duplicates elements in a sorted array, only leave maximum 2 same numbers. 
         */
        public int RemoveDuplicates(int[] nums)
        {
            int i = 0;
            foreach (int num in nums)
            {
                // 最多2个相同元素
                if (i < 2 || nums[i - 2] < num)
                {
                    nums[i] = num;
                    i++;
                }
            }
            return i;
        }



        /* https://leetcode.com/problems/minimum-size-subarray-sum/
         * (滑动窗口) Minimum length of a sub-array, when sum is greater than target
         */
        public int MinSubArrayLen(int target, int[] nums)
        {
            if (nums.Length == 0) return 0;
            int result = int.MaxValue;
            int i = 0, j = 0;
            int cur = 0;
            // 右边界达到最大结束
            while (j < nums.Length)
            {
                // 右边界扩展
                cur += nums[j++];
                while (cur >= target)
                {
                    // 比较最小值
                    result = Math.Min(result, j - i);
                    // 左边界缩小
                    cur -= nums[i++];
                }
            }
            return result == int.MaxValue ? 0 : result;
        }



        /* https://leetcode.com/problems/longest-consecutive-sequence/
         * 给定一个未排序的整数数组 nums ，找出数字连续的最长序列（不要求序列元素在原数组中连续）的长度。
         */
        public int LongestConsecutive(int[] nums)
        {
            // 初始化HashSet
            HashSet<int> hs = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                hs.Add(nums[i]);
            }

            int cnt = 0;
            // 遍历数组
            for (int i = 0; i < nums.Length; i++)
            {
                // 只有当当前元素之前一位(连续数字)数字不在哈希表中时进行后续比对
                if (!hs.Contains(nums[i] - 1))
                {
                    int rnd = 1;  // 重置计数器
                    int cur = nums[i] + 1;  // 从当前元素数值后一位开始比对
                    while (hs.Contains(cur))  // 当找到连续数值时继续
                    {
                        rnd++;
                        cur++;
                    }
                    // 记录最大值
                    cnt = cnt < rnd ? rnd : cnt;
                }
            }
            return cnt;
        }


        /* https://leetcode.com/problems/maximum-gap/
         * (Bucket Sort) 给定一个无序的数组，找出数组在排序之后，相邻元素之间最大的差值。
         */
        public static int MaximumGap(int[] nums)
        {
            if (nums.Length < 2) return 0;

            int min = nums.Min();
            int max = nums.Max();

            // 设置桶间距
            int gap = (max - min) / (nums.Length - 1);
            if (gap == 0) gap++;  // 至少为1
            // 初始化桶
            int len = (max - min) / gap + 1;
            int[] tmax = new int[len];
            int[] tmin = new int[len];

            // 扫描目标数组
            for (int i = 0; i < nums.Length; i++)
            {
                // 判断元素进入哪个桶
                int idx = (nums[i] - min) / gap;
                if (nums[i] > tmax[idx]) tmax[idx] = nums[i];  // 桶中最大值
                if (tmin[idx] == 0 || nums[i] < tmin[idx]) tmin[idx] = nums[i];  // 桶中最小值
            }

            int distance = 0;
            for (int i = 0; i < len; i++)
            {
                // 依次查询桶间最大间距
                if (distance < tmin[i] - min) distance = tmin[i] - min;
                if (tmax[i] != 0) min = tmax[i];
            }
            return distance;
        }



        /* 
         * 找到小于 N 的所有质数/素数
         */
        public IList<int> findPrimes(int n)
        {
            bool[] isPrime = new bool[n];
            // 初始化
            Array.Fill<bool>(isPrime, true);
            // 从2开始, 只需要查询到i < √￣n
            for (int i = 2; i * i < n; i++)
            {
                if (isPrime[i])
                {
                    // 找到所有可以i的倍数并标记非质数
                    for (int j = i * i; j < n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            IList<int> res = new List<int>();
            for (int i = 2; i < n; i++)
            {
                if (isPrime[i]) res.Add(i);
            }

            return res;
        }



        /* https://leetcode.com/problems/daily-temperatures/
         * (单调栈 Monotone-stack) 相隔最近升温需要等待天数
         */
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] ans = new int[temperatures.Length];
            Stack<int> s = new Stack<int>();
            for (int i = 0; i < temperatures.Length; i++)
            {
                // 当遇到温度身高的一天时，将栈中元素全部弹出（反向填充之前没有的）
                while (s.Count() > 0 && temperatures[i] > temperatures[s.Peek()])
                {
                    //填充之前的空缺，当前天数(from begining) - 栈顶(from begining)
                    ans[s.Peek()] = i - s.Pop();
                }
                // 将小于栈顶元素对应温度的天数直接入栈
                s.Push(i);
            }
            return ans;
        }



        /* https://leetcode.com/problems/next-greater-element-i/
         * (单调栈 Monotone-stack) 下一个更大的数
         */
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> kvs = new Dictionary<int, int>();
            Stack<int> stack = new Stack<int>();
            for (int i = nums2.Length - 1; i >= 0; i--)
            {
                // 元素大于栈顶
                while (stack.Count > 0 && nums2[i] > stack.Peek())
                {
                    stack.Pop();
                }
                // 栈非空
                if (stack.Count > 0)
                {
                    kvs.Add(nums2[i], stack.Peek());
                }
                // 元素小于栈顶
                stack.Push(nums2[i]);
            }
            // 填充答案
            for (int i = 0; i < nums1.Length; i++)
            {
                nums1[i] = kvs.GetValueOrDefault(nums1[i], -1);
            }
            return nums1;
        }

        /* https://leetcode.com/problems/next-greater-element-ii/
         * (单调栈 Monotone-stack) 下一个更大的数(循环数组)
         */
        public int[] NextGreaterElements(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            Array.Fill(res, -1);
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n * 2; i++)
            {
                while (stack.Count > 0 && nums[stack.Peek()] < nums[i % n])
                    res[stack.Pop()] = nums[i % n];
                stack.Push(i % n);
            }
            return res;
        }



        /* https://leetcode-cn.com/problems/interval-list-intersections/
         * 区间列表的交集
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



        /* https://leetcode.com/problems/merge-intervals/
         * 合并区间
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



        /* https://leetcode.com/problems/pancake-sorting/
         * 烧饼排序, 每次都翻转最大值到当前
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
            {
                if (arr[i] > maxCake)
                {
                    maxCakeIndex = i;
                    maxCake = arr[i];
                }
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
    /* 
     * 删除有序数组中的重复项 --- RemoveDuplicates --- [滑动窗口]
     * 长度最小的子数组 --- MinSubArrayLen --- [滑动窗口]
     * 连续的最长序列 --- LongestConsecutive --- [哈希表]
     * 相邻元素之间最大的差值 --- MaximumGap --- [桶排序]
     * 找到小于 N 的所有质数/素数 --- findPrimes --- [数组]
     * 最近升温需要等待天数 --- DailyTemperatures --- [单调栈]
     * 下一个更大的数 --- NextGreaterElement --- [单调栈]
     * 下一个更大的数(循环数组) --- NextGreaterElements --- [单调栈]
     * 区间列表的交集 IntervalIntersection
     * 合并区间 MergeIntervals
     * 烧饼排序 PancakeSort
     */
}
