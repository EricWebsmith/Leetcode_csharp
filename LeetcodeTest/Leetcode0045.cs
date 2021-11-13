using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0045;

public class Solution
{
    public int Jump(int[] nums)
    {
        int[] results = new int[nums.Length];
        results[nums.Length - 1] = 0;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            int jumpPower = nums[i];
            int minJump = 1 + results[i+1];
            for (int j = 1; j <= jumpPower && i + j <= nums.Length - 1; j++)
            {
                minJump = Math.Min(minJump,results[i+j]+1);
            }
            results[i] = minJump;
        }
        return results[0];
    }

    public int Jump2(int[] nums)
    {
        int max = 0;
        int nextMax = 0;
        int jumps = 0;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            nextMax = Math.Max(nextMax, i + nums[i]);
            if (nextMax >= nums.Length - 1)
            {
                return jumps + 1;
            }
            if (i == max)
            {
                max = nextMax;
                jumps++;
            }
        }
        return jumps;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.Jump2(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 2, 3, 1, 1, 4 }, 2); }
    [TestMethod] public void Test2() { TestBase(new int[] { 2, 3, 0, 1, 4 }, 2); }
    [TestMethod] public void Test3() { TestBase(new int[] { 3, 3 }, 1); }
    [TestMethod] public void Test4() { TestBase(new int[] { 1, 1, 1, 1 }, 3); }
    [TestMethod] public void Test5() { TestBase(new int[] { 0 }, 0); }
    [TestMethod] public void Test6() { TestBase(new int[] { 4, 2, 1, 0, 4 }, 1); }
    [TestMethod] public void Test8() { TestBase(new int[] { 4, 3, 8, 0, 0, 0, 0, 4 }, 2); }
    


}
