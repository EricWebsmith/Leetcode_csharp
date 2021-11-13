using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0740;

public class Solution
{

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

        int[] income = new int[nums.Length];
        income[income.Length - 1] = nums[nums.Length - 1];
        income[income.Length - 2] = nums[nums.Length - 2];
        int maxIncome = Math.Max(nums[nums.Length - 1], nums[nums.Length - 2]);
        for (int i = nums.Length - 3; i >= 0; i--)
        {
            income[i] = nums[i] + income[i + 2];
            for (int j = i + 3; j < nums.Length; j++)
            {
                income[i] = Math.Max(income[i], nums[i] + income[j]);
            }
            maxIncome = Math.Max(maxIncome, income[i]);
        }

        return maxIncome;
    }


    public int DeleteAndEarn(int[] nums)
    {
        SortedDictionary<int, int> value_counts = new SortedDictionary<int, int>();


        
        for(int i = 0; i< nums.Length; i++)
        {
            if(value_counts.ContainsKey(nums[i]))
            {
                value_counts[nums[i]]++;
            }
            else
            {
                value_counts.Add(nums[i], 1);
            }
        }

        int maxValue = value_counts.Keys.Last();
        int[] neighborHood = new int[maxValue];
        foreach(KeyValuePair<int, int> kv in value_counts)
        {
            neighborHood[kv.Key-1] = kv.Key * kv.Value;
        }

        return Rob(neighborHood);
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.DeleteAndEarn(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 3, 4, 2 },6); }
    [TestMethod] public void Test2() { TestBase(new int[] { 2, 2, 3, 3, 3, 4 },9); }

}
