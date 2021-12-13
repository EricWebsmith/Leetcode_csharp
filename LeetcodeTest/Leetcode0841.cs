namespace Leetcode0841;

public class Solution
{
    int n;
    bool[] visited;
    IList<IList<int>> rooms = new List<IList<int>>();
    private void Dfs(int roomIndex)
    {
        IList<int> keys = rooms[roomIndex];
        foreach (int key in keys)
        {
            if (visited[key]) { continue; }
            visited[key] = true;
            Dfs(key);
        }
    }


    public bool CanVisitAllRooms(IList<IList<int>> rooms)
    {
        this.rooms = rooms;
        n = rooms.Count;
        visited = new bool[n];
        visited[0] = true;
        Dfs(0);
        return visited.All(c => c);
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase()
    {

    }

    [TestMethod] public void Test1() { TestBase(); }
    [TestMethod] public void Test2() { TestBase(); }
    [TestMethod] public void Test3() { TestBase(); }
    [TestMethod] public void Test4() { TestBase(); }
}