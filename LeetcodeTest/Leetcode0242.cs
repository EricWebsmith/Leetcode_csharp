using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Leetcode0242;

public class Solution
{
    private Dictionary<char, int> ToDict(string s)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach (char c in s)
        {
            if (dict.ContainsKey(c))
            {
                dict[c]++;
            }
            else
            {
                dict.Add(c, 1);
            }
        }
        return dict;
    }

    public bool IsAnagram(string s, string t)
    {
        if(s.Length != t.Length)
        {
            return false;
        }

        Dictionary<char, int> sDict = ToDict(s);

        foreach(char c in t)
        {
            if (!sDict.ContainsKey(c))
            {
                return false;
            }

            sDict[c]--;
        }

        foreach(var kv in sDict)
        {
            if (kv.Value != 0)
            {
                return false;
            }
        }

        return true;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(string s, string t, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.IsAnagram(s, t);
        Assert.AreEqual(expected, actual);    
    }

    [TestMethod] public void Test1() { TestBase("anagram", "nagaram", true); }
    [TestMethod] public void Test2() { TestBase("rat", "car", false); }
    
}
