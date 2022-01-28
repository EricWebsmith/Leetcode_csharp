namespace Leetcode0941;


public class Solution
{
    public bool ValidMountainArray(int[] arr)
    {
        int n = arr.Length;
        if (n < 3) { return false; }
        if (arr[0] >= arr[1]) { return false; }
        if (arr[n - 1] >= arr[n - 2]) { return false; }
        int leftPeakIndex = 0;
        for (int i = 1; i < n; i++)
        {
            if (arr[i] > arr[leftPeakIndex])
            {
                leftPeakIndex = i;
            }
            else
            {
                break;
            }
        }

        int rightPeakIndex = n - 1;
        for(int i = n-2;i >= 0; i--)
        {
            if(arr[i] > arr[rightPeakIndex])
            {
                rightPeakIndex = i;
            }
            else
            {
                break;
            }
        }

        return leftPeakIndex == rightPeakIndex;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int[] arr, bool expected)
    {
        bool actual = new Solution().ValidMountainArray(arr);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 2, 1 }, false); }
    [TestMethod] public void Test2() { TestBase(new int[] {3, 5, 5}, false); }
    [TestMethod] public void Test3() { TestBase(new int[] {0, 3, 2, 1}, true); }
    //[TestMethod] public void Test4() { TestBase(); }

}