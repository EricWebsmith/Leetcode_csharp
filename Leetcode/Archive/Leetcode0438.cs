namespace Leetcode0438;

/// <summary>
/// Runtime: 136 ms, faster than 64.40% of C# online submissions for Find All Anagrams in a String.
/// Memory Usage: 43.5 MB, less than 62.35% of C# online submissions for Find All Anagrams in a String.
/// </summary>
public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        IList<int> result = new List<int>();
        if (string.IsNullOrEmpty(s))
        {
            return result;
        }

        Dictionary<char, int> map = new Dictionary<char, int>();
        for(int i=0;i<p.Length;i++)
        {
            if (map.ContainsKey(p[i]))
            {
                map[p[i]]++;
            }
            else
            {
                map.Add(p[i], 1);
            }
        }


        int sum = 0;
        for(int i=0; i < s.Length; i++)
        {
            // remove
            int removeIndex = i - p.Length;
            if (removeIndex >= 0 && map.ContainsKey(s[removeIndex]))
            {
                map[s[removeIndex]] ++;
                
            }

            // add
            if (map.ContainsKey(s[i]))
            {
                map[s[i]]--;
            }

            bool found = true;
            foreach(int v in map.Values)
            {
                if (v != 0)
                {
                    found = false;
                }
            }

            if (found)
            {
                result.Add(i-p.Length+1);
            }
        }

        return result;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "cbaebabacd", "abc", "[0,6]")]
    [DataRow(2, "abab", "ab", "[0,1,2]")]
    [DataRow(3, "ababa", "ab", "[0,1,2,3]")]
    [DataRow(4, "ababcabab", "ab", "[0,1,2,5,6,7]")]
    [DataRow(5, "abcab", "ab", "[0,3]")]
    [DataRow(6, "aabcaba", "aab", "[0,4]")]
    [DataTestMethod]
    public void Test(int order, string s , string p, string expectedStr)
    {
        IList<int> actual = new Solution().FindAnagrams(s, p);
        Assert.AreEqual(expectedStr, actual.ToLeetcode());
    }
}