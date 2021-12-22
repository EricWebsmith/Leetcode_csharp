namespace Leetcode0389;

/// <summary>
/// Runtime: 92 ms, faster than 72.47% of C# online submissions for Find the Difference.
/// Memory Usage: 38.8 MB, less than 24.72% of C# online submissions for Find the Difference.
/// </summary>
public class Solution
{
    public char FindTheDifference(string s, string t)
    {
        int[] letters = new int[26];
        foreach(char c in s)
        {
            letters[c-'a']--;
        }

        foreach(char c in t)
        {
            letters[c - 'a']++;
        }

        for(int i = 0; i < 26; i++)
        {
            if(letters[i] == 1)
            {
                return (char)('a'+i);
            }
        }
        return '0';
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}