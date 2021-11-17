using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode0264;

public class Solution
{
    static List<int> nums = new List<int>() { 1 };
    static int i2 = 0;
    static int i3 = 0;
    static int i5 = 0;

    public int NthUglyNumber(int n)
    {
        while(nums.Count < n)
        {
            int next2 = nums[i2] * 2;
            int next3 = nums[i3] * 3;
            int next5 = nums[i5] * 5;
            int next =Math.Min( Math.Min(next2, next3), next5);
            if (next == next2) i2++;
            if (next == next3) i3++;
            if (next == next5) i5++;
            nums.Add(next);
        }
        return nums[n - 1];
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int n, int expected)
    {
        int actual = (new Solution()).NthUglyNumber(n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01_10() { TestBase(10, 12); }
    [TestMethod] public void Test02_1() { TestBase(1, 1); }

    [TestMethod] public void Test03_1690() { TestBase(1690, 2123366400); }
    [TestMethod] public void Test04_100() { TestBase(100, 1536); }
    [TestMethod] public void Test05_1000() { TestBase(1000, 51200000); }
    [TestMethod] public void Test06_2() { TestBase(2, 2); }
}