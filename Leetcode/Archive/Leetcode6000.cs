namespace Leetcode6000;


public class Solution
{
    public int[] SortEvenOdd(int[] nums)
    {
        int n = nums.Length;
        int n1 = n / 2 + n % 2;
        int n2 = n / 2;
        int[] nums1 = new int[n1];
        int[] nums2 = new int[n2];

        int i1 = 0;
        int i2 = 0;
        for(int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                i1 = i / 2;
                nums1[i1] = nums[i];
            }
            else
            {
                i2 = i / 2;
                nums2[i2] = nums[i];
            }
        }

        Array.Sort(nums1);
        Array.Sort(nums2);

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                i1 = i / 2;
                 nums[i] = nums1[i1] ;
            }
            else
            {
                i2 = i / 2;
                nums[i] = nums2[n2-1-i2]  ;
            }
        }

        return nums;
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