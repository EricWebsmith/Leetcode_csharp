namespace Leetcode0413;

public class Solution
{
    private int Sum(int from, int to)
    {
        if (from == to) { return from; }
        return (from + to) * (to - from + 1) /2;
    }

    public int NumberOfArithmeticSlices(int[] nums)
    {
        if (nums.Length < 3)
        {
            return 0;
        }

        int result = 0;

        for (int i = nums.Length - 1; i > 0; i--)
        {
            nums[i] = nums[i] - nums[i - 1];
        }

        int diff = nums[1];
        int diffStart = 1;
        int diffLength = 0;
        for (int i = 2; i < nums.Length; i++)
        {
            if (diff != nums[i])
            {
                diffLength = i - diffStart;
                if (diffLength >= 2)
                {
                    result += Sum(1, diffLength - 1);
                }
                diffStart = i;
                diff = nums[i];
            }
        }


        diffLength = nums.Length - diffStart;
        if (diffLength >= 2)
        {
            result += Sum(1, diffLength - 1);
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
        int actual = solution.NumberOfArithmeticSlices(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase(new int[] { 1, 2, 3, 4 }, 3); }
    [TestMethod] public void Test02() { TestBase(new int[] { 1 }, 0); }
    [TestMethod] public void Test03() { TestBase(new int[] { 3, 3 }, 0); }
    [TestMethod] public void Test04() { TestBase(new int[] { 1, 2, 3, 4, 5 }, 6); }

    [TestMethod] public void Test05() { TestBase(new int[] { 1 }, 0); }
    [TestMethod] public void Test06() { TestBase(new int[] { 0 }, 0); }
    [TestMethod] public void Test07() { TestBase(new int[] { 0, 0, 0 }, 1); }
    [TestMethod] public void Test08() { TestBase(new int[] { 0, 1, 0 }, 0); }
    [TestMethod] public void TestLast() { TestBase(new int[] { 1, 2, 3, 4 }, 3); }
}
