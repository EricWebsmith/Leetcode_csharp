using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0557;


public class Solution
{
    private void ReverseCharArr(char[] arr, int pointer1, int pointer2)
    {
        while (pointer1 < pointer2)
        {
            char temp = arr[pointer1];
            arr[pointer1] = arr[pointer2];
            arr[pointer2] = temp;
            pointer1++;
            pointer2--;
        }
    }

    private int FindSecondSpace(char[] arr, int firstSpace)
    {
        for(int i = firstSpace+1;i < arr.Length; i++)
        {
            if(arr[i] == ' ')
            {
                return i;
            }
        }
        return arr.Length;
    }

    public string ReverseWords(string s)
    {
        char[] arr = s.ToArray();
        int firstSpace = -1;
        int secondSpace = 0;
        while (secondSpace < s.Length-1)
        {
            secondSpace = FindSecondSpace(arr, firstSpace);
            ReverseCharArr(arr, firstSpace+1, secondSpace-1);

            firstSpace = secondSpace;
        }

        return String.Join(String.Empty, arr);
    }
}


[TestClass]
public class SolutionTest
{

    private void TestBase(string s, string expected)
    {
        Solution solution = new Solution();
        string actual = solution.ReverseWords(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc"); }
    [TestMethod] public void Test2() { TestBase("God Ding", "doG gniD"); }


}
