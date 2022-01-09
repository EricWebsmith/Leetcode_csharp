namespace Leetcode5978;


public class Solution
{

    private string[] GetSorted(string[] words)
    {
        string[] maps = new string[words.Length];
        for (int i = 0; i < words.Length; i++)
        {
            char[] chars = words[i].ToArray();
            Array.Sort(chars);
            StringBuilder sb = new StringBuilder();
            sb.Append(chars);
            maps[i]=sb.ToString();
        }

        return maps;
    }

    private bool FindStart(string target)
    {
        for(int i=0; i<target.Length; i++)
        {
            string start = target.Remove(i,1);
            if (map.Contains(start))
            {
                return true;
            }
        }
        return false;
    }

    string[] startWords;
    string[] targetWords;
    HashSet<string> map = new HashSet<string>();
    public int WordCount(string[] startWords, string[] targetWords)
    {
        this.startWords = GetSorted(startWords);
        map = this.startWords.ToHashSet();
        this.targetWords = GetSorted(targetWords);

        int ans = 0;
        for(int t =0; t < this.targetWords.Length; t++)
        {
            if (FindStart(this.targetWords[t]))
            {
                ans++;
            }
        }

        return ans;
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string startWordsStr, string targetWordsStr, int expected)
    {
        string[] startWords = startWordsStr.LeetcodeToStringArray();
        string[] targetWords = targetWordsStr.LeetcodeToStringArray();
        int actual = new Solution().WordCount(startWords, targetWords);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[ant,act,tack]", "[tack,act,acti]", 2); }
    [TestMethod] public void Test2() { TestBase("[ab,a]", "[abc,abcd]", 1); }
    [TestMethod] public void Test3() { TestBase("[abc,ab,a]", "[ab,abc,abcd]", 3); }
    [TestMethod] public void Test4() { TestBase("[a]", "[ab]", 1); }

    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}