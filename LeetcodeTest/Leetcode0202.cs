using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Leetcode0202;

public class Solution
{
    private int Next(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            int r = n % 10;
            sum += r * r;
            n = n / 10;
        }
        return sum;
    }

    public bool IsHappy(int n)
    {
        HashSet<int> cache = new HashSet<int>();
        cache.Add(n);
        while (n != 1)
        {

            n = Next(n);
            if (cache.Contains(n))
            {
                return false;
            }
            cache.Add(n);
        }
        return n == 1;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int n, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.IsHappy(n);
        Assert.AreEqual(expected, actual);
    }

    private void SmockingTestBase(int n, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.IsHappy(n);
        // Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(19, true); }
    [TestMethod] public void Test2() { TestBase(2, false); }
    [TestMethod] public void Test3() { SmockingTestBase(2<<31-1, true); }
    [TestMethod] public void Test4() { SmockingTestBase(int.MaxValue, true); }


}
