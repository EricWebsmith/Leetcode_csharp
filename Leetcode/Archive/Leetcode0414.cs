namespace Leetcode0414;


public class SolutionNetCore6
{
    public int ThirdMax(int[] nums)
    {
        int n = nums.Length;
        if (n < 3)
        {
            return nums.Max();
        }

        PriorityQueue<int, int> pq = new PriorityQueue<int, int>();
        pq.Enqueue(nums[0], nums[0]);
        pq.Enqueue(nums[1], nums[1]);
        pq.Enqueue(nums[2], nums[2]);

        for (int i = 3; i < nums.Length; i++)
        {
            pq.EnqueueDequeue(nums[i], nums[i]);
        }

        return pq.Dequeue();
    }
}

public class PriorityQueue
{
    private List<int> list = new List<int>();

    public int Count
    {
        get
        {
            return list.Count;
        }
    }

    public int Capacity { get; private set; }

    public PriorityQueue(int capacity)
    {
        Capacity = capacity;
    }

    private void Insert(int value)
    {
        for (int i = 0; i < Count; i++)
        {
            if(value == list[i])
            {
                break;
            }

            if (value > list[i])
            {
                list.Insert(i, value);
                break;
            }
        }
        if(Count == Capacity + 1)
        {
            list.RemoveAt(Count-1);
        }
    }

    public void Enqueue(int value)
    {
        if (Count == 0)
        {
            list.Add(value);
        }
        else if (Count < Capacity)
        {
            if (value < list.Last())
            {
                list.Add(value);
            }
            else
            {
                Insert(value);
            }
        }
        else if (Count == Capacity)
        {
            if (value <= list.Last())
            {
                return;
            }
            else
            {
                Insert(value);
            }
        }
    }

    public int First()
    {
        return list.First();
    }

    public int Last()
    {
        return list.Last();
    }
}

/// <summary>
/// Runtime: 96 ms, faster than 38.16% of C# online submissions for Third Maximum Number.
/// Memory Usage: 38.1 MB, less than 80.68% of C# online submissions for Third Maximum Number.
/// </summary>
public class Solution
{
    public int ThirdMax(int[] nums)
    {
        int n = nums.Length;
        if (n < 3)
        {
            return nums.Max();
        }

        PriorityQueue pq = new PriorityQueue(3);
        foreach (int num in nums)
        {
            pq.Enqueue(num);
        }

        if(pq.Count < 3)
        {
            return pq.First();
        }

        return pq.Last();
    }
}


[TestClass]
public class SolutionTests
{
    private void TestBase(string numsStr, int expected)
    {
        int[] nums = numsStr.LeetcodeToArray();
        int actual = new Solution().ThirdMax(nums);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod] public void Test1() { TestBase("[3,2,1]", 1); }
    [TestMethod] public void Test2() { TestBase("[1,2]", 2); }
    [TestMethod] public void Test3() { TestBase("[2, 2, 3, 1]", 1); }
    [TestMethod] public void Test4() { TestBase("[1,1,1,2,2,3]", 1); }
}