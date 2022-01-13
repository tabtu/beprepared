// merge sort
// quick sort
// 3 way quick sort
// bucket sort

using System;
using System.Collections.Generic;

namespace coding
{
    public class _Sort
    {







        // --------------------------------- Merge Sort ---------------------------------
        public int[] mergeSort(int[] arr)
        {
            int[] res = new int[arr.Length];
            arr.CopyTo(res, 0);
            mergeSort(res, 0, arr.Length - 1);
            return res;
        }

        public void mergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle point
                int m = l + (r - l) / 2;

                mergeSort(arr, l, m);
                mergeSort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }
        private void merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two subarrays to be merged
            int nL = m - l + 1;
            int nR = r - m;
            int[] arrL = new int[nL];
            int[] arrR = new int[nR];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < nL; ++i)
                arrL[i] = arr[l + i];
            for (j = 0; j < nR; ++j)
                arrR[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < nL && j < nR)
            {
                if (arrL[i] <= arrR[j])
                {
                    arr[k] = arrL[i];
                    i++;
                }
                else
                {
                    arr[k] = arrR[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < nL)
            {
                arr[k] = arrL[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < nR)
            {
                arr[k] = arrR[j];
                j++;
                k++;
            }
        }





        // --------------------------------- Quick Sort ---------------------------------
        public int[] quickSort(int[] arr)
        {
            int[] result = new int[arr.Length];
            arr.CopyTo(result, 0);
            // quickSort(result, 0, arr.Length - 1);
            // quickSort2Way(result, 0, arr.Length - 1);
            quickSort3Way(result, 0, arr.Length - 1);
            return result;
        }

        /// <summary>
        /// quick sort with random pivot
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l">left/low</param>
        /// <param name="r">right/high</param>
        public void quickSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int p = partition(arr, l, r);
                quickSort(arr, l, p - 1);
                quickSort(arr, p + 1, r);
            }
        }
        private int partition(int[] arr, int l, int r)
        {
            // random pivot
            Random random = new Random();
            int rdp = random.Next(l, r);
            swap(ref arr[r], ref arr[rdp]);

            // pivot value at right
            int pivot = arr[r];

            // Index of smaller element and indicates the right position of pivot found so far
            int i = (l - 1);

            for (int j = l; j <= r - 1; j++)
            {
                // If current element is smaller than the pivot
                if (arr[j] < pivot)
                {
                    // Increment index of smaller element
                    i++;
                    swap(ref arr[i], ref arr[j]);
                }
            }
            swap(ref arr[i + 1], ref arr[r]);
            return (i + 1);
        }

        /// <summary>
        /// 2 way quick sort with random pivot
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l">left/low</param>
        /// <param name="r">right/high</param>
        public void quickSort2Way(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int p = partition2Way(arr, l, r);

                quickSort(arr, l, p - 1);
                quickSort(arr, p + 1, r);
            }
        }
        private int partition2Way(int[] arr, int l, int r)
        {
            // random pivot
            Random random = new Random();
            int rdp = random.Next(l, r);
            swap(ref arr[l], ref arr[rdp]);

            // pivot value at left
            int pivot = arr[l];
            // 
            int i = l + 1;
            int j = r;

            while (true)
            {
                while (i <= r && arr[i] < pivot)
                    i++;
                while (j >= l + 1 && arr[j] > pivot)
                    j--;
                if (i > j)
                    break;
                swap(ref arr[i], ref arr[j]);
                i++;
                j--;
            }
            swap(ref arr[l], ref arr[j]);
            return j;
        }

        /// <summary>
        /// 3 way quick sort with random pivot
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="l">left/low</param>
        /// <param name="r">right/high</param>
        private void quickSort3Way(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // random pivot
                Random random = new Random();
                int rdp = random.Next(l, r);
                swap(ref arr[l], ref arr[rdp]);

                // define 3 partitions
                int pivot = arr[l];
                int lt = l;     // arr[l+1...lt] < pivot
                int gt = r + 1; // arr[gt...r] > pivot
                int i = l + 1;    // arr[lt+1...i) == pivot

                while (i < gt)  // traversal
                {
                    if (arr[i] < pivot)
                    {
                        // to left
                        swap(ref arr[i], ref arr[lt + 1]);
                        i++;
                        lt++;
                    }
                    else if (arr[i] > pivot)
                    {
                        // to right
                        swap(ref arr[i], ref arr[gt - 1]);
                        gt--;
                    }
                    else  // arr[i] == v
                    {
                        i++;
                    }
                }
                swap(ref arr[l], ref arr[lt]);

                quickSort3Way(arr, l, lt - 1);
                quickSort3Way(arr, gt, r);
            }
        }





        // --------------------------------- helping ---------------------------------
        private void swap(ref int i, ref int j)
        {
            int tmp = i;
            i = j;
            j = tmp;
        }





        // --------------------------------- SOLUTIONS ---------------------------------

        /*
         * https://leetcode.com/problems/kth-largest-element-in-an-array
         * 
         * Find the Kth largest number in an array
         * 
         */
        public int findKthLargest(int[] nums, int k)
        {
            int len = nums.Length;
            int left = 0;
            int right = len - 1;

            // 转换一下，第 k 大元素的下标是 len - k
            int target = len - k;

            while (true)
            {
                int index = partitionKth(nums, left, right);
                if (index == target)
                {
                    return nums[index];
                }
                else if (index < target)
                {
                    left = index + 1;
                }
                else
                {
                    right = index - 1;
                }
            }
        }
        /**
         * 对数组 nums 的子区间 [left..right] 执行 partition 操作，返回 nums[left] 排序以后应该在的位置
         * 在遍历过程中保持循环不变量的定义：
         * nums[left + 1..j] < nums[left]
         * nums(j..i) >= nums[left]
         */
        public int partitionKth(int[] nums, int left, int right)
        {
            // random pivot
            Random random = new Random();
            int rdp = random.Next(left, right);
            swap(ref arr[left], ref arr[rdp]);

            int pivot = nums[left];
            int j = left;
            for (int i = left + 1; i <= right; i++)
            {
                if (nums[i] < pivot)
                {
                    // j 的初值为 left，先右移，再交换，小于 pivot 的元素都被交换到前面
                    j++;
                    swap(ref nums[i], ref nums[j]);
                }
            }
            // 在之前遍历的过程中，满足 nums[left + 1..j] < pivot，并且 nums(j..i) >= pivot
            swap(ref nums[j], ref nums[left]);
            // 交换以后 nums[left..j - 1] < pivot, nums[j] = pivot, nums[j + 1..right] >= pivot
            return j;
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
}
