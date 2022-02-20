namespace Leetcode6014;


public class Solution
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        int n = s.Length;
        Dictionary<char, int> map = new Dictionary<char, int>();
        for(char c = 'a'; c <= 'z'; c++)
        {
            map[c] = 0;
        }

        foreach(char c in s)
        {
            map[c]++;
        }

        StringBuilder sb = new StringBuilder();
        while (n > 0)
        {
            char leading = '\0';
            for(char c = 'z'; c >= 'a'; c--)
            {
                if(map[c] == 0)
                {
                    continue;
                }

                if(leading == '\0')
                {
                    leading = c;
                }

                if(c == leading)
                {
                    
                    if(sb.Length>0 && sb[sb.Length-1] == c)
                    {
                        return sb.ToString();
                    }

                    if (map[c] > repeatLimit)
                    {
                        sb.Append(c, repeatLimit);
                        n -= repeatLimit;
                        map[c] -= repeatLimit;
                    }
                    else
                    {
                        sb.Append(c, map[c]);
                        n -= map[c];
                        map[c] = 0;
                        leading = '\0';
                    }
                }
                else
                {
                    sb.Append(c);
                    n--;
                    map[c]--;
                    break;
                }
                


            }
        }

        return sb.ToString();
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string s, int repeatLimit, string expected)
    {
        string actual = new Solution().RepeatLimitedString(s, repeatLimit);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("cczazcc", 3, "zzcccac"); }
    [TestMethod] public void Test2() { TestBase("aababab", 2, "bbabaa"); }
    [TestMethod] public void Test3() 
    { 
        TestBase(
            "robnsdvpuxbapuqgopqvxdrchivlifeepy",
            2,
            "yxxvvuvusrrqqppopponliihgfeeddcbba"
            ); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}