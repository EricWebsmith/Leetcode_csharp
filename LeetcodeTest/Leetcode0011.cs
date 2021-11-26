namespace Leetcode0011;

public class Solution
{
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;

        int maxArea = 0;
        while (left < right)
        {
            int area = (right - left) * Math.Min(height[left], height[right]);
            maxArea = Math.Max(maxArea, area);
            if (height[left] > height[right])
            {
                right--;
            }
            else
            {
                left++;
            }
        }
        return maxArea;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, "1,8,6,2,5,4,8,3,7", 49)]
    [DataRow(2, "1,1", 1)]
    [DataRow(3, "4,3,2,1,4", 16)]
    [DataRow(4, "1,2,1", 2)]
    [DataRow(5, "0, 0, 0", 0)]
    [DataRow(6, "10000, 10000, 0", 10000)]
    [DataRow(7, "1000, 10000, 0", 1000)]
    [DataTestMethod]
    public void Test(int order, string heightStr, int expected)
    {
        int[] heigt = Helper.Convert1D(heightStr);
        int actual = (new Solution()).MaxArea(heigt);
        Assert.AreEqual(expected, actual);
    }
}