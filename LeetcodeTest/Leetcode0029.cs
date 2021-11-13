using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Leetcode0029;

public class Solution
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == 1 << 31 && divisor == -1) return int.MaxValue;
        if (dividend == 1 << 31 && divisor == 1 << 31) return 1;
        if (divisor == 1 << 31) return 0;
        if (dividend == -2147483648)
        {
            if (divisor > 0)
            {
                return Divide(dividend + divisor, divisor) - 1;
            }
            else
            {
                return Divide(dividend - divisor, divisor) + 1;
            }
        }
        if (divisor == 1) return dividend;
        
        if (dividend == 0) return 0;


        int sign = Math.Sign(dividend) * Math.Sign(divisor);
        dividend = Math.Abs(dividend);
        divisor = Math.Abs(divisor);

        if (dividend == divisor) return sign;
        if (dividend < divisor) return 0;
        if (divisor == 1) return sign * dividend;


        int shift = 0;
        int shifted = divisor;
        while (shifted < dividend && shifted > 0)
        {
            shifted = shifted << 1;
            shift++;
        }


        shift--;
        shifted = divisor << shift;


        int remainder = dividend - shifted;

        int remainder_divide = 0;
        if (remainder >= divisor)
        {
            remainder_divide = Divide(remainder, divisor);
        }

        int result = (1 << shift) + remainder_divide;

        if (sign == 1)
        {
            return result;
        }
        else
        {
            return -result;
        }

    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int dividend, int divisor, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.Divide(dividend, divisor);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase(10, 3, 3); }
    [TestMethod] public void Test02() { TestBase(7, -3, -2); }
    [TestMethod] public void Test03() { TestBase(0, 1, 0); }
    [TestMethod] public void Test04() { TestBase(1, 1, 1); }
    [TestMethod] public void Test05() { TestBase(-1, 1, -1); }
    [TestMethod] public void Test06() { TestBase(-2147483648, -1, int.MaxValue); }
    
    [TestMethod] public void Test07() { TestBase(2147483647, 1, 2147483647); }
    [TestMethod] public void Test08() { TestBase(-2147483648, 1, -2147483648); }
    [TestMethod] public void Test09() { TestBase(-2147483648, 2, -1073741824); }
    [TestMethod] public void Test10() { TestBase(-2147483646, 2, -1073741823); }

    [TestMethod] public void Test11() { TestBase(-7, 2, -3); }
    [TestMethod] public void Test12() { TestBase(-1010369383, -2147483648, 0); }
    [TestMethod] public void Test13() { TestBase(-2147483646, -2147483646, 1); }
}
