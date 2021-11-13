using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode0283;

public class Solution
{
    public void MoveZeroes(int[] nums)
    {
        int zeroes = 0;
        for (int i = nums.Length -1; i >= 0; i--)
        {
            if(nums[i] == 0)
            {
                for(int j=i; j < nums.Length-1; j++)
                {
                     nums[j] = nums[j+1];
                }
                zeroes++;
            }
        }

        for(int i = nums.Length-1; i > nums.Length - 1 - zeroes; i--)
        {
            nums[i] = 0;
        }
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int[] expected)
    {
        Solution solution = new Solution();
        solution.MoveZeroes(nums);
        for(int i = 0; i < nums.Length; i++)
        {
            Assert.AreEqual(expected[i], nums[i]);
        }
        
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 }); }
    [TestMethod] public void Test2() { TestBase(new int[] { 0 }, new int[] { 0 }); }
    [TestMethod] public void Test3() { TestBase(new int[] { 0, 1, 0 }, new int[] { 1, 0, 0 }); }

}
