namespace Leetcode0121;

public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int lowest_price = prices[0];
        int max_profit = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            int profit = prices[i] - lowest_price;
            max_profit = Math.Max(profit, max_profit);
            lowest_price = Math.Min(lowest_price, prices[i]);
        }
        return max_profit;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] prices, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.MaxProfit(prices);
        Assert.AreEqual(expected, actual);

    }

    [TestMethod] public void Test1() { TestBase(new int[] { 7, 1, 5, 3, 6, 4 }, 5); }
    [TestMethod] public void Test2() { TestBase(new int[] { 7, 6, 4, 3, 1 }, 0); }

}
