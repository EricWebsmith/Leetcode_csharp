namespace Leetcode0085;

/// <summary>
/// This is based on 84
/// Runtime: 100 ms, faster than 98.28% of C# online submissions for Maximal Rectangle.
/// Memory Usage: 41.8 MB, less than 62.93% of C# online submissions for Maximal Rectangle
/// </summary>
public class Solution
{
    private int LargestRectangleArea(int[] height)
    {
        int n = height.Length;

        int[] leftLimits = new int[n];
        leftLimits[0] = -1;
        for (int i = 1; i < n; i++)
        {
            int p = i - 1;
            while(p >= 0 && height[p] >= height[i])
            {
                p = leftLimits[p];
            }
            leftLimits[i] = p;
        }

        int[] rightLimits = new int[n];
        rightLimits[n - 1] = n;
        for(int i = n-2;i>= 0; i--)
        {
            int p = i + 1;
            while(p<n && height[p] >= height[i])
            {
                p = rightLimits[p];
            }
            rightLimits[i] = p;
        }

        int maxArea = 0;
        for(int i = 0; i < n; i++)
        {
            int area = height[i] * (rightLimits[i] - leftLimits[i] - 1);
            maxArea = Math.Max(maxArea, area);
        }
        return maxArea;
    }

    public int MaximalRectangle(char[][] matrix)
    {
        int m = matrix.Length;
        if (m == 0) { return 0; }
        int n = matrix[0].Length;
        if(n == 0) { return 0; }
        //histogram
        
        int[][] histograms = new int[m][];
        for(int r=0; r<m; r++)
        {
            histograms[r] = new int[n];
            for (int c=0; c<n; c++)
            {
                if(matrix[r][c] == '0')
                {
                    histograms[r][c] = 0;
                }
                else
                {
                    histograms[r][c] = 1;
                    if (r > 0)
                    {
                        histograms[r][c] += histograms[r - 1][c];
                    }
                }
            }
        }

        histograms.Print2D();

        // calculate area from histogram
        int maxArea = 0;
        for (int r=0; r < m; r++)
        {
            maxArea = Math.Max(maxArea, LargestRectangleArea(histograms[r]));
        }

        return maxArea;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[['1','0','1','0','0'],['1','0','1','1','1'],['1','1','1','1','1'],['1','0','0','1','0']]", 6)]
    [DataRow(2, "[]", 0)]
    [DataRow(3, "[['0']]", 0)]
    [DataRow(4, "[['1']]", 1)]
    [DataRow(5, "[['0','0']]", 0)]
    [DataRow(6, "[['1','1']]", 2)]
    [DataTestMethod]
    public void Test(int order, string matrixStr, int expected)
    {
        char[][] matrix = Helper.Convert2DChar(matrixStr);
        int actual = new Solution().MaximalRectangle(matrix);
        Assert.AreEqual(expected, actual);
    }
}