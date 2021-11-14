using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Leetcode0152;

public class Solution
{
    private int Product(int[] nums , int start, int end)
    {
        int product = 1;
        for(int i=start;i<=end;i++)
        {
            product *= nums[i];
        }
        return product;
    }

    private int MaxProductNoZero(int[] nums, int start, int end)
    {
        if(start == end)
        {
            return nums[start];
        }
        int firstNegative = -1;
        int lastNegative = -1;
        int countNegative = 0;
        for(int i = start; i <= end; i++)
        {
            if(nums[i] < 0)
            {
                countNegative++;
                if(firstNegative == -1)
                {
                    firstNegative = i;
                }
                lastNegative = i;
            }
        }

        if(countNegative % 2 == 0)
        {
            return Product(nums, start, end);
        }

        return Math.Max(Product(nums, firstNegative+1, end), Product(nums, start, lastNegative-1));
    }

    public int MaxProduct(int[] nums)
    {
        if (nums.Length == 1) { return nums[0]; }
        int maxValue = nums[0];
        int start = 0;
        int end = nums.Length - 1;
        for(int i=1;i< nums.Length; i++)
        {
            // find end
            if (nums[i] == 0 && nums[i-1]!=0)
            {
                maxValue = Math.Max(0, maxValue);
                end = i - 1;
                if(end>= start)
                {
                    int curMaxValue = MaxProductNoZero(nums, start, end);
                    maxValue = Math.Max(maxValue, curMaxValue);
                }
                
                start = i + 1;
            }

            if(nums[i] !=0 && nums[i - 1] == 0)
            {
                start = i;
            }
        }

        if(nums[nums.Length-1] != 0)
        {
            int curMaxValue = MaxProductNoZero(nums, start, nums.Length - 1);
            maxValue = Math.Max(maxValue, curMaxValue);
        }


        return maxValue;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.MaxProduct(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase(new int[] { 2, 3, -2, 4 }, 6); }
    [TestMethod] public void Test02() { TestBase(new int[] { -2, 0, -1 }, 0); }
    [TestMethod] public void Test03() { TestBase(new int[] { 0 }, 0); }
    [TestMethod] public void Test04() { TestBase(new int[] { -1 }, -1); }
    [TestMethod] public void Test05_TwoNegative() { TestBase(new int[] { -1, -1 }, 1); }
    [TestMethod] public void Test06() { TestBase(new int[] { 4, -2, 3, 2 }, 6); }
    [TestMethod] public void Test07() { TestBase(new int[] { 4, -2, 0, 2, -2, 3, 2 }, 6); }
    [TestMethod] public void Test08() { TestBase(new int[] { 2, -2, 3, 2 }, 6); }
    [TestMethod] public void Test09() { TestBase(new int[] { 2, -5, -2, -4, 3 }, 24); }
    [TestMethod] public void Test10() { TestBase(new int[] { 2, -5, -4, 3 }, 120); }
    [TestMethod] public void Test11() { TestBase(new int[] { 4, -2, 3, 2, -2, 3, 3, -2, 1 }, 864); }


}
