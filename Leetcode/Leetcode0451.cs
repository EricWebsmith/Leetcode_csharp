namespace Leetcode0451;


public class Solution
{
    public string FrequencySort(string s)
    {
        
        Dictionary<char, int> counts = new Dictionary<char, int>();
        foreach(char c in s)
        {
            if (counts.ContainsKey(c))
            {
                counts[c]++;
            }
            else
            {
                counts.Add(c, 1);
            }
        }

        var query = from c in counts orderby c.Value descending select c;

        StringBuilder sb = new StringBuilder();
        foreach(var kv in query)
        {
            for(int i=0; i<kv.Value; i++)
            {
                sb.Append(kv.Key);
            }
        }
        return sb.ToString();
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string s, string expected)
    {
        string actual = new Solution().FrequencySort(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("tree", "eert"); }
    [TestMethod] public void Test2() { TestBase("cccaaa", "aaaccc"); }
    [TestMethod] public void Test3() { TestBase("Aabb", "bbAa"); }
    //[TestMethod] public void Test4() { TestBase(); }
}