using System;
using System.Collections.Generic;

namespace coding
{
    public class _Heap
    {
        protected bool isMax = true;  // maxHeap

        protected int[] data;
        protected int count;
        protected int capacity;

        public _Heap(int[] arr, bool im = true)
        {
            isMax = im;
            Heapify(arr, arr.Length);
        }

        public _Heap(int[] arr, int cnt, bool im = true)
        {
            isMax = im;
            Heapify(arr, cnt);
        }

        /// <summary>
        /// Heapify
        /// </summary>
        /// <param name="arr"></param>
        public void Heapify(int[] arr, int cnt)
        {
            capacity = arr.Length;
            data = new int[capacity + 1];
            count = cnt;

            for (int i = 0; i < capacity; i++)
            {
                data[i + 1] = arr[i];
            }

            for (int i = count / 2; i >= 1; i--)
            {
                sink(i);
            }
        }

        public void Push(int item)
        {
            Insert(item);
        }

        public int Pop()
        {
            return extractTop();
        }

        public int Peek()
        {
            return getTop();
        }

        public void Insert(int item)
        {
            if (count == capacity) return;
            data[count + 1] = item;
            count++;
            swim(count);
        }

        public int extractTop()
        {
            int ret = data[1];
            swap(1, count);
            count--;
            sink(1);
            return ret;
        }

        public int getTop()
        {
            return data[1];
        }

        public int Size()
        {
            return count;
        }

        public int Capacity()
        {
            return capacity;
        }

        public bool isEmpty()
        {
            return count == 0;
        }

        /// <summary>
        /// Swim/ShiftUp
        /// </summary>
        /// <param name="k"></param>
        private void swim(int k)
        {
            if (isMax == true)
            {
                while (k > 1 && data[k / 2] < data[k])
                {
                    swap(k, k / 2);
                    k /= 2;
                }
            }
            else
            {
                while (k > 1 && data[k / 2] > data[k])
                {
                    swap(k, k / 2);
                    k /= 2;
                }
            }
        }

        /// <summary>
        /// Sink/ShiftDown
        /// </summary>
        /// <param name="k"></param>
        private void sink(int k)
        {
            if (isMax == true)
            {
                while (2 * k <= count)
                {
                    int j = 2 * k;  // 在此轮循环中,data[k]和data[j]交换位置
                    if (j + 1 <= count && data[j + 1] > data[j])
                        j++;
                    // data[j] 是 data[2*k]和data[2*k+1]中的最大值
                    if (data[k] >= data[j]) break;
                    swap(k, j);
                    k = j;
                }
            }
            else
            {
                while (2 * k <= count)
                {
                    int j = 2 * k;  // 在此轮循环中,data[k]和data[j]交换位置
                    if (j + 1 <= count && data[j + 1] < data[j])
                        j++;
                    // data[j] 是 data[2*k]和data[2*k+1]中的最小值
                    if (data[k] <= data[j]) break;
                    swap(k, j);
                    k = j;
                }
            }
        }

        private void swap(int i, int j)
        {
            int t = data[i];
            data[i] = data[j];
            data[j] = t;
        }












        // --------------------------------- SOLUTIONS ---------------------------------

        /* https://leetcode-cn.com/problems/kth-largest-element-in-an-array
         * Find the Kth Largest Number
         */
        private static int findKthLargest(int[] nums, int k)
        {
            // min heap
            _Heap heap = new _Heap(new int[k + 1], 0, false);

            foreach (int ele in nums)
            {
                heap.Push(ele);
                // drop element with heap is over limit k
                if (heap.Count() > k)
                {
                    heap.Pop();
                }
            }
            return heap.Peek();
        }



        /*
         * Median Stream
         * 
         * You're given a list of n integers arr[0..(n-1)]. You must compute a list output[0..(n-1)] such that, for each index i (between 0 and n-1, inclusive), output[i] is equal to the median of the elements arr[0..i] (rounded down to the nearest integer).
         * The median of a list of integers is defined as follows. If the integers were to be sorted, then:
         * If there are an odd number of integers, then the median is equal to the middle integer in the sorted order.
         * Otherwise, if there are an even number of integers, then the median is equal to the average of the two middle-most integers in the sorted order.
         * Signature
         * int[] findMedian(int[] arr)
         * Input
         * n is in the range [1, 1,000,000].
         * Each value arr[i] is in the range [1, 1,000,000].
         * Output
         * Return a list of n integers output[0..(n-1)], as described above.
         * Example 1
         * n = 4
         * arr = [5, 15, 1, 3]
         * output = [5, 10, 5, 4]
         * The median of [5] is 5, the median of [5, 15] is (5 + 15) / 2 = 10, the median of [5, 15, 1] is 5, and the median of [5, 15, 1, 3] is (3 + 5) / 2 = 4.
         */
        private static int[] findMedian(int[] arr)
        {
            int[] res = new int[arr.Length];

            _Heap queLeft = new _Heap(new int[arr.Length / 2 + 1], 0, true);
            _Heap queRight = new _Heap(new int[arr.Length / 2 + 1], 0, false);

            for (int i = 0; i < arr.Length; i++)
            {
                // add element into two queues, and make them balance
                if (queLeft.isEmpty() || arr[i] <= queLeft.Peek())
                {
                    queLeft.Push(arr[i]);
                    if (queRight.Count() + 1 < queLeft.Count())
                    {
                        queRight.Push(queLeft.Pop());
                    }
                }
                else
                {
                    queRight.Push(arr[i]);
                    if (queRight.Count() > queLeft.Count())
                    {
                        queLeft.Push(queRight.Pop());
                    }
                }

                // get median number each round.
                if (queRight.Count() == queLeft.Count())
                {
                    res[i] = (queRight.Peek() + queLeft.Peek()) / 2;
                }
                else
                {
                    res[i] = queRight.Count() < queLeft.Count() ? queLeft.Peek() : queRight.Peek();
                }
            }
            return res;
        }





        // --------------------------------- Main ---------------------------------
        //static void Main(string[] args)
        //{
        //}
    }

    /*
     * 平衡函数 --- Heapify
     * 上浮函数 --- swim
     * 下沉函数 --- sink
     * 
     * 查找第K大的数 --- findKthLargest
     * 查找中位数 --- findMedian
     */
}
