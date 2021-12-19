namespace Leetcode0304;

public class NumMatrix
{
    int[][] dp;


    public NumMatrix(int[][] mat)
    {
        dp = new int[mat.Length][];
        for (int i = 0; i < mat.Length; i++)
        {
            dp[i] = mat[i].ToArray();
        }

        for (int i = 1; i < dp.Length; i++)
        {
            for (int j = 0; j < dp[i].Length; j++)
            {
                dp[i][j] += dp[i - 1][j];
            }
        }

        for (int i = 0; i < dp.Length; i++)
        {
            for (int j = 1; j < dp[i].Length; j++)
            {
                dp[i][j] += dp[i][j - 1];
            }
        }
    }

    public int SumRegion(int row1, int col1, int row2, int col2)
    {
        int result = 0;
        result += dp[row2][col2];
        if (row1 - 1 >= 0)
        {
            result -= dp[row1 - 1][col2];
        }

        if (col1 - 1 >= 0)
        {
            result -= dp[row2][col1 - 1];
        }

        if (row1 - 1 >= 0 && col1 - 1 >= 0)
        {
            result += dp[row1 - 1][col1 - 1];
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{

    private void Test(int[][] mat, int[][] regions, int[] expected)
    {
        NumMatrix matrix = new NumMatrix(mat);
        for (int i = 0; i < regions.Length; i++)
        {
            int actual = matrix.SumRegion(regions[i][0], regions[i][1], regions[i][2], regions[i][3]);
            Assert.AreEqual(expected[i], actual);
        }
    }

    [TestMethod]
    public void Test1()
    {
        int[][] mat = new int[][]
        {
            new int[]{3, 0, 1, 4, 2 },
            new int[]{5, 6, 3, 2, 1 },
            new int[]{ 1, 2, 0, 1, 5 },
            new int[]{ 4, 1, 0, 1, 7 },
            new int[]{ 1, 0, 3, 0, 5 },
        };

        int[][] regions = new int[][]
        {
            new int[]{1, 1, 2, 2 },
            new int[]{2, 1, 4, 3 },
            new int[]{ 1, 2, 2, 4 }
        };

        int[] expected = new int[] { 11, 8, 12 };

        Test(mat, regions, expected);
    }
}