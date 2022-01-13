





using System;
using System.Collections.Generic;

namespace coding
{
    public class _Heap
    {
        protected bool isMax = true;  // maxHeap

        protected int[] data;
        protected int count;

        public _Heap(bool im, int[] arr)
        {
            isMax = im;
            Heapify(arr);
        }

        /// <summary>
        /// Heapify
        /// </summary>
        /// <param name="arr"></param>
        public void Heapify(int[] arr)
        {
            int n = arr.Length;
            data = new int[n + 1];
            count = n;

            for (int i = 0; i < n; i++)
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







        // --------------------------------- Main ---------------------------------
        //static void Main(string[] args)
        //{
        //}
    }
}
