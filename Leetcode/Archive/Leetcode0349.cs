namespace Leetcode0349;

/// <summary>
/// Runtime: 124 ms, faster than 81.14% of C# online submissions for Intersection of Two Arrays.
/// Memory Usage: 41.4 MB, less than 52.31% of C# online submissions for Intersection of Two Arrays.
/// </summary>
public class Solution
{
    public int[] Intersection(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);
        int n1 = nums1.Length;
        int n2 = nums2.Length;
        int i = 0;
        int j = 0;
        List<int> result = new List<int>();
        while(i<n1 && j < n2)
        {
            if(nums1[i] == nums2[j])
            {
                if(result.Count ==0 || nums1[i] != result.Last())
                {
                    result.Add(nums1[i]);
                }
                i++;
                j++;
            }
            else if(nums1[i] < nums2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
            
        }

        return result.ToArray();

    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string nums1Str, string nums2Str, string expected)
    {
        int[] nums1 = nums1Str.LeetcodeToArray();
        int[] nums2 = nums2Str.LeetcodeToArray();
        var actual = new Solution().Intersection(nums1, nums2);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[1,2,2,1]", "[2,2]", "[2]"); }
    [TestMethod] public void Test2() { TestBase("[4,9,5]", "[9,4,9,8,4]", "[4,9]"); }
    [TestMethod] public void Test3() { TestBase("[1]", "[1]", "[1]"); }
    [TestMethod] public void Test4() { TestBase("[1]","[2]","[]"); }
}