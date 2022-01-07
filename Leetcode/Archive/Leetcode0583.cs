namespace Leetcode0583;

/// <summary>
/// Runtime: 80 ms, faster than 61.11% of C# online submissions for Delete Operation for Two Strings.
/// Memory Usage: 39.4 MB, less than 56.67% of C# online submissions for Delete Operation for Two Strings.
/// </summary>
public class Solution
{

    private int LongestCommonSubsequence(string word1, string word2)
    {
        int n1 = word1.Length;
        int n2 = word2.Length;
        int[] dp = new int[n2+1];
        for (int i = 0; i <= n1; i++)
        {
            int[] currentDp = new int[n2 + 1];
            for (int j = 0; j <= n2; j++)
            {
                if(i==0 || j == 0)
                {
                    continue;
                }

                if(word1[i-1] == word2[j - 1])
                {
                    currentDp[j] = dp[j-1]+1;
                }
                else
                {
                    currentDp[j] = Math.Max(dp[j], currentDp[j - 1]);
                }
            }
            dp = currentDp;
        }
        return dp[n2];
    }

    public int MinDistance(string word1, string word2)
    {
        int lcs = LongestCommonSubsequence(word1, word2);
        return word1.Length + word2.Length - lcs * 2;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string word1, string word2, int expected)
    {
        int actual = new Solution().MinDistance(word1, word2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("sea", "eat", 2); }
    [TestMethod] public void Test2() { TestBase("leetcode", "etco", 4); }
    [TestMethod] public void Test3() { TestBase("book", "good", 4); }
    [TestMethod] public void Test4() { TestBase("book", "look", 2); }
    [TestMethod] public void Test5() { TestBase("book", "", 4); }
    [TestMethod] public void Test6() { TestBase("", "look", 4); }
    [TestMethod] public void Test7() { TestBase("", "", 0); }
    [TestMethod] public void Test8() { TestBase("sea", "tea", 2); }
    [TestMethod] public void Test9() { TestBase("mart", "karma", 5); }
    [TestMethod] public void Test10() { TestBase("plasma", "altruism", 8); }
    [TestMethod] public void Test11() { TestBase("ab", "bc", 2); }
    [TestMethod] public void Test12() { TestBase("teacher", "archer", 3); }
}