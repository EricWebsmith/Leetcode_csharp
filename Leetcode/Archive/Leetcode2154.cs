namespace Leetcode2154;


public class Solution
{
    public int FindFinalValue(int[] nums, int original)
    {
        int n = nums.Length;
        Array.Sort(nums);
        for(int i = 0; i < n; i++)
        {
            if(nums[i] == original)
            {
                original *= 2;
            }
        }
        return original;
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