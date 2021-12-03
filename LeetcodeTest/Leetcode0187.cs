namespace Leetcode0187;

/// <summary>
/// Runtime: 136 ms, faster than 87.86% of C# online submissions for Repeated DNA Sequences.
/// Memory Usage: 50.3 MB, less than 63.59% of C# online submissions for Repeated DNA Sequences.
/// </summary>
public class Solution
{

    public IList<string> FindRepeatedDnaSequences(string s)
    {
        HashSet<string> hash =new HashSet<string>();
        HashSet<string> result = new HashSet<string>();
        for(int i = 0;i<=s.Length - 10; i++)
        {
            string subStr = s.Substring(i, 10);
            if (hash.Contains(subStr))
            {
                result.Add(subStr);
            }
            else
            {
                hash.Add(subStr);
            }
        }

        return result.ToList();
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT", 2)]
    [DataRow(2, "AAAAAAAAAAAAA", 1)]
    [DataRow(3, "AGCTAGCTAGCTAGCTAGCTAGCTAGCTAGCT", 4)]
    [DataRow(4, "AGCAGCAGCAGCAGCAGCAGCAGCAGCAGCAGC", 3)]
    [DataRow(5, "AAAAAAAAAAA", 1)]
    [DataTestMethod]
    public void Test(int order, string s, int expected)
    {
        var actual = new Solution().FindRepeatedDnaSequences(s);
        actual.Print1D();
        Assert.AreEqual(expected, actual.Count);
    }
}