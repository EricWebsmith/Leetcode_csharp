using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode0263;

public class Solution
{
    public bool IsUgly(int n)
    {
        if (n <= 0)
        {
            return false;
        }

        //2
        while((n & 0x1) == 0)
        {
            n = n >> 1;
        }

        //3
        while (n % 3 == 0)
        {
            n /= 3;
        }

        //5
        while (n % 5 == 0)
        {
            n /= 5;
        }

        return n == 1;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int n, bool expected)
    {
        bool actual =(new Solution()).IsUgly(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase(6, true); }
    [TestMethod] public void Test02() { TestBase(8, true); }
    [TestMethod] public void Test03() { TestBase(14, false); }
    [TestMethod] public void Test04() { TestBase(1, true); }
    [TestMethod] public void Test05() { TestBase(100, true); }
    [TestMethod] public void Test06() { TestBase(1024, true); }

    [TestMethod] public void Test07() { TestBase(49, false); }
}