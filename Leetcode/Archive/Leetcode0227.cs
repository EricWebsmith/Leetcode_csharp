namespace Leetcode0227;


/// <summary>
/// Runtime: 68 ms, faster than 87.95% of C# online submissions for Basic Calculator II.
/// Memory Usage: 39.3 MB, less than 33.41% of C# online submissions for Basic Calculator II.
/// </summary>
public class Solution
{
    Stack<int> stack = new Stack<int>();
    char op = '\0';
    int current = 0;

    public void Operate(char newOp)
    {
        if (op == '*')
        {
            current = stack.Pop() * current;
        }
        if (op == '/')
        {
            current = stack.Pop() / current;
        }

        op = newOp;
        stack.Push(current);
        current = 0;
    }

    public int Calculate(string s)
    {

        foreach (char c in s + '+')
        {
            switch (c)
            {
                case char n when ('0' <= n && n <= '9'):
                    int tmp = n - '0';
                    if (op == '-')
                    {
                        tmp = -tmp;
                    }
                    current = current * 10 + tmp;

                    break;
                case '+':
                    Operate('+');
                    break;
                case '-':
                    Operate('-');
                    break;
                case '*':
                    Operate('*');
                    break;
                case '/':
                    Operate('/');
                    break;
                default:
                    continue;
            }
        }
        int ans = 0;
        while (stack.Count > 0)
        {
            ans += stack.Pop();
        }
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string s, int expected)
    {
        int actual = new Solution().Calculate(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("3+2*2", 7); }
    [TestMethod] public void Test2() { TestBase(" 3/2 ", 1); }
    [TestMethod] public void Test3() { TestBase(" 3+5 / 2 ", 5); }
    [TestMethod] public void Test4() { TestBase("2*2*2*2", 16); }
    [TestMethod] public void Test5() { TestBase("0-2147483647", -2147483647); }
}