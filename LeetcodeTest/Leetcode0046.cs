using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0046;

public class Solution
{

    public IList<IList<int>> Permute(int[] nums)
    {
        if (nums.Length == 1)
        {
            return new List<IList<int>> { new List<int>() { nums[0] } };
        }

        IList<IList<int>> results = new List<IList<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            var temp = nums.ToList();
            temp.Remove(nums[i]);
            int[] previousNums = temp.ToArray();
            IList<IList<int>> previousResults = Permute(previousNums);
            foreach (IList<int> arr in previousResults)
            {
                arr.Add(nums[i]);
                results.Add(arr);
            }
        }
        return results;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        IList<IList<int>> actual = solution.Permute(nums);
        Assert.AreEqual(expected, actual.Count);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 1, 2, 3 }, 6); }
    [TestMethod] public void Test2() { TestBase(new int[] { 0, 1 }, 2); }
    [TestMethod] public void Test3() { TestBase(new int[] { 1, 2, 3, 4 }, 24); }

}
