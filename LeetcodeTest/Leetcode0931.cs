namespace  Leetcode0931;

public class Solution
{
    public int MinFallingPathSum(int[][] matrix)
    {
        int height = matrix.Length;
        int width = matrix[0].Length;

        for(int h = 1; h < height; h++)
        {
            for(int w = 0; w < width; w++)
            {
                int dp = matrix[h-1][w];
                if (w > 0)
                {
                    dp = Math.Min(dp, matrix[h-1][w-1]);
                }
                if (w < width - 1)
                {
                    dp =Math.Min(dp, matrix[h-1][w+1]);
                }
                matrix[h][w] += dp;
            }
        }

        int result = int.MaxValue;
        for(int w=0; w < width; w++)
        {
            result = Math.Min(result, matrix[height - 1][w]);
        }
        return result;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int[][] matrix, int expected)
    {
        int actual = (new Solution()).MinFallingPathSum(matrix);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1()
    {
        int[][] matrix = {
            new int[]{ 2, 1, 3 },
            new int[]{ 6,5,4 },
            new int[]{ 7,8,9 },
        };
        TestBase(matrix, 13);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] matrix = {
            new int[]{ -19, 57 },
            new int[]{ -40, -5 }
        };
        TestBase(matrix, -59);
    }


    [TestMethod]
    public void Test3()
    {
        int[][] matrix = {
            new int[]{ -1, -2 },
            new int[]{ -3, -4 }
        };
        TestBase(matrix, -6);
    }

    [TestMethod]
    public void Test4()
    {
        int[][] matrix = {
            new int[]{ 0, 0 },
            new int[]{ 0, 0 }
        };
        TestBase(matrix, 0);
    }

    [TestMethod]
    public void Test5()
    {
        int[][] matrix = {
            new int[]{ 0, 8, 1, 3, 3 },
            new int[]{ 10, 0, 0, 5, 6 },
            new int[]{ 0, 10, 0, 0, 6 },
            new int[]{ 9, 0, 10, 5, 6 },
            new int[]{ 0, 1, 8, 5, 6 },
        };
        TestBase(matrix, 0);
    }
}