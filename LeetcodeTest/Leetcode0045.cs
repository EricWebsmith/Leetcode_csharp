namespace Leetcode0045;

/// <summary>
/// Runtime: 100 ms, faster than 82.20% of C# online submissions for Jump Game II.
/// Memory Usage: 41 MB, less than 32.32% of C# online submissions for Jump Game II.
/// </summary>
public class Solution
{
    public int Jump(int[] nums)
    {
        int n = nums.Length;
        if (n == 1) { return 0; }
        int max = 0;
        int nextMax = 0;
        int jumps = 0;
        for (int i = 0; i < n - 1; i++)
        {
            nextMax = Math.Max(nextMax , nums[i] + i);

            if (nextMax >= n - 1)
            {
                return jumps + 1;
            }

            if (max == i)
            {
                max = nextMax;
                jumps++;
            }
        }
        return -1;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.Jump(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 2, 3, 1, 1, 4 }, 2); }
    [TestMethod] public void Test2() { TestBase(new int[] { 2, 3, 0, 1, 4 }, 2); }
    [TestMethod] public void Test3() { TestBase(new int[] { 3, 3 }, 1); }
    [TestMethod] public void Test4() { TestBase(new int[] { 1, 1, 1, 1 }, 3); }
    [TestMethod] public void Test5() { TestBase(new int[] { 0 }, 0); }
    [TestMethod] public void Test6() { TestBase(new int[] { 4, 2, 1, 0, 4 }, 1); }
    [TestMethod] public void Test8() { TestBase(new int[] { 4, 3, 8, 0, 0, 0, 0, 4 }, 2); }



}
