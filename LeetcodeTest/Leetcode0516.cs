namespace Leetcode0516;

public class Solution
{
    public int LongestPalindromeSubseq(string s)
    {
        int n = s.Length;
        int[][] dp = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dp[i] = new int[n];
        }

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < n; x++)
            {
                if (s[x] == s[n - 1 - y])
                {
                    dp[y][x] = 1;
                }
            }
        }

        int curentMax = 0;
        int[] maxArr = new int[n];
        maxArr[0] = dp[0][0];
        for (int x = 0; x < n; x++)
        {
            if (dp[0][x] == 1)
            {
                curentMax = 1;
                
            }
            else
            {
                curentMax = Math.Max(curentMax, dp[0][x]);
            }
            maxArr[x] = curentMax;
        }

        for (int y = 1; y < n; y++)
        {


            for (int x = 1; x < n; x++)
            {
                if (dp[y][x] == 1)
                {
                    dp[y][x] = maxArr[x - 1] + 1;
                }
            }

            // update maxArr
            if (dp[y][0] == 1)
            {
                maxArr[0] = 1;
            }

            for (int x = 1; x < n; x++)
            {
                if (dp[y][x] >= 1)
                {
                    maxArr[x] = dp[y][x];
                }
                else
                {
                    maxArr[x] = Math.Max(maxArr[x-1], maxArr[x]);
                }
            }
        }

        return maxArr.Last();
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "bbbab", 4)]
    [DataRow(2, "cbbd", 2)]
    [DataRow(3, "abcd", 1)]
    [DataRow(4, "abcda", 3)]
    [DataRow(5, "abab", 3)]
    [DataRow(6, "abcba", 5)]
    [DataRow(7, "a", 1)]
    [DataRow(8, "aaaaaaaaaa", 10)]
    [DataRow(9, "ababa", 5)]
    [DataRow(10, "operation", 3)]
    [DataRow(11, "oao", 3)]
    [DataRow(12, "oabo", 3)]
    [DataRow(13, "oabod", 3)]
    [DataRow(14, "coperation", 3)]
    [DataTestMethod]
    public void Test(int order, string s, int expected)
    {
        int actual = (new Solution()).LongestPalindromeSubseq(s);
        Assert.AreEqual(expected, actual);
    }
}
/*
  c b b d
d 0 0 0 1
b 0 1 1 0
b 0 1 1 0
c 1 0 0 0

  b b b a b
b 1 1 1 0 1
a 0 0 0 1 0
b 1 1 1 0 1
b 1 1 1 0 1
b 1 1 1 0 1

  d b b a b
b 0 1 1 0 1
a 0 0 0 1 0
b 0 1 1 0 1
b 0 1 1 0 1
d 1 0 0 0 0

  d b b a b
b 0 1 1 0 1
a 0 0 0 2 0
b 0 1 2 0 3
b 0 1 2 0 3
d 1 0 0 0 0

  b b b a b
b 1 1 1 0 1
a 0 1 1 2 2
b 1 2 2 2 2
b 1 1 1 2 1
b 1 1 1 0 3

  a b c 
c 0 0 1
b 0 1 0 
a 1 0 0

  a b c b a
a 1 0 0 0 1
b 0 1 0 1 0
c 0 0 1 0 0
b 0 1 0 1 0
a 1 0 0 0 1


  a b a b
b 0 1 0 1
a 1 0 1 0
b 0 1 0 1
a 1 0 1 0

 */