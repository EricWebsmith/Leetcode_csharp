namespace Leetcode5990;


public class Solution
{
    public IList<int> FindLonely(int[] nums)
    {
        int n= nums.Length;
        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; i++)
        {
            if (!dict.ContainsKey(nums[i]))
            {
                dict[nums[i]] = new List<int>();
            }
            dict[nums[i]].Add(i);
        }

        IList<int> ans = new List<int>();
        foreach(var kv in dict)
        {
            if (kv.Value.Count > 1)
            {
                continue;
            }

            if(dict.ContainsKey(kv.Key-1) || dict.ContainsKey(kv.Key + 1))
            {
                continue ;
            }

            ans.Add(kv.Key);
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