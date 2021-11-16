using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Leetcode2068;

public class Solution
{
    public bool CheckAlmostEquivalent(string word1, string word2)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        foreach(char c in word1)
        {
            if (dict.ContainsKey(c))
            {
                dict[c] += 1;
            }
            else
            {
                dict.Add(c, 1);
            }
        }

        foreach (char c in word2)
        {
            if (dict.ContainsKey(c))
            {
                dict[c] -= 1;
            }
            else
            {
                dict.Add(c, -1);
            }
        }

        foreach(int v in dict.Values)
        {
            if(v<-3 || v > 3)
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

    private void TestBase(string word1, string word2, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.CheckAlmostEquivalent(word1, word2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("aaaa", "bccb", false); }
    [TestMethod] public void Test2() { TestBase("abcdeef", "abaaacc", true); }
    [TestMethod] public void Test3() { TestBase("aabbcc", "abcabc", true); }
    [TestMethod] public void Test4() { TestBase("a","b",true); }


}
