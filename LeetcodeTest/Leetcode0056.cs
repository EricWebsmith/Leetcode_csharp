namespace Leetcode0056;


public class Solution
{
    public int[][] Merge(int[][] intervals)
    {
        List<int[]> list = intervals.ToList();
        list.Sort((a, b) => a[0].CompareTo(b[0]));
        List<int> removeList = new List<int>();
        for (int i = 1; i < list.Count; i++)
        {
            if (list[i][0] <= list[i - 1][1])
            {
                list[i][0] = list[i - 1][0];
                list[i][1] = Math.Max(list[i][1], list[i - 1][1]);
                removeList.Add(i - 1);
            }
        }

        for (int i = removeList.Count - 1; i >= 0; i--)
        {
            list.RemoveAt(removeList[i]);
        }

        return list.ToArray();
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(int[][] intervals, int[][] expected)
    {
        int[][] actual = (new Solution()).Merge(intervals);
        Assert.AreEqual(expected.Length, actual.Length);

        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i][0], actual[i][0]);
            Assert.AreEqual(expected[i][1], actual[i][1]);
        }
    }

    [TestMethod]
    public void Test1()
    {
        int[][] intervals = new int[][]{
            new int[]{ 1,3},
            new int[]{ 2, 6},
            new int[]{ 8, 10},
            new int[]{ 15, 18}
        };

        int[][] expected = new int[][]
        {
            new int[]{ 1,6},
            new int[]{ 8, 10},
            new int[]{ 15, 18}
        };

        TestBase(intervals, expected);
    }

    [TestMethod]
    public void Test2()
    {
        int[][] intervals = new int[][]{
            new int[]{ 1,4},
            new int[]{ 4, 5}
        };

        int[][] expected = new int[][]
        {
            new int[]{ 1, 5}
        };

        TestBase(intervals, expected);
    }

    [TestMethod]
    public void Test3()
    {
        int[][] intervals = new int[][] {
            new int[]{2, 3 },
            new int[]{ 2, 2},
            new int[]{ 3, 3},
            new int[]{ 1, 3},
            new int[]{ 5, 7},
            new int[]{ 2, 2},
            new int[]{ 4, 6}
        };

        int[][] expected = new int[][]
        {
            new int[]{ 1, 3},
            new int[]{4, 7}
        };

        TestBase(intervals, expected);
    }

}