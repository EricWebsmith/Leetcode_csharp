namespace Leetcode1502;


public class Solution
{
    public bool CanMakeArithmeticProgression(int[] arr)
    {
        Array.Sort(arr);
        int diff =Math.Abs( arr[0] - arr[1]);
        for(int i = 1;i< arr.Length - 1; i++)
        {
            int newDiff = arr[i]-arr[i+1];
            if (diff != newDiff)
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