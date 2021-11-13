using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0977;
public class Solution
{
    public int GetLastNegative(int[] nums)
    {
        // mid is last negative
        int mid = nums.Length / 2;
        int lo = 0;
        int hi = nums.Length - 1;

        while (lo <= hi)
        {
            if (nums[mid] < 0 && mid + 1 < nums.Length && nums[mid + 1] >= 0)
            {
                break;
            }
            else if (nums[mid] < 0)
            {
                lo = mid + 1;
            }
            else
            {
                hi = mid - 1;
            }

            mid = (lo + hi) / 2;
        }

        return mid;
    }

    public int[] SortedSquares(int[] nums)
    {
        if (nums[0] >= 0)
        {
            return (from num in nums select num * num).ToArray();
        }

        if (nums[nums.Length - 1] < 0)
        {
            return (from num in nums.Reverse() select num * num).ToArray();
        }

        int lastNegative = GetLastNegative(nums);

        List<int> results = new List<int>();
        int negative = lastNegative;
        int positive = lastNegative + 1;
        while (negative >= 0 && positive < nums.Length)
        {
            if (-nums[negative] <= nums[positive])
            {
                results.Add(nums[negative] * nums[negative]);
                negative--;
            }
            else
            {
                results.Add(nums[positive] * nums[positive]);
                positive++;
            }
        }

        // add remaining negative numbers
        while (negative >= 0)
        {
            results.Add(nums[negative] * nums[negative]);
            negative--;
        }

        while (positive < nums.Length)
        {
            results.Add(nums[positive] * nums[positive]);
            positive++;
        }
        return results.ToArray();
    }
}



[TestClass]
public class Leetcode0977
{
    
    public void TestBase(int[] nums, int mid)
    {
        Solution solution = new Solution();
        int lastNegative = solution.GetLastNegative(nums);
        Assert.AreEqual(mid, lastNegative);
    }

    [TestMethod]
    public void Test1()
    {
        TestBase(new int[] { -4, -1, 0, 3, 10 }, 1);
    }

    [TestMethod]
    public void Test2()
    {
        TestBase(new int[] { -7, -3, 2, 3, 11 }, 1);
    }
}

