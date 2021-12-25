namespace Leetcode0207;

/// <summary>
/// Runtime: 92 ms, faster than 99.88% of C# online submissions for Course Schedule.
/// Memory Usage: 43.2 MB, less than 33.81% of C# online submissions for Course Schedule.
/// </summary>
public class Solution
{
    Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
    HashSet<int> visited = new HashSet<int>();

    private bool Dfs(int course)
    {
        if (visited.Contains(course))
        {
            return false;
        }

        if(preMap[course].Count == 0)
        {
            return true;
        }

        visited.Add(course);

        foreach(int pre in preMap[course])
        {
            if (!Dfs(pre))
            {
                return false;
            }
        }

        preMap[course].Clear();
        visited.Remove(course);

        return true;
    }

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        if (numCourses == 1) { return true; }
        
        for(int i = 0; i < numCourses; i++)
        {
            preMap[i] = new List<int>();
        }

        foreach(int[] coursePre in prerequisites)
        {
            preMap[coursePre[0]].Add(coursePre[1]);
        }

        for(int i = 0;i < numCourses; i++)
        {
            if(!Dfs(i))
            {
                return false;
            }
        }

        return true;

    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(int numCourses, string prerequisitesStr, bool expected)
    {
        int[][] prerequisites = prerequisitesStr.LeetcodeToArray2D();
        bool actual = new Solution().CanFinish(numCourses, prerequisites);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase(2, "[[1,0]]", true); }
    [TestMethod] public void Test2() { TestBase(2, "[[1,0],[0,1]]", false); }
    [TestMethod] public void Test3() { TestBase(3, "[[0,1],[1,2]]", true); }
    [TestMethod] public void Test4() { TestBase(3, "[[0,1],[1,2],[2,0]]", false); }
}