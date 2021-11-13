using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0350;

public class Solution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        List<int> l1 = nums1.ToList();
        List<int> l2 = nums2.ToList();
        l1.Sort();
        l2.Sort();

        int pointer1 = 0;
        int pointer2 = 0;

        List<int> result = new List<int>();

        while(pointer1 < l1.Count && pointer2 < l2.Count)
        {
            if(l1[pointer1] == l2[pointer2])
            {
                result.Add(l1[pointer1]);
                pointer1++;
                pointer2++;
            }
            else if(l1[pointer1] < l2[pointer2])
            {
                pointer1++;
            }
            else
            {
                pointer2++;
            }
        }

        return result.ToArray();

    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums1, int[] nums2, int[] expected)
    {
        Solution solution = new Solution();
        int[] actual = solution.Intersect(nums1, nums2);
        for(int i = 0; i < actual.Length; i++)
        {
            Assert.AreEqual(expected[i], actual[i]);
        }
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }, new int[] { 2, 2 }); }
    [TestMethod] public void Test2() { TestBase(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, new int[] {4, 9}); }
    

}
