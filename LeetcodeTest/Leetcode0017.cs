using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0017;

public class Solution
{
    static Dictionary<char, char[]> mappings = new Dictionary<char, char[]>();

    static Solution()
    {
        mappings['2'] = new char[] { 'a', 'b', 'c' };
        mappings['3'] = new char[] { 'd', 'e', 'f' };
        mappings['4'] = new char[] { 'g', 'h', 'i' };
        mappings['5'] = new char[] { 'j', 'k', 'l' };
        mappings['6'] = new char[] { 'm', 'n', 'o' };
        mappings['7'] = new char[] { 'p', 'q', 'r', 's' };
        mappings['8'] = new char[] { 't', 'u', 'v' };
        mappings['9'] = new char[] { 'w', 'x', 'y', 'z' };
    }

    Queue<List<char>> queue = new Queue<List<char>>();


    public void LetterCombinations(string digits, int index)
    {
        if(index >= digits.Length)
        {
            return;
        }

        int count = queue.Count;
        for(int i = 0; i < count; i++)
        {
            List<char> stringBuilder = queue.Dequeue();
            foreach (char c in mappings[digits[index]])
            {
                List<char> newBuilder = stringBuilder.ToList();
                newBuilder.Add(c);
                queue.Enqueue(newBuilder);
            }
        }
    }

    public IList<string> LetterCombinations(string digits)
    {
        if(digits.Length == 0) { return new List<string>(); }

        queue.Enqueue(new List<char>());
        for (int i=0; i < digits.Length; i++)
        {
            LetterCombinations(digits, i);
        }

        List<string> result = new List<string>();
        while(queue.Count > 0)
        {
            List<char> chars = queue.Dequeue();
            result.Add(String.Join(String.Empty, chars));
        }
        return result;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(string digits, int expected)
    {
        IList<string> actual = (new Solution()).LetterCombinations(digits);
        Assert.AreEqual(expected, actual.Count);
    }

    [TestMethod] public void Test01() { TestBase("23", 9); }
    [TestMethod] public void Test02() { TestBase("", 0); }
    [TestMethod] public void Test03() { TestBase("2", 3); }
    [TestMethod] public void Test04() { TestBase("9", 4); }
    [TestMethod] public void Test05() { TestBase("7", 4); }
    [TestMethod] public void Test06() { TestBase("6", 3); }
    [TestMethod] public void Test07() { TestBase("5", 3); }
    [TestMethod] public void Test08() { TestBase("79", 16); }
    [TestMethod] public void Test09() { TestBase("59", 12); }
}