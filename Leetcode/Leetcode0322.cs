namespace Leetcode0322;

public class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        Array.Sort(coins);
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0;

        for (int i = 1; i <= amount; i++)
        {
            foreach (int coin in coins)
            {
                if (i - coin >= 0)
                {
                    dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                }
                else
                {
                    break;
                }
            }
        }

        if(dp[amount] == amount + 1)
        {
            return -1;
        }

        return dp[amount];
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "1,2,5", 11, 3)]
    [DataRow(2, "2", 3, -1)]
    [DataRow(3, "1", 0, 0)]
    [DataRow(4, "1", 1, 1)]
    [DataRow(5, "1", 2, 2)]
    [DataTestMethod]
    public void Test(int order, string coinsStr,int amount, int expected)
    {
        int[] coins = Helper.Convert1D(coinsStr);
        int actual = (new Solution()).CoinChange(coins, amount);
        Assert.AreEqual(expected, actual);
    }
}