namespace Leetcode0152;

/// <summary>
/// Runtime: 64 ms, faster than 100.00% of C# online submissions for Maximum Product Subarray.
/// Memory Usage: 38.9 MB, less than 8.97% of C# online submissions for Maximum Product Subarray.
/// Always keep the current max and current min, because current min will be flipped to max.
/// </summary>
public class Solution
{
    public int MaxProduct(int[] nums)
    {
        int result = nums[0];
        int currentMin = nums[0];
        int currentMax = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if(nums[i] == 0)
            {
                result = Math.Max(result, 0);
                currentMax = 1;
                currentMin = 1;
                continue;
            }

            int[] options = new int[] {currentMax * nums[i], currentMin * nums[i] , nums[i] };
            Array.Sort(options);
            currentMin = options[0];
            currentMax = options[2];
            result = Math.Max(result, currentMax);
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.MaxProduct(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase(new int[] { 2, 3, -2, 4 }, 6); }
    [TestMethod] public void Test02() { TestBase(new int[] { -2, 0, -1 }, 0); }
    [TestMethod] public void Test03() { TestBase(new int[] { 0 }, 0); }
    [TestMethod] public void Test04() { TestBase(new int[] { -1 }, -1); }
    [TestMethod] public void Test05_TwoNegative() { TestBase(new int[] { -1, -1 }, 1); }
    [TestMethod] public void Test06() { TestBase(new int[] { 4, -2, 3, 2 }, 6); }
    [TestMethod] public void Test07() { TestBase(new int[] { 4, -2, 0, 2, -2, 3, 2 }, 6); }
    [TestMethod] public void Test08() { TestBase(new int[] { 2, -2, 3, 2 }, 6); }
    [TestMethod] public void Test09() { TestBase(new int[] { 2, -5, -2, -4, 3 }, 24); }
    [TestMethod] public void Test10() { TestBase(new int[] { 2, -5, -4, 3 }, 120); }
    [TestMethod] public void Test11() { TestBase(new int[] { 4, -2, 3, 2, -2, 3, 3, -2, 1 }, 864); }

}
