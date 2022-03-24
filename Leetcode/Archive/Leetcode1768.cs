namespace Leetcode1768;


public class Solution
{
    public string MergeAlternately(string word1, string word2)
    {
        StringBuilder sb = new StringBuilder();
        for(int i=0; i<Math.Min( word1.Length, word2.Length); i++)
        {
            sb.Append(word1[i]).Append(word2[i]);
        }

        if(word1.Length > word2.Length)
        {
            sb.Append(word1.Substring(word2.Length));
        }
        else if (word1.Length < word2.Length)
        {
            sb.Append(word2.Substring(word1.Length));
        }
        return sb.ToString();
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string word1, string word2, string expected)
    {
        string actual = new Solution().MergeAlternately(word1, word2 );
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("abc", "pqr", "apbqcr"); }
    [TestMethod] public void Test2() { TestBase("ab", "pqrs", "apbqrs"); }
    [TestMethod] public void Test3() { TestBase("abcd", "pq", "apbqcd"); }
    //[TestMethod] public void Test4() { TestBase(); }

}

/*
Runtime: 68 ms, faster than 99.04% of C# online submissions for Merge Strings Alternately.
Memory Usage: 37.4 MB, less than 11.54% of C# online submissions for Merge Strings Alternately. 
 */