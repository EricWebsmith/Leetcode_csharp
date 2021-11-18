using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Leetcode0668;

public class Solution
{
    public int FindKthNumber(int m, int n, int k)
    {
        int lo = 1;
        int hi = m * n + 1;
        while (lo < hi)
        {
            int mid = (lo + hi) / 2;
            if (Lex(m, n, mid) >= k)
            {
                hi = mid;
            }
            else
            {
                lo = mid + 1;
            }
        }
        return lo;
    }

    private int Lex(int m, int n, int x)
    {
        int count = 0;
        for (int i = 1; i <= m; i++)
        {
            count += Math.Min(n, x / i);
        }
        return count;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int m, int n, int k, int expected)
    {
        int actual = (new Solution()).FindKthNumber(m, n, k);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(3, 3, 5, 3); }
    [TestMethod] public void Test2() { TestBase(2, 3, 6, 6); }

}