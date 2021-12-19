namespace Leetcode0198;

/// <summary>
/// Runtime: 72 ms, faster than 98.37% of C# online submissions for House Robber.
/// Memory Usage: 37 MB, less than 60.48% of C# online submissions for House Robber.
/// </summary>
public class Solution
{
    public int Rob(int[] nums)
    {
        if(nums.Length == 1)
        {
            return nums[0];
        }
        if(nums.Length == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }
        int n = nums.Length;
        int a = nums[n - 1];
        int b = nums[n - 2];
        int c = nums[n - 3] + nums[n - 1];

        for(int i = n - 4; i >= 0; i--)
        {
            int d = nums[i] + Math.Max(a, b);
            a = b;
            b = c;
            c = d;
        }

        return Math.Max(b, c);
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

    [TestMethod] public void Test1() { TestBase(new int[] { 1, 2, 3, 1 },4); }
    [TestMethod] public void Test2() { TestBase(new int[] { 2, 7, 9, 3, 1 },12); }
    [TestMethod] public void Test3() { TestBase(new int[] { 0 }, 0); }
    [TestMethod] public void Test4() { TestBase(new int[] { 1,2 }, 2); }
    [TestMethod] public void Test5() { TestBase(new int[] { 2, 1 }, 2); }
    [TestMethod] public void Test6() { TestBase(new int[] { 1, 3, 1 }, 3); }
}
