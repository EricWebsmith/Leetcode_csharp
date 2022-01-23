namespace Leetcode5989;


public class Solution
{
    public int CountElements(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int minCount = 0;
        int maxCount = 0;
        for(int i = 1; i < n; i++)
        {
            if(nums[i] == nums[0])
            {
                minCount++;
            }
            else
            {
                break;
            }
        }

        for(int i = n-2;i >= 0; i--)
        {
            if(nums[i] == nums[n - 1])
            {
                maxCount++;
            }
            else
            {
                break;
            }
        }

        return Math.Max(0, n - minCount - maxCount - 2);
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