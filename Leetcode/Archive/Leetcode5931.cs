namespace Leetcode5931;


public class Solution
{
    public bool PossibleToStamp(int[][] grid, int stampHeight, int stampWidth)
    {


        return true;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase(string gridStr, int stampHeight, int stampWidth, bool expected)
    {
        int[][] grid = gridStr.LeetcodeToArray2D();
        bool actual = new Solution().PossibleToStamp(grid, stampHeight, stampWidth);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[1,0,0,0],[1,0,0,0],[1,0,0,0],[1,0,0,0],[1,0,0,0]]", 4, 3, true); }
    [TestMethod] public void Test2() { TestBase("[[1,0,0,0],[0,1,0,0],[0,0,1,0],[0,0,0,1]]", 2, 3, false); }
    [TestMethod] public void Test3()
    { 
        TestBase(
        "[[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0],[0,0,0,0,0,0,0,0]]",
        2,8, true); 
    }    
    
    [TestMethod] public void Test4()
    { 
        TestBase(
        "[[0,0,0,0,0],[0,0,0,0,0],[0,0,1,0,0],[0,0,0,0,1],[0,0,0,1,1]】",
        2,2, false); 
    }
    //[TestMethod] public void Test4() { TestBase(); }

}