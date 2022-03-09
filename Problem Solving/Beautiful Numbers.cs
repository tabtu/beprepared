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

        // long[] testcases = { 345, 62346, 34256, 7654, 342, 5643, 6, 4573, 45, 364, 573, 12312 };
        string[] testcases = { "346262", "1849375289347562543598374569", "702349572934857203948756912387465197382456" };

        Solution cd = new Solution();
        // for solution 2
        cd.initInstance();

        foreach (var l in testcases)
        {
            // long result = cd.findNextBeautifulNumber1(l);
            // long result = cd.findNextBeautifulNumber2(l);
            string result = cd.findNextBeautifulNumber3(l);
            Console.WriteLine(result);
        }
    }

    // Solution 3: make string compare, support max length of 45, change parameter type to string.
    // TODO: issue on some boundary cases. reference with MARK tag.
    private string findNextBeautifulNumber3(string n)
    {
        int length = n.Length;
        // maximum length
        if (length > 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9) return "";
        // case seeds
        int[] lens = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // init case instance for DFS
        cas = new HashSet<int[]>();
        List<int> cur = new List<int>();
        dfs3(cur, n.Length, lens.ToList());
        // MAXIMUM result
        string result = "999999999888888887777777666666555554444333221";
        foreach (var rw in cas)
        {
            string str = "";
            foreach (var r in rw)
            {
                for (int i = 0; i < r; i++)
                {
                    str += r.ToString();
                }
            }

            // list out the smallest case in each combination.
            // Console.WriteLine(str);
            string round = nearestLargeStr(n, str.ToArray());
            if (round != "" && round.CompareTo(result) < 0) result = round;
            // Console.WriteLine(round);
            // Console.WriteLine();
        }
        return result;
    }

    private string nearestLargeStr(string tar, char[] str)
    {
        // length do not equalize.
        if (tar.Length != str.Length) return "";
        // tar is greater than max of str.
        string maxRound = new string(str.Reverse().ToArray());
        if (maxRound.CompareTo(tar) < 0) return "";

        int n = str.Length;
        for (int i = 0; i < n - 1; i++)
        {
            // TODO MARK: have to fix boundary cases.
            char[] rest = str.Skip(i).Take(str.Length - i).ToArray();
            if (tar[i] > str[i] && tar[i] <= rest.Max())
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (tar[i] <= str[j])
                    {
                        pick(ref str, i, j);
                        break;
                    }
                }
            }
        }
        return new string(str);
    }
    private void pick(ref char[] str, int a, int b)
    {
        List<char> vs = str.ToList();
        char tmp = vs[b];
        vs.RemoveAt(b);
        vs.Insert(a, tmp);
        str = vs.ToArray();
    }
    private static HashSet<int[]> cas;
    private void dfs3(List<int> curpts, int target, IList<int> options)
    {
        if (target < 0) return;
        if (target == 0)
        {
            curpts.Sort();
            cas.Add(curpts.ToArray());
            return;
        }

        for (int i = 0; i < options.Count; i++)
        {
            curpts.Add(options[i]);

            IList<int> next_options = options.Skip(i + 1).Take(options.Count - 1 - i).ToList();
            target = target - options[i];

            dfs3(curpts, target, next_options);
            target = target + options[i];
            curpts.RemoveAt(curpts.Count - 1);
        }
    }



    // Solution 2: Permutations
    private long findNextBeautifulNumber2(long n)
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
        // find all possible combine cases. CPU wont have result with "55555".
        string[] ori = { "4444", "333", "22", "1" };
        cases = new HashSet<string>();
        IList<string> cur = new List<string>();
        dfs1(cur, ori);
        //Console.WriteLine(cases.Count);

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

    // Solution 1, Loop
    private long findNextBeautifulNumber1(long n)
    {
        while (n < long.MaxValue)
        {
            if (isBeautiful(n)) return n;
            else n++;
        }
        return 0;
    }
    private static bool isBeautiful(long n)
    {
        string str = n.ToString();
        Dictionary<char, int> keys = new Dictionary<char, int>();
        foreach (char ch in str)
        {
            bool first = keys.TryAdd(ch, 1);
            if (first == false)
            {
                keys[ch]++;
            }
        }
        foreach (var kvp in keys)
        {
            if (int.Parse(kvp.Key.ToString()) != kvp.Value)
            {
                return false;
            }
        }
        return true;
    }
}