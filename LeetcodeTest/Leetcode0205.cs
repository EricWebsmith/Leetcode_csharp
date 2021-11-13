using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0205;

public class Solution
{
    public bool IsIsomorphic(string s, string t)
    {
        Dictionary<char, char> map = new Dictionary<char, char>();
        HashSet<char> set = new HashSet<char>();
        for (int i = 0; i < s.Length; i++)
        {
            if (map.ContainsKey(s[i]))
            {
                if (map[s[i]] != t[i])
                {
                    return false;
                }
            }
            else if (!set.Add(t[i]))
            {
                return false;
            }
            else
            {

                map[s[i]] = t[i];
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
        bool actual = solution.IsIsomorphic(s, t);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("egg", "add", true); }
    [TestMethod] public void Test2() { TestBase("foo","bar", false); }
    [TestMethod] public void Test3() { TestBase("paper", "title", true); }
    [TestMethod] public void Test4() { TestBase("badc", "baba", false); }


}
