namespace Leetcode1249;

/// <summary>
/// Runtime: 96 ms, faster than 69.92% of C# online submissions for Minimum Remove to Make Valid Parentheses.
/// Memory Usage: 44 MB, less than 11.65% of C# online submissions for Minimum Remove to Make Valid Parentheses.
/// </summary>
public class Solution
{
    public string MinRemoveToMakeValid(string s)
    {
        List<char> chars = s.ToCharArray().ToList();
        Stack<int> openStack = new Stack<int>();
        for (int i = 0; i < chars.Count; i++)
        {
            char c = chars[i];
            if(c == '(')
            {
               openStack.Push(i);
            }
            else if(c == ')')
            {
                if (openStack.Count > 0)
                {
                    openStack.Pop();
                }
            }
        }

        while(openStack.Count > 0)
        {
            chars.RemoveAt(openStack.Pop());
        }

        List<int> closeStack= new List<int>();
        for (int i = chars.Count - 1; i >=0; i--)
        {
            char c = chars[i];
            if (c == ')')
            {
                closeStack.Add(i);
            }
            else if (c == '(')
            {
                if (closeStack.Count > 0)
                {
                    closeStack.RemoveAt(closeStack.Count-1);
                }
            }
        }

        for (int i = 0; i < closeStack.Count; i++)
        {
            chars.RemoveAt(closeStack[i]);
        }

        return string.Join(string.Empty, chars);
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "lee(t(c)o)de)", "lee(t(c)o)de")]
    [DataRow(2, "a)b(c)d", "ab(c)d")]
    [DataRow(3, "))((", "")]
    [DataRow(4, "(a(b(c)d)", "a(b(c)d)")]
    [DataRow(5, "", "")]
    [DataTestMethod]
    public void Test(int order, string s, string expected)
    {
        string actual = new Solution().MinRemoveToMakeValid(s);
        Assert.AreEqual(expected, actual);
    }
}