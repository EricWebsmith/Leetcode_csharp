using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0566;

public class Solution
{
    public int[][] MatrixReshape(int[][] mat, int r, int c)
    {
        int m = mat.Length;
        int n = mat[0].Length;
        if (m * n != r * c)
        {
            return mat;
        }

        int[][] mat2 = new int[r][];
        int index = 0;
        for (int i = 0; i < m; i++)
        {

            for (int j = 0; j < n; j++)
            {
                int row_index = index / c;
                int col_index = index % c;
                if (col_index == 0)
                {
                    mat2[row_index] = new int[c];
                }
                mat2[row_index][col_index] = mat[i][j];
                index++;
            }
        }
        return mat2;
    }
}

[TestClass]
public class SolutionTest
{

    private void TestBase(int[][] mat, int r, int c, int[][] expected)
    {
        Solution solution = new Solution();
        int[][] actual = solution.MatrixReshape(mat, r, c);
        for (int i = 0; i < expected.Length; i++)
        {
            for (int j = 0; j < expected[i].Length; j++)
            {
                Assert.AreEqual(expected[i][j], actual[i][j]);

            }
        }
    }

    [TestMethod]
    public void Test1()
    {
        int[][] mat = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
        int[][] expected = new int[][] { new int[] { 1, 2, 3, 4 } };
        TestBase(mat, 1, 4, expected);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] mat = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
        int[][] expected = new int[][] { new int[] { 1, 2 }, new int[] { 3, 4 } };
        TestBase(mat, 2, 4, expected);
    }

}
