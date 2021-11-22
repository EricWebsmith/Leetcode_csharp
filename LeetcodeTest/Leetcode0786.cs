namespace Leetcode0786;

public class Solution
{
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        return null;
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int[][] firstList, int[][] secondList, int[][] expected)
    {
        int[][] actual = (new Solution()).IntervalIntersection(firstList, secondList);
        Assert.AreEqual(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i], actual[i]);
        }
    }

    [TestMethod]
    public void Test1()
    {
        int[][] firstList = new int[][]
        {
            new int[]{0,2}
        };
    }
}