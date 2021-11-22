

namespace Leetcode0986;

public class Solution
{
    public int[][] IntervalIntersection(int[][] firstList, int[][] secondList)
    {
        if (firstList.Length == 0 || secondList.Length == 0)
        {
            return new int[][] { };
        }

        List<int[]> result = new List<int[]>();
        int p1 = 0;
        int p2 = 0;
        while (p1 < firstList.Length && p2 < secondList.Length)
        {
            // no joint
            if (firstList[p1][0] > secondList[p2][1])
            {
                p2++;
            }
            else if (secondList[p2][0] > firstList[p1][1])
            {
                p1++;
            }
            else if (firstList[p1][1] > secondList[p2][1])
            {
                result.Add(new int[]
                {
                    Math.Max(firstList[p1][0], secondList[p2][0]),
                    secondList[p2][1]
                });
                p2++;
            }
            else if (firstList[p1][1] < secondList[p2][1])
            {
                result.Add(new int[]
                {
                    Math.Max(firstList[p1][0], secondList[p2][0]),
                    firstList[p1][1]
                });
                p1++;
            }
            else //firstList[p1][1] == secondList[p2][1]
            {
                result.Add(new int[]
                {
                    Math.Max(firstList[p1][0], secondList[p2][0]),
                    firstList[p1][1]
                });
                p1++;
                p2++;
            }
        }

        return result.ToArray();
    }
}

[TestClass]
public class MyTestClass
{
    [DataRow(1, "[[0,2],[5,10],[13,23],[24,25]]", "[[1,5],[8,12],[15,24],[25,26]]", "[[1,2],[5,5],[8,10],[15,23],[24,24],[25,25]]")]
    [DataRow(2, "[[1,3],[5,9]]", "[]", "[]")]
    [DataRow(3, "[]", "[[4,8],[10,12]]", "[]")]
    [DataTestMethod]
    public void MyTestMethod(int order, string firstListStr, string secondListStr, string expectedStr)
    {
        int[][] firstList = Helper.Convert2D(firstListStr);
        int[][] secondList = Helper.Convert2D(secondListStr);
        int[][] expected = Helper.Convert2D(expectedStr);
        int[][] actual = (new Solution()).IntervalIntersection(firstList, secondList);
        Assert.AreEqual(expected.Length, actual.Length);
        for (int i = 0; i < expected.Length; i++)
        {
            Assert.AreEqual(expected[i][0], actual[i][0]);
            Assert.AreEqual(expected[i][1], actual[i][1]);
        }
    }
}