namespace Leetcode0088;

/// <summary>
/// Runtime: 124 ms, faster than 74.75% of C# online submissions for Merge Sorted Array.
/// Memory Usage: 41 MB, less than 30.53% of C# online submissions for Merge Sorted Array.
/// </summary>
public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int mIndex = m - 1;
        int nIndex = n - 1;
        for(int i = m+n-1; i >=0; i--)
        {
            if (nIndex < 0)
            {
                nums1[i] = nums1[mIndex];
                mIndex--;
            }
            else if(mIndex < 0)
            {
                nums1[i] = nums2[nIndex];
                nIndex--;
            }
            else if(nums1[mIndex] > nums2[nIndex])
            {
                nums1[i] = nums1[mIndex];
                mIndex--;
            }
            else
            {
                nums1[i] = nums2[nIndex];
                nIndex--;
            }
        }
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums1, int m, int[] nums2, int n, int[] expected)
    {
        Solution solution = new Solution();
        solution.Merge(nums1, m, nums2, n);
        for (int i = 0; i < nums1.Length; i++)
        {
            Assert.AreEqual(expected[0], nums1[0]);
        }
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 }); }
    [TestMethod] public void Test2() { TestBase(new int[] { 1 }, 1, new int[] { }, 0, new int[] { 1 }); }
    [TestMethod] public void Test3() { TestBase(new int[] { 0 }, 0, new int[] { 1 }, 1, new int[] { 1 }); }
    //[TestMethod] public void Test4() { TestBase(new int[] { 1, 2, 3, 0, 0, 0 }, 3, new int[] { 2, 5, 6 }, 3, new int[] { 1, 2, 2, 3, 5, 6 }); }


}
