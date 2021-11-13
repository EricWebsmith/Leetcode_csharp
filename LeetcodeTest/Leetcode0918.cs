using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Leetcode0918;

public class Solution
{
    public int MaxSubarraySumCircular(int[] nums)
    {
        int maxSub = nums[0];
        int curSum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            curSum = Math.Max(curSum + nums[i], nums[i]);
            maxSub = Math.Max(maxSub, curSum);
        }

        int minSub = nums[0];
        curSum = 0;
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            curSum = Math.Min(curSum + nums[i], nums[i]);
            minSub = Math.Min(minSub, curSum);
        }
        int circMax = sum - minSub;
        if (circMax <= 0)
        {
            return maxSub;
        }

        return Math.Max(maxSub, circMax);
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.MaxSubarraySumCircular(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 1, -2, 3, -2 }, 3); }
    [TestMethod] public void Test2() { TestBase(new int[] { 5, -3, 5 }, 10); }
    [TestMethod] public void Test3() { TestBase(new int[] { 3, -1, 2, -1 }, 4); }
    [TestMethod] public void Test4() { TestBase(new int[] { 3, -2, 2, -3 }, 3); }
    [TestMethod] public void Test5() { TestBase(new int[] { -2, -3, -1 }, -1); }
    [TestMethod] public void Test6() { TestBase(new int[] { 5, 1, -3, 5 }, 11); }
    [TestMethod] public void Test7() { TestBase(new int[] { 5, 6, 1, 4, 8, -8, 7, -5, 3 }, 29); }
    //    [TestMethod] public void Test4() { TestBase(new int[] { -1, 0, 1, 1, 55 }, 3, 2); }

}

// Runtime: 76 ms, faster than 99.22% of C# online submissions for 3Sum Closest.
// Memory Usage: 41.6 MB, less than 5.18% of C# online submissions for 3Sum Closest.