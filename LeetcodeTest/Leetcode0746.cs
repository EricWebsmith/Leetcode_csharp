using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Leetcode0746;

public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        int a = cost[cost.Length - 1];
        int b = cost[cost.Length - 2];
        if (cost.Length == 2)
        {
            return Math.Min(a, b);
        }
        int c = 0;
        for (int i = cost.Length - 3; i >= 0; i--)
        {
            c = Math.Min(cost[i] + a, cost[i] + b);
            a = b;
            b = c;
        }
        return Math.Min(a, c);
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] cost, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.MinCostClimbingStairs(cost);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 10, 15, 20 }, 15); }
    [TestMethod] public void Test2() { TestBase(new int[] { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 }, 6); }
    [TestMethod] public void Test3() { TestBase(new int[] { 1, 100 }, 1); }

}
