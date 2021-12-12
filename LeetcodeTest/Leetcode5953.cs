namespace Leetcode5953;


public class Solution
{
    public long SubArrayRanges(int[] nums)
    {
        int n = nums.Length;

        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            int largest = nums[i];
            int smallest = nums[i];
            for (int j = i + 1; j < n; j++)
            {
                largest = Math.Max(largest, nums[j]);
                smallest = Math.Min(smallest, nums[j]);
                ans += largest - smallest;
            }
        }

        return ans;
    }
}




[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, long expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        long actual = new Solution().SubArrayRanges(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[1,2,3]", 4); }
    [TestMethod] public void Test2() { TestBase("[1,3,3]", 4); }
    [TestMethod] public void Test3() { TestBase("[4,-2,-3,4,1]", 59); }
    [TestMethod] public void Test4() { TestBase("[1]", 0); }
}