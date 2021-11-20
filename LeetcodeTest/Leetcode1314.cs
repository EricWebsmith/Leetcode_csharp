namespace Leetcode1314;

public class Solution
{
    public int[][] MatrixBlockSum(int[][] mat, int k)
    {
        int m = mat.Length;
        int n = mat[0].Length;

        // first build accumulation
        int[][] dp = new int[mat.Length][];
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


        int[][] result = new int[mat.Length][];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = new int[mat[i].Length];
            for (int j = 0; j < result[i].Length; j++)
            {
                int bottom = Math.Min( i + k , m - 1);
                int right = Math.Min( j + k, n - 1);

                if (i - k - 1 >= 0 && j - k - 1 >= 0)
                {
                    result[i][j] += dp[i - k - 1][j - k - 1];
                }

                if (i - k - 1 >= 0)
                {
                    result[i][j] -= dp[i - k - 1][right];
                }

                if (j - k - 1 >= 0)
                {
                    result[i][j] -= dp[bottom][j - k - 1];
                }

                
                result[i][j] += dp[bottom][right];
            }
        }

        return result;
    }
}

[TestClass]
public class SolutionTest
{

    private void Test(int[][] mat, int k, int[][] expected)
    {
        int[][] actual = (new Solution()).MatrixBlockSum(mat, k);
        for (int i = 0; i < actual.Length; i++)
        {
            for (int j = 0; j < actual[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);
            }
        }
    }

    [TestMethod]
    public void Test1()
    {
        int[][] mat = new int[][]
        {
            new int[]{1, 2, 3 },
            new int[]{4, 5, 6 },
            new int[]{7, 8, 9 }
        };

        int[][] expected = new int[][]
        {
            new int[]{12, 21, 16 },
            new int[]{27, 45, 33 },
            new int[]{24, 39, 28 }
        };

        Test(mat, 1, expected);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] mat = new int[][]
        {
            new int[]{1, 2, 3 },
            new int[]{4, 5, 6 },
            new int[]{7, 8, 9 }
        };

        int[][] expected = new int[][]
        {
            new int[]{45, 45, 45 },
            new int[]{45, 45, 45 },
            new int[]{45, 45, 45 }
        };

        Test(mat, 2, expected);
    }

    [TestMethod]
    public void Test3()
    {
        int[][] mat = new int[][]
        {
            new int[]{1, 1, 1, 1 },
            new int[]{1, 1, 1, 1 },
            new int[]{1, 1, 1, 1 }
        };

        int[][] expected = new int[][]
        {
            new int[]{4, 6, 6, 4 },
            new int[]{6, 9, 9, 6 },
            new int[]{4, 6, 6, 4 }
        };

        Test(mat, 1, expected);
    }

    [TestMethod]
    public void Test4()
    {
        int[][] mat = new int[][]
        {
            new int[]{0, 0, 0, 0 },
            new int[]{0, 0, 0, 0 },
            new int[]{0, 0, 0, 0 }
        };

        int[][] expected = new int[][]
        {
            new int[]{0, 0, 0, 0 },
            new int[]{0, 0, 0, 0 },
            new int[]{0, 0, 0, 0 }
        };

        Test(mat, 1, expected);
    }

        [TestMethod]
    public void Test5()
    {
        int[][] mat = new int[][]
        {
            new int[]{-1, -1, -1, -1 },
            new int[]{-1, -1, -1, -1 },
            new int[]{-1, -1, -1, -1 }
        };

        int[][] expected = new int[][]
        {
            new int[]{-4, -6, -6, -4 },
            new int[]{-6, -9, -9, -6 },
            new int[]{-4, -6, -6, -4 }
        };

        Test(mat, 1, expected);
    }
}