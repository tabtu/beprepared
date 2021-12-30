/* https://leetcode.com/problems/word-ladder/
 * 
 * TODO:
 * 
 *
 */
public class Solution
{
    public int LadderLength(string beginWord, string endWord, IList<string> wordList)
    {
        HashSet<string> reached = new HashSet<string>();
        reached.Add(beginWord);
        wordList.Add(endWord);
        int distance = 1;
        while (!reached.Contains(endWord))
        {
            HashSet<string> toAdd = new HashSet<string>();
            foreach (String each in reached)
            {
                for (int i = 0; i < each.Length; i++)
                {
                    char[] chars = each.ToCharArray();
                    for (char ch = 'a'; ch <= 'z'; ch++)
                    {
                        chars[i] = ch;
                        string word = new string(chars);
                        if (wordList.Contains(word))
                        {
                            toAdd.Add(word);
                            wordList.Remove(word);
                        }
                    }
                }
            }
            distance++;
            if (toAdd.Count == 0) return 0;
            reached = toAdd;
        }
        return distance;
    }
}