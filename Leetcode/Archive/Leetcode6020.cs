namespace Leetcode6020;


public class Solution
{
    public bool DivideArray(int[] nums)
    {
        Array.Sort(nums);   
        for(int i=0; i<nums.Length; i += 2)
        {
            if(nums[i] != nums[i + 1])
            {
                return false;
            }
        }
        return true;
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