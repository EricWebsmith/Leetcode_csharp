namespace Leetcode1662;

/// <summary>
/// Runtime: 104 ms, faster than 33.53% of C# online submissions for Check If Two String Arrays are Equivalent.
/// Memory Usage: 38.7 MB, less than 80.84% of C# online submissions for Check If Two String Arrays are Equivalent.
/// </summary>
public class Solution
{
    private IEnumerator<char> Generate(string[] words)
    {
        foreach(string word in words)
        {
            foreach(char c in word)
            {
                yield return c;
            }
        }
    }


    public bool ArrayStringsAreEqual(string[] word1, string[] word2)
    {
        IEnumerator<char> g1 = Generate(word1);
        IEnumerator<char> g2 = Generate(word2);
        char c1 = '\0';
        char c2 = '\0';

        while (c1 == c2)
        {
            if (c1 != c2)
            {
                return false;
            }

            bool movable1 = g1.MoveNext();
            bool movable2 = g2.MoveNext();
            if (movable1 != movable2)
            {
                return false;
            }
            else if (!movable1)
            {
                return true;
            }
            

            c1 = g1.Current;
            c2 = g2.Current;
        }

        return false;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string word1Str, string word2Str, bool expected)
    {
        string[] word1 = word1Str.LeetcodeToStringArray();
        string[] word2 = word2Str.LeetcodeToStringArray();
        bool actual = new Solution().ArrayStringsAreEqual(word1, word2);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[ab,c]", "[a,bc]", true); }
    [TestMethod] public void Test2() { TestBase("[a,cb]", "[ab,c]", false); }
    [TestMethod] public void Test3() { TestBase("[abc,d,defg]", "[abcddefg]", true); }
    //[TestMethod] public void Test4() { TestBase(); }

}