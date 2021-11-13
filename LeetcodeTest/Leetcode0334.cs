using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0334;

public class Solution
{
    public void ReverseString(char[] s)
    {
        int pointer1 = 0;
        int pointer2 = s.Length - 1;
        while(pointer1 < pointer2)
        {
            char temp = s[pointer1];
            s[pointer1] = s[pointer2];
            s[pointer2] = temp;
            pointer1++;
            pointer2--;
        }
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(char[] s, char[] expected)
    {
        Solution solution = new Solution();
        solution.ReverseString(s);
        for(int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], s[i]);
        }
    }

    [TestMethod] public void Test1() { TestBase(new char[] { 'h', 'e', 'l', 'l', 'o' }, new char[] { 'o', 'l', 'l', 'e', 'h' }); }
    [TestMethod] public void Test2() { TestBase(new char[] { 'H', 'a', 'n', 'n', 'a', 'h' }, new char[] { 'h', 'a', 'n', 'n', 'a', 'H' }); }


}
