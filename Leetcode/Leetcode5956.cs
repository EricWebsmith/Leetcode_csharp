namespace Leetcode5956;


public class Solution
{
    private bool IsPalindrome(string s)
    {
        for(int i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }

    public string FirstPalindrome(string[] words)
    {
        foreach(string word in words)
        {
            if (IsPalindrome(word))
            {
                return word;
            }
        }
        return string.Empty;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}