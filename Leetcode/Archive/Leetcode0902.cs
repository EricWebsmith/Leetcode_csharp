namespace Leetcode0902;


/// <summary>
/// Runtime: 92 ms, faster than 100.00% of C# online submissions for Numbers At Most N Given Digit Set.
/// Memory Usage: 39 MB, less than 100.00% of C# online submissions for Numbers At Most N Given Digit Set.
/// </summary>
public class Solution
{

    public int AtMostNGivenDigitSet(string[] digits, int n)
    {
        Array.Sort(digits);
        int[] iDigits = digits.Select(x => int.Parse(x)).ToArray();

        string s = n.ToString();
        int nLen = s.Length;
        int[] pows = new int[nLen];
        for (int i = 0; i < nLen; i++)
        {
            pows[i] = (int)Math.Pow(digits.Length, i);
        }

        int[] nArray = new int[nLen];
        for (int i = 0; i < nLen; i++)
        {
            nArray[i] = s[i] - '0';
        }

        // all numbers with a len smaller than nLen.
        int ans = pows.Sum() - 1;

        for (int i = 0; i < nLen; i++)
        {
            bool prefix = false;
            foreach (int digit in iDigits)
            {
                if (digit < nArray[i])
                {
                    ans += pows[nLen - i - 1];
                }
                else if (digit == nArray[i])
                {
                    prefix = true;
                    break;
                }
            }
            if (!prefix)
            {
                return ans;
            }
        }

        return ans + 1;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string digitsStr, int n, int expected)
    {
        string[] digits = digitsStr.Select(c => c.ToString()).ToArray();
        int actual = new Solution().AtMostNGivenDigitSet(digits, n);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("1357", 100, 20); }
    [TestMethod] public void Test2() { TestBase("147", 1000000000, 29523); }
    [TestMethod] public void Test3() { TestBase("7", 8, 1); }
    [TestMethod] public void Test4() { TestBase("17", 8, 2); }
    [TestMethod] public void Test5() { TestBase("348", 4, 2); }
}