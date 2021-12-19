namespace Leetcode0221;

public class Solution
{

    private int Min(params int[] arr)
    {
        int min = arr[0];
        for(int i = 1;i < arr.Length; i++)
        {
            min = Math.Min(min, arr[i]);
        }
        return min;
    }

    public int MaximalSquare(char[][] matrix)
    {
        int ones = 0;
        int m = matrix.Length;
        int n = matrix[0].Length;

        int[][] dp = new int[m][];
        for (int y = 0; y < m; y++)
        {
            dp[y] = new int[n];
            for (int x = 0; x < n; x++)
            {
                dp[y][x] = matrix[y][x] == '1' ? 1 : 0;
                ones += dp[y][x];
            }
        }

        if (ones == 0)
        {
            return 0;
        }

        int result = 1;
        for (int x = 1; x < n; x++)
        {
            for (int y = 1; y < m; y++)
            {
                if(dp[y][x] == 1)
                {
                    dp[y][x] = Min(dp[y - 1][x - 1], dp[y][x - 1], dp[y - 1][x]) + 1;
                    result = Math.Max(dp[y][x], result);
                }
            }
        }
        return result * result;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(char[][] matrix, int expected)
    {
        int actual = (new Solution()).MaximalSquare(matrix);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test0()
    {
        Solution s = new Solution();
    }

    [TestMethod]
    public void Test1()
    {
        char[][] matrix = new char[][]
        {
            new char[]{ '1', '0', '1', '0', '0' },
            new char[]{ '1','0','1','1','1' },
            new char[]{ '1','1','1','1','1' },
            new char[]{ '1','0','0','1','0'}
        };

        TestBase(matrix, 4);
    }

    [TestMethod]
    public void Test2()
    {
        char[][] matrix = new char[][]
        {
            new char[]{'1', '0' },
            new char[]{'0', '1'},
        };

        TestBase(matrix, 1);
    }


    [TestMethod]
    public void Test3()
    {
        char[][] matrix = new char[][]
        {
            new char[]{ '0' }
        };

        TestBase(matrix, 0);
    }

    [TestMethod]
    public void Test4_4x4()
    {
        char[][] matrix = new char[][]
        {
            new char[]{ '1', '1', '1', '1',  },
            new char[]{ '1','1','1','1' },
            new char[]{ '1','1','1','1' },
            new char[]{ '1','1','1','1'}
        };

        TestBase(matrix, 16);
    }
}