namespace Leetcode0658;


public class Solution
{
    public IList<int> FindClosestElements(int[] arr, int k, int x)
    {
        int n = arr.Length;
        int left = 0;
        int right = n;
        while(left < right)
        {
            int mid = (left + right) >> 1;
            if (arr[mid] < x)
            {
                left = mid + 1;
            } 
            else
            {
                right = mid;
            }
        }
        left--;

        int l = 0;
        while (l < k)
        {
            if (right==n || (left>=0 && x - arr[left] <= arr[right] - x))
            {
                left--;
            } 
            else
            {
                right++;
            }
            l++;
        }

        return arr.Skip(left+1).Take(k).ToList();
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string arrStr, int k, int x, string expectedStr)
    {
        int[] arr = arrStr.LeetcodeToArray();
        IList<int> actual = new Solution().FindClosestElements(arr, k, x);
        Assert.AreEqual(actual.ToLeetcode(), expectedStr);
    }

    [TestMethod] public void Test1() { TestBase("[1,2,3,4,5]", 4, 3, "[1,2,3,4]"); }
    [TestMethod] public void Test2() { TestBase("[1,2,3,4,5]", 4, -1, "[1,2,3,4]"); }
    [TestMethod] public void Test3() { TestBase("[1, 1, 1, 10, 10, 10]", 1, 9, "[10]"); }
}

/*
Runtime: 196 ms, faster than 94.26% of C# online submissions for Find K Closest Elements.
Memory Usage: 54.1 MB, less than 11.48% of C# online submissions for Find K Closest Elements.
 */