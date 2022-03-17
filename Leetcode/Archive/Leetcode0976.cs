namespace Leetcode0976;


public class Solution
{
    public int LargestPerimeter(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        for(int i=n-1; i>=2; i--)
        {
            if(nums[i] < nums[i - 1] + nums[i - 2])
            {
                return nums[i]+ nums[i - 1] + nums[i - 2];
            }
        }
        return 0;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().LargestPerimeter(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[2,1,2]", 5); }
    [TestMethod] public void Test2() { TestBase("[1,2,1]", 0); }
    [TestMethod] public void Test3() { TestBase("[9,6,3,2,1]", 0); }
    [TestMethod] public void Test4() { TestBase("[9,6,3,2,2]", 7); }
    [TestMethod] public void Test5() { TestBase("[10,5,5,5]", 15); }

}