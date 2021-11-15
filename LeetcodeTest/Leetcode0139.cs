using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Leetcode0139;

public class Solution
{
    private static bool StartsWith(string s, string word, int start)
    {

        if(s.Length - start < word.Length)
        {
            return false;
        }

        for(int i = 0; i < word.Length; i++)
        {
            if(s[start+i] != word[i])
            {
                return false;
            }
        }

        return true;
    }

    public bool WordBreak(string s, IList<string> wordDict)
    {
        bool[] dp = new bool[s.Length+1];
        dp[0] = true;
        // iterate
        for(int i = 0; i < s.Length; i++)
        {
            if (!dp[i])
            {
                continue;
            }

            foreach(string word in wordDict)
            {
                if (i + word.Length >= dp.Length)
                {
                    continue;
                }

                if(dp[i + word.Length])
                {
                    continue;
                }

                if (StartsWith(s, word, i))
                {
                    dp[i + word.Length] = true;
                }
            }
        }

        return dp[dp.Length - 1];
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(string s, IList<string> wordDict, bool expected)
    {
        Solution solution = new Solution();
        bool actual = solution.WordBreak(s, wordDict);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test01() { TestBase("leetcode", new List<string> { "leet", "code" }, true); }
    [TestMethod] public void Test02() { TestBase("applepenapple", new List<string> { "apple", "pen" }, true); }
    [TestMethod] public void Test03() { TestBase("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" }, false); }
    [TestMethod] public void Test04() { TestBase("teapotisfulloftea", new List<string> { "tea", "pot","is", "full" }, false); }
    [TestMethod] public void Test05() { TestBase("teapotisfulloftea", new List<string> { "tea", "pot", "is", "full", "of" }, true); }
    [TestMethod] public void Test06() { TestBase("tea", new List<string> { "tea" }, true); }
    [TestMethod] public void Test07() { TestBase("a", new List<string> { "a" }, true); }
    [TestMethod] public void Test08() { TestBase("studentsstudyinschool", new List<string> { "student", "study", "in", "school", "ss" }, false); }
    [TestMethod] 
    public void Test09() { 
        TestBase(
            "acaaaaabbbdbcccdcdaadcdccacbcccabbbbcdaaaaaadb", 
            new List<string> {
                "abbcbda","cbdaaa","b","dadaaad","dccbbbc","dccadd",
                "ccbdbc","bbca","bacbcdd","a","bacb","cbc","adc","c",
                "cbdbcad","cdbab","db","abbcdbd","bcb","bbdab","aa",
                "bcadb","bacbcb","ca","dbdabdb","ccd","acbb","bdc",
                "acbccd","d","cccdcda","dcbd","cbccacd","ac","cca",
                "aaddc","dccac","ccdc","bbbbcda","ba","adbcadb","dca","abd",
                "bdbb","ddadbad","badb","ab","aaaaa","acba","abbb"
            }, true); }

    [TestMethod] 
    public void Test10() { 
        TestBase(
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab",
            new List<string> {
                "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa"
            }, false);
    }

    [TestMethod]
    public void Test11()
    {
        TestBase(
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            new List<string> {
                "aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa","ba"
            }, false);
    }

    [TestMethod]
    public void Test12()
    {
        TestBase(
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            new List<string> {
                "a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa","ba"
            }, true);
    }

}
