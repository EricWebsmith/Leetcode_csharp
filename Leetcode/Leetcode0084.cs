namespace Leetcode0084;

/// <summary>
/// Runtime: 196 ms, faster than 92.05% of C# online submissions for Largest Rectangle in Histogram.
/// Memory Usage: 45.5 MB, less than 71.85% of C# online submissions for Largest Rectangle in Histogram.
/// </summary>
public class Solution
{
    public int LargestRectangleArea(int[] heights)
    {
        int n = heights.Length;
        // left limits
        int[] leftLimits = new int[n];
        leftLimits[0] = -1;
        for (int i = 1; i < n; i++)
        {
            int p = i - 1;
            while(p >=0 && heights[p] >= heights[i])
            {
                p = leftLimits[p];
            }
            leftLimits[i] = p;
        }

        // right limits
        int[] rightLimits = new int[n];
        rightLimits[n - 1] = n;
        for (int i = n - 2; i >= 0; i--)
        {
            int p = i+1;
            while (p <n && heights[p] >= heights[i])
            {
                p = rightLimits[p];
            }
            rightLimits[i] = p;
        }

        // calculate area
        int maxArea = 0;
        for (int i = 0; i < n; ++i)
        {
            int left = leftLimits[i];
            int right = rightLimits[i];
            int area = (right - left - 1) * heights[i];
            maxArea = Math.Max(maxArea, area);
        }

        return maxArea;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[2,1,5,6,2,3]", 10)]
    [DataRow(2, "[2,4]", 4)]
    [DataRow(3, "[3,2,6,5,1,2]", 10)]
    [DataRow(4, "[4,2]", 4)]
    [DataRow(5, "[0]", 0)]
    [DataRow(6, "[10000,10000]", 20000)]
    [DataRow(7, "[10000,10000]", 20000)]
    [DataRow(8, "[1,0, 1]", 1)]
    [DataRow(9, "[3,6,5,7,4,8,1,0]", 20)]
    [DataRow(10, "[[1,1]]", 2)]
    [DataTestMethod]
    public void Test(int order, string heightsStr, int expected)
    {
        int[] heights = heightsStr.Convert1D();
        int actual = new Solution().LargestRectangleArea(heights);
        Assert.AreEqual(expected, actual);
    }
}
