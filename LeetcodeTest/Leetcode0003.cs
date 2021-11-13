using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0003;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();

        int maxLength = 0;
        int start = 0;
        int end = 0;
        for(int i=0; i<s.Length; i++)
        {
            char c = s[i];
            if (map.ContainsKey(c))
            {
                if(map[c] < start)
                {
                    map.Remove(c);
                }
                else
                {
                    end = i;
                    int curLength = end - start;
                    maxLength = Math.Max(maxLength, curLength);
                    start = map[c] + 1;
                }
            }
            map[c] = i;
        }

        maxLength = Math.Max(maxLength, s.Length - start);

        return maxLength;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(string s, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.LengthOfLongestSubstring(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("abcabcbb", 3); }
    [TestMethod] public void Test2() { TestBase("bbbbb", 1); }
    [TestMethod] public void Test3() { TestBase("pwwkew", 3); }
    [TestMethod] public void Test4() { TestBase("", 0); }
    [TestMethod] public void Test5() { TestBase(" ", 1); }

}
