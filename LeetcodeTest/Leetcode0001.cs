using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0001;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        // covert and sort
        List<int> numList = nums.ToList();
        numList.Sort();
        // two pointers
        int lo = 0;
        int hi = nums.Length-1;
        while (lo < hi)
        {
            if (numList[lo] + numList[hi] == target)
            {
                //return new int[] { nums[lo], nums[hi] };
                break;
            }
            else if (numList[lo] + numList[hi] < target)
            {
                lo++;
            }
            else
            {
                hi--;
            }
        }

        int lo_index = 0;
        int hi_index = 0;
        for(int i = 0; i < nums.Length; i++)
        {
            if(nums[i] == numList[lo])
            {
                lo_index = i;
                break;
            }
        }

        for(int j = 0; j < nums.Length; j++)
        {
            if (j == lo_index)
            {
                continue;
            }

            if (nums[j] == numList[hi])
            {
                hi_index = j;
                break;
            }
        }

        if (lo_index > hi_index)
        {
            int temp = lo_index;
            lo_index = hi_index;
            hi_index = temp;
        }

        return new int[] { lo_index, hi_index };
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int target, int[] expected)
    {
        Solution solution = new Solution();
        int[] actual = solution.TwoSum(nums, target);
        Assert.AreEqual(expected[0], actual[0]);
        Assert.AreEqual(expected[1], actual[1]);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 2, 7, 11, 15 },9, new int[] { 0, 1 }); }
    [TestMethod] public void Test2() { TestBase(new int[] { 3, 2, 4 },6, new int[] {1,2}); }
    [TestMethod] public void Test3() { TestBase(new int[] { 3,3 },6, new int[] { 0, 1 }); }
    [TestMethod] public void Test4() { TestBase(new int[] { -1, -2, -3, -4, -5 }, -8, new int[] { 2, 4 }); }


}
