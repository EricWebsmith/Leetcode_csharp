namespace Leetcode0844;

public class Solution
{
    private int GoBack(string s, int p)
    {
        int skip = 0;
        while (p >= 0)
        {
            if (s[p] == '#')
            {
                skip++;
            }
            else if (skip > 0)
            {
                skip--;
            }
            else
            {
                break;
            }
            p--;
        }
        return p;
    }

    public bool BackspaceCompare(string s, string t)
    {
        int ps = s.Length - 1;
        int pt = t.Length - 1;
        while (ps >= 0 || pt >= 0)
        {
            ps = GoBack(s, ps);
            pt = GoBack(t, pt);

            if (ps >= 0 ^ pt >= 0)
            {
                return false;
            }

            if (ps >= 0 && pt >= 0 && s[ps] != t[pt])
            {
                return false;
            }

            ps--;
            pt--;
        }

        return true;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(01, "ab#c", "ad#c", true)]
    [DataRow(2, "ab##", "c#d#", true)]
    [DataRow(3, "a##c", "#a#c", true)]
    [DataRow(4, "a#c", "b", false)]
    [DataRow(5, "a#c", "b#c", true)]
    [DataRow(6, "####", "b#c#", true)]
    [DataRow(7, "abcd", "abcd", true)]
    [DataRow(8, "a", "a", true)]
    [DataRow(9, "a", "b", false)]
    [DataRow(10, "a", "#", false)]
    [DataRow(11, "#", "#", true)]
    [DataRow(12, "nzp#o#g", "b#nzp#o#g", true)]
    [DataRow(13, "b#a", "a", true)]
    [DataRow(14, "bbbextm", "bbb#extm", false)]
    [DataRow(15, "be", "b#e", false)]
    [DataTestMethod]
    public void Test(int order, string s, string t, bool expected)
    {
        bool actual = (new Solution()).BackspaceCompare(s, t);
        Assert.AreEqual(expected, actual);
    }
}


