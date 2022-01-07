namespace Leetcode5948;


public class Solution
{
    public bool CanBeValid(string s, string locked)
    {
        int n = s.Length;
        if (n % 2 == 1)
        {
            return false;
        }

        Stack<char> stack = new Stack<char>();

        // from left to right
        int freedom = 0;
        for (int i = 0; i < n; i++)
        {

            if (s[i] == ')' && locked[i] == '1')
            {
                freedom--;
            }
            else
            {
                freedom++;
            }
            if (freedom < 0)
            {
                return false;
            }
        }

        // from right to left
        freedom = 0;
        for (int i = n - 1; i >= 0; i--)
        {

            if (s[i] == '(' && locked[i] == '1')
            {
                freedom--;
            }
            else
            {
                freedom++;
            }
            if (freedom < 0)
            {
                return false;
            }
        }

        return true;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(string s, string locked, bool expected)
    {
        bool actual = new Solution().CanBeValid(s, locked);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("))()))", "010100", true); }
    [TestMethod] public void Test2() { TestBase("()()", "0000", true); }
    [TestMethod] public void Test3() { TestBase(")", "0", false); }
    [TestMethod] public void Test4() { TestBase("))()))", "110100" ,false); }
   // [TestMethod] public void Test4() { TestBase(); }
}