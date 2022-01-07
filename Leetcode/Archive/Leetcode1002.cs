namespace Leetcode1002;

/// <summary>
/// Runtime: 140 ms, faster than 82.08% of C# online submissions for Find Common Characters.
/// Memory Usage: 43.8 MB, less than 38.68% of C# online submissions for Find Common Characters.
/// </summary>
public class Solution
{
    private Dictionary<char, int> GetFrequency(string word)
    {
        Dictionary<char, int> frequency = new Dictionary<char,int>();
        foreach(char c in word)
        {
            if (frequency.ContainsKey(c))
            {
                frequency[c]++;
            }
            else
            {
                frequency.Add(c, 1);
            }
        }
        return frequency;
    }

    private void MergeDict(Dictionary<char, int> d1, Dictionary<char, int> d2)
    {
        foreach(var kv in d1)
        {
            if (d2.ContainsKey(kv.Key))
            {
                d1[kv.Key] = Math.Min(d1[kv.Key], d2[kv.Key]);
            }
            else
            {
                d1.Remove(kv.Key);
            }
        }
    }

    public IList<string> CommonChars(string[] words)
    {
        Dictionary<char, int> frequency = GetFrequency(words[0]);
        for(int i=1; i<words.Length; i++)
        {
            Dictionary<char, int> newFrequency = GetFrequency(words[i]);
            MergeDict(frequency, newFrequency);
        }

        List<string> result = new List<string>();
        foreach(var kv in frequency)
        {
            for(int i = 0; i < kv.Value; i++)
            {
                result.Add(kv.Key.ToString());
            }
        }
        return result;
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