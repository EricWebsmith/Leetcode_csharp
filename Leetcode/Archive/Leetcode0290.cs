namespace Leetcode0290;

/// <summary>
/// Runtime: 84 ms, faster than 52.98% of C# online submissions for Word Pattern.
/// Memory Usage: 37.2 MB, less than 60.26% of C# online submissions for Word Pattern.
/// </summary>
public class Solution
{
    public bool WordPattern(string pattern, string s)
    {
        int n = pattern.Length;
        string[] words = s.Split(' ');
        if (n != words.Length)
        {
            return false;
        }

        Dictionary<char, string> mapChar2String = new Dictionary<char, string>();
        Dictionary<string, char> mapString2Char = new Dictionary<string, char>();
        for (int i = 0; i < words.Length; i++)
        {
            if (!mapChar2String.ContainsKey(pattern[i]))
            {
                mapChar2String[pattern[i]] = words[i];
            }
            else if (mapChar2String[pattern[i]] != words[i])
            {
                return false;
            }


            if (!mapString2Char.ContainsKey(words[i]))
            {
                mapString2Char[words[i]] = pattern[i];
            }
            else if (mapString2Char[words[i]] != pattern[i])
            {
                return false;
            }
        }

        return true;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "abba", "dog cat cat dog", true)]
    [DataRow(2, "abba", "dog cat cat fish", false)]
    [DataRow(3, "aaaa", "dog cat cat dog", false)]
    [DataRow(4, "abba", "dog dog dog dog", false)]
    [DataTestMethod]
    public void Test(int order, string pattern, string s, bool expected)
    {
        bool actual = new Solution().WordPattern(pattern, s);
        Assert.AreEqual(expected, actual);
    }
}