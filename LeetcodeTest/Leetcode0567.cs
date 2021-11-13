using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0567;

public class Solution
{
    Dictionary<char, int> dict1 = new Dictionary<char, int>();
    Dictionary<char, int> dict2 = new Dictionary<char, int>();

    bool isAnagram()
    {
        foreach(KeyValuePair<char, int> kvp in dict1)
        {
            if(kvp.Value != dict2[kvp.Key])
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckInclusion(string s1, string s2)
    {
        foreach (char c in s1)
        {
            if (dict1.ContainsKey(c))
            {
                dict1[c] += 1;
            }
            else
            {
                dict1.Add(c, 1);
            }
            dict2[c] = 0;
        }

        for(int i = 0; i < s2.Length; i++)
        {
            char c = s2[i];
            if (dict2.ContainsKey(c))
            {
                dict2[c] += 1;
            }

            if (i >= s1.Length)
            {
                if (dict2.ContainsKey(s2[i-s1.Length]))
                {
                    dict2[s2[i - s1.Length]] -= 1;
                }
            }

            if (isAnagram())
            {
                return true;
            }
            
        }
        return false;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(string s1, string s2, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.CheckInclusion(s1, s2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("ab", "eidbaooo", true); }
    [TestMethod] public void Test2() { TestBase("ab", "eidboaoo", false); }

    [TestMethod] public void Test3() { TestBase("adc", "dcda", true); }

    [TestMethod] public void Test4() { TestBase("ab", "abc", true); }

    [TestMethod] public void Test5() { TestBase("ab", "aabc", true); }

}
