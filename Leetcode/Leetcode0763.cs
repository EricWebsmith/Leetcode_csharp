namespace Leetcode0763;

/// <summary>
/// Runtime: 116 ms, faster than 76.62% of C# online submissions for Partition Labels.
/// Memory Usage: 41.6 MB, less than 19.69% of C# online submissions for Partition Labels.
/// </summary>
public class Solution
{
    public IList<int> PartitionLabels(string s)
    {
        int n = s.Length;
        Dictionary<char, int> lastDict = new Dictionary<char, int>();
        for (int i = n - 1; i >= 0; i--)
        {
            if (!lastDict.ContainsKey(s[i]))
            {
                lastDict.Add(s[i], i);
            }
        }

        List<int> splits = new List<int>();
        int last = 0;
        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            last = Math.Max(last, lastDict[c]);
            if (i == last)
            {
                splits.Add(i);
            }
        }

        List<int> results = new List<int>();
        results.Add(splits[0] + 1);
        for (int i = 1; i < splits.Count; i++)
        {
            results.Add(splits[i] - splits[i - 1]);
        }
        return results;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "ababcbacadefegdehijhklij", "[9,7,8]")]
    [DataRow(2, "eccbbbbdec", "[10]")]
    [DataRow(3, "abcd", "[1,1,1,1]")]
    [DataRow(4, "abcad", "[4,1]")]
    [DataRow(5, "abcadede", "[4,4]")]
    [DataRow(6, "a", "[1]")]
    [DataTestMethod]
    public void Test(int order, string s, string expectedStr)
    {
        IList<int> actual = new Solution().PartitionLabels(s);
        Assert.AreEqual(expectedStr, actual.ToLeetcode());
    }
}