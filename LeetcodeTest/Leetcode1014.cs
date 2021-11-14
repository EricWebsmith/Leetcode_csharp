using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Leetcode1014;

public class Solution
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        if (values.Length == 2)
        {
            return values[0] + values[1] - 1;
        }

        int[] shiftedValues = new int[values.Length];
        for (int i = 0; i < shiftedValues.Length; i++)
        {
            shiftedValues[i] = values[i] - i;
        }

        int[] localMaxAtArr = new int[values.Length];
        localMaxAtArr[values.Length - 1] = values.Length - 1;
        int localMax = shiftedValues[values.Length - 1];
        int localMaxAt = values.Length - 1;
        for (int i = values.Length - 2; i > 0; i--)
        {
            if (shiftedValues[i] >= localMax)
            {
                localMax = shiftedValues[i];
                localMaxAt = i;
            }

            localMaxAtArr[i] = localMaxAt;
        }

        int result = 0;
        for (int i = 0; i < values.Length - 1; i++)
        {
            int endAt = localMaxAtArr[i + 1];
            int iMax = values[i] + values[endAt] + i - endAt;
            result = Math.Max(result, iMax);
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] values, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.MaxScoreSightseeingPair(values);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase(new int[] { 8, 1, 5, 2, 6 }, 11); }
    [TestMethod] public void Test02() { TestBase(new int[] { 1, 2 }, 2); }
    [TestMethod] public void Test03() { TestBase(new int[] { 3, 3 }, 5); }
    [TestMethod] public void Test04() { TestBase(new int[] { 1, 2, 3, 4, 5 }, 8); }
    [TestMethod] public void Test05() { TestBase(new int[] { 5, 4, 3, 2, 1 }, 8); }

    [TestMethod] public void Test06() { TestBase(new int[] { 1, 1, 1, 1, 1 }, 1); }
    [TestMethod] public void Test07() { TestBase(new int[] { 8, 1, 1, 1, 8 }, 12); }
    [TestMethod] public void Test08() { TestBase(new int[] { 2, 1 }, 2); }
    [TestMethod] public void Test09() { TestBase(new int[] { 1, 2, 1 }, 2); }
    [TestMethod] public void Test10() { TestBase(new int[] { 2, 1, 2 }, 2); }

}
