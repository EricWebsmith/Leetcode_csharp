namespace Leetcode0049;

/// <summary>
/// Runtime: 176 ms, faster than 74.13% of C# online submissions for Group Anagrams.
/// Memory Usage: 49.5 MB, less than 56.87% of C# online submissions for Group Anagrams.
/// </summary>
public class Solution
{
    private string Sort(string s)
    {
        char[] arr = s.ToArray();
        Array.Sort(arr);
        return string.Join(string.Empty, arr);
    }

    public IList<IList<string>> GroupAnagrams(string[] strs)
    {
        Dictionary<string, IList<string>> groups = new Dictionary<string, IList<string>>();
        foreach(string str in strs)
        {
            string sorted = Sort(str);

            if (!groups.ContainsKey(sorted))
            {
                groups.Add(sorted, new List<string>());
            }

            groups[sorted].Add(str);
        }

        IList<IList<string>> result = groups.Values.ToList();
        return result;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[eat,tea,tan,ate,nat,bat]", 3)]
    [DataRow(2, "", 1)]
    [DataRow(3, "[a]", 1)]
    [DataRow(4, @"[a,""""]", 2)]
    [DataTestMethod]
    public void Test(int order, string strsStr, int expected)
    {
        string[] strs = strsStr.LeetcodeToStringArray();
        var actual = new Solution().GroupAnagrams(strs);
        actual.Print2D();
        Assert.AreEqual(expected, actual.Count);
    }
}

