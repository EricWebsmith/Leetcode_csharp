namespace Leetcode0409;

/// <summary>
/// Runtime: 64 ms, faster than 94.78% of C# online submissions for Longest Palindrome.
/// Memory Usage: 36 MB, less than 27.24% of C# online submissions for Longest Palindrome.
/// </summary>
public class Solution
{
    public int LongestPalindrome(string s)
    {
        Dictionary<char, int> charCount=new Dictionary<char, int>();
        foreach(char c in s)
        {
            if (charCount.ContainsKey(c))
            {
                charCount[c]++;
            }
            else
            {
                charCount[c] = 1;
            }
        }

        int centerChar = 0;
        int sideCharCount = 0;
        int mask = ~1;
        foreach(int v in charCount.Values)
        {
            centerChar = centerChar | v;
            sideCharCount += v & mask;
        }

        centerChar = centerChar & 1;

        return sideCharCount + centerChar;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "abccccdd", 7)]
    [DataRow(2, "a", 1)]
    [DataRow(3, "bb", 2)]
    [DataRow(4, "Aa", 1)]
    [DataRow(5, "abcabc", 6)]
    [DataTestMethod]
    public void Test(int order, string s, int expected)
    {
        int actual = new Solution().LongestPalindrome(s);
        Assert.AreEqual(expected, actual);
    }
}