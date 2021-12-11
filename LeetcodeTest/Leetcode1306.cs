namespace Leetcode1306;

/// <summary>
/// Runtime: 140 ms, faster than 88.44% of C# online submissions for Jump Game III.
/// Memory Usage: 45.7 MB, less than 87.07% of C# online submissions for Jump Game III.
/// </summary>
public class Solution
{
    public bool CanReach(int[] arr, int start)
    {
        int n = arr.Length;
        bool[] visited = new bool[n];
        Queue<int> q = new Queue<int>();
        q.Enqueue(start);
        visited[start] = true;
        while (q.Count > 0)
        {
            int index = q.Dequeue();
            if (arr[index] == 0)
            {
                return true;
            }

            int left = index - arr[index];
            if(left >=0 && !visited[left])
            {
                q.Enqueue(left);
                visited[left] = true;
            }

            int right = index + arr[index];

            if (right < n && !visited[right])
            {
                q.Enqueue(right);
                visited[right] = true;
            }
        }
        
        return false;
    }
}

[TestClass]
public class SolutionTests
{
    private void BaseTest(string arrStr, int start, bool expected)
    {
        int[] arr = arrStr.LeetcodeToArray();
        bool actual = new Solution().CanReach(arr, start);
        Assert.AreEqual(actual, expected);
    }

    [TestMethod] public void Test1() { BaseTest("[4,2,3,0,3,1,2]", 5, true); }
    [TestMethod] public void Test2() { BaseTest("[4,2,3,0,3,1,2]", 0, true); }
    [TestMethod] public void Test3() { BaseTest("[3,0,2,1,2]", 2, false); }
}