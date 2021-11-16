using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Leetcode2073;

public class Solution
{
    public int TimeRequiredToBuy(int[] tickets, int k)
    {
        int sum = 0;
        // people who is in front of k
        // before k leaves, they buy at most as many tickets as k does
        // and they will not buy more then they wish.
        // so they will be min(tickets[i], tickets[k])
        for (int i = 0; i < k; i++)
        {
            sum += Math.Min(tickets[i], tickets[k]);
        }

        // k himself buys tickets[k] tickets.
        sum += tickets[k];

        // when k leaves
        // the ones who is behind k
        // will buy less then tickets[k]
        for (int i = k + 1; i < tickets.Length; i++)
        {
            sum += Math.Min(tickets[i], tickets[k] - 1);
        }

        return sum;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] tickets, int k, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.TimeRequiredToBuy(tickets, k);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 2, 3, 2 }, 2, 6); }
    [TestMethod] public void Test2() { TestBase(new int[] { 5, 1, 1, 1 }, 0, 8); }
    [TestMethod] public void Test3() { TestBase(new int[] { 3, 3 }, 0, 5); }
    [TestMethod] public void Test4() { TestBase(new int[] { 3, 3 }, 1, 6); }
    [TestMethod] public void Test5() { TestBase(new int[] { 100, 100, 1, 3 }, 2, 3); }
    [TestMethod] public void Test6() { TestBase(new int[] { 100, 100, 5, 3 }, 2, 18); }
    [TestMethod] public void Test7() { TestBase(new int[] { 100, 100, 5, 100 }, 2, 19); }



}
