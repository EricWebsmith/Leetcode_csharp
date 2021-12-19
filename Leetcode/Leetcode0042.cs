namespace Leetcode0042;

public class Solution
{
    public int Trap(int[] height)
    {
        int[] maxFromLeft = new int[height.Length];
        int[] maxFromRight = new int[height.Length];

        maxFromLeft[0] = height[0];
        for (int i = 1; i < height.Length; i++)
        {
            maxFromLeft[i] = Math.Max(maxFromLeft[i-1], height[i]);
        }

        maxFromRight[height.Length-1] = height[height.Length-1];
        for(int i = height.Length - 2; i >= 0; i--)
        {
            maxFromRight[i] = Math.Max(maxFromRight[i+1], height[i]);
        }

        int water = 0;
        for(int i = 1; i < height.Length - 1; i++)
        {
            water += Math.Min(maxFromLeft[i], maxFromRight[i]) - height[i];
        }
        return water;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int[] height, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.Trap(height);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 },6); }
    [TestMethod] public void Test2() { TestBase(new int[] { 4, 2, 0, 3, 2, 5 },9); }
    [TestMethod] public void Test3() { TestBase(new int[] { 3,3 },0); }
    [TestMethod] public void Test4() { TestBase(new int[] { 1,2,3,4,5 }, 0); }

    [TestMethod] public void Test5() { TestBase(new int[] { 1 }, 0); }
    [TestMethod] public void Test6() { TestBase(new int[] { 0 }, 0); }
    [TestMethod] public void Test7() { TestBase(new int[] { 0, 0, 0 }, 0); }
    [TestMethod] public void Test8() { TestBase(new int[] { 0, 1, 0 }, 0); }
}
