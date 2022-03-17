namespace Leetcode0856;


public class Solution
{
    public int ScoreOfParentheses(string s)
    {
        int ans = 0;
        int times = 1;
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '('){
                times <<= 1 ;
            }
            else
            {
                times >>= 1;
                if(s[i-1] == '(')
                {
                    ans += times;
                }
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string s, int expected)
    {
        int actual = new Solution().ScoreOfParentheses(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("()", 1); }
    [TestMethod] public void Test2() { TestBase("(())", 2); }
    [TestMethod] public void Test3() { TestBase("()()", 2); }
    [TestMethod] public void Test4() { TestBase("(()())()", 5); }

}

/*
Runtime: 56 ms, faster than 98.18% of C# online submissions for Score of Parentheses.
Memory Usage: 36.4 MB, less than 10.91% of C# online submissions for Score of Parentheses.
 */