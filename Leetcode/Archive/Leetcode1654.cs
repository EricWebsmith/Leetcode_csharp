namespace Leetcode1654;


public class Solution
{
    public int MinimumJumps(int[] forbidden, int a, int b, int x)
    {
        if (x == 0) { return 0; }

        Queue<(int, bool)> q = new Queue<(int, bool)>();
        q.Enqueue((0, false));
        int max = 1 + a + b + Math.Max(x, forbidden.Max());
        bool[] visited = new bool[max];
        foreach(int i in forbidden)
        {
            visited[i] = true;
        }
        int jumpCount = 0;

        while (q.Count > 0)
        {
            int qCount = q.Count;
            for (int i = 0; i < qCount; i++)
            {
                var (position, jumpedBack) = q.Dequeue();
                if (position == x)
                {
                    return jumpCount;
                }

                if (position < 0 || position >= visited.Length || visited[position])
                {
                    continue;
                }

                visited[position] = true;

                int forward = position + a;

                if (!jumpedBack)
                {
                    q.Enqueue((position - b, true));
                }
                q.Enqueue((forward, false));
            }
            jumpCount++;
        }
        return -1;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string forbiddenStr, int a, int b, int x, int expected)
    {
        int[] forbidden = forbiddenStr.LeetcodeToArray();
        int actual = new Solution().MinimumJumps(forbidden, a, b, x);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[14,4,18,1,15]", 3, 15, 9, 3); }
    [TestMethod] public void Test2() { TestBase("[8,3,16,6,12,20]", 15, 13, 11, -1); }
    [TestMethod] public void Test3() { TestBase("[1,6,2,14,5,17,4]", 16, 9, 7, 2); }
    string test4forbiden = "[1401,832,1344,173,1529,1905,1732,277,1490,650,1577,1886,185,1728,1827,1924,1723,1034,1839,1722,1673,1198,1667,538,911,1221,1201,1313,251,752,40,1378,1515,1789,1580,1422,907,1536,294,1677,1807,1419,1893,654,1176,812,1094,1942,876,777,1850,1382,760,347,112,1510,1278,1607,1491,429,1902,1891,647,1560,1569,196,539,836,290,1348,479,90,1922,111,1411,1286,1362,36,293,1349,667,430,96,1038,793,1339,792,1512,822,269,1535,1052,233,1835,1603,577,936,1684,1402,1739,865,1664,295,977,1265,535,1803,713,1298,1537,135,1370,748,448,254,1798,66,1915,439,883,1606,796]";
    [TestMethod] public void Test4() { TestBase(test4forbiden, 19, 18, 1540, 120); }

}


/*
Runtime: 120 ms, faster than 82.86% of C# online submissions for Minimum Jumps to Reach Home.
Memory Usage: 39.7 MB, less than 100.00% of C# online submissions for Minimum Jumps to Reach Home. 
 */