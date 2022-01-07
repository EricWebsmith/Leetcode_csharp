namespace Leetcode0055;

/// <summary>
/// Runtime: 164 ms, faster than 94.50% of C# online submissions for Jump Game.
/// Memory Usage: 43.6 MB, less than 29.25% of C# online submissions for Jump Game.
/// </summary>
public class Solution
{

    public bool CanJump(int[] nums)
    {
        var maxLength = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if(i > maxLength)
            {
                return false;
            }

            maxLength = Math.Max(maxLength, i + nums[i]);
        }

        return maxLength >= nums.Length - 1;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.CanJump(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 2, 3, 1, 1, 4 }, true); }
    [TestMethod] public void Test2() { TestBase(new int[] { 3, 2, 1, 0, 4 }, false); }
    [TestMethod] public void Test3() { TestBase(new int[] { 3, 3 }, true); }
    [TestMethod] public void Test4() { TestBase(new int[] { 0, 0 }, false); }
    [TestMethod] public void Test5() { TestBase(new int[] { 0 }, true); }
    [TestMethod] public void Test6() { TestBase(new int[] { 4, 2, 1, 0, 4 }, true); }
    [TestMethod] public void Test7() { TestBase(new int[] { 4, 3, 2, 1, 0, 4 }, false); }
    [TestMethod] public void Test8() { TestBase(new int[] { 4, 3, 8, 0, 0, 0, 0, 4 }, true); }


}
