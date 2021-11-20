namespace Leetcode0461;

public class Solution
{
    public int HammingDistance(int x, int y)
    {
        int z = x ^ y;
        int diff = 0;
        while(z > 0)
        {
            z = z & (z - 1);
            diff++;
        }
        return diff;
    }
}

[TestClass]
public class SolutionTest
{
    [DataRow(1, 1, 4, 2)]
    [DataRow(2, 3, 1, 1)]
    [DataRow(3, 1, 1, 0)]
    [DataRow(4, 8, 1, 2)]
    [DataTestMethod]
    public void Test(int order, int x, int y, int expected)
    {
        int actual =(new Solution()).HammingDistance(x, y); 
        Assert.AreEqual(expected, actual);
    }
}