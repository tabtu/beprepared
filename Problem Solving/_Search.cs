/*
 * Binary Search
 * 
 * 算法模板:
 * ---------------------------------

 // loop
int binary_search(T[] array, T target, int left, int right) {
    int result = -1;  // initial
    while (left < right) {
        int mid = left + (right - left) / 2;
        if (target < array[mid]) {  // left
            right = mid - 1;
        }
        else if (array[mid] < target) {  // right
            left = mid + 1;
        }
        else {  // target
            result = mid;
            break;
        }
    }
    return result;
}

// recursive
int binary_search(T[] array, T target, int left, int right) {
    if (left > right) return -1;  // boundary
    int mid = left + (right - left) / 2;
    if (target < array[mid]) {  // left
        return binary_search(array, target, left, mid - 1);
    }
    else if (array[mid] < target) {  // right
        return binary_search(array, target, mid + 1, right);
    }
    else {
        return mid;
    }
}

 * ---------------------------------
 * 
 */







using System;

namespace coding
{
    public class _Search
    {
        // --------------------------------- Binary Search ---------------------------------
        public int binary_search_lp(int[] array, int target, int left, int right)
        {
            int result = -1;  // initial
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (target < array[mid])
                {  // left
                    right = mid - 1;
                }
                else if (array[mid] < target)
                {  // right
                    left = mid + 1;
                }
                else
                {  // target
                    result = mid;
                    break;
                }
            }
            return result;
        }

        int binary_search_rc(int[] array, int target, int left, int right)
        {
            if (left > right) return -1;  // boundary
            int mid = left + (right - left) / 2;
            if (target < array[mid])
            {  // left
                return binary_search_rc(array, target, left, mid - 1);
            }
            else if (array[mid] < target)
            {  // right
                return binary_search_rc(array, target, mid + 1, right);
            }
            else
            {
                return mid;
            }
        }


        // --------------------------------- SOLUTIONS ---------------------------------

        /*
         * https://leetcode.com/problems/search-in-rotated-sorted-array/
         * 
         * Search in rotated sorted array.
         * 
         * There is an integer array nums sorted in ascending order (with distinct values).
         * Prior to being passed to your function, nums is possibly rotated at an unknown pivot index k (1 <= k < nums.length) such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). For example, [0,1,2,4,5,6,7] might be rotated at pivot index 3 and become [4,5,6,7,0,1,2].
         * Given the array nums after the possible rotation and an integer target, return the index of target if it is in nums, or -1 if it is not in nums.
         * You must write an algorithm with O(log n) runtime complexity.
         * 
         * Example 1:
         * Input: nums = [4,5,6,7,0,1,2], target = 0
         * Output: 4
         * Example 2:
         * Input: nums = [4,5,6,7,0,1,2], target = 3
         * Output: -1
         * Example 3:
         * Input: nums = [1], target = 0
         * Output: -1
         * 
         */
        public int searchInRotatedSorted(int[] nums, int target)
        {
            int lo = 0;
            int hi = nums.Length - 1;

            while (lo < hi)
            {
                int mid = (lo + hi) / 2;
                if (nums[mid] == target) return mid;

                if (nums[lo] <= nums[mid])
                {
                    if (target >= nums[lo] && target < nums[mid])
                    {
                        hi = mid - 1;
                    }
                    else
                    {
                        lo = mid + 1;
                    }
                }
                else
                {
                    if (target > nums[mid] && target <= nums[hi])
                    {
                        lo = mid + 1;
                    }
                    else
                    {
                        hi = mid - 1;
                    }
                }
            }
            return nums[lo] == target ? lo : -1;
        }


