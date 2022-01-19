using System;

namespace coding
{
    public class _Sort
    {
        // --------------------------------- Simple Sort ---------------------------------
        /// <summary>
        /// Selection sort
        /// </summary>
        /// <param name="a">array</param>
        /// <returns>sorted array</returns>
        public void SelectionSort(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int min = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < a[min]) min = j;
                }
                swap(ref a[i], ref a[min]);
            }
        }

        /// <summary>
        /// Insertion sort
        /// </summary>
        /// <param name="a">array</param>
        /// <returns>sorted array</returns>
        public void InsertionSort(int[] a)
        {
            int n = a.Length;
            for (int i = 1; i < n; i++)
            {
                for (int j = i; j > 0 && a[j] < a[j - 1]; j--)
                {
                    swap(ref a[j], ref a[j - 1]);
                }
            }
        }

        /// <summary>
        /// Shell sort
        /// </summary>
        /// <param name="a">array</param>
        /// <returns>sorted array</returns>
        public void ShellSort(int[] a)
        {
            int n = a.Length;

            // 3x+1 increment sequence:  1, 4, 13, 40, 121, 364, 1093, ... 
            int h = 1;
            while (h < n / 3) h = 3 * h + 1;

            while (h >= 1)
            {
                // h-sort the array
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j >= h && a[j] < a[j - h]; j -= h)
                    {
                        swap(ref a[j], ref a[j - h]);
                    }
                }
                h /= 3;
            }
        }





        // --------------------------------- Bucket Sort ---------------------------------
        /// <summary>
        /// Bucket sort
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] bucketSort(int[] nums)
        {
            /*桶排序：
                先找到追到最大最小的值，（假设最大max，最小min）
                桶数的计算：(max - min) / arr.Length + 1。
                然后将需要排序的数值一一对应放到各个所属范围的桶里面，
                然后把每个桶里面的数值进行基本排序，最后把排序后的数值按次序拿出来
             */
            List<int> numList = new List<int>();
            int min = nums.Min();
            int max = nums.Max();
            // 计算桶的数量
            int b_num = (max - min) / nums.Length + 1;
            // 定义桶
            List<int>[] buckets = new List<int>[b_num];
            // 初始化桶
            for (int i = 0; i < b_num; i++)
            {
                buckets[i] = new List<int>();
            }
            //分配待排序的数到各个桶里
            for (int i = 0; i < nums.Length; i++)
            {
                int index = (nums[i] - min) / nums.Length;
                buckets[index].Add(nums[i]);
            }
            //最后把各个桶里的数据拿出
            for (int i = 0; i < b_num; i++)
            {
                // 桶内排序
                buckets[i].Sort();
                // 合并桶
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    numList.Add(buckets[i][j]);
                }
            }
            int[] arr = numList.ToArray();
            return arr;
        }





        // --------------------------------- Heap Sort ---------------------------------
        /// <summary>
        /// Heap sort
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public void heapSort(int[] arr)
        {
            int n = arr.Length;

            // 注意，此时我们的堆是从0开始索引的
            // 从(最后一个元素的索引-1)/2开始
            // 最后一个元素的索引 = n-1
            for (int i = (n - 1 - 1) / 2; i >= 0; i--)
                shiftDown(arr, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                swap(ref arr[0], ref arr[i]);
                shiftDown(arr, i, 0);
            }
        }
        private void shiftDown(int[] arr, int n, int k)
        {
            while (2 * k + 1 < n)
            {
                //左孩子节点
                int j = 2 * k + 1;
                //右孩子节点比左孩子节点大
                if (j + 1 < n && arr[j + 1] > arr[j])
                    j += 1;
                //比两孩子节点都大
                if (arr[k] >= arr[j]) break;
                //交换原节点和孩子节点的值
                swap(ref arr[k], ref arr[j]);
                k = j;
            }
        }





        // --------------------------------- Merge Sort ---------------------------------
        /// <summary>
        /// Merge sort
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Quick sort
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
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

        private bool isSorted(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
                if (a[i] < a[i - 1]) return false;
            return true;
        }

        // sorted by gap length of h
        private bool isHsorted(int[] a, int h)
        {
            for (int i = h; i < a.Length; i++)
                if (a[i] < a[i - h]) return false;
            return true;
        }





        // --------------------------------- SOLUTIONS ---------------------------------

        /* https://leetcode.com/problems/kth-largest-element-in-an-array
         * Find the Kth largest number in an array (partition)
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
        /*
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
            swap(ref nums[left], ref nums[rdp]);

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



        /* https://leetcode.com/problems/sort-colors/
         * array only have 0, 1, 2 (merge)
         */
        public void sortColors(int[] nums)
        {
            int len = nums.length;
            if (len < 2)
            {
                return;
            }

            // all in [0, zero) = 0
            // all in [zero, i) = 1
            // all in [two, len - 1] = 2

            // 循环终止条件是 i == two，那么循环可以继续的条件是 i < two
            // 为了保证初始化的时候 [0, zero) 为空，设置 zero = 0，
            // 所以下面遍历到 0 的时候，先交换，再加
            int zero = 0;  // left

            // 为了保证初始化的时候 [two, len - 1] 为空，设置 two = len
            // 所以下面遍历到 2 的时候，先减，再交换
            int two = len;  // right
            int i = 0;
            // 当 i == two 上面的三个子区间正好覆盖了全部数组
            // 因此，循环可以继续的条件是 i < two
            while (i < two)
            {
                if (nums[i] == 0)
                {
                    swap(nums, i, zero);
                    zero++;
                    i++;
                }
                else if (nums[i] == 1)
                {
                    i++;
                }
                else
                {
                    two--;
                    swap(nums, i, two);
                }
            }
        }



        /* https://leetcode.com/problems/h-index/
         * H index (至少N篇论文出现至少N次)
         * 桶排序寻找桶中数量大于桶序号
         */
        public int HIndex(int[] citations)
        {
            int n = citations.Length;
            int[] buckets = new int[n + 1];
            foreach (int c in citations)
            {
                if (c >= n)
                {
                    buckets[n]++;
                }
                else
                {
                    buckets[c]++;
                }
            }
            int count = 0;
            for (int i = n; i >= 0; i--)
            {
                count += buckets[i];
                if (count >= i)
                {
                    return i;
                }
            }
            return 0;
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
