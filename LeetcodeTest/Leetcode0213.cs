using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0213;

public class Solution
{
    public int RobLine(int[] nums)
    {
        if(nums.Length == 1)
        {
            return nums[0];
        }
        
        if(nums.Length == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }

        int[] income = new int[nums.Length];
        income[income.Length - 1] = nums[nums.Length - 1];
        income[income.Length - 2] = nums[nums.Length - 2];
        int maxIncome = Math.Max(nums[nums.Length - 1], nums[nums.Length - 2]);
        for(int i = nums.Length - 3; i >= 0; i--)
        {
            income[i] = nums[i] + income[i+2];
            for (int j = i+3;j< nums.Length; j++)
            {
                income[i] = Math.Max(income[i], nums[i] + income[j]);
            }
            maxIncome = Math.Max(maxIncome, income[i]);
        }

        return maxIncome;
    }

    public int Rob(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        if (nums.Length == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }
        int[] nums1 = new int[nums.Length-1];
        int[] nums2 = new int[nums.Length - 1];
        for(int i = 0; i < nums.Length-1; i++)
        {
            nums1[i] = nums[i];
            nums2[i] = nums[i+1];
        }
        int plan1 = RobLine(nums1);
        int plan2 = RobLine(nums2);
        return Math.Max(plan1, plan2);
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.Rob(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 2,3,2 },3); }
    [TestMethod] public void Test2() { TestBase(new int[] { 1, 2, 3, 1 },4); }
    [TestMethod] public void Test3() { TestBase(new int[] { 1,2,3 }, 3); }
    [TestMethod] public void Test4() { TestBase(new int[] { 0 }, 0); }
}
