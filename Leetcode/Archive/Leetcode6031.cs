namespace Leetcode6031;


public class Solution
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        int n = nums.Length;
        bool [] indices = new bool[n];
        for(int i = 0; i < n; i++)
        {
            if(nums[i] == key)
            {
                int start = Math.Max(0, i - k);
                int end = Math.Min(nums.Length - 1, i + k);
                for(int j = start; j <= end; j++)
                {
                    indices[j] = true;
                }
            }
        }

        List<int> ans = new List<int>();
        for(int i = 0;i < n; i++)
        {
            if (indices[i])
            {
                ans.Add(i);
            }
        }

        return ans;
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