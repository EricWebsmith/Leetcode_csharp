namespace Leetcode5958;


public class Solution
{
    public long GetDescentPeriods(int[] prices)
    {
        int n = prices.Length;
        List<long> periods = new List<long>();
        int period = 0;
        for (int i = 1; i < n; i++)
        {
            if (prices[i] - prices[i - 1] == -1)
            {
                period++;
            }
            else
            {
                if (period > 0)
                {
                    periods.Add(period);
                }
                period = 0;
            }
        }

        if (period > 0)
        {
            periods.Add(period);
        }

        long ans = n;
        for (int i = 0; i < periods.Count; i++)
        {
            ans = ans + (1 + periods[i]) * periods[i] / 2;
        }

        return ans;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(string pricesStr, long epxected)
    {
        int[] prices = pricesStr.LeetcodeToArray();
        long actual = new Solution().GetDescentPeriods(prices);
        Assert.AreEqual(epxected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3,2,1,4]", 7); }
    [TestMethod] public void Test2() { TestBase("[8,6,7,7]", 4); }
    [TestMethod] public void Test3() { TestBase("[1]", 1); }
    [TestMethod] public void Test4() { TestBase("[3,2,1]", 6); }
    [TestMethod] public void Test5() { TestBase("[100000...1]", 5000050000); }


}