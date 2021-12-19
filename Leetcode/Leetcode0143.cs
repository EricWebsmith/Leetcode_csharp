namespace Leetcode0143;

/// <summary>
/// Runtime: 96 ms, faster than 72.31% of C# online submissions for Reorder List.
/// Memory Usage: 42.6 MB, less than 13.59% of C# online submissions for Reorder List.
/// </summary>
public class Solution
{
    public void ReorderList(ListNode head)
    {
        if (head == null) { return; }
        if (head.next == null) { return; }

        List<ListNode> list = new List<ListNode>();
        ListNode current = head;
        while (current != null)
        {
            list.Add(current);
            current = current.next;
        }

        int n = list.Count;

        current = null;
        for (int i = 0; i < list.Count / 2; i++)
        {
            if (current != null)
            {
                current.next = list[i];
            }
            list[i].next = list[n - 1 - i];
            current = list[n - 1 - i];
            current.next = null;
        }

        if ((n & 1) == 1)
        {
            current.next = list[n / 2];
            list[n / 2].next = null;
        }
    }
}

[TestClass]
public class SolutionTests
{
    [DataRow(1, "[1,2,3,4]", "[1,4,2,3]")]
    [DataRow(2, "[1,2,3,4,5]", "[1,5,2,4,3]")]
    [DataRow(3, "[1]", "[1]")]
    [DataRow(4, "[1,2,3]", "[1,3,2]")]
    [DataTestMethod]
    public void Test(int order, string headStr, string expected)
    {
        ListNode head = headStr.ToListNode();
        new Solution().ReorderList(head);
        string actual = head.ToStr();
        Assert.AreEqual(expected, actual);
    }
}