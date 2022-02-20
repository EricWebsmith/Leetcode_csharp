namespace Leetcode1984;


public class Solution
{
    public int MinimumDifference(int[] nums, int k)
    {
        if (k == 1) { return 0; }
        int n = nums.Length;
        Array.Sort(nums);
        int minDiff = int.MaxValue;
        for (int i = k-1; i < n; i++)
        {
            minDiff = Math.Min(minDiff, nums[i]- nums[i-k+1]);
        }

        return minDiff;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}