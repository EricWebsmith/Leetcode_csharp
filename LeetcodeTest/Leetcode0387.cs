using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0387;

public class Solution
{
    public int FirstUniqChar(string s)
    {
        Dictionary<char, int> dict = new Dictionary<char, int>();
        for (int i=0;i<s.Length;i++)
        {
            if (dict.ContainsKey(s[i]))
            {
                dict[s[i]] = int.MaxValue;
            }
            else
            {
                dict.Add(s[i], i);
            }
        }

        int result = dict.Values.Min();
        if (result == int.MaxValue)
        {
            return -1;
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(string s, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.FirstUniqChar(s);
        Assert.AreEqual(expected, actual);
        
    }

    [TestMethod] public void Test1() {TestBase("leetcode", 0); }

    [TestMethod] public void Test2() { TestBase("loveleetcode", 2); }
    [TestMethod] public void Test3() { TestBase("aabb", -1); }

}
