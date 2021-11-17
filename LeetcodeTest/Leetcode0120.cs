using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leetcode0120;

public class Solution
{
    public int MinimumTotal(IList<IList<int>> triangle)
    {
        int top = triangle.First().First();
        if (triangle.Count == 1)
        {
            return top;
        }
        IList<int> previousLayer = triangle[1];
        triangle[1][0] += top;
        triangle[1][1] += top;

        for (int i = 2; i < triangle.Count; i++)
        {
            IList<int> currentLayer = triangle[i];
            //first and last
            currentLayer[0] += previousLayer[0];
            currentLayer[currentLayer.Count-1] += previousLayer[previousLayer.Count-1];
            for(int j=1; j<currentLayer.Count-1; j++)
            {
                currentLayer[j] += Math.Min( previousLayer[j], previousLayer[j-1]);
            }
            previousLayer = currentLayer;
        }
        return triangle.Last().Min();
    }
}

[TestClass]
public class SolutionTest
{
    private void TestBase(IList<IList<int>> triangle, int expected)
    {
        Solution solution = new Solution();
        int actual = solution.MinimumTotal(triangle);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void Test1()
    {
        List<IList<int>> triangle = new List<IList<int>>()
        {
            new List<int>(){2},
            new List<int>(){3,4},
            new List<int>(){6, 5, 7},
            new List<int>(){4, 1, 8, 3 }
        };
        
        TestBase(triangle, 11);
    }

    [TestMethod]
    public void Test2()
    {
        List<IList<int>> triangle = new List<IList<int>>()
        {
            new List<int>(){-10}
        };

        TestBase(triangle, -10);
    }
}

/*
[[2],[3,4],[6,5,7],[4,1,8,3]]
[[-10]]
[[1]]
[[1], [-2,-2]]
[[2],[3,4],[6,5,7],[-4,1,8,3]]
 */