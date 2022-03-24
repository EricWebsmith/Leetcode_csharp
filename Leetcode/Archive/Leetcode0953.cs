namespace Leetcode0953;


public class Solution
{
    string order = string.Empty;

    private bool isOrdered(string word1, string word2)
    {
        for (int i = 0; i < Math.Min(word1.Length, word2.Length); i++)
        {
            if (order.IndexOf(word1[i]) < order.IndexOf(word2[i]))
            {
                return true;
            }

            if (order.IndexOf(word1[i]) > order.IndexOf(word2[i]))
            {
                return false;
            }
        }

        if (word1.Length > word2.Length && word1.Substring(0, word2.Length) == word2)
        {
            return false;
        }

        return true;
    }

    public bool IsAlienSorted(string[] words, string order)
    {
        this.order = order; 
        for (int i = 1; i < words.Length; i++)
        {
            if (!isOrdered(words[i-1], words[i]))
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
    private void TestBase(string wordsStr, string order, bool expected)
    {
        string[] words = wordsStr.LeetcodeToStringArray();
        bool actual = new Solution().IsAlienSorted(words, order);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[hello,leetcode]", "hlabcdefgijkmnopqrstuvwxyz", true); }
    [TestMethod] public void Test2() { TestBase("[word,world,row]", "worldabcefghijkmnpqstuvxyz", false); }
    [TestMethod] public void Test3() { TestBase("[apple,app]", "abcdefghijklmnopqrstuvwxyz", false); }
    [TestMethod] public void Test4() { TestBase("[kuvp,q]", "ngxlkthsjuoqcpavbfdermiywz", true); }

}

/*
Runtime: 88 ms, faster than 92.91% of C# online submissions for Verifying an Alien Dictionary.
Memory Usage: 40.9 MB, less than 20.73% of C# online submissions for Verifying an Alien Dictionary.
 */