        /*
         * https://leetcode.com/problems/find-minimum-in-rotated-sorted-array
         * 
         * Find Minimum in Rotated Sorted Array
         * 
         */
        public int FindMin(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;

            while (l < r)
            {
                int mid = l + (r - l) / 2;
                if (nums[r] < nums[mid])
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid;
                }
            }
            return nums[r];
        }


        /*
         * https://leetcode.com/problems/find-peak-element/
         * 
         * Find Peak Element
         * 
         */
        public int FindPeakElement(int[] nums)
        {
            return peak(nums, 0, nums.Length - 1);
        }
        private int peak(int[] a, int l, int r)
        {
            if (l > r) return -1;

            int mid = l + (r - l) / 2;
            if ((mid == 0 || a[mid - 1] < a[mid]) && (mid == a.Length - 1 || a[mid] > a[mid + 1])) return mid;

            if (a[mid] < a[mid + 1])
                return peak(a, mid + 1, r);
            else
                return peak(a, l, mid - 1);
        }



        /*
         * https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
         * 
         * Search repeated range.
         * 
         * Given an array of integers nums sorted in non-decreasing order, find the starting and ending position of a given target value.
         * If target is not found in the array, return [-1, -1].
         * You must write an algorithm with O(log n) runtime complexity.
         * Example 1:
         * Input: nums = [5,7,7,8,8,10], target = 8
         * Output: [3,4]
         * Example 2:
         * Input: nums = [5,7,7,8,8,10], target = 6
         * Output: [-1,-1]
         * Example 3:
         * Input: nums = [], target = 0
         * Output: [-1,-1]
         * 
         */
        public int[] SearchRange(int[] nums, int target)
        {
            //寻找左边界(这里寻找第一个 >= target的索引)
            int leftIndex = search(nums, target);
            if (leftIndex >= nums.Length || nums[leftIndex] != target)
            {
                return new int[] { -1, -1 };
            }
            //寻找右边界(这里寻找第一个 >= target+1的索引)
            int rightIndex = search(nums, target + 1);
            return new int[] { leftIndex, rightIndex - 1 };
        }
        /**
         * 寻找第一个>=目标值的索引, 找不到则返回数组长度
         */
        private int search(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int mid = (right - left) / 2 + left;
                if (nums[mid] >= target)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }



        /*
         * https://leetcode.com/problems/h-index-ii/
         * 
         * Sorted array search H index.
         * 
         */
        public int HIndex(int[] citations)
        {
            int left = 0, len = citations.Length, right = len - 1, mid;
            while (left <= right)
            {
                mid = left + (right - left) / 2;
                if (citations[mid] >= (len - mid)) right = mid - 1;
                else left = mid + 1;
            }
            return len - left;
        }


        /*
         * https://leetcode.com/problems/longest-increasing-subsequence/
         * 
         * Longest increasing subsequence
         * 
         */
        public int LengthOfLIS(int[] nums)
        {
            int[] tails = new int[nums.Length];
            int size = 0;
            foreach (int x in nums)
            {
                int left = 0, right = size;
                while (left != right)
                {
                    int m = (left + right) / 2;
                    if (tails[m] < x)
                        left = m + 1;
                    else
                        right = m;
                }
                tails[left] = x;
                if (left == size) ++size;
            }
            return size;
        }


        /* 
         * https://leetcode.com/problems/maximum-subarray/
         * 
         * Maximum Subarray (divide and conquer)
         * 
         */
        public int maxSequence(int[] a, int l, int r)
        {
            // middle r = l + 1
            if (l > r) return 0;
            if (l == r) return a[l];
            int m = l + (r - l) / 2;

            // left side
            int lmax = a[m];
            int lsum = 0;
            for (int i = m; i >= l; i--)
            {
                lsum += a[i];
                if (lsum > lmax)
                {
                    lmax = lsum;
                }
            }

            // right side
            int rmax = a[m + 1];
            int rsum = 0;
            for (int i = m + 1; i <= r; i++)
            {
                rsum += a[i];
                if (rsum > rmax)
                {
                    rmax = rsum;
                }
            }

            return max3(lmax + rmax, maxSequence(a, l, m), maxSequence(a, m + 1, r));
        }

        public int max3(int i, int j, int k)
        {
            if (i >= j && i >= k) return i;
            return max3(j, k, i);
        }


        // --------------------------------- Main ---------------------------------
        // static void Main(string[] args)
        // {
        //     int[] arr = { -54, 35, 5, 87, 12, -4, 24, 765, -314, 53, -9087, -13245, 6364 };
        //     int[] res = quickSort3Way(arr);
        //     foreach (int i in res)
        //     {
        //         Console.Write(i + ", ");
        //     }
        // }
    }
    /* 
     * 
     * 桶排序 --- bucketSort
     * 堆排序 --- heapSort
     * 合并排序 --- mergeSort
     * 快速排序 --- quickSort
     * 2路快速排序 --- partition2Way
     * 3路快速排序 --- quickSort3Way
     * 
     * 查找第K大的数 --- findKthLargest
     * 排序(只有三种元素) --- sortColors
     * 论文指数 --- HIndex
     */
}
