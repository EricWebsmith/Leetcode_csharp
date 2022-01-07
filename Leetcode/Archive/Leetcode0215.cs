namespace Leetcode0215;

/// <summary>
/// Cannot summit to leetcode, because leetcode does not use .net core 6.
/// </summary>
public class Solution_6
{
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> pq=new PriorityQueue<int, int>();
        foreach(int num in nums)
        {
            pq.Enqueue(num, num);
            if(pq.Count > k)
            {
                pq.Dequeue();
            }
        }
        return pq.Peek();
    }
}

/// <summary>
/// Runtime: 88 ms, faster than 87.72% of C# online submissions for Kth Largest Element in an Array.
/// Memory Usage: 39.3 MB, less than 27.18% of C# online submissions for Kth Largest Element in an Array.
/// </summary>
public class Solution
{
    int k;

    /// <summary>
    /// make a priority queue.
    /// </summary>
    /// <param name="pq"></param>
    /// <param name="num"></param>
    private void Insert(List<int> pq, int num)
    {
        
        if(pq.Last() >= num)
        {
            if (pq.Count >= k)
            {
                return;
            }
            pq.Add(num);
            return;
        }

        int index = 0;
        for (int i = 0; i < pq.Count; i++)
        {
            if(pq[i] < num)
            {
                index = i;
                break;
            }
        }

        pq.Insert(index, num);
        if (pq.Count > k)
        {
            pq.RemoveAt(pq.Count-1);
        }
    }

    public int FindKthLargest(int[] nums, int k)
    {
        this.k = k;
        List<int> pq = new List<int>();
        pq.Add(int.MinValue);
        foreach(int num in nums)
        {
            if(pq.Count >= k && num < pq.Last())
            {
                continue;
            }
            Insert(pq, num);
        }

        return pq.Last();
    }
}

[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int k, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().FindKthLargest(nums, k);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3,2,1,5,6,4]", 2, 5); }
    [TestMethod] public void Test2() { TestBase("[3,2,3,1,2,4,5,5,6]",4,4); }
    [TestMethod] public void Test3() { TestBase("[1,2,3,4,5,6,7,8]", 2, 7); }
    [TestMethod] public void Test4() { TestBase("[1,2,3,4,5,6,7,8]", 4, 5); }
    [TestMethod] public void Test5() { TestBase("[3,2,1]", 2, 2); }
    [TestMethod] public void Test6() { TestBase("[3,2,1]", 3, 1); }
    [TestMethod] public void Test7() { TestBase("[1,2,3]", 3, 1); }
    [TestMethod] public void Test8() { TestBase("[1]", 1, 1); }
    [TestMethod] public void Test9() { TestBase("[3,3,3,3,4,3,3,3,3]", 5, 3); }
}