namespace Leetcode5922;

public class Solution
{
    public int CountWords(string[] words1, string[] words2)
    {
        Dictionary<string, int> dict1 = new Dictionary<string, int>();
        foreach(string word1 in words1)
        {
            if (dict1.ContainsKey(word1))
            {
                dict1[word1]+=1;
            }
            else
            {
                dict1.Add(word1, 1);
            }
        }

        Dictionary<string, int> dict2 = new Dictionary<string, int>();
        foreach (string word2 in words2)
        {
            if (dict2.ContainsKey(word2))
            {
                dict2[word2] += 1;
            }
            else
            {
                dict2.Add(word2, 1);
            }
        }

        int result = 0;
        foreach(var kv in dict1)
        {
            if(kv.Value == 1)
            {
                if (dict2.ContainsKey(kv.Key) && dict2[kv.Key]==1){
                    result++;
                }
            }
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(string[] words1, string[] words2, int expected)
    {
        int actual = new Solution().CountWords(words1, words2);
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Test1()
    {
        string[] words1 = { "leetcode", "is", "amazing", "as", "is" };
        string[] words2 = { "amazing", "leetcode", "is" };
        TestBase(words1, words2, 2);
    }

    [TestMethod]
    public void Test2()
    {
        string[] words1 = { "b", "bb", "bbb" };
        string[] words2 = { "a", "aa", "aaa" };
        TestBase(words1, words2, 0);
    }


    [TestMethod]
    public void Test3()
    {
        string[] words1 = { "a", "ab" };
        string[] words2 = { "a", "a", "a", "ab" };
        TestBase(words1, words2, 1);
    }
}