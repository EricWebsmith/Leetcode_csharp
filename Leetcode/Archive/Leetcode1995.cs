namespace Leetcode1995;


public class Solution
{

    private int Count(List<int> list, int threshold)
    {
        for(int i=0; i<list.Count; i++)
        {
            if(list[i] > threshold)
            {
                return list.Count-i;
            }
        }
        return 0;
    }

    public int CountQuadruplets(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
        for(int i = 0; i < n; i++)
        {
            if (!map.ContainsKey(nums[i]))
            {
                map[nums[i]] = new List<int>();
            }
            map[nums[i]].Add(i);
        }

        int ans = 0;
        for(int i = 0; i < n; i++)
        {
            for(int j = i+1; j < n; j++)
            {
                
                for(int k = j+1; k < n; k++)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (map.ContainsKey(sum))
                    {
                        ans += Count(map[sum], k);
                    }
                }
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