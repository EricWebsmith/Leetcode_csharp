namespace Leetcode01898;

public class Solution
{
    string s = string.Empty;
    string p = string.Empty;
    int[] removable = null;

    private bool Condition(int candidate)
    {
        int ps = 0;
        int pp = 0;

        HashSet<int> map = new HashSet<int>();
        for (int i = 0; i < candidate; i++)
        {
            map.Add(removable[i]);
        }

        while (ps < s.Length && pp < p.Length)
        {
            if (!map.Contains(ps) && s[ps] == p[pp])
            {
                pp++;   
            }

            ps++;
        }

        return pp == p.Length;
    }

    public int MaximumRemovals(string s, string p, int[] removable)
    {
        this.s = s;
        this.p = p;
        this.removable = removable;

        int left = 0;
        int right = removable.Length;
        while(left < right)
        {
            int mid = left + (right - left+1) / 2;
            if (Condition(mid))
            {
                left = mid;
            }
            else
            {
                right = mid - 1;
            }
        }

        return left;

    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string s , string p, string removableStr, int expected)
    {
        int[] removable = removableStr.LeetcodeToArray();
        int actual = new Solution().MaximumRemovals(s, p, removable);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("abcacb", "ab", "[3,1,0]", 2); }
    [TestMethod] public void Test2() { TestBase("abcbddddd", "abcd", "[3,2,1,4,5,6]", 1); }
    [TestMethod] public void Test3() { TestBase("abcab", "abc", "[0,1,2,3,4]", 0); }
}

/*
Runtime: 676 ms, faster than 44.83% of C# online submissions for Maximum Number of Removable Characters.
Memory Usage: 52.2 MB, less than 58.62% of C# online submissions for Maximum Number of Removable Characters.
 */