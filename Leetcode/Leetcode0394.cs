namespace Leetcode0394;

public class Solution
{
    string s;

    private string Repeat(string s, int count)
    {
        string result = string.Empty;
        for (int i = 0; i < count; i++)
        {
            result += s;
        }
        return result;
    }

    private Tuple<int, string> DecodeString(int end)
    {
        string result = string.Empty;
        int i = end;
        bool quiting = false;
        int count = 0;
        int amplifier = 1;

        while (i >= 0)
        {
            if (quiting)
            {
                int t = s[i] - '0';
                if (t >= 0 && t <= 9)
                {
                    count += t * amplifier;
                    amplifier *= 10;
                }
                else
                {
                    return Tuple.Create(i, Repeat(result, count));
                }
            }
            else if (s[i] == ']')
            {

                var sub = DecodeString(i - 1);
                i = sub.Item1;
                result = sub.Item2 + result;
                continue;
            }
            else if (s[i] == '[')
            {
                quiting = true;
            }

            else
            {
                result = s[i] + result;
            }

            i--;

        }

        if(quiting && count > 0)
        {
            return Tuple.Create(i, Repeat(result, count));
        }

        return Tuple.Create(i, result);
    }

    public string DecodeString(string s)
    {
        this.s = s;
        var result = DecodeString(this.s.Length-1);
        return result.Item2;
    }
}

[TestClass]
public class SolutionTests0000
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string s, string expected)
    {
        string actual = new Solution().DecodeString(s);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("3[a]2[bc]", "aaabcbc"); }
    [TestMethod] public void Test2() { TestBase("3[a2[c]]", "accaccacc"); }
    [TestMethod] public void Test3() { TestBase("2[abc]3[cd]ef", "abcabccdcdcdef"); }
    [TestMethod] public void Test4() { TestBase("abc3[cd]xyz", "abccdcdcdxyz"); }
    [TestMethod] public void Test5() { TestBase("abcd", "abcd"); }
    [TestMethod] public void Test6() { TestBase("2[a]", "aa"); }
    [TestMethod] public void Test7() { TestBase("2[a]2[b]", "aabb"); }
}