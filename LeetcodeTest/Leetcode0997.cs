namespace Leetcode0997;

/// <summary>
/// Runtime: 248 ms, faster than 73.80% of C# online submissions for Find the Town Judge.
/// Memory Usage: 47.6 MB, less than 34.93% of C# online submissions for Find the Town Judge.
/// </summary>
public class Solution
{
    public int FindJudge(int n, int[][] trust)
    {
        List<List<int>> trusts = new List<List<int>>();
        List<List<int>> trustedBy = new List<List<int>>();
        for (int i = 0; i < n; i++)
        {
            trusts.Add(new List<int>());
            trustedBy.Add(new List<int>());
        }

        for (int i = 0; i < trust.Length; i++)
        {
            trusts[trust[i][0] - 1].Add(trust[i][1] - 1);
            trustedBy[trust[i][1] - 1].Add(trust[i][0] - 1);
        }

        for (int i = 0; i < n; i++)
        {
            if (trusts[i].Count == 0 && trustedBy[i].Count == n - 1)
            {
                return i + 1;
            }
        }
        return -1;

    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(int n, string trustStr, int expected)
    {
        int[][] trust = trustStr.LeetcodeToArray2D();
        int actual = new Solution().FindJudge(n, trust);    
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(2, "[[1,2]]", 2); }
    [TestMethod] public void Test2() { TestBase(3, "[[1,3],[2,3]]",3); }
    [TestMethod] public void Test3() { TestBase(3, "[[1,3],[2,3],[3,1]]",-1); }
    [TestMethod] public void Test4() { TestBase(3, "[[1,3],[2,3],[3,1]]",-1); }
    [TestMethod] public void Test5() { TestBase(4, "[[1,3],[1,4],[2,3],[2,4],[4,3]]", 3); }
    [TestMethod] public void Test6() { TestBase(1, "[]", -1); }
    [TestMethod] public void Test7() { TestBase(1, "[]", -1); }
}