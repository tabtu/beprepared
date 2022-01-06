/* Minimizing Permutations
 * 
 * In this problem, you are given an integer N, and a permutation, P of the integers from 1 to N, denoted as (a_1, a_2, ..., a_N). You want to rearrange the elements of the permutation into increasing order, repeatedly making the following operation:
 * Select a sub-portion of the permutation, (a_i, ..., a_j), and reverse its order.
 * Your goal is to compute the minimum number of such operations required to return the permutation to increasing order.
 * Signature
 * int minOperations(int[] arr)
 * Input
 * Array arr is a permutation of all integers from 1 to N, N is between 1 and 8
 * Output
 * An integer denoting the minimum number of operations required to arrange the permutation in increasing order
 */

public class Solution
{
    static void Main(string[] args)
    {
        int[] arr = { 3, 1, 2 };
        Console.Write(minOperations(arr));
    }

    // Breadth First Search
    private static int minOperations(int[] arr)
    {
        // define the target 
        int[] target = new int[arr.Length];
        arr.CopyTo(target, 0);
        Array.Sort(target);

        // result container
        int ret = 0;

        // initialize logged hashtable and option queue
        HashSet<string> seen = new HashSet<string>();
        Queue<int[]> queue = new Queue<int[]>();
        queue.Enqueue(arr);
        seen.Add(Arr2Str(arr));

        // loop when option queue is not null
        while (queue.Count > 0)
        {
            int size = queue.Count;
            // loop all cases in option queue
            for (int i = 0; i < size; i++)
            {
                // do option
                int[] curr = queue.Dequeue();

                // return if find result
                if (target.Equals(curr))
                {
                    return ret;
                }

                // try all cases in the same level.
                for (int j = 0; j < curr.Length; j++)
                {
                    for (int k = j + 1; k < curr.Length; k++)
                    {
                        int[] next = new int[curr.Length];
                        curr.CopyTo(next, 0);
                        // reverse between j and k
                        reverse(next, j, k);
                        // add if not scanned
                        if (!seen.Contains(Arr2Str(next)))
                        {
                            queue.Enqueue(next);
                            seen.Add(Arr2Str(next));
                        }
                    }
                }
            }

            // next level
            ret++;
        }
        return ret;
    }

    // partation reverse
    private static void reverse(int[] arr, int from, int to)
    {
        for (; from < to; from++, to--)
        {
            int tmp = arr[from];
            arr[from] = arr[to];
            arr[to] = tmp;
        }
    }

    // change to string for comparing and saving
    public static string Arr2Str(int[] arr)
    {
        string result = "";
        foreach (int a in arr)
        {
            result += (a + "");
        }
        return result;
    }
}