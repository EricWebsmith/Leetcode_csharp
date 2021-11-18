namespace Leetcode0055;

public class Solution
{
    public bool CanJump(int[] nums)
    {
        bool[] results = new bool[nums.Length];
        results[nums.Length - 1] = true;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            int jumps = nums[i];
            for (int j = 1; j <= jumps && i + j <= nums.Length - 1; j++)
            {
                if (results[i + j])
                {
                    results[i] = true;
                    break;
                }
            }
        }
        return results[0];
    }

    public bool CanJump2(int[] nums)
    {
        var maxLength = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (i <= maxLength)
            {
                maxLength = Math.Max(maxLength, i + nums[i]);
            }

            if (maxLength >= nums.Length - 1)
            {
                return true;
            }
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
        bool actual = solution.CanJump2(nums);
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
