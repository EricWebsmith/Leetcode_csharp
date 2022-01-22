namespace Leetcode1510;

/// <summary>
/// Runtime: 78 ms, faster than 100.00% of C# online submissions for Stone Game IV.
/// Memory Usage: 27 MB, less than 100.00% of C# online submissions for Stone Game IV.
/// </summary>
public class Solution
{
    public bool WinnerSquareGame(int n)
    {
        bool[] dp = new bool[n+1];

        for(int i = 0; i <= n; i++)
        {
            int j = 1;
            while (j * j <= i)
            {
                if (!dp[i - j * j])
                {
                    dp[i] = true;
                    break;
                }
                j++;
            }
        }

        return dp[n];
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int n, bool expected)
    {
        bool actual = new Solution().WinnerSquareGame(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(1, true); }
    [TestMethod] public void Test2() { TestBase(2, false); }
    [TestMethod] public void Test3() { TestBase(3, true); }
    [TestMethod] public void Test4() { TestBase(4, true); }
    [TestMethod] public void Test5() { TestBase(5, false); }

}