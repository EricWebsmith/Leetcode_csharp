namespace Leetcode5964;

public class Point
{
    public int Row { get; set; }
    public int Col { get; set; }
}

public class Solution
{
    Point current = new Point();
    int n;

    private bool Move(char c)
    {
        switch (c)
        {
            case 'U':
                current.Row--;
                break;
            case 'D':
                current.Row++;
                break;
            case 'R':
                current.Col++;
                break;
            case 'L':
                current.Col--;
                break;
        }

        if(current.Row <0 || current.Row >=n || current.Col <0 || current.Col >= n)
        {
            return false;
        }
        return true;
    }

    public int[] ExecuteInstructions(int n, int[] startPos, string s)
    {
        this.n = n;
        int m = s.Length;


        int[] ans  = new int[m];
        for(int i = 0; i < m; i++)
        {
            current.Row = startPos[0];
            current.Col = startPos[1];

            for (int j = i; j < m; j++)
            {
                if (!Move(s[j]))
                {
                    break;
                }
                ans[i]++;
            }
        }
        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int n, string startPosStr, string s, string expected)
    {
        int[] startPos = startPosStr.LeetcodeToArray();
        int[] actual = new Solution().ExecuteInstructions(n, startPos, s);
        Assert.AreEqual(expected, actual.ToLeetcode());
    }

    [TestMethod] public void Test1() { TestBase(3, "[0,1]", "RRDDLU", "[1,5,4,3,1,0]"); }
    [TestMethod] public void Test2() { TestBase(2, "[1,1]", "LURD", "[4,1,0,0]"); }
    [TestMethod] public void Test3() { TestBase(1,"[0,0]","LRUD", "[0,0,0,0]"); }
    //[TestMethod] public void Test4() { TestBase(); }
}