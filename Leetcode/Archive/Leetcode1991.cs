namespace Leetcode1991;


public class Solution
{
    public int FindMiddleIndex(int[] nums)
    {
        int n = nums.Length;
        int[] leftAcc = new int[n];
        leftAcc[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            leftAcc[i] = leftAcc[i-1]+nums[i];
        }

        int[] rightAcc = new int[n];
        rightAcc[n-2] = nums[n-1];
        for(int i = n-1; i >= 0; i--)
        {
            rightAcc[i] = rightAcc[i+1]+nums[i];
        }

        for(int i = 0; i < n; i++)
        {
            int left = i==0?0:leftAcc[i-1];
            int right = i==(n-1)?0:rightAcc[i+1];
            if(left == right)
            {
                return i;
            }
        }

        return -1;
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