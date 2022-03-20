namespace Leetcode1572;


public class Solution
{
    public int DiagonalSum(int[][] mat)
    {
        int n = mat.Length;
        int sum = 0;
        for (int i = 0,  r = n - 1; i < n; i++)
        {
            sum += mat[i][i] + ((r==i)?0: mat[i][r]);
            r--;
        }

        return sum;
    }
}



[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    //[TestMethod] public void Test1() { TestBase(); }
    //[TestMethod] public void Test2() { TestBase(); }
    //[TestMethod] public void Test3() { TestBase(); }
    //[TestMethod] public void Test4() { TestBase(); }

}