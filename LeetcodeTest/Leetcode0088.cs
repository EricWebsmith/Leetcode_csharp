using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Leetcode0088;

public class Solution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int[] temp = new int[m];
        for (int i = 0; i < m; i++)
        {
            temp[i] = nums1[i];
        }

        int index1 = 0;
        int index2 = 0;
        int index = 0;
        while (index < m + n && index1 < m && index2<n)
        {
            if (temp[index1] <= nums2[index2])
            {
                nums1[index] = temp[index1];
                index1++;
            }
            else
            {
                nums1[index] = nums2[index2];
                index2++;
            }
            index++;
        }

        while (index1 < m )
        {
            nums1[index] = temp[index1];
            index1++;
            index++;
        }

        while (index2 < n)
        {
            nums1[index] = nums2[index2];
            index2++;
            index++;
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
