namespace Leetcode5203;


public class Solution
{
    bool[][] uncover = null;

    private bool CanExtract(int[] artifact)
    {
        for (int r = artifact[0]; r <= artifact[2]; r++)
        {
            for (int c = artifact[1]; c <= artifact[3]; c++)
            {
                if (!uncover[r][c])
                {
                    return false;

                }
            }
        }

        return true;
    }

    public int DigArtifacts(int n, int[][] artifacts, int[][] dig)
    {
        uncover = new bool[n][];
        for (int i = 0; i < n; i++)
        {
            uncover[i] = new bool[n];
        }

        foreach(int[] digItem in dig)
        {
            uncover[digItem[0]][digItem[1]] = true;
        }

        int ans = 0;
        foreach(int[] artifact in artifacts)
        {
            if (CanExtract(artifact))
            {
                ans++;
            }
        }

        return ans;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int n, string artifactsStr, string digStr, int expected)
    {
        int[][] artifacts = artifactsStr.LeetcodeToArray2D();
        int[][] dig = digStr.LeetcodeToArray2D();
        int actual = new Solution().DigArtifacts(n, artifacts, dig);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(2, "[[0,0,0,0],[0,1,1,1]]", "[[0,0],[0,1]]", 1); }
    [TestMethod] public void Test2() { TestBase(2, "[[0,0,0,0],[0,1,1,1]]", "[[0,0],[0,1],[1,1]]", 2); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}