using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0091;

public class Solution
{
    private int OneStep(string s, int start)
    {
        return s[start] != '0' ? 1 : 0;
    }

    private int TwoSteps(string s, int start)
    {

        if (s[start] != '1' && s[start] != '2')
        {
            return 0;
        }

        if (s[start] == '1')
        {
            return 1;
        }

        if (s[start] == '2')
        {
            if (s[start + 1] > '6')
            {
                return 0;
            }
        }

        return 1;
    }

    public int NumDecodings(string s)
    {
        //if (s[0] == '0')
        //{
        //    return 0;
        //}

        if (s.Length == 1)
        {
            return OneStep(s, 0);
        }

        int a = 0;
        int b = 0;
        int c = 0;

        a = 1;
        b = OneStep(s, 0);

        for (int i = 2; i <= s.Length; i++)
        {
            c = a * TwoSteps(s, i-2) + b * OneStep(s, i-1);
            a = b;
            b = c;

        }
        return c;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(string s, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.NumDecodings(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase("12", 2); }
    [TestMethod] public void Test02() { TestBase("226", 3); }
    [TestMethod] public void Test03() { TestBase("0", 0); }
    [TestMethod] public void Test04() { TestBase("10", 1); }
    [TestMethod] public void Test05() { TestBase("20", 1); }
    [TestMethod] public void Test06() { TestBase("100", 0); }
    [TestMethod] public void Test07() { TestBase("1", 1); }

    [TestMethod] public void Test08() { TestBase("27", 1); }
    [TestMethod] public void Test09() { TestBase("228", 2); }
    [TestMethod] public void Test10() { TestBase("611", 2); }

}