namespace Leetcode0435;

/// <summary>
/// Runtime: 412 ms, faster than 93.17% of C# online submissions for Non-overlapping Intervals.
/// Memory Usage: 63 MB, less than 62.80% of C# online submissions for Non-overlapping Intervals.
/// </summary>
public class Solution
{

    private int IntervalCompare(int[] interval1, int[] interval2)
    {
        if (interval1[0] != interval2[0])
        {
            return interval1[0] - interval2[0];
        }

        return interval1[1] - interval2[1];
    }

    public int EraseOverlapIntervals(int[][] intervals)
    {


        Array.Sort(intervals, IntervalCompare);
        int result = 0;
        int previousEnd = intervals[0][1];
        for (int i = 1; i < intervals.Length; i++)
        {
            int start = intervals[i][0];
            int end = intervals[i][1];
            if (start >= previousEnd)
            {
                previousEnd = end;
            }
            else
            {
                result ++;
                previousEnd = Math.Min(previousEnd, end);
            }
        }

        return result;
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[[1,2],[2,3],[3,4],[1,3]]", 1)]
    [DataRow(2, "[[1,2],[1,2],[1,2]]", 2)]
    [DataRow(3, "[[1,2],[2,3]]", 0)]
    [DataRow(4, "[[1,2],[1,3],[1,4],[2,3],[2,4]]", 3)]
    [DataRow(5, "[[1,2]]", 0)]
    [DataRow(6,
        "[[-52,31],[-73,-26],[82,97],[-65,-11],[-62,-49],[95,99],[58,95],[-31,49],[66,98],[-63,2],[30,47],[-40,-26]]",
        7)]
    [DataRow(7,
        "[[40,70],[56,80],[63,87],[-51,39],[-74,59],[38,41],[-49,17],[6,57],[36,85],[-73,26],[-6,70],[15,70],[66,78],[37,87],[79,96],[46,97],[36,49],[-58,40],[-58,52],[26,83],[-27,43],[15,86],[11,56],[23,34],[-9,73],[-95,-75],[2,30],[-91,26],[88,89],[-83,-43]]",
        24)]
    [DataTestMethod]
    public void Test(int order, string intervalsStr, int expected)
    {
        int[][] intervals = intervalsStr.Convert2D();
        int actual = new Solution().EraseOverlapIntervals(intervals);
        Assert.AreEqual(expected, actual);
    }
}