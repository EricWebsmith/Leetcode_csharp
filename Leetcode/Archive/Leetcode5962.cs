namespace Leetcode5962;


public class Solution
{
    public int LongestPalindrome(string[] words)
    {
        int n = words.Length;
        bool[] visited = new bool[n];
        int reversePairs = 0;
        int sameTwins = 0;
        int twins = 0;

        Dictionary<string, int> map = new Dictionary<string, int>();

        for (int i = 0; i < n; i++)
        {
            if (visited[i])
            {
                continue;
            }

            if (words[i][0] == words[i][1])
            {
                twins++;

                if (map.ContainsKey(words[i]) && map[words[i]]>0)
                {
                    sameTwins++;
                    twins -= 2;
                    map[words[i]]--;
                    continue;
                }
            }
            else
            {
                string reverseString = words[i][1].ToString() + words[i][0].ToString();
                if (map.ContainsKey(reverseString) && map[reverseString] > 0)
                {
                    reversePairs++;
                    map[reverseString]--;
                    continue;
                }
            }


            if (map.ContainsKey(words[i]))
            {
                map[words[i]]++;
            }
            else
            {
                map[words[i]]=1;
            }
        }

        return (reversePairs * 2 + (twins > 0 ? 1 : 0) + sameTwins * 2) * 2;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(string wordsStr, int expected)
    {
        string[] words = wordsStr.LeetcodeToStringArray();
        int actual = new Solution().LongestPalindrome(words);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[lc,cl,gg]", 6); }
    [TestMethod] public void Test2() { TestBase("[ab,ty,yt,lc,cl,ab]", 8); }
    [TestMethod] public void Test3() { TestBase("[cc,ll,xx]", 2); }
    [TestMethod] public void Test4() { TestBase("[aa,sq,aq,aq]", 2); }
    [TestMethod] public void Test5() { TestBase("[em,pe,mp,ee,pp,me,ep,em,em,me]", 14); }

}