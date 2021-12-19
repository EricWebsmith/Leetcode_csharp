namespace Leetcode0213;

/// <summary>
/// Runtime: 88 ms, faster than 45.57% of C# online submissions for House Robber II.
/// Memory Usage: 37.6 MB, less than 5.27% of C# online submissions for House Robber II.
/// </summary>
public class Solution
{
    public int RobLine(int[] nums, int start, int end)
    {
        int a = nums[end];
        int b = nums[end - 1];
        int c = a + nums[end-2];
        int d;
        for(int i = end - 3;i>= start; i--)
        {
            d = Math.Max(a, b) + nums[i];
            a = b;
            b = c;
            c = d;
        }
        Console.WriteLine($"{b} {c}");
        return Math.Max(b, c);
    }

    public int Rob(int[] nums)
    {
        int n = nums.Length;

        if (nums.Length <= 3)
        {
            return nums.Max();
        }

        int plan1 = RobLine(nums, 0, n-2);
        int plan2 = RobLine(nums, 1, n-1);
        return Math.Max(plan1, plan2);
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

    [TestMethod] public void Test1() { TestBase(new int[] { 2,3,2 },3); }
    [TestMethod] public void Test2() { TestBase(new int[] { 1, 2, 3, 1 },4); }
    [TestMethod] public void Test3() { TestBase(new int[] { 1,2,3 }, 3); }
    [TestMethod] public void Test4() { TestBase(new int[] { 0 }, 0); }
    [TestMethod] public void Test5() { TestBase(new int[] { 200, 3, 140, 20, 10 }, 340); }
    [TestMethod] public void Test6() { TestBase(new int[] { 4, 1, 2, 7, 5, 3, 1 }, 14); }
}
