namespace Leetcode0005;

/// <summary>
/// Runtime: 84 ms, faster than 95.03% of C# online submissions for Longest Palindromic Substring.
/// Memory Usage: 37 MB, less than 75.16% of C# online submissions for Longest Palindromic Substring.
/// </summary>
public class Solution
{
    private int GetRadius(string s, int left, int right)
    {
        int radius = 0;
        for (radius = 1; left - radius >= 0 && right + radius < s.Length; radius++)
        {
            if (s[left - radius] != s[right + radius])
            {
                return radius - 1;
            }
        }

        return radius - 1;
    }

    public string LongestPalindrome(string s)
    {
        int n = s.Length;
        int maxLen = 1;
        int maxLeft = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            // odd
            int radius = GetRadius(s, i, i);
            int len = 1 + radius * 2;
            if (len > maxLen)
            {
                maxLen = len;
                maxLeft = i - radius;
            }

            //even
            if (s[i] == s[i + 1])
            {
                radius = GetRadius(s, i, i + 1);
                len = 2 + radius * 2;
                if(len > maxLen)
                {
                    maxLen = len;
                    maxLeft = i - radius;
                }
            }
        }

        return s.Substring(maxLeft, maxLen);
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "babad", "bab")]
    [DataRow(2, "cbbd", "bb")]
    [DataRow(3, "a", "a")]
    [DataRow(4, "ac", "a")]
    [DataRow(5, "abcdefghijklmnopqrstuvwxyzzyxwvutsrqponmlkjihgfedcba", "abcdefghijklmnopqrstuvwxyzzyxwvutsrqponmlkjihgfedcba")]
    [DataRow(6, "acca", "acca")]
    [DataRow(7, "acaca", "acaca")]
    [DataRow(8, "acacb", "aca")]
    [DataTestMethod]
    public void Test(int order, string s, string expected)
    {
        string actual = new Solution().LongestPalindrome(s);
        Console.WriteLine(actual);
        Assert.AreEqual(expected.Length, actual.Length);
    }
}