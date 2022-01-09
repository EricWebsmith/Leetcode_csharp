namespace Leetcode5976;


public class Solution
{
    public bool CheckValid(int[][] matrix)
    {
        int n = matrix.Length;
        
        for (int i = 0; i < n; i++)
        {
            bool[] horizontal = new bool[n+1];
            for (int j = 0; j < n; j++)
            {
                if (horizontal[matrix[i][j]])
                {
                    return false;
                }
                horizontal[matrix[i][j]] = true;
            }
            Array.Fill(horizontal, false);
        }

        for (int c = 0; c < n; c++)
        {

            bool[] vertical = new bool[n + 1];
            for (int r = 0; r < n; r++)
            {

                //
                if (vertical[matrix[r][c]])
                {
                    return false;
                }
                vertical[matrix[r][c]] = true;
            }
            Array.Fill(vertical, false);
        }
        return true;
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string matrixStr, bool expected)
    {
        int[][] matrix = matrixStr.LeetcodeToArray2D();
        bool actual = new Solution().CheckValid(matrix);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[[1,2,3],[3,1,2],[2,3,1]]", true); }
    [TestMethod] public void Test2() { TestBase("[[1,1,1],[1,2,3],[1,2,3]]", false); }
    [TestMethod] public void Test3() { TestBase("[[1,2,3],[1,2,3],[1,2,3]]", false); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}