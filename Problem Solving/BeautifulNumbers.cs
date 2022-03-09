/* 
 * IMAX code test.
 * Find the nearest large beautiful number.
 * 1, 122, 122333, 3313, 44144 -> these are beautiful numbers.
 *
 * edit on Mar 09 2022 with 90 minutes.
 */

public class Solution
{
    public static void Main(String[] args)
    {
        Solution sol = new Solution();
        sol.initInstance();

        long[] testcases = { 345, 62346, 6243645734, 7654, 342, 5643, 6, 4573, 45, 364, 573, 12312 };

        foreach (long l in testcases)
        {
            long result = sol.findNextBeautifulNumber(l);
            Console.WriteLine(result);
        }

    }

    private long findNextBeautifulNumber(long n)
    {
        return (from st in paths where st > n select st).First();
    }

    private void initInstance()
    {
        // print out maximum value and length for a Long type.
        long lmax = long.MaxValue;
        string lmaxStr = lmax.ToString();
        int maxLen = lmaxStr.Length;
        Console.WriteLine(lmax + " : " + maxLen);

        // target the maximum beautiful number with a Long type.
        // max length is 5; maxvalue is 555554444333221
        int result = 0;
        for (int i = 1; i <= 9; i++)
        {
            result += i;
            if (result > maxLen)
            {
                Console.WriteLine("The maximum length for a beautiful number in long is " + (result - i));
                break;
            }
        }
        Console.WriteLine();

        // group of all elements can be used.
        // find all possible combine cases.
        string[] ori = { "55555", "4444", "333", "22", "1" };
        cases = new HashSet<string>();
        IList<string> cur = new List<string>();
        dfs1(cur, ori);
        Console.WriteLine(cases.Count);

        // find all permutations based on conditions beyond.
        paths = new HashSet<long>();
        foreach (string cb in cases)
        {
            char[] dist = cb.Distinct().ToArray();
            if (dist.Length == 1)
            {
                // add when all element are the same.
                paths.Add(long.Parse(cb.ToArray()));
            }
            else
            {
                // do dfs.
                IList<char> cur2 = new List<char>();
                dfs2(cur2, cb.ToList());
            }
        }
        //Console.WriteLine(paths.Count);

        // order all beautiful number in ascending order.
        paths = (from st in paths orderby st ascending select st).ToHashSet();
    }

    private static HashSet<string> cases;
    private void dfs1(IList<string> curpts, IList<string> options)
    {
        if (curpts.Count > 0)
        {
            IList<string> ord = (from st in curpts orderby st descending select st).ToList();
            string str = "";
            foreach (string s in ord)
            {
                str += s;
            }
            cases.Add(str);
        }

        for (int i = 0; i < options.Count; i++)
        {
            curpts.Add(options[i]);

            IList<string> next_options = options.ToList();
            next_options.RemoveAt(i);

            dfs1(curpts, next_options);
            curpts.RemoveAt(curpts.Count - 1);
        }
    }

    private static HashSet<long> paths;
    private void dfs2(IList<char> curpts, IList<char> options)
    {
        if (options.Count == 0)
        {
            try
            {
                long l = long.Parse(curpts.ToArray());
                paths.Add(l);
            }
            catch { };
        }

        for (int i = 0; i < options.Count; i++)
        {
            curpts.Add(options[i]);

            IList<char> next_options = options.ToList();
            next_options.RemoveAt(i);

            dfs2(curpts, next_options);
            curpts.RemoveAt(curpts.Count - 1);
        }
    }
}