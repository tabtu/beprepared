/* https://leetcode.com/problems/daily-temperatures/
 * 
 * Single way stack, only push element value in one way.
 * - push in stack one by one;
 * - loop pop when t[cur] > t[stack.peek], or empty stack
 * 
 * stack saves the position in array.
 */
public class Solution
{

    public void test_dailyTemperatures()
    {
        int[] t = { 73, 74, 75, 71, 69, 72, 76, 73 };
        int[] r = dailyTemperatures(t);
        // foreach (int i in r)
        // {
        //     Console.Write(i + " ");
        // }
    }

    public int[] DailyTemperatures(int[] temperatures)
    {
        int[] ans = new int[temperatures.Length];
        Stack<int> s = new Stack<int>();
        for (int i = 0; i < temperatures.Length; i++)
        {
            while (s.Count() > 0 && temperatures[i] > temperatures[s.Peek()])
            {
                ans[s.Peek()] = i - s.Pop();
            }
            s.Push(i);
        }
        return ans;
    }
}