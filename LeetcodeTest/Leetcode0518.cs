namespace Leetcode0518;

public class Solution
{
    public int Change(int amount, int[] coins)
    {
        Array.Sort(coins);
        int[] dp = new int[amount + 1];
        dp[0] = 1;

        foreach (int coin in coins)
        {
            int[] nextDP = new int[amount + 1];
            nextDP[0] = 1;
            for (int i = 1; i <= amount; i++)
            {
                nextDP[i] = dp[i];

                int reminder = i - coin;
                if (reminder >= 0)
                {
                    nextDP[i] += nextDP[reminder];
                }
            }
            dp = nextDP;
        }
        return dp[amount];
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, 5, "1,2,5", 4)]
    [DataRow(2, 3, "2", 0)]
    [DataRow(3, 10, "10", 1)]
    [DataRow(4, 1, "1,2,5", 1)]
    [DataRow(5, 0, "1,2,5", 1)]
    [DataRow(6, 10, "5", 1)]
    [DataTestMethod]
    public void Test(int order, int amount, string coinsStr, int expected)
    {
        int[] coins = Helper.Convert1D(coinsStr);
        int actual = (new Solution()).Change(amount, coins);
        Assert.AreEqual(expected, actual);
    }
}