
/* Question 1:
 * implement interface of LRU algorithm.
 * interface show below
interface featureLRU {
   void put(K k, V v);
   void remove(K k);
   T get(K k);
   T last();
}
 * 
 * Example: 
 * [put, 20, 30],[put, 10, 60],[get, 20],[last],[put, 20, 40],[last],[remove,20],[last]
 * [],[],[30],[60],[],[40],[],[60]
 */



/* Question 2:
 * input to simulate CPU working time.
 * Example:
 * input : [foo,20,b],[bar,30,b],[bar,50,e],[foo,100,e]
 * output : [foo,60],[bar,20]
 * explaination : [name,time,action], 'b' stand for begin, 'e' stand for end.
 */


using System;
using System.Linq;
using System.Collections.Generic;

namespace coding
{
    public class FB_screening
    {
        public FB_screening()
        {
            /* Testing on question 1 start */

            /* Testing on question 1 end */



            /* Testing on question 2 start */

            /* Testing on question 2 start */

        }

    }

    /* ----------- Solution 1 start ----------- */
    public interface FeatureLRU
    {
        void put(int k, int v);
        void remove(int k);
        int get(int k);
        int last();
    }

    public class ImplementLRU : FeatureLRU
    {
        Dictionary<int, int> kvs;
        // PriorityQueue is the first choice at the first time.
        // but later, I found sortedlist can have more supported api to show on solving this problem.
        SortedList<int, long> cache;

        public ImplementLRU()
        {
            kvs = new Dictionary<int, int>();
            cache = new SortedList<int, long>();
        }

        public void put(int k, int v)
        {
            // update key-value in kvs
            if (kvs.ContainsKey(k)) kvs.Remove(k);
            kvs.Add(k, v);

            // update cache seq by datetime now
            if (cache.ContainsKey(k)) cache.Remove(k);
            cache.Add(k, -1 * DateTime.Now.ToBinary());
        }

        public void remove(int k)
        {
            if (kvs.ContainsKey(k)) kvs.Remove(k);
            if (cache.ContainsKey(k)) cache.Remove(k);
        }

        public int get(int k)
        {
            if (kvs.ContainsKey(k)) return kvs.GetValueOrDefault(k);
            if (cache.ContainsKey(k))
            {
                cache.Remove(k);
                cache.Add(k, -1 * DateTime.Now.ToBinary());
            }
            return -1;  // if failure on finding
        }

        public int last()
        {
            if (cache.Count > 0) return kvs.GetValueOrDefault(cache.First().Key);
            return -1;
        }
    }
    /* ----------- Solution 1 end ----------- */


    /* ----------- Solution 2 start ----------- */
    // Use stack on saving process state.
    // 'b' -> push into stack
    // 'e' -> pop out of stack
    // calculating the gap between 'b' and 'e'
    public class SimulatingCPU
    {
        Stack<KeyValuePair<string, int>> stack;

        public SimulatingCPU()
        {
            stack = new Stack<KeyValuePair<string, int>>();
        }

        public Dictionary<string, int> calculatingCPU(IList<string> input)
        {
            int curCost = 0;
            Dictionary<string, int> result = new Dictionary<string, int>();
            foreach (string rw in input)
            {
                string[] paras = rw.Split(',');
                if (paras[2] == "b")
                {
                    // if verb is begin, push into stack
                    stack.Push(new KeyValuePair<string, int>(paras[0], int.Parse(paras[1])));
                }
                else if (paras[2] == "e")
                {
                    // pop the top, and confirm the name before calculating
                    var item = stack.Pop();
                    if (item.Key == paras[0])
                    {
                        int gap = int.Parse(paras[1]) - item.Value - curCost;
                        // have to avoid the cost between
                        // a(s) -> b(s) -> b(e) -> a(e)
                        // a(s) -> a(e) = a(e).time - a(s).time - (b(e).time - b(s).time)
                        // curCost += b(s) -> b(e)
                        curCost += gap;
                        // update result
                        if (result.ContainsKey(item.Key))
                        {
                            gap += result.GetValueOrDefault(item.Key);
                            result.Remove(item.Key);
                        }
                        result.Add(item.Key, gap);
                    }
                }
            }
            return result;
        }

    }
    /* ----------- Solution 2 start ----------- */
}
