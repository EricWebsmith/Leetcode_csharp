namespace Leetcode1143;

/// <summary>
/// Runtime: 68 ms, faster than 93.44% of C# online submissions for Longest Common Subsequence.
/// Memory Usage: 39.4 MB, less than 73.13% of C# online submissions for Longest Common Subsequence.
/// </summary>
public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        int n1 = text1.Length;
        int n2 = text2.Length;

        int[] dp = new int[n2 + 1];
        for (int i = 0; i <= n1; i++)
        {
            //matrx[i] = new int[n2 + 1];
            int[] current = new int[n2 + 1];
            for (int j = 0; j <= n2; j++)
            {
                if (i == 0 || j == 0)
                {
                    continue;
                }

                if(text1[i-1] == text2[j - 1])
                {
                    current[j] = 1 + dp[j - 1];
                }
                else
                {
                    current[j] = Math.Max(dp[j], current[j - 1]);
                }
            }
            dp = current;
        }
        return dp[n2];
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string text1, string text2, int expected)
    {
        int actual = new Solution().LongestCommonSubsequence(text1, text2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("abcde", "ace", 3); }
    [TestMethod] public void Test2() { TestBase("abc", "abc", 3); }
    [TestMethod] public void Test3() { TestBase("book", "look", 3); }
    [TestMethod] public void Test4() { TestBase("good", "book", 2); }
    [TestMethod] public void Test5() { TestBase("", "", 0); }
}