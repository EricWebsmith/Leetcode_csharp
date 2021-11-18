using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0448;

public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        List<int> result = new List<int>();
        int[] markers = new int[nums.Length];
        for(int i =0;i<nums.Length;i++)
        {
            markers[nums[i]-1] = 1;
        }

        for(int i = 1; i <= nums.Length; i++)
        {
            if(markers[i-1] == 0)
            {
                result.Add(i);
            }
        }

        int c = 1;
        
        c++;
        c++;

        return result;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int[] nums, int expected) 
    {
        IList<int> actual = (new Solution()).FindDisappearedNumbers(nums);
        Assert.AreEqual(expected, actual.Count);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 4, 3, 2, 7, 8, 2, 3, 1 }, 2); }
    [TestMethod] public void Test2() { TestBase(new int[] { 1, 1 }, 1); }
}