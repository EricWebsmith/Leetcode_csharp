namespace Leetcode0347;


public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        Dictionary<int, int> frequentDict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (frequentDict.ContainsKey(nums[i]))
            {
                frequentDict[nums[i]]++;
            }
            else
            {
                frequentDict.Add(nums[i], 1);
            }
        }

        int threshold = frequentDict.Values.OrderByDescending(c => c).Take(k).Last();

        List<int> result = new List<int>();
        foreach (var kv in frequentDict)
        {
            if(kv.Value >= threshold)
            {
                result.Add(kv.Key);
            }
        }

        return result.ToArray();
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int k, string expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int[] actual = new Solution().TopKFrequent(nums, k);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase("[1,1,1,2,2,3]", 2, "[1,2]"); }
    [TestMethod] public void Test2() { TestBase("[1]", 1, "[1]"); }
    [TestMethod] public void Test3() { TestBase("[1,2,2,1,3,1]",3,"[1,2,3]"); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,4,2,3,5,3,1,2,3]", 3, "[1,2,3]"); }
    [TestMethod] public void Test5() { TestBase("[1,2]", 2, "[1,2]"); }
    [TestMethod] public void Test6() { TestBase("[4,1,-1,2,-1,2,3]", 2, "[-1,2]"); }
}