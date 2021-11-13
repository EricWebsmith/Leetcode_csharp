using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0740BrutalForce;

public class Solution
{
    private List<int> earns = new List<int>();

    public SortedDictionary<int, int> Copy(SortedDictionary<int, int> valueCounts)
    {
        SortedDictionary<int, int > newValueCounts = new SortedDictionary<int, int>();
        foreach(KeyValuePair<int, int> pair in valueCounts)
        {
            newValueCounts.Add(pair.Key, pair.Value);
        }
        return newValueCounts;
    }

    private void DeleteAndEarn(SortedDictionary<int, int> value_counts, int earn)
    {
        int previousKey = value_counts.Keys.First();
        for(int i = 0;i< value_counts.Keys.Count;i++)
        {
            int key = value_counts.Keys.ElementAt(i);
            int value = value_counts[key];
            int newEarn = earn + key * value;
            SortedDictionary<int, int> newValueCounts = Copy(value_counts);
            newValueCounts.Remove(key);
            if (i > 0 && key - previousKey == 1)
            {
                newValueCounts.Remove(previousKey);
            }

            if (i + 1 < value_counts.Count)
            {
                int nextKey = value_counts.Keys.ElementAt(i + 1);
                if(nextKey - key == 1)
                {
                    newValueCounts.Remove(nextKey);
                }
            }

            if(newValueCounts.Keys.Count == 0)
            {
                earns.Add(newEarn);

            }
            else
            {
                DeleteAndEarn(newValueCounts, newEarn);
            }
            

            previousKey = value_counts.Keys.ElementAt(i);
        }
    }

    public int DeleteAndEarn(int[] nums)
    {
        SortedDictionary<int, int> value_counts = new SortedDictionary<int, int>();
        
        for(int i = 0; i< nums.Length; i++)
        {
            if(value_counts.ContainsKey(nums[i]))
            {
                value_counts[nums[i]]++;
            }
            else
            {
                value_counts.Add(nums[i], 1);
            }
        }

        DeleteAndEarn(value_counts, 0);

        return earns.Max();
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[] nums, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.DeleteAndEarn(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(new int[] { 3, 4, 2 },6); }
    [TestMethod] public void Test2() { TestBase(new int[] { 2, 2, 3, 3, 3, 4 },9); }

}